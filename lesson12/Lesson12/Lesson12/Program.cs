using System;
using System.Threading;

namespace Publisher
{
	class Program
	{
		static void Main(string[] args)
		{
			var publisher = new Publisher();

			var receiver1 = new WebAppReceiver();
			var receiver2 = new WebAppReceiver();
			var receiver3 = new WebAppReceiver();
			var receiver4 = new WebAppReceiver();

			var phoneReceiver1 = new PhoneAppReceiver();
			var phoneReceiver2 = new PhoneAppReceiver();

			publisher.MessageSent += receiver1.OnMessageReceived;
			publisher.MessageSent += receiver2.OnMessageReceived;
			publisher.MessageSent += receiver3.OnMessageReceived;
			publisher.MessageSent += receiver4.OnMessageReceived;

			publisher.MessageSent += phoneReceiver1.OnReceive;
			publisher.MessageSent += phoneReceiver2.OnReceive;

			publisher.MessageSent -= receiver2.OnMessageReceived;

			for (int i = 0; i < 4; i++)
			{
				if(i == 2)
				{
					publisher.MessageSent += receiver2.OnMessageReceived;
				}
				Thread.Sleep(500);
				publisher.SendBroadcast($"Test message #{i + 1}.");
			}
		}
	}

	public class WebAppReceiver
	{
		public void OnMessageReceived(object sender, MessageEventArgs e)
		{
			Console.WriteLine($"Message received.\tText: \"{e.Message}\".");
		}
	}

	public class PhoneAppReceiver
	{
		public void OnReceive(object sender, MessageEventArgs e)
		{
			Console.WriteLine($"Phone app received a message.\t\"{e.Message}\".");
		}
	}
}
