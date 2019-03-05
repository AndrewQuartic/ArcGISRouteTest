

namespace ArcGISRouteTest
{
    using Esri.ArcGISRuntime.Geometry;
    using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArcGISRouteTool
    {
        private RouteTask routeTask = null;

        private RouteParameters routeParams = null;

        private List<Stop> stopPoints = new List<Stop>();

        private List<PointBarrier> pointBarriers = new List<PointBarrier>();

        public Uri RouteServiceUri { get; private set; }
        public SpatialReference SpatialRef { get; private set; }

        public ArcGISRouteTool(string routeServiceUrl, int SpatialReferenceWkid = 102100, bool ReturnDirections = true, bool ReturnRoutes = true)
        {
            var RouteServiceUri = new Uri(routeServiceUrl);
            SpatialRef = new SpatialReference(SpatialReferenceWkid);
            Initialize();
        }

        private async void Initialize()
        {
            routeTask = await RouteTask.CreateAsync(RouteServiceUri);
            // get the default route parameters
            routeParams = await routeTask.CreateDefaultParametersAsync();
            // explicitly set values for some params
            routeParams.ReturnDirections = true;
            routeParams.ReturnRoutes = true;
            routeParams.OutputSpatialReference = SpatialRef;
        }

        public void AddStop(double x, double y, int spatialRefWkid)
        {
            // create a Stop for my location
            var myLocation = new MapPoint(x, y, new SpatialReference(spatialRefWkid));
            var stop1 = new Stop(myLocation);
            stopPoints.Add(stop1);
        }

        public void AddBarrier(double x, double y, int spatialRefWkid)
        {
            // create a PointBarrier to avoid
            var accidentLocation = new MapPoint(x, y, spatialRefWkid);
            var barrier = new PointBarrier(accidentLocation);
            pointBarriers.Add(barrier);
        }

        public void ResetStops()
        {
            stopPoints.Clear();
        }

        public void ResetBarriers()
        {
            pointBarriers.Clear();
        }

        public async Task<Route> Solve()
        {
            routeParams.SetStops(stopPoints);
            routeParams.SetPointBarriers(pointBarriers);
            var routeResult = await routeTask.SolveRouteAsync(routeParams);
            ResetStops();
            ResetBarriers();
            return routeResult.Routes[0];
        }

    }
}
