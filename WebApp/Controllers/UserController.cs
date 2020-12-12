using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;
using WebApp.ViewModels;


namespace WebApp.Controllers {

	[Authorize]
	public class UserController : Controller {

		private IPollRepository		_pollRepository;
		private IPetitionRepository	_petitionRepository;
		private IUserRepository		_userRepository;


		public UserController(IPollRepository pollRepository,
							  IPetitionRepository petitionRepository,
							  IUserRepository userRepository) {

			_pollRepository		= pollRepository;
			_petitionRepository	= petitionRepository;
			_userRepository		= userRepository;
		}

		[HttpGet]
		public IActionResult Personal() {

			User model = _userRepository.FindByUserName(User.Identity.Name);

			ViewBag.Polls		= _pollRepository.GetAll();
			ViewBag.Petitions	= _petitionRepository.GetAll();

			return View(model);
		}

	}

}
