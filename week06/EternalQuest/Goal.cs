public class Goal{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points){
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual int RecordEvent(string shortName){
        return (shortName == _shortName) ? _points : 0;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual bool IsComplete() => false;

    public virtual string GetDetailsString() => $"{_shortName} - {_description} - Points: {_points}";

    public virtual string GetStringRepresentation() => $"{GetType().Name}:{_shortName}, {_description}, {_points}";

    public string GetShortName() => _shortName;
    public int GetPoints() => _points;
}