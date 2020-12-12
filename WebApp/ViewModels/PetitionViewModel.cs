using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels {

	public class PetitionViewModel {

		[Required]
		[DataType(DataType.Text)]
		public string Heading { get; set; }

		[Required]
		public ulong TotalGoal { get; set; }

		public ulong NextGoal { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string Description { get; set; }

	}

}
