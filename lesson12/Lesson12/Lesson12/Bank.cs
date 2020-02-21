using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Publisher
{
	public delegate void MessageSentHandler(object sender, MessageEventArgs e);
	public class Bank
	{
		public event MessageSentHandler MessageSent;
		//public event EventHandler<MessageEventArgs> MessageSent;

		public virtual void UpdateRates(string message, int usd, int eur)
		{
			Console.WriteLine($"...updating quotations...");
			var args = new MessageEventArgs(message, usd, eur);
			Thread.Sleep(1000);
			OnRatesUpdated(args);
		}

		protected virtual void OnRatesUpdated(MessageEventArgs e)
		{
			if (MessageSent != null)
			{
				MessageSent.Invoke(this, e);
			}
		}
	}

	public class MessageEventArgs : EventArgs
	{
		public string Message { get; set; }
		public int USD { get; set; }
		public int EUR { get; set; }
		public MessageEventArgs(string msg, int usd, int eur)
		{
			Message = msg;
			USD = usd;
			EUR = eur;
		}
	}
}
