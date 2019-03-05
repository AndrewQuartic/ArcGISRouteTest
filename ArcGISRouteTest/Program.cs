
namespace ArcGISRouteTest
{
    using Esri.ArcGISRuntime.Geometry;
    using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private const string RouteService = "http://webmapsdev.sandiego.gov/arcgis/rest/services/FireDispatch/Fire_RoadNetService/NAServer/Route";

        private static void Main(string[] args)
        {
            RunRouteTask();
            Console.ReadLine();
        }

        private static async void RunRouteTask()
        {
            ArcGISRouteTool route = new ArcGISRouteTool(RouteService);
            route.AddStop(-13034379.7137452, 3858390.14190331, 102100);
            route.AddStop(-13032763.2362459, 3860880.60006008, 102100);
            var result = await route.Solve();
        }
    }
}
