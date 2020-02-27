using System;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			IObservable blogger = new Blogger();
			Observer subscriber = new Subscriber();
			Observer moderator = new Moderator();

			subscriber.Name = "Ivan";
			moderator.Name = "Fyodor";

			subscriber.Subscribe(blogger);
			moderator.Subscribe(blogger);

			((Blogger) blogger).WriteBlog();
		}
	}
}
