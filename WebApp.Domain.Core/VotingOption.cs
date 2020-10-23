using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Domain.Core {

	public class VotingOption {

		[Key]
		public uint Id { get; set; }
		public string Content { get; set; }
		public uint VotersAmount { get; set; }
		public List<uint> VotersId { get; set; }

	}

}
