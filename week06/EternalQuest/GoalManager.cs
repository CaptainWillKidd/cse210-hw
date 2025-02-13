using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        _goals.Add(new EternalGoal("Read Scriptures", "Read scriptures every day", 100));
        _goals.Add(new SimpleGoal("Run Marathon", "Complete a marathon", 1000));
        _goals.Add(new ChecklistGoal("Attend Temple", "Attend the temple 10 times", 50, 10, 500));
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}\n");
        Console.WriteLine("Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetShortName());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateChecklistGoal(string shortName, string description, int points, int target, int bonus)
    {
        _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
    }

    public void CreateSimpleGoal(string shortName, string description, int points)
    {
        _goals.Add(new SimpleGoal(shortName, description, points));
    }

    public void CreateEternalGoal(string shortName, string description, int points)
    {
        _goals.Add(new EternalGoal(shortName, description, points));
    }

    public void CreateDeadlineGoal(string shortName, string description, int points, DateTime deadline)
    {
        _goals.Add(new DeadlineGoal(shortName, description, points, deadline));
    }

    public void RecordEvent(string shortName)
    {
        foreach (Goal goal in _goals)
        {
            if (goal.GetShortName() == shortName)
            {
                int pointsEarned = goal.RecordEvent(shortName);
                _score += pointsEarned;
                Console.WriteLine($"Event recorded for '{shortName}'. You earned {pointsEarned} points!");
                if (goal.IsComplete())
                {
                    Console.WriteLine($"Congratulations! You completed the goal: {shortName}");
                }
                return;
            }
        }
        Console.WriteLine($"Goal with name '{shortName}' not found.");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Score:{_score}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals and score saved successfully.");
    }

    public void LoadGoals(string filename)
    {
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
                            _goals.Add(new DeadlineGoal(data[0], data[1], int.Parse(data[2]), deadline));
                            break;
                    }
                }
            }
        }
        Console.WriteLine("Goals and score loaded successfully.");
    }
}