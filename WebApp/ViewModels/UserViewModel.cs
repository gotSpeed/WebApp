using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels {

	public class UserViewModel {

		public string UserName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

	}

}
