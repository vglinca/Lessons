using System;
using System.Collections.Generic;
using System.Text;

namespace Locator
{
	public class OrderValidator : IOrderValidator
	{
		public bool ValidateOrder()
		{
			Console.WriteLine("validating some order...");
			var rnd = new Random();
			var num = rnd.Next(10, 100);
			Console.WriteLine($"num = {num}");
			return num % 2 == 0;
		}
	}
}
