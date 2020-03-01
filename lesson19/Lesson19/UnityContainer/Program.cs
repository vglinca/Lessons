using System;
using Unity;
using Locator;

namespace Container
{
	class Program
	{
		static void Main(string[] args)
		{
			var uc = new UnityContainer();
			uc.RegisterType<IRepository<int>, Repository<int>>();

			var rep = uc.Resolve<IRepository<int>>();
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
		}
	}
}
