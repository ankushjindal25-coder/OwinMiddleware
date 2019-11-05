using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add the Owin Usings:
using Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin;
using OwinMiddleware.Middleware;

namespace OwinMiddleware
{
    // use an alias for the OWIN AppFunc:
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:8080");
            Console.WriteLine("Server Started; Press enter to Quit");
            Console.ReadLine();
        }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //app.AddMyMiddlewarecomponent();
                //app.AddMyOtherMiddlewarecomponent();
                app.UseSillyLogging();
                app.UseSillyAuthentication();
                app.AddMyGreetingExtensionComponent(new MyGreetingMiddlewareConfigOptions("Hello World", "Ankush"));
            }
        }


    }
}
