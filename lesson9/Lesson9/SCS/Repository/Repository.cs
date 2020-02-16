using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCS.Repository
{
	class Repository<T> : IRepository<T> where T: class
	{
		private IList<T> _collection;
		public Repository()
		{
			_collection = new List<T>();
		}
		public void Delete(T entity)
		{
			if(entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_collection.Remove(entity);
		}

		public IEnumerable<T> GetAll()
		{
			return _collection;
		}

		public T GetById(int id)
		{
			return _collection[id - 1];
		}

		public void Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_collection.Add(entity);
		}

		public void Update(T entity, int id)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_collection[id - 1] = entity;
		}
	}
}
