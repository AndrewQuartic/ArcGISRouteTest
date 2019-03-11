
using System;

namespace ArcGISRouteTools
{
    /// <summary>
    /// Class holding the information for a single route.
    /// </summary>
    public class RouteUtilityResult
    {
        /// <summary>
        /// Gets name or unique identifier of route
        /// </summary>
        public string RouteName { get; internal set; }

        /// <summary>
        /// Gets route total time.
        /// </summary>
        /// <Remarks>
        /// This includes any travel time, time spent waiting at stops 
        /// (arriving before the start of a time window), and service time at stops.
        /// </Remarks>
        public TimeSpan TotalTime { get; internal set; }

        /// <summary>
        /// Provides override for formatting return string.
        /// </summary>
        /// <returns>String formatted for easy readout</returns>
        public override string ToString()
        {
            return $"ID: {RouteName, -10} | Drive Time {TotalTime}";
        }
    }
}
