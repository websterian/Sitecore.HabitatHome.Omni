using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.HabitatHome.Fitness.Feature.StoreSelector.Controllers;
using Sitecore.LayoutService.Serialization.ItemSerializers;

namespace Sitecore.HabitatHome.Fitness.Feature.StoreSelector
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRouter, Router>();
            serviceCollection.AddTransient<StoresController>();
        }
    }
}