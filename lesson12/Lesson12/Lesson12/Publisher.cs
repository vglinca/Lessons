using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Publisher
{
	public delegate void MessageSentHandler(object sender, MessageEventArgs e);
	public class Publisher
	{
		public event MessageSentHandler MessageSent;
		//public event EventHandler<MessageEventArgs> MessageSent;

		public virtual void SendBroadcast(string message)
		{
			Console.WriteLine($"...sending message...");
			var args = new MessageEventArgs(message);
			Thread.Sleep(1000);
			OnMessageSent(args);
		}

		protected virtual void OnMessageSent(MessageEventArgs e)
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
		public MessageEventArgs(string msg)
		{
			Message = msg;
		}
	}
}
