
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
            routeUtil.AddStop(-117.0670431809381, 32.761347321543, SpatialRefTypes.GCS_North_American_1983); // College & El Cajon
            routeUtil.AddStop(-117.06932108233752, 32.77041338583157, SpatialRefTypes.GCS_North_American_1983);
            var result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());

            routeUtil.AddStop(-117.05740450717408, 32.77609542980793, SpatialRefTypes.GCS_North_American_1983); // Alvarado Hospital
            result = await routeUtil.Solve();
            Console.WriteLine(result.ToString());
        }
    }
}
