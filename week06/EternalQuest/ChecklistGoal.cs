
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _bonusAwarded;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = false;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = amountCompleted >= target;
    }

    public int AmountCompleted => _amountCompleted;
    public int Target => _target;

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}" + (IsComplete() ? " [COMPLETED]" : "");
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int awarded = _points;
        if (!_bonusAwarded && _amountCompleted >= _target)
        {
            awarded += _bonus;
            _bonusAwarded = true;
        }
        return awarded;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
