using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels {

	public class RegistrationViewModel {

		[Required]
		[DataType(DataType.Text)]
		public string UserName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare(otherProperty: "Password")]
		public string ConfirmPassword { get; set; }

	}

}
