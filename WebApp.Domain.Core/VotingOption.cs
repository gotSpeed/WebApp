using System;
using System.Collections.Generic;


namespace WebApp.Domain.Core {
	public class VotingOption {
		public ushort Id { get; set; }
		public string Name { get; set; }
		public uint VotersAmount { get; set; }
		public IEnumerable<User> Voters { get; set; }
	}
}
