using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers {

	public class ContactsController : Controller {

		[Route("~/Contacts")]
		public IActionResult Contacts() {
			return View();
		}

	}

}
