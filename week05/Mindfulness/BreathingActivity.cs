public class BreathingActivity : Activity{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 5){
    }

    public void PerformActivity(){
        DisplayStartingMessage();
        int duration = _duration;
        while (duration > 0){
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            duration -= 4;
            if (duration <= 0) break;
            Console.WriteLine("Breathe out...");
            ShowCountdown(6);
            duration -= 6;
        }
        DisplayEndingMessage();
    }
}