using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace WebApp.Domain.Core {

	public class User : IdentityUser<int> {

		public string FirstName { get; set; }
		public string SecondName { get; set; }


		public virtual ICollection<Poll>		UserPolls { get; set; }
		public virtual ICollection<Petition>	UserPetitions { get; set; }

	}

}
