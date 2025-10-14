using System;
namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        protected DateTime Date => _date;
        protected int Minutes => _minutes;

        protected Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public abstract double GetDistance(); // km
        public abstract double GetSpeed();    // kph
        public abstract double GetPace();     // min per km

        public virtual string GetSummary()
        {
            string typeName = GetType().Name.Replace("Activity","");
            return $"{_date:dd MMM yyyy} {typeName} ({_minutes} min): " +
                   $"Distance {GetDistance():0.0} km, " +
                   $"Speed: {GetSpeed():0.0} kph, " +
                   $"Pace: {GetPace():0.00} min per km";
        }
    }
}
