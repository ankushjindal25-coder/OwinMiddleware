using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinMiddleware.Middleware
{
    public class MyGreetingMiddlewareConfigOptions
    {
        string _greetingTextFormat = "{0} from {1}{2}";
        public MyGreetingMiddlewareConfigOptions(string greeting, string greeter){
            GreetingText = greeting;
            Greeter = greeter;
            Date = DateTime.Now;
        }

        public string GreetingText { get; set; }
        public string Greeter { get; set; }
        public DateTime Date { get; set; }

        public string GetGreeting(){
            return string.Format(_greetingTextFormat, GreetingText, Greeter,Date.ToShortDateString() );
        }
    }
}
