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
    class MyMiddlewareComponent
    {
        AppFunc _next;
        public MyMiddlewareComponent(AppFunc next)
        {
            _next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            await context.Response.WriteAsync("<h1>Hello from My First Middleware</h1>");
            await _next.Invoke(environment);
        }
    }
}
