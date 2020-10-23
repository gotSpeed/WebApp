using System.Collections.Generic;


namespace WebApp.Domain.Core {

	public class Poll : Post {

		public bool IsAnonymous { get; set; }
		public List<uint> OptionsId { get; set; }

	}

}
