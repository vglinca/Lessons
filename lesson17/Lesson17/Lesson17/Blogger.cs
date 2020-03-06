using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
	//concrete subject to be observed
	public class Blogger : IObservable
	{
		//we create list of subscribers
		List<Observer> _subscribers;
		public string Name { get; set; }
		public Blogger()
		{
			_subscribers = new List<Observer>();
		}
		public void Attach(Observer observer)
		{
			_subscribers.Add(observer);
		}

		public void Detach(Observer observer)
		{
			_subscribers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in _subscribers)
			{
				observer.Update();
			}
		}

		public void WriteBlog()
		{
			Console.WriteLine($"Writing some new blog...");
			Notify();
		}
	}
}
