public class EternalGoal : Goal{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points) { }

    public override int RecordEvent(string shortName) => (shortName == _shortName) ? _points : 0;

    public override string GetDetailsString() => $"[ ] {_shortName} - {_description} - Points: {_points} (Eternal)";

    public override string GetStringRepresentation() => $"{base.GetStringRepresentation()}";
}
