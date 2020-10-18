using System;


namespace WebApp.Domain.Core {
	public class Petition {
		public DateTime ExpirationDate { get; set; }
		public uint NextGoal { get; set; }
		public uint TotalGoal { get; set; }
	}
}
