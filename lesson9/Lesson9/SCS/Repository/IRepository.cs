using System;
using System.Collections.Generic;
using System.Text;

namespace SCS.Repository
{
	interface IRepository<T, TId> where T: Entity<TId>
	{
		T GetById(TId id);
		IEnumerable<T> GetAll();
		void Insert(T entity);
		void Update(T entity, TId id);
		void Delete(T entity);
	}
}
