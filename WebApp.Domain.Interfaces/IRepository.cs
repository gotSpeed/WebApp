using System;
using System.Collections.Generic;


namespace WebApp.Domain.Interfaces {

	public interface IRepository<TDomainObject> : IDisposable {

		TDomainObject Get(object keyValues);

		IEnumerable<TDomainObject> GetAll();

		void Create(TDomainObject newInstance);

		void Delete(object keyValues);

		void Update(object keyValues, TDomainObject newData);

	}

}
