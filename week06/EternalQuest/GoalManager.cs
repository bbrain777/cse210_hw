
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private readonly List<Goal> _goals = new();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goal Details");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string checkbox = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {checkbox} {g.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        var type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = ReadInt();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = ReadInt();
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Unknown goal type.");
                break;
        }
        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");

        Console.Write("Which goal did you accomplish? ");
        int idx = ReadInt();
        if (idx < 1 || idx > _goals.Count) { Console.WriteLine("Invalid selection."); return; }

        var goal = _goals[idx - 1];
        int awarded = goal.RecordEvent();
        _score += awarded;
        Console.WriteLine($"Event recorded! You earned {awarded} points.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        var filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename)) { Console.WriteLine("Canceled."); return; }

        using var writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        foreach (var g in _goals)
            writer.WriteLine(g.GetStringRepresentation());

        Console.WriteLine($"Saved {_goals.Count} goals and score to {filename}.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        var filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var lines = File.ReadAllLines(filename);
        _goals.Clear();
        if (lines.Length == 0) { Console.WriteLine("Empty file."); return; }

        _score = int.TryParse(lines[0], out var s) ? s : 0;

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            try
            {
                _goals.Add(Goal.FromString(lines[i]));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Skipping corrupt line {i}: {ex.Message}");
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals. Current score: {_score}");
    }

    private static int ReadInt()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int n)) return n;
            Console.Write("Please enter a valid integer: ");
        }
    }
}
