public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent(string shortName) {
        if (shortName != _shortName) return 0;

        _amountCompleted++;
        int total = _points;
        if (_amountCompleted == _target) total += _bonus;
        return total;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => $"[{(_amountCompleted >= _target ? "X" : " ")}] {_shortName} - {_description} - Completed {_amountCompleted}/{_target} - Points: {_points} (+{_bonus} bonus)";

    public override string GetStringRepresentation() => $"{base.GetStringRepresentation()},{_target},{_bonus},{_amountCompleted}";
}