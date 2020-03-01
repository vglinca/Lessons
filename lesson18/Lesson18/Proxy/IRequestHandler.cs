using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
	//subject interface
	//this interface will implement the real subject and our proxy
	public interface IRequestHandler
	{
		HttpResponse HandleRequest(HttpRequest request);
	}
}
