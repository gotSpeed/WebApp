using System.Collections.Generic;

using WebApp.Domain.Core;


namespace WebApp.Domain.Interfaces {

	public interface IPetitionRepository : IRepository<Petition> {

		IEnumerable<Petition> GetMostPopular();

	}

}
