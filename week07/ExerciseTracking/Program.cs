using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>(){
            new Running(new DateTime(2025, 2, 1), 45, 6),
            new Cycling(new DateTime(2025, 2, 2), 120, 18),
            new Swimming(new DateTime(2025, 2, 3), 60, 50)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}