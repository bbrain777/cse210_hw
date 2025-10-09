
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        // Always awards points, never completes
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        // Type|name|desc|points
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}
