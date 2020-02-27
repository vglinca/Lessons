using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
	public abstract class Observer
	{
		protected IObservable _subject;
		public string Name { get; set; }
		public Observer()
		{
		}
		public abstract void Subscribe(IObservable subject);
		public abstract void Update();
	}
}
