using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
	//all subjects will implement this interface
	public interface IObservable
	{
		void Attach(Observer observer);
		void Detach(Observer observer);
		void Notify();
	}
}
