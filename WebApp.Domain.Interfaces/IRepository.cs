using System;
using System.Collections.Generic;

using WebApp.Domain.Core;


namespace WebApp.Domain.Interfaces {

	public interface IRepository<TDomainObject> : IDisposable {

		TDomainObject Get();

		IEnumerable<TDomainObject> GetAll();

		void Create(Post post);

		void Delete(ushort id);

		void Update(ushort id, Post newData);

	}

}
