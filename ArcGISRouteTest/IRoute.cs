
namespace ArcGISRouteTest
{
    using System;

    public interface RouteResult
    {

        TimeSpan EndTimeShift { get; }

        //
        //     Gets route's name.
        string RouteName { get; }
        //
        // Summary:
        //     Gets start time in UTC.
        //
        // Remarks:
        //     To calculate the departure time for the timezone of the start location, add the
        //     Esri.ArcGISRuntime.Tasks.NetworkAnalysis.Route.StartTimeShift. Note that this
        //     might be a different timezone than System.DateTimeKind.Local if the start location
        //     is in a different timezone than the device. You can also use System.DateTime.ToLocalTime
        //     to get the arrival time in the time zone of the device.
        DateTimeOffset? StartTime { get; }
        //
        // Summary:
        //     Gets the time-zone shift for the start time.
        //
        // Remarks:
        //     The shift is the amount to apply to the Esri.ArcGISRuntime.Tasks.NetworkAnalysis.Route.StartTime
        //  // Summary:
           to get the local time of the start location.
        TimeSpan StartTimeShift { get; }

        //
        // Summary:
        //     Gets total route length in meters.
        double TotalLength { get; }
        //
        // Summary:
        //     Gets route total time.
        //
        // Remarks:
        //     This includes any travel time, time spent waiting at stops (arriving before the
        //     start of a time window), and service time at stops.
        TimeSpan TotalTime { get; }
        //
        // Summary:
        //     Gets total travel time.
        //
        // Remarks:
        //     This includes only time of the travel.
        TimeSpan TravelTime { get; }
        //
        // Summary:
        //     Gets the total amount of additional time incurred due to time window violations.
       TimeSpan ViolationTime { get; }
        //
        // Summary:
        //     Gets the total amount of additional time incurred due to waiting at time windows.
        TimeSpan WaitTime { get; }
    }
}
