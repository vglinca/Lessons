using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
	public class HttpRequest
	{
		public Dictionary<string, string> Headers { get; set; }
		public string Body { get; set; }
	}
}
