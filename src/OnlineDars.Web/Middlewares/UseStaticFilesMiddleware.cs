namespace OnlineDars.Web.Middlewares
{
    public class UseStaticFilesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebApplication _web;

        public UseStaticFilesMiddleware(RequestDelegate next,WebApplication web) 
        {
            _next = next;   
            _web = web;
        }
        public Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers.Keys.Contains("Authorization");
            if (token)
            {
                _web.UseStaticFiles();    
            }
            return _next(context);
        }
    }
}
