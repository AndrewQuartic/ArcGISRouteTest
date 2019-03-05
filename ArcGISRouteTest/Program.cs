
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
            var routeSourceUri = new Uri(RouteService);
            var routeTask = await RouteTask.CreateAsync(routeSourceUri);

            // get the default route parameters
            var routeParams = await routeTask.CreateDefaultParametersAsync();
            // explicitly set values for some params
            routeParams.ReturnDirections = true;
            routeParams.ReturnRoutes = true;
            routeParams.OutputSpatialReference = new Esri.ArcGISRuntime.Geometry.SpatialReference(102100);

            // create a Stop for my location
            var myLocation = new MapPoint(-13034379.7137452, 3858390.14190331, SpatialReferences.WebMercator);
            var stop1 = new Stop(myLocation);

            // create a Stop for your location
            var yourLocation = new MapPoint(-13032763.2362459, 3860880.60006008, SpatialReferences.WebMercator);
            var stop2 = new Stop(yourLocation);

            // assign the stops to the route parameters
            var stopPoints = new List<Stop> { stop1, stop2 };
            routeParams.SetStops(stopPoints);

            // create a PointBarrier to avoid
            var accidentLocation = new MapPoint(-13033331.7103904, 3859368.53617918, SpatialReferences.WebMercator);
            var barrier = new PointBarrier(accidentLocation);

            // add the point barriers to the route parameters
            List<PointBarrier> pointBarriers = new List<PointBarrier> { barrier };
            routeParams.SetPointBarriers(pointBarriers);

            var routeResult = await routeTask.SolveRouteAsync(routeParams);

            // get the route from the results
            var route = routeResult.Routes[0];

        }


    }
}
