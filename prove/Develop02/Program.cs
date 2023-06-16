using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    public static List<JournalEntry> journal = new List<JournalEntry>();
    public static Random random = new Random();
    public static Dictionary<int, string> prompts = new Dictionary<int, string>()
    {
        { 1, "Who was the most interesting person I interacted with today?" },
        { 2, "What was the best part of my day?" },
        { 3, "How did I see the hand of the Lord in my life today?" },
        { 4, "What was the strongest emotion I felt today?" },
        { 5, "If I had one thing I could do over today, what would it be?" }
    };

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("> ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void WriteNewEntry()
    {
        int promptKey = random.Next(1, prompts.Count + 1);
        string prompt = prompts[promptKey];
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        JournalEntry entry = new JournalEntry()
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };
        journal.Add(entry);
        Console.WriteLine("Entry added successfully.");
    }

    static void DisplayJournal()
    {
        foreach (JournalEntry entry in journal)
        {
            Console.WriteLine("Date: " + entry.Date);
            Console.WriteLine("Prompt: " + entry.Prompt);
            Console.WriteLine("Response: " + entry.Response);
            Console.WriteLine();
        }
    }

    static void SaveJournalToFile()
    {
        Console.Write("Enter the filename: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (JournalEntry entry in journal)
                {
                    writer.WriteLine(entry.Date);
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Response);
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Journal saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving journal to file: " + ex.Message);
        }
    }

    static void LoadJournalFromFile()
    {
        Console.Write("Enter the filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            List<JournalEntry> newJournal = new List<JournalEntry>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string dateStr = reader.ReadLine();
                    string prompt = reader.ReadLine();
                    string response = reader.ReadLine();
                    reader.ReadLine(); 

                    DateTime date;
                    if (DateTime.TryParse(dateStr, out date))
                    {
                        JournalEntry entry = new JournalEntry()
                        {
                            Prompt = prompt,
                            Response = response,
                            Date = date
                        };
                        newJournal.Add(entry);
                    }
                }
            }

            journal = newJournal;
            Console.WriteLine("Journal loaded from file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading journal from file: " + ex.Message);
        }
    }
}