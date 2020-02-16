using System;
using System.Collections.Generic;
using System.Text;

namespace SCS.Repository
{
	interface IRepository<T> where T: class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		void Insert(T entity);
		void Update(T entity, int id);
		void Delete(T entity);
	}
}
