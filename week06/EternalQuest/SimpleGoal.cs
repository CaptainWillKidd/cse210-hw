public class SimpleGoal : Goal{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points){
        _isComplete = false;
    }

    public override int RecordEvent(string shortName){
        if(shortName == _shortName && !_isComplete){
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() => $"[{(_isComplete ? "X" : " ")}] {_shortName} - {_description} - Points: {_points}";

    public override string GetStringRepresentation() => $"{base.GetStringRepresentation()},{_isComplete}";
}