using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add the Owin Usings:
using Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin;

namespace OwinMiddleware.Middleware
{
    // use an alias for the OWIN AppFunc:
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class MyGreetingMiddlewareComponent
    {
        AppFunc _next;
        MyGreetingMiddlewareConfigOptions _options;
        public MyGreetingMiddlewareComponent(AppFunc next, MyGreetingMiddlewareConfigOptions options){
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await _next.Invoke(environment);
            IOwinContext context = new OwinContext(environment);
            await context.Response.WriteAsync(string.Format("<h1>{0}</h1>",_options.GetGreeting()));

            // Update the response code to 200 OK:
            context.Response.StatusCode = 200;
            context.Response.ReasonPhrase = "OK";
        }

    }
}
