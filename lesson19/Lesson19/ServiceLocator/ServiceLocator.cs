using System;
using System.Collections.Generic;

namespace ServiceLocator
{
	//this class will maintain services registering and it's retrieving
	//it has dictionary with all registered services
	//we create new instance of this dictionary in a static constructor
	//thus new instance will be created only with first appeal to ServiceLocator class in runtime
	public static class ServiceLocator
	{
		private static readonly Dictionary<Type, object> _services;

		static ServiceLocator()
		{
			_services = new Dictionary<Type, object>();
		}
		//get requested service
		public static T Resolve<T>()
		{
			return (T) _services[typeof(T)];
		}
		//we register service type and it's instance
		//we create service instance using Activator class
		public static void Register<T1, T2>()
		{
			_services[typeof(T1)] = Activator.CreateInstance(typeof(T2));
		}
		//this method will clear our service collection
		public static void Reset()
		{
			_services.Clear();
		}
	}
}
