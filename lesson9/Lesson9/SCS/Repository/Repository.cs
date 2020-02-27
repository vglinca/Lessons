using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCS.Repository
{
	class Repository<T, TId> : IRepository<T, TId> where T: Entity<TId>
	{
		private List<T> _collection;
		public Repository()
		{
			_collection = new List<T>();
		}
		public virtual void Delete(T entity)
		{
			if(entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_collection.Remove(entity);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _collection;
		}


		public virtual T GetById(TId id)
		{
			return _collection.Find(e => e.Id.Equals(id));
		}

		public virtual void Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			_collection.Add(entity);
		}

		
		public virtual void Update(T newEntity, TId id)
		{
			if (newEntity == null)
			{
				throw new ArgumentNullException(nameof(newEntity));
			}
			var item = _collection.Find(e => e.Id.Equals(id));
			item = newEntity;
		}
	}
}
