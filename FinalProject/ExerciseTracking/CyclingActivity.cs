using System;
namespace ExerciseTracking
{
    public sealed class CyclingActivity : Activity
    {
        private readonly double _avgSpeedKph;

        public CyclingActivity(DateTime date, int minutes, double avgSpeedKph)
            : base(date, minutes)
        {
            _avgSpeedKph = avgSpeedKph;
        }

        public override double GetDistance()
        {
            return _avgSpeedKph * (Minutes / 60.0);
        }

        public override double GetSpeed() => _avgSpeedKph;

        public override double GetPace()
        {
            return 60.0 / _avgSpeedKph;
        }
    }
}
