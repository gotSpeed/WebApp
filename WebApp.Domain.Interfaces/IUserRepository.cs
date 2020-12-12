using WebApp.Domain.Core;


namespace WebApp.Domain.Interfaces {

	public interface IUserRepository : IRepository<User> {

		public User FindByEmail(string email);
		public User FindByUserName(string userName);

	}

}
