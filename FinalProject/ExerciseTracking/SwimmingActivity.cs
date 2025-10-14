using System;
namespace ExerciseTracking
{
    public sealed class SwimmingActivity : Activity
    {
        private readonly int _laps;
        private const double LapMeters = 50.0;

        public SwimmingActivity(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return (_laps * LapMeters) / 1000.0;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60.0;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }
}
