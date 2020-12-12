using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels {

	public class SignInViewModel {

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

	}

}
