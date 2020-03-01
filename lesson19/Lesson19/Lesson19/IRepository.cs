using System;
using System.Collections.Generic;
using System.Text;

namespace Locator
{
	public interface IRepository<T>
	{
		void Add(T data);
		List<T> Retrieve();
	}
}
