using Publisher;
using System;

namespace Subscriber
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	public class Receiver
	{
		public void OnMessageReceived(object sender, MessageEventArgs e)
		{
			Console.WriteLine($"Message received.\tText: {e.Message}");
		}
	}
}
