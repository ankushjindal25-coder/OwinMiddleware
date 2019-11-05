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

    class SillyAuthenticationComponent
    {
        AppFunc _next;
        public SillyAuthenticationComponent(AppFunc next){
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment) {

            IOwinContext context = new OwinContext(environment);
            var username = context.Request.QueryString.Value;
            var isAuthenticate = (username == "Ankush");
            if (isAuthenticate)
            {
                // _next is only invoked is authentication succeeds:
                context.Response.StatusCode = 200;
                context.Response.ReasonPhrase = "OK";
                await _next.Invoke(environment);
            }
            else {
                context.Response.StatusCode = 401;
                context.Response.ReasonPhrase = "Not Authorized";

                // Send back a really silly error page:
                await context.Response.WriteAsync(string.Format("<h1>Error {0}-{1}",
                    context.Response.StatusCode,
                    context.Response.ReasonPhrase));
            }
        }

    }
}
