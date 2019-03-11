
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
            routeUtil = new RouteUtility(routeService, SpatialRefTypes.GCS_WGS_1984);
            RunRouteTask();
            Console.ReadLine();
        }

        /// <summary>
        /// Performs route task using a set of example input points geocoded using 
        /// https://webmapsdev.sandiego.gov/arcgis/rest/services/Locators/SDW_CompositeAddLocatorNew/GeocodeServer
        /// </summary>
        private static async void RunRouteTask()
        {
            routeUtil.AddStop(-117.06705506901389, 32.76135209262446, SpatialRefTypes.GCS_WGS_1984); // College & El Cajon
            routeUtil.AddStop(-117.06933297145534, 32.770418157877245, SpatialRefTypes.GCS_WGS_1984);
            var result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());

            routeUtil.AddStop(-117.05741639463984, 32.77610020313963, SpatialRefTypes.GCS_WGS_1984); // Alvarado Hospital
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
