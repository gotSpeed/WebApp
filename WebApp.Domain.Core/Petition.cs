using System;


namespace WebApp.Domain.Core {

	public class Petition : Post {

		public DateTime ExpirationDate { get; set; }
		public uint NextGoal { get; set; }
		public uint TotalGoal { get; set; }

	}

}
