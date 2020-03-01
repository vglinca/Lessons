using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
	//this is our proxy
	//it will intercept all requests to controller - the real suject
	//request knows nothing about this proxy interceptor
	public class Pointcut : IRequestHandler
	{
		private WebApiController _webApiController = new WebApiController();
		public HttpResponse HandleRequest(HttpRequest request)
		{
			AddSomeLoggingToRequest(request);
			var response = _webApiController.HandleRequest(request);
			AddSomeLoggingToResponse(response);

			return response;
		}

		private void AddSomeLoggingToResponse(HttpResponse response)
		{
			Console.WriteLine("<<<<<<<<<<<<<<<<RESPONSE<<<<<<<<<<<<<<<<<<<");
			Console.WriteLine($"Status code: {response.StatusCode}");
			Console.WriteLine($"Response body: {response.ResponseBody}");
			Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
		}

		private void AddSomeLoggingToRequest(HttpRequest request)
		{
			Console.WriteLine(">>>>>>>>>>>>>>>>REQUEST>>>>>>>>>>>>>>>>>>>>>");
			Console.WriteLine("Request headers:");
			foreach (var header in request.Headers)
			{
				Console.WriteLine($"{header.Key} : {header.Value}");
			}
			Console.WriteLine($"Request body: {request.Body}");
			Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}
}
