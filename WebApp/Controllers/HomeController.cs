using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers {

	public class HomeController : Controller {

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
