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
    class SillyLoggingComponent
    {
        AppFunc _next;
        public SillyLoggingComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Pass everything up through the pipeline first:
            await _next.Invoke(environment);

            // Do the logging on the way out:
            IOwinContext context = new OwinContext(environment);
            Console.WriteLine("URI: {0} Status Code: {1}",
            context.Request.Uri, context.Response.StatusCode);
        }
    }
}

