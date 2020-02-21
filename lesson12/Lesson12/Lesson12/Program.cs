using System;
using System.Threading;

namespace Publisher
{
	class Program
	{
		static void Main(string[] args)
		{
			var publisher = new Bank();

			var broker1 = new Broker();
			var broker2 = new Broker();
			var broker3 = new Broker();
			var broker4 = new Broker();


			publisher.MessageSent += broker1.OnMessageReceived;
			publisher.MessageSent += broker2.OnMessageReceived;
			publisher.MessageSent += broker3.OnMessageReceived;
			publisher.MessageSent += broker4.OnMessageReceived;

			Random rnd = new Random();

			for (int i = 0; i < 4; i++)
			{
				var usd = rnd.Next(50, 250);
				var eur = rnd.Next(35, 400);
				Console.WriteLine("-----------------------------------------------------------------------");
				publisher.UpdateRates($"Updating rates. New qoutations: USD: {usd}; EUR: {eur}.", usd, eur);
			}
		}
	}

	public class Broker
	{
		public void OnMessageReceived(object sender, MessageEventArgs e)
		{
			Console.WriteLine();
			Console.WriteLine($"Rating info from bank: {e.Message}.");
			if (e.EUR < 100)
			{
				Console.WriteLine($"Sell EURO with rate {e.EUR} and buy USD with rate {e.USD}.");
			} else if (e.USD < 120)
			{
				Console.WriteLine($"Sell USD with rate {e.USD} and buy EURO with rate {e.EUR}.");
			} else
			{
				Console.WriteLine($"Ignore rating update.");
			}
		}
	}
}
