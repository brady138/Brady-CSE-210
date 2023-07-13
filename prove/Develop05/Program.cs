using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Eternal Quest Demo!");
        Thread.Sleep(1000);
        Console.Clear();
        bool menuRunner = false;
        GoalManager goalManager = new GoalManager(); 
        int totalPoints = 0; 

        while (!menuRunner)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                goalManager.CreateGoal();
            }
            else if (userInput == "2")
            {
                goalManager.GoalLister(totalPoints); 
            }
            else if (userInput == "3")
            {
                goalManager.GoalSaver();
            }
            else if (userInput == "4")
            {
                goalManager.GoalLoader();
            }
            else if (userInput == "5")
            {
                goalManager.EventRecorder(ref menuRunner, ref totalPoints); 
            }
            else if (userInput == "6")
            {
                Console.WriteLine("Have a great day and get your goals done!");
                Console.WriteLine("Goodbye!");
                menuRunner = true;
                Environment.Exit(0);
            }
        }
    }

    public class GoalManager
{
    public List<Goal> goals = new List<Goal>();
    public string filePath = "goals.txt";
    public int totalPoints = 0; 
    public void CreateGoal()
    {
        bool createGoalRunner = false;
        while (!createGoalRunner)
        {
            Console.WriteLine("Goal Types:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("Please input the goal type (or quit): ");
            string goalTypeInput = Console.ReadLine();

            if (goalTypeInput == "quit")
            {
                createGoalRunner = true;
            }
            else if (goalTypeInput == "1")
            {
                Console.WriteLine("Goal Description:");
                string goal = Console.ReadLine();
                Console.WriteLine("Points: ");
                string points = Console.ReadLine();

                Goal simpleGoal = new SimpleGoal(goal, points);
                goals.Add(simpleGoal); 
                totalPoints += int.Parse(points); 
                GoalSaver(); 
            }
            else if (goalTypeInput == "2")
            {
                Console.WriteLine("Goal Description:");
                string goal = Console.ReadLine();
                Console.WriteLine("Points: ");
                string points = Console.ReadLine();

                Goal eternalGoal = new EternalGoal(goal, points);
                eternalGoal.Check();
                goals.Add(eternalGoal); 
                GoalSaver(); 
            }
            else if (goalTypeInput == "3")
            {
                Console.WriteLine("Goal Description:");
                string goal = Console.ReadLine();
                Console.WriteLine("Points: ");
                string points = Console.ReadLine();

                Goal checklistGoal = new ChecklistGoal(goal, points);
                goals.Add(checklistGoal); 
                GoalSaver(); 
            }
            Console.WriteLine();
        }
    }

        public void GoalLister(int totalPoints) // Accept totalPoints as a parameter
        {
            Console.WriteLine("Here are your goals and points.");

            if (goals.Count == 0)
            {
                Console.WriteLine("No goals found.");
            }

            foreach (var goal in goals)
            {
                string goalType = goal.GetType().Name;
                string goalDescription = goal.Description;
                string goalPoints = goal.Points;
                string goalCompletionStatus = goal.ToString(); 

                Console.WriteLine($"{goalType}: {goalDescription} Points: {goalPoints} {goalCompletionStatus}");
            }

            Console.WriteLine($"Total Points: {totalPoints}"); 

            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }

        public void GoalSaver()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var goal in goals)
                    {
                        string goalType = goal.GetType().Name;
                        string goalDescription = goal.Description;
                        string goalPoints = goal.Points;
                        string goalCompletionStatus = goal.ToString(); 

                        string line = $"{goalType} {goalDescription} {goalPoints} {goalCompletionStatus}"; 
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while saving the goals: {e.Message}");
            }
        }

        public void GoalLoader()
        {
        
            goals.Clear();

        
            string[] lines = File.ReadAllLines(filePath);

        
            foreach (string line in lines)
            {
            
                string[] parts = line.Split(' ');

                if (parts.Length >= 4) 
                {
                    Goal goal;
                    string goalType = parts[0];
                    string goalDescription = string.Join(" ", parts.Skip(1).Take(parts.Length - 3));
                    string goalPoints = parts[parts.Length - 3];
                    string goalCompletionStatus = parts[parts.Length - 1]; 
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(goalDescription, goalPoints);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(goalDescription, goalPoints);
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal(goalDescription, goalPoints);
                            break;
                        default:
                            Console.WriteLine($"Invalid goal type found: {goalType}");
                            continue;
                    }

                
                    int checkmarks = goalCompletionStatus.Length;
                    goal.Checkmarks = checkmarks;

                
                    goals.Add(goal);
                }
            }
        }

        public void EventRecorder(ref bool exitProgram, ref int totalPoints) // Add totalPoints as a ref parameter
    {
        Console.WriteLine("Record Event:");

    
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.Description}");
        }

    
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int goalIndex))
        {
        
            if (goalIndex >= 1 && goalIndex <= goals.Count)
            {
            
                Goal selectedGoal = goals[goalIndex - 1];

            
                selectedGoal.Check();
                Console.WriteLine("Event recorded successfully.");

            
                totalPoints = CalculateTotalPoints();
            }
            else
            {
                Console.WriteLine("Invalid goal index. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }

    
        exitProgram = false;
    }

    public abstract class Goal
    {
        public string Description { get; set; }
        public string Points { get; set; }
        public int Checkmarks { get; set; }
        public int totalPoints { get; set; }

        public Goal(string description, string points)
        {
            Description = description;
            Points = points;
            Checkmarks = 0;
        }

        public abstract void Check();
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string description, string points) : base(description, points)
        {
        }

        public override void Check()
        {
            if (Checkmarks < 1) 
            {
                Checkmarks++; 
                int goalPoints = int.Parse(Points);
                totalPoints += goalPoints; 
            }
            else
            {
                Console.WriteLine("Goal already completed!");
            }
        }

        public override string ToString()
        {
            string completionStatus = new string('*', Checkmarks);
            return $"Completed: {completionStatus}";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string description, string points) : base(description, points)
        {
        }

        public override void Check()
        {
            Console.WriteLine("Eternal goals are always considered completed!");
        }

        public override string ToString()
        {
            return "Completed: ***";
        }
    }

    public class ChecklistGoal : Goal
    {
        public ChecklistGoal(string description, string points) : base(description, points)
        {
        }

        public override void Check()
        {
            if (Checkmarks < 1000) 
            {
                Checkmarks++; 
            }
            else
            {
                Console.WriteLine("Goal already completed!");
            }
        }

        public override string ToString()
        {
            string completionStatus = new string('*', Checkmarks);
            return $"Completed: {completionStatus}";
        }
    }
    private int CalculateTotalPoints()
    {
        int total = 0;
        foreach (var goal in goals)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                total += simpleGoal.Checkmarks * int.Parse(simpleGoal.Points);
            }
        }
        return total;
    }
    }    
}