public class Swimming : Activity{
    private int _laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration){
        _laps = laps;
    }

    public override double GetDistance(){
        return _laps * 0.05;
    }

    public override double GetSpeed(){
        return (GetDistance() / DurationMinutes) * 60;
    }

    public override double GetPace(){
        return DurationMinutes / GetDistance();
    }
}