using System.Collections.Generic;

using WebApp.Domain.Core;


namespace WebApp.Domain.Interfaces {

	public interface IPollRepository : IRepository<Poll> {

		IEnumerable<Poll> GetMostPopular();
	
	}

}
