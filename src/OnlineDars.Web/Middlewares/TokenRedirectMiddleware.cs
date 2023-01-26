using Microsoft.AspNetCore.Http;

namespace OnlineDars.Web.Middlewares
{
	public class TokenRedirectMiddleware
	{
		private readonly RequestDelegate _next;

		public TokenRedirectMiddleware(RequestDelegate next)
		{
			this._next = next;
		}
		public Task Invoke(HttpContext context) 
		{
			if (context.Request.Cookies.TryGetValue("X-Access-Token", out var accessToken))
			{
				if (!string.IsNullOrEmpty(accessToken))
				{
					string bearerToken = String.Format("Bearer {0}", accessToken);
					context.Request.Headers.Add("Authorization", bearerToken);
				}
			}
			return _next(context);
		}
	}
}
