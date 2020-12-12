using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using WebApp.DataAccess.DbContexts;
using WebApp.DataAccess.Misc.Exceptions;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.DataAccess.Repositories {

	public class PetitionRepository : IPetitionRepository {

		private readonly CustomDbContext _context;


		public PetitionRepository(CustomDbContext context) {
			_context = context;
		}

		public Petition Get(object keyValues) {
			return	_context.Petitions.Find(keyValues) ??
					throw new RowNotFoundException($"Cannot extract data: no row with PK = {keyValues}");
		}

		public IEnumerable<Petition> GetMostPopular() {
			var PetitionsList =	from Petition Petition in _context.Petitions
								orderby Petition.VotersAmount descending
								select Petition;

			return PetitionsList.Include(petition => petition.Author)
								.ToList();
		}

		public IEnumerable<Petition> GetAll() {
			return _context.Petitions.ToList();
		}

		public void Create(Petition newInstance) {
			try {
				_context.Petitions.Add(newInstance);
				_context.SaveChanges();
			}
			catch ( DbUpdateException exception ) {
				//add log here

				_context.Petitions.Remove(newInstance);

				throw exception;
			}
		}

		public void Delete(object keyValues) {
			Petition PetitionToDelete = null;

			try {
				PetitionToDelete =	_context.Petitions.Find(keyValues) ??
									throw new RowNotFoundException($"Cannot delete data: no row with PK = {keyValues}");

				_context.Petitions.Remove(PetitionToDelete);
				_context.SaveChanges();
			}
			catch ( DbUpdateException exception ) {
				//add log here

				_context.Petitions.Add(PetitionToDelete);

				throw exception;
			}
		}

		public void Update(object keyValues, Petition newData) {
			try {
				Petition updatedInstance =	_context.Petitions.Find(keyValues) ??
											throw new RowNotFoundException($"Cannot update data: no row with PK = {keyValues}");

				updatedInstance = newData;
			}
			catch ( DbUpdateException exception ) {
				//add log here

				throw exception;
			}
		}

		public void Dispose() {
			try {
				_context.SaveChanges();
			}
			catch ( DbUpdateException exception ) {
				//add log here

				throw exception;
			}

			//add code
		}

	}

}
