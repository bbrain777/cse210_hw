# Exercise Tracking (CSE 210 – W07)
This project demonstrates abstraction, encapsulation, inheritance, and polymorphism with a simple exercise tracker for Running, Cycling, and Swimming.

## How it meets the rubric
- Abstraction: Activity is the base class with abstract calculation methods.
- Encapsulation: All fields are private; derived classes access shared state via protected accessors.
- Inheritance: RunningActivity, CyclingActivity, and SwimmingActivity derive from Activity.
- Polymorphism (overriding): Each derived class overrides GetDistance(), GetSpeed(), and GetPace().
- Virtual use from base: Activity.GetSummary() calls virtual methods and works for all derived types.
- Functionality: Program.cs creates each activity, stores them in a single list, and prints correct summaries.
- Style: Each class in its own file, naming conventions follow course spec.

## Units
All calculations use kilometers and kph. Lap length is 50 meters.

## Run
dotnet build
dotnet run

A sample console output is provided in sample_output.png for your screenshot requirement.
