using DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Services;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.ServiceLocation.Compatibility;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Initialization
{
    [InitializableModule]
    public class InitializeDependencies : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure(c =>
            {
                c.For<IDynamicDataStoreService>().Use<DynamicDataStoreService>();
            });
        }
    }
}