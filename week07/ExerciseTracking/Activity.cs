public abstract class Activity{
    private DateTime _date;
    private int _duration;

    public Activity(DateTime date, int duration){
        _date = date;
        _duration = duration;
    }

    public int DurationMinutes => _duration;
    public DateTime Date => _date;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary(){
        return $"{Date:dd MMMM yyyy} {GetType().Name} ({DurationMinutes} min) - Distance: {GetDistance():0.0} Km, Speed: {GetSpeed():0.0} km/h, Pace: {GetPace():0.0} min/km";
        
    }
}