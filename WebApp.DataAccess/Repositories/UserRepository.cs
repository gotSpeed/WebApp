using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using WebApp.DataAccess.DbContexts;
using WebApp.DataAccess.Misc.Exceptions;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.DataAccess.Repositories {

	public class UserRepository : IUserRepository {

		private readonly CustomDbContext _context;


		public UserRepository(CustomDbContext context) {
			_context = context;
		}

		public User Get(object keyValues) {
			return _context.Users.Find(keyValues) ??
					throw new RowNotFoundException($"Cannot extract data: no row with PK = {keyValues}");
		}

		public User FindByEmail(string email) {
			return _context.Users.First(user => user.Email == email);
		}
		
		public User FindByUserName(string userName) {
			return _context.Users.First(user => user.UserName == userName);
		}

		public IEnumerable<User> GetAll() {
			return _context.Users.ToList();
		}

		public void Create(User newInstance) {
			try {
				_context.Users.Add(newInstance);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.Users.Remove(newInstance);

				throw exception;
			}
		}

		public void Delete(object keyValues) {
			User pollToDelete = null;

			try {
				pollToDelete = _context.Users.Find(keyValues) ??
								throw new RowNotFoundException($"Cannot delete data: no row with PK = {keyValues}");

				_context.Users.Remove(pollToDelete);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.Users.Add(pollToDelete);

				throw exception;
			}
		}

		public void Update(object keyValues, User newData) {
			try {
				User updatedInstance =  _context.Users.Find(keyValues) ??
										throw new RowNotFoundException($"Cannot update data: no row with PK = {keyValues}");

				updatedInstance = newData;
			}
			catch (DbUpdateException exception) {
				//add log here

				throw exception;
			}
		}

		public void Dispose() {
			try {
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				throw exception;
			}

			//add code
		}

	}

}
