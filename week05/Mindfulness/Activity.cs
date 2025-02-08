public class Activity{
    private string _name;
    private string _description;
    protected int _duration;

    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public Activity(string name, string description, int duration){
        _name = name;
        _description = description;
        _duration = duration;

        if (_activityCounts.ContainsKey(_name)){
            _activityCounts[_name]++;
        }
        else{
            _activityCounts[_name] = 1;
        }
    } 

    public static void DisplayActivityLog(){
        Console.WriteLine("\nActivity Log:");
        foreach (var entry in _activityCounts){
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }

    public void DisplayStartingMessage(){
        Console.WriteLine($"Starting {_name} activity");
        Console.WriteLine($"Description: {_description}");
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(5);
    }

    public void DisplayEndingMessage(){
        Console.WriteLine($"Good job! You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds){
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime){
            Console.Write("/");
            Thread.Sleep(100);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(100);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(100);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
    }

    public void ShowCountdown(int seconds){
        for (int i = seconds; i > 0; i--){
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}