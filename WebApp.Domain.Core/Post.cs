using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Domain.Core {

	public class Post {

		[Key]
		public uint Id { get; set; }
		public string Header { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public DateTime PublicationDate { get; set; }
		public User Author { get; set; }
		public uint VotersAmount { get; set; }
		public List<uint> VotersId { get; set; }

	}

}
