using System;
using System.Collections.Generic;


namespace WebApp.Domain.Core {
	public class Poll : Post {
		public bool IsAnonymous { get; set; }
		public IEnumerable<VotingOption> Options { get; set; }
	}
}
