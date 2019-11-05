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
   public static class AppBuilderExtensions
    {
        public static void AddMyMiddlewarecomponent(this IAppBuilder app) {
            app.Use<MyMiddlewareComponent>();
        }

        public static void AddMyOtherMiddlewarecomponent(this IAppBuilder app)
        {
            app.Use<MyOtherMiddlewareComponent>();
        }

        public static void AddMyGreetingExtensionComponent(this IAppBuilder app, MyGreetingMiddlewareConfigOptions options) {
            app.Use<MyGreetingMiddlewareComponent>(options);
        }

        public static void UseSillyAuthentication(this IAppBuilder app)
        {
            app.Use<SillyAuthenticationComponent>();
        }

        public static void UseSillyLogging(this IAppBuilder app)
        {
            app.Use<SillyLoggingComponent>();
        }

    }
}
