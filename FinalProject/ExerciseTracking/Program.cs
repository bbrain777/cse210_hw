using System;
using System.Collections.Generic;
using ExerciseTracking;

internal class Program
{
    private static void Main()
    {
        var activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2025, 10, 10), 30, distanceKm: 5.2),
            new CyclingActivity(new DateTime(2025, 10, 11), 45, avgSpeedKph: 24.0),
            new SwimmingActivity(new DateTime(2025, 10, 12), 40, laps: 60)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
