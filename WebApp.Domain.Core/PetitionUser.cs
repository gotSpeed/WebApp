namespace WebApp.Domain.Core {

	public class PetitionUser {

		public int				PetitionId { get; set; }
		public int				UserId { get; set; }
		public virtual Petition	Petition { get; set; }
		public virtual User		User { get; set; }

	}

}
