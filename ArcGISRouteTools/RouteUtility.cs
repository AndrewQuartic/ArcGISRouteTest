

namespace ArcGISRouteTools
{
    using Esri.ArcGISRuntime.Geometry;
    using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Types;

    /// <summary>
    /// Class containing logic to perform point to point routing.
    /// </summary>
    public class RouteUtility
    {
        #region Fields

        private RouteTask routeTask = null;

        private RouteParameters routeParams = null;

        private List<Stop> stopPoints = new List<Stop>();

        private List<PointBarrier> pointBarriers = new List<PointBarrier>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the service URI for network routing endpoint.
        /// </summary>
        public Uri RouteServiceUri { get; private set; }

        /// <summary>
        /// Gets the input spatial reference for the given routing task.
        /// </summary>
        public SpatialReference SpatialRef { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Creates a default instance of type <see cref="RouteUtility"/>
        /// </summary>
        /// <param name="routeServiceUrl"></param>
        /// <param name="SpatialReferenceWkid"></param>
        public RouteUtility(string routeServiceUrl, SpatialRefTypes SpatialReferenceWkid)
        {
            RouteServiceUri = new Uri(routeServiceUrl);
            SpatialRef = new SpatialReference((int)SpatialReferenceWkid);
        }

        /// <summary>
        /// Creates a default instance of type <see cref="RouteUtility"/>
        /// </summary>
        /// <param name="routeServiceUrl"></param>
        /// <param name="SpatialReferenceWkid"></param>
        public RouteUtility(string routeServiceUrl, int SpatialReferenceWkid)
        {
            RouteServiceUri = new Uri(routeServiceUrl);
            SpatialRef = new SpatialReference(SpatialReferenceWkid);
        }

        #endregion Construtor

        #region Methods

        /// <summary>
        /// Adds a stop to the parameter list for a route.
        /// </summary>
        /// <param name="x">Input X coordinate</param>
        /// <param name="y">Input Y Coordinate</param>
        /// <param name="spatialRefWkid">Spatial reference WKID</param>
        public void AddStop(double x, double y)
        {
            // create a Stop for my location
            var myLocation = new MapPoint(x, y, SpatialRef);
            var stop1 = new Stop(myLocation);
            stopPoints.Add(stop1);
        }

        /// <summary>
        /// Adds a stop to the parameter list for a route.
        /// </summary>
        /// <param name="x">Input X coordinate</param>
        /// <param name="y">Input Y Coordinate</param>
        /// <param name="spatialRefWkid">Spatial reference WKID</param>
        public void AddStop(double x, double y, SpatialRefTypes spatialRef)
        {
            AddStop(x, y, (int)spatialRef);
        }

        /// <summary>
        /// Adds a stop to the parameter list for a route.
        /// </summary>
        /// <param name="x">Input X coordinate</param>
        /// <param name="y">Input Y Coordinate</param>
        /// <param name="spatialRefWkid">Spatial reference WKID</param>
        public void AddStop(double x, double y, int spatialRef)
        {
            // create a Stop for my location
            var myLocation = new MapPoint(x, y, new SpatialReference(spatialRef));
            var stop1 = new Stop(myLocation);
            stopPoints.Add(stop1);
        }

        /// <summary>
        /// Adds a barrier to the parameter list for a route.
        /// </summary>
        /// <param name="x">Input X coordinate</param>
        /// <param name="y">Input Y Coordinate</param>
        /// <param name="spatialRefWkid">Spatial reference WKID</param>
        public void AddBarrier(double x, double y)
        {
            // create a PointBarrier to avoid
            var accidentLocation = new MapPoint(x, y, SpatialRef);
            var barrier = new PointBarrier(accidentLocation);
            pointBarriers.Add(barrier);
        }

        /// <summary>
        /// Resets stops
        /// </summary>
        public void ResetStops()
        {
            if (routeParams != null)
            {
                routeParams.ClearStops();
            }

            stopPoints.Clear();
        }

        /// <summary>
        /// Resets barriers
        /// </summary>
        public void ResetBarriers()
        {
            if (routeParams != null)
            {
                routeParams.ClearPointBarriers();
            }

            pointBarriers.Clear();
        }

        /// <summary>
        /// Solves routing problem for given input parameters
        /// </summary>
        /// <returns></returns>
        public async Task<RouteUtilityResult> Solve()
        {
            routeTask = (routeTask) ?? await RouteTask.CreateAsync(RouteServiceUri);
            var routInfo = routeTask.RouteTaskInfo;

            // get the default route parameters
            routeParams = (routeParams) ?? await routeTask.CreateDefaultParametersAsync();
            // explicitly set values for some params
            // routeParams.ReturnDirections = true;
            // routeParams.ReturnRoutes = true;
            routeParams.OutputSpatialReference = SpatialRef;

            routeParams.SetStops(stopPoints);
            routeParams.SetPointBarriers(pointBarriers);
            var routeResult = await routeTask.SolveRouteAsync(routeParams);
            return new RouteUtilityResult
            {
                RouteName = routeResult.Routes[0].RouteName,
                TotalTime = routeResult.Routes[0].TotalTime
            };
        }

        #endregion Methods
    }
}
