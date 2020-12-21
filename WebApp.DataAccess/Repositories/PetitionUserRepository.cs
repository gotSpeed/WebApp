using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using WebApp.DataAccess.DbContexts;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.DataAccess.Repositories {

	public class PetitionUserRepository : IPetitionUserRepository {

		private readonly CustomDbContext _context;


		public PetitionUserRepository(CustomDbContext context) {
			_context = context;
		}

		public void Create(PetitionUser newInstance) {

			try {
				_context.PetitionUser.Add(newInstance);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.PetitionUser.Remove(newInstance);

				throw exception;
			}
		}

		public void Delete(params object[] pkeys) => throw new System.NotImplementedException();
		public void Dispose() => throw new System.NotImplementedException();
		public PetitionUser Get(params object[] pkeys) => throw new System.NotImplementedException();
		public IEnumerable<PetitionUser> GetAll() => throw new System.NotImplementedException();
		public void Update(PetitionUser newData, params object[] pkeys) => throw new System.NotImplementedException();

		public bool CheckIfUserPutSign(params object[] pkeys) {
            return _context.PetitionUser.Find(pkeys) != null ? true : false;
        }

    }

}
