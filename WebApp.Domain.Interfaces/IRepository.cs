using System;
using System.Collections.Generic;


namespace WebApp.Domain.Interfaces {

	public interface IRepository<TDomainObject> : IDisposable {

		TDomainObject Get(params object[] pkeys);

		IEnumerable<TDomainObject> GetAll();

		void Create(TDomainObject newInstance);

		void Delete(params object[] pkeys);

		void Update(TDomainObject newData, params object[] pkeys);

	}

}
