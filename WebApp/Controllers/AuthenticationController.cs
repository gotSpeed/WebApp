using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;
using WebApp.ViewModels;


namespace WebApp.Controllers {

	public class AuthenticationController : Controller {

		private readonly UserManager<User>      _userManager;
		private readonly SignInManager<User>    _signInManager;
		private readonly IUserRepository        _userRepository;

		public AuthenticationController(UserManager<User> userManager,
										SignInManager<User> signInManager,
										IUserRepository userRepository) : base() {

			_userManager = userManager;
			_signInManager = signInManager;
			_userRepository = userRepository;
		}

		[HttpGet]
		public IActionResult Register() {

			return View("SignUp");
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationViewModel registrationVM) {

			if (ModelState.IsValid) {
				User user = new User {
					UserName = registrationVM.UserName,
					Email = registrationVM.Email
				};

				var result = await _userManager.CreateAsync(user, registrationVM.Password);

				if (result.Succeeded) {
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Home", "Home");
				}
				else {
					foreach (var error in result.Errors) {
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View("SignUp", registrationVM);
		}

		[HttpGet]
		public async Task<IActionResult> SignIn(string returnUrl = null) {

			SignInViewModel model = new SignInViewModel() {
				ReturnUrl = returnUrl ?? Url.Content("~/Home"),
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel signInVM) {

			if (ModelState.IsValid) {

				User user = _userRepository.FindByEmail(signInVM.Email);

				if (user != null) {
					var result = await _signInManager.PasswordSignInAsync(user, signInVM.Password, false, false);

					if (result.Succeeded) {
						return RedirectToAction("Home", "Home");
					}
				}
			}

			return View(signInVM);
		}

		[HttpPost]
		public IActionResult SignInExternal(string provider, string returnUrl) {

			var redirectUrl = Url.Action("SignInExternalCallback", "Authentication", new { ReturnUrl = returnUrl });
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

			return new ChallengeResult(provider, properties);
		}

		public async Task<IActionResult> SignInExternalCallback(string returnUrl = null, string remoteError = null) {

			returnUrl = returnUrl ?? Url.Content("~/");

			SignInViewModel signInViewModel = new SignInViewModel() {
				ReturnUrl = returnUrl,
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			if (remoteError != null) {
				ModelState.AddModelError(string.Empty, remoteError);

				return View("SignIn", signInViewModel);
			}

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null) {
				ModelState.AddModelError(string.Empty, "Error loading external login info.");

				return View("SignIn", signInViewModel);
			}

			var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
																			 info.ProviderKey,
																			 isPersistent: false,
																			 bypassTwoFactor: false);
			if (signInResult.Succeeded) {
				return LocalRedirect(returnUrl);
			}
			else {
				var email = info.Principal.FindFirstValue(ClaimTypes.Email);
				if (email != null) {

					var user = await _userManager.FindByEmailAsync(email);
					if (user == null) {

						user = new User() {
							UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
							Email = info.Principal.FindFirstValue(ClaimTypes.Email)
						};

						await _userManager.CreateAsync(user);
					}

					await _userManager.AddLoginAsync(user, info);
					await _signInManager.SignInAsync(user, isPersistent: false);

					return LocalRedirect(returnUrl);
				}

				ViewBag.ErrorMessage = $"Email not received from {info.LoginProvider}";

				return View("Error");
			}
		}

		public async Task<IActionResult> SignOut() {

			await _signInManager.SignOutAsync();

			return RedirectToAction("Home", "Home");
		}

	}

}
