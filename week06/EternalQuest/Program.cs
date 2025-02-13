using System;
using System.Collections.Generic;
using System.IO;

//i added to the program a way to do a deadlinegoal.

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Deadline Goal");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            case "4":
                Console.Write("Enter deadline (yyyy-MM-dd): ");
                DateTime deadline = DateTime.Parse(Console.ReadLine());
                _goals.Add(new DeadlineGoal(name, description, points, deadline));
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Choose a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int pointsEarned = _goals[choice].RecordEvent(_goals[choice].GetShortName());
            _score += pointsEarned;
            Console.WriteLine($"Event recorded for '{_goals[choice].GetShortName()}'. You earned {pointsEarned} points!");
            if (_goals[choice].IsComplete())
            {
                Console.WriteLine($"Congratulations! You completed the goal: {_goals[choice].GetShortName()}");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void ShowScore()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Score:{_score}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        _score = 0;

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Score:"))
                {
                    _score = int.Parse(line.Split(':')[1]);
                }
                else
                {
                    
                    string[] parts = line.Split(':');
                    string type = parts[0];
                    string[] data = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            var simpleGoal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                            if (bool.Parse(data[3])) simpleGoal.RecordEvent(data[0]); 
                            _goals.Add(simpleGoal);
                            break;

                        case "EternalGoal":
                            _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                            break;

                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                            for (int i = 0; i < int.Parse(data[5]); i++) checklistGoal.RecordEvent(data[0]); 
                            _goals.Add(checklistGoal);
                            break;

                        case "DeadlineGoal":
                            DateTime deadline = DateTime.Parse(data[3]);
                            var deadlineGoal = new DeadlineGoal(data[0], data[1], int.Parse(data[2]), deadline);
                            _goals.Add(deadlineGoal);
                            break;
                    }
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}