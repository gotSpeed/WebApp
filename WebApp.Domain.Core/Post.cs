using System;
using System.Collections.Generic;


namespace WebApp.Domain.Core {
	public class Post {
		public ushort Id { get; set; }
		public string Header { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public DateTime PublicationDate { get; set; }
		public User Author { get; set; }
		public uint VotersAmount { get; set; }
		public IEnumerable<User> Voters { get; set; }
	}
}