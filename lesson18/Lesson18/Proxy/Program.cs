using System;
using System.Collections.Generic;

namespace Proxy
{
	class Program
	{
		static void Main(string[] args)
		{
			var req = new HttpRequest
			{
				Headers = new Dictionary<string, string> {
				{"Method", "GET" },
				{"Accept-Language", "en, ru, nl" },
				{"Connection", "keep-alive" },
				{"Accept", "application/json" }
			},
				Body = "key1: value1\nkey2: value2\nkey3: value3"
			};
			var pointcut = new Pointcut();
			var resp = pointcut.HandleRequest(req);
		}
	}
}
