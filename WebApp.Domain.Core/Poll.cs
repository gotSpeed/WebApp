using System.Collections.Generic;


namespace WebApp.Domain.Core {

	public class Poll : Post {

		public bool									IsAnonymous { get; set; }
		public virtual ICollection<VotingOption>	Options { get; set; }

	}

}
