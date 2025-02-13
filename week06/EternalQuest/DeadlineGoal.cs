public class DeadlineGoal : Goal
{
    private DateTime _deadline;

    public DeadlineGoal(string shortName, string description, int points, DateTime deadline) 
        : base(shortName, description, points)
    {
        _deadline = deadline;
    }

    public override int RecordEvent(string shortName)
    {
        if (shortName == GetShortName() && !IsComplete())
        {
            if (DateTime.Now <= _deadline)
            {
                return GetPoints();
            }
            else
            {
                Console.WriteLine("Deadline has passed. No points awarded.");
                return 0;
            }
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return DateTime.Now > _deadline;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} - {GetDescription()} - Due: {_deadline.ToShortDateString()} - Points: {GetPoints()}";
    }

    public override string GetStringRepresentation()
    {
        return $"DeadlineGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_deadline:yyyy-MM-dd}";
    }
}