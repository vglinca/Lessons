using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
	class Subscriber : Observer
	{
		public Subscriber()
		{
		}
		public override void Subscribe(IObservable subject)
		{
			_subject = subject;
			_subject.Attach(this);
		}

		public override void Update()
		{
			Console.WriteLine($"Subscriber {Name} got notification from blogger.\nLet's read some blog.");
		}
	}
}
