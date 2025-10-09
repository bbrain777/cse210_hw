
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Overloaded constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0; // already completed, no extra points
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        // Type|name|desc|points|isComplete
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}
