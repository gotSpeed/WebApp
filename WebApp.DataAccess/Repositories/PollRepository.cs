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

		public Poll Get(params object[] pkeys) {
			return	_context.Polls.Find(pkeys) ??
					throw new RowNotFoundException($"Cannot extract data: no row with pkeys = {pkeys}");
		}

		public IEnumerable<Poll> GetMostPopular() {
			var pollsList =	from Poll poll in _context.Polls
							orderby poll.VotersAmount descending
							select poll;

			return pollsList.Include(poll => poll.Author)
							.ToList();
		}

		public IEnumerable<Poll> GetAll() {
			return _context.Polls.ToList();
		}

		public void Create(Poll newInstance) {
			try {
				_context.Polls.Add(newInstance);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.Polls.Remove(newInstance);

				throw exception;
			}
		}

		public void Delete(params object[] pkeys) {
			Poll pollToDelete = null;

			try {
				pollToDelete =	_context.Polls.Find(pkeys) ??
								throw new RowNotFoundException($"Cannot delete data: no row with pkeys = {pkeys}");

				_context.Polls.Remove(pollToDelete);
				_context.SaveChanges();
			}
			catch (DbUpdateException exception) {
				//add log here

				_context.Polls.Add(pollToDelete);

				throw exception;
			}
		}

		public void Update(Poll newData, params object[] pkeys) {
			try {
				Poll updatedInstance =	_context.Polls.Find(pkeys) ??
										throw new RowNotFoundException($"Cannot update data: no row with pkeys = {pkeys}");

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
			catch (DbUpdateException exception) {
				//add log here

				throw exception;
			}

			//add code
		}

	}

}
