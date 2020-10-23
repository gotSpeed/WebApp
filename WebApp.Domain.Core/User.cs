using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Domain.Core {

	public class User : IdentityUser<uint> {

		[Key]
		public override uint Id { get; set; }
		public List<Poll> UserPolls { get; set; }
		public List<Petition> UserPetitions { get; set; }

	}

}
