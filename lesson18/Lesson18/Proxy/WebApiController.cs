using System;

namespace Proxy
{
	//this is the real subject
	//request to it will be intercepted by Pointcut - our proxy
	public class WebApiController : IRequestHandler
	{
		public HttpResponse HandleRequest(HttpRequest request)
		{
			Console.WriteLine($"Handling some request.");
			Console.WriteLine($"Validating request.");
			Console.WriteLine($"Creating some response.");
			return new HttpResponse
			{
				StatusCode = 200,
				ResponseBody = $"some random content from server."
			};
		}
	}
}
