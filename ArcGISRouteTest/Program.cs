
namespace ArcGISRouteTest
{
    using ArcGISRouteTools;
    using ArcGISRouteTools.Types;
    using System;

    /// <summary>
    /// Example application utilizing ArcGISRouteTools class library
    /// Performs point to point routing using a given set of input parameters.
    /// </summary>
    public class Program
    {
        public const string routeService = "http://webmapsdev.sandiego.gov/arcgis/rest/services/FireDispatch/Fire_RoadNetService/NAServer/Route";
        private static RouteUtility routeUtil = null;

        /// <summary>
        /// Main entrypoint for application. Initializes RouteUtility class and solves an example route.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        private static void Main(string[] args)
        {
            routeUtil = new RouteUtility(routeService, SpatialRefTypes.GCS_North_American_1983);
            RunRouteTask();
            Console.ReadLine();
        }

        /// <summary>
        /// Performs route task using a set of example input points geocoded using 
        /// https://webmapsdev.sandiego.gov/arcgis/rest/services/Locators/SDW_CompositeAddLocatorNew/GeocodeServer
        /// </summary>
        private static async void RunRouteTask()
        {
            routeUtil.AddStop(32.811467, 117.150312, 102100); // station 10
            routeUtil.AddStop(-13032098.5338906, 3864870.31162168, 102100);
            var result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());

            routeUtil.AddStop(-13030771.9866275, 3865622.58069907, 102100); // Alvarado Hospital
            result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());

            /*
            routeUtil.AddBarrier(-13031844.958950741, 3863670.1178109264, 102100); // College & El Cajon
            routeUtil.AddBarrier(-13030429.313097086, 3864592.621714865, 102100); // El Cajon & Montezuma
            result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());
            */
        }
    }
}
