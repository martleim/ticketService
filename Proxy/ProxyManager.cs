using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Business;
using Tickets.Common;
using Tickets.Proxy.Proxies;

namespace Tickets.Proxy

{
    public class ProxyManager
    {

        static bool UseBusinessLogic = "false".Equals(System.Configuration.ConfigurationManager.AppSettings["useProxy"]);
        public static IEventsManager EventsManager
        {
            get
            {
                if (UseBusinessLogic)
                    return new EventBusinessManager();

                return new EventsManagerProxy();
            }
        }

        public static ISecurityManager SecurityManager
        {
            get
            {
                if (UseBusinessLogic)
                    return new SecurityBusinessManager();

                return new SecurityManagerProxy();
            }
        }

        public static ITicketsManager TicketsManager
        {
            get
            {
                if (UseBusinessLogic)
                    return new TicketBusinessManager();

                return new TicketsManagerProxy();
            }
        }

        public static IAspNetUserManager AspNetUserManager
        {
            get
            {
                if (UseBusinessLogic)
                    return new AspNetUserManager();

                return new AspNetUserManagerProxy();
            }
        }


    }
}
