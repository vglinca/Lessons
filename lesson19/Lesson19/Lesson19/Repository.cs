using System;
using System.Collections.Generic;
using System.Text;

namespace Locator
{
	public class Repository<T> : IRepository<T>
	{
		private List<T> _collection = new List<T>();
		public void Add(T data)
		{
			_collection.Add(data);
		}

		public List<T> Retrieve()
		{
			return _collection;
		}
	}
}
