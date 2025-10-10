
using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    /// <summary>
    /// Record an event for this goal. Returns points awarded.
    /// </summary>
    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    public static Goal FromString(string line)
    {
        var parts = line.Split('|');
        if (parts.Length < 4) throw new InvalidOperationException("Corrupt save line: " + line);

        var type = parts[0];
        var name = parts[1];
        var desc = parts[2];
        var points = int.Parse(parts[3]);

        return type switch
        {
            "SimpleGoal" => new SimpleGoal(name, desc, points, isComplete: (parts.Length > 4 && bool.Parse(parts[4]))),
            "EternalGoal" => new EternalGoal(name, desc, points),
            "ChecklistGoal" => new ChecklistGoal(name, desc, points,
                                target: int.Parse(parts[5]), bonus: int.Parse(parts[6]),
                                amountCompleted: int.Parse(parts[4])),
            _ => throw new InvalidOperationException("Unknown goal type: " + type)
        };
    }
}
