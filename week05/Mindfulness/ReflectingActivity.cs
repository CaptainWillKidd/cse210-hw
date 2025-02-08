public class ReflectingActivity : Activity{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 5){
        _prompts = new List<string> {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void PerformActivity(){
        DisplayStartingMessage();
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[promptIndex]);
        ShowSpinner(3);

        int duration = _duration;
        while (duration > 0){
            int questionIndex = random.Next(_questions.Count);
            Console.WriteLine(_questions[questionIndex]);
            ShowSpinner(5);
            duration -= 5;
        }
        DisplayEndingMessage();
    }

    private void GetRandomItem(List<string> items){
        Random random = new Random();
        int index = random.Next(items.Count);
        Console.WriteLine(items[index]);
    }

    public void ShowPrompts(){
        for (int i = 0; i < 3; i++){
            GetRandomItem(_prompts);
            Thread.Sleep(5000);
        }
    }

    public void DisplayPrompt(){
        GetRandomItem(_questions);
        string response = Console.ReadLine();
        Console.WriteLine($"You said: {response}");
    }

    public void DisplayQuestions(){
        for (int i = 0; i < 3; i++){
            DisplayPrompt();
            Thread.Sleep(5000);
        }
    }
}