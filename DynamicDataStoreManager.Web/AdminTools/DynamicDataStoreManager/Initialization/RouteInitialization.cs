using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Initialization
{
    [InitializableModule]
    public class RouteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapRoute("DdsPluginIndex", "custom-plugins/dds-plugin",
                new { controller = "DdsManager", action = "Index" });
            RouteTable.Routes.MapRoute("DdsPluginGetStores", "custom-plugins/dds-plugin/getstores",
                new { controller = "DdsManager", action = "GetStores" });
            RouteTable.Routes.MapRoute("DdsPluginGetStoreData", "custom-plugins/dds-plugin/getstoredata",
                new { controller = "DdsManager", action = "GetStoreData" });
            RouteTable.Routes.MapRoute("DdsPluginDeleteStoreItem", "custom-plugins/dds-plugin/deletestoreitem",
                new { controller = "DdsManager", action = "DeleteStoreItem" });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}