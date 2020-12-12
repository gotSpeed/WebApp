using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Domain.Core {

	public class VotingOption {

		[Key]
		public int		Id { get; set; }
		public string	Content { get; set; }
		public uint		VotersAmount { get; set; }
		public virtual ICollection<VotingOptionUser> Voters { get; set; }

		public int?			PollId { get; set; }
		public virtual Poll	Poll { get; set; }

	}

}
