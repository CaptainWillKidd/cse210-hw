using System;
using System.Collections.Generic;

//I added the actitity log to the Activity project so we can know how many times each activity has been performed.
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Activities");
            Console.WriteLine("1. Reflecting");
            Console.WriteLine("2. Listing");
            Console.WriteLine("3. Breathing");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.PerformActivity();
                    break;
                case "2":
                    ListingActivity listingActivity = new ListingActivity("Listing", "List your thoughts", 10, new List<string> {
                        "Who are people that you appreciate?",
                        "What are personal strengths of yours?",
                        "Who are people that you have helped this week?",
                        "When have you felt the Holy Ghost this month?",
                        "Who are some of your personal heroes?"
                    });
                    listingActivity.PerformActivity();
                    break;
                case "3":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.PerformActivity();
                    break;
                case "4":
                Activity.DisplayActivityLog();
                break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("Activity completed. Returning to main menu...");
        }
    }
}