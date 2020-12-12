using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using WebApp.Domain.Interfaces;


namespace WebApp.Controllers {

	public class HomeController : Controller {

		protected readonly IPollRepository _pollRepository;
		protected readonly IPetitionRepository _petitionRepository;

		public HomeController(IPollRepository pollRepository,
								IPetitionRepository petitionRepository) : base() {

			_pollRepository = pollRepository;
			_petitionRepository = petitionRepository;
		}

		[Route("~/")]
		public IActionResult Empty() {
			return RedirectToRoutePermanent("controller", new { controller = "Home" });
		}

		[Route("~/Home")]
		public IActionResult Home() {
			ViewBag.PopularPolls = _pollRepository.GetMostPopular();
			ViewBag.PopularPetitions = _petitionRepository.GetMostPopular();

			ViewBag.UserName = User.Identity.Name;

			return View();
		}

	}

}
