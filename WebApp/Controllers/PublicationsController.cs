using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using WebApp.Domain.Interfaces;


namespace WebApp.Controllers {

	public class PublicationsController : Controller {

		protected readonly IPollRepository _pollRepository;
		protected readonly IPetitionRepository _petitionRepository;


		public PublicationsController(IPollRepository pollRepository,
										IPetitionRepository petitionRepository) : base() {

			_pollRepository = pollRepository;
			_petitionRepository = petitionRepository;
		}

		[Route("~/Publications")]
		public IActionResult Publications() {
			ViewBag.Polls		= _pollRepository.GetAll();
			ViewBag.Petitions	= _petitionRepository.GetAll();

			ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return View();
		}

		[HttpGet]
		public IActionResult New() {
			return View("CreatePetition");
		}

	}

}
