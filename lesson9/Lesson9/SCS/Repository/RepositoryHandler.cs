using System;
using System.Collections.Generic;
using System.Text;

namespace SCS.Repository
{
	class RepositoryHandler
	{
		private Dictionary<string, object> _repositories;

		public IRepository<T> GetRepository<T>() where T : class
		{
			if(_repositories == null)
			{
				_repositories = new Dictionary<string, object>();
			}
			//get type of repository
			var type = typeof(T).Name;
			//if we haven't got such repository yet we create it from scratch.
			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(Repository<>);
				//use activator to create an instance of requested repository
				var repositoryInstance = Activator.CreateInstance(repositoryType
					.MakeGenericType(typeof(T)));
				_repositories.Add(type, repositoryInstance);
			}

			return (IRepository<T>) _repositories[type];
		}
	}
}
