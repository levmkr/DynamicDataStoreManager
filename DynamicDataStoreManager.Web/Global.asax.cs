using System.Web.Mvc;
using System.Web.Routing;
using DynamicDataStoreManager.Web.Business;

namespace DynamicDataStoreManager.Web
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}