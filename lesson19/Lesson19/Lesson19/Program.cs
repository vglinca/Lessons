using System;

namespace Locator
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceLocator.ServiceLocator.Register<IOrderValidator, OrderValidator>();
			ServiceLocator.ServiceLocator.Register<IRepository<int>, Repository<int>>();

			var val = ServiceLocator.ServiceLocator.Resolve<IOrderValidator>();
			val.ValidateOrder();

			var rep = ServiceLocator.ServiceLocator.Resolve<IRepository<int>>();
			var rnd = new Random();
			for (int i = 0; i < 10; i++)
			{
				rep.Add(rnd.Next(i, i * 2));
			}
			var res = rep.Retrieve();
			int j = 0;
			foreach (var item in res)
			{
				Console.WriteLine($"{++j}: {item}");
			}
			ServiceLocator.ServiceLocator.Reset();

		}
	}
}
