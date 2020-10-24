using Microsoft.AspNetCore.Mvc;

using WebApp.Domain.Interfaces;


namespace WebApp.Controllers {

	public class HomeController : Controller {

		private readonly IPollRepository _pollRepository;
		//private readonly IPetitionRepository _petitionRepository;
		//private readonly IUserRepository _userRepository;
		//private readonly IVotingOptionRepository _voptionRepository;

		public HomeController(IPollRepository pollRepository
							  /*IPetitionRepository petitionRepository,
							  IUserRepository userRepository,
							  IVotingOptionRepository voptionRepository*/) {

			_pollRepository = pollRepository;
			//_petitionRepository = petitionRepository;
			//_userRepository = userRepository;
			//_voptionRepository = voptionRepository;
		}

		[Route("~/")]
		public IActionResult Empty() {
			return RedirectToRoutePermanent("controller", new { controller = "Home" });
		}

		[Route("~/Home")]
		public IActionResult Home() {
			return View();
		}

	}

}
