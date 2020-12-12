using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Domain.Core {

	public class Post {

		[Key]
		public int		Id { get; set; }
		public string	Header { get; set; }
		public string	ShortDescription { get; set; }
		public string	Description { get; set; }
		public DateTime	PublicationDate { get; set; }
		public uint		VotersAmount { get; set; }

		public int?							AuthorId { get; set; }
		public virtual User					Author { get; set; }

	}

}
