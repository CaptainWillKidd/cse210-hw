public class ListingActivity : Activity{
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration, List<string> prompts) : base(name, description, duration){
        _prompts = prompts;
    }

    public void PerformActivity(){
        DisplayStartingMessage();
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[promptIndex]);
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime){
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item)){
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
        DisplayEndingMessage();
    }
}