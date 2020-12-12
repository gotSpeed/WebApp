namespace WebApp.Domain.Core {

	public class VotingOptionUser {

		public int					UserId { get; set; }
		public int					VotingOptionId { get; set; }
		public virtual User			User { get; set; }
		public virtual VotingOption	VotingOption { get; set; }

	}

}
