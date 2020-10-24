using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using WebApp.DataAccess.DbContexts;
using WebApp.DataAccess.Misc.Exceptions;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.DataAccess.Repositories {

	public class PollRepository : IPollRepository {

		private readonly CustomDbContext _context;

		public PollRepository(CustomDbContext context) {
			_context = context;
		}

		public Poll Get(object keyValues) {
			return _context.Polls.Find(keyValues);
		}

		public IEnumerable<Poll> GetAll() {
			return _context.Polls.AsEnumerable();
		}

		public void Create(Poll newInstance) {
			try {
				_context.Polls.Add(newInstance);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				throw exception;
			}
			finally {
				_context.Polls.Remove(newInstance);
			}
		}

		public void Delete(object keyValues) {
			Poll pollToDelete = null;

			try {
				pollToDelete = _context.Polls.Find(keyValues) ??
							   throw new DbEntityNotFoundException();

				_context.Polls.Remove(pollToDelete);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.Polls.Add(pollToDelete);

				throw exception;
			}
			catch (DbEntityNotFoundException exception) {
				throw exception;
			}
		}

		public void Update(object keyValues, Poll newData) {
			//try {
			//	Poll updatedInstance = _context.Polls.Find(keyValues) ??
			//						   throw new DbEntityNotFoundException();

			//	var values = newData.GetType().GetMembers();
			//	updatedInstance.

			//	foreach (var value in values) {
			//		value.
			//		switch (value) {
			//			case
			//			default:
			//				break;
			//		}
			//	}
			//}
			//catch (DbEntityNotFoundException exception) {
			//	throw exception;
			//}
		}

		public void Dispose() {
			try {
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here
			}

			//add code
		}

	}

}
