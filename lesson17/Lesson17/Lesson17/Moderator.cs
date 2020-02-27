using System;

namespace Observer
{
	class Moderator : Observer
	{
		public Moderator()
		{
		}

		public override void Subscribe(IObservable subject)
		{
			_subject = subject;
			_subject.Attach(this);
		}

		public override void Update()
		{
			Console.WriteLine($"Moderator {Name} got notified that some blogger has posted something." +
				$"Let's check that post if there are some rules violation.");
		}
	}
}
