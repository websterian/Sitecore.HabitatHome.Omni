using System.Web.Mvc;

namespace Sitecore.HabitatHome.Fitness.Feature.StoreSelector
{
    public class Router : IRouter
    {
        public void MapRoutes(System.Web.Routing.RouteCollection routeCollection)
        {
            RouteCollectionExtensions.MapRoute(routeCollection, "habitathome-fitness-stores", "sitecore/api/habitatfitness/stores/{action}", new
            {
                //action = "Index",
                controller = "Stores"
            });

            //RouteCollectionExtensions.MapRoute(routeCollection, "habitathome-fitness-stores-search", "sitecore/api/habitatfitness/stores/{action}", new
            //{
            //    action = "search",
            //    controller = "Stores",
            //});
        }
    }

    public interface IRouter
    {
        void MapRoutes(System.Web.Routing.RouteCollection routeCollection);
    }
}