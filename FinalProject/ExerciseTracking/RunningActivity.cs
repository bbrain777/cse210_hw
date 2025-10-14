using System;
namespace ExerciseTracking
{
    public sealed class RunningActivity : Activity
    {
        private readonly double _distanceKm;

        public RunningActivity(DateTime date, int minutes, double distanceKm)
            : base(date, minutes)
        {
            _distanceKm = distanceKm;
        }

        public override double GetDistance() => _distanceKm;

        public override double GetSpeed()
        {
            return (_distanceKm / Minutes) * 60.0;
        }

        public override double GetPace()
        {
            return Minutes / _distanceKm;
        }
    }
}
