using System;
using System.Collections.Generic;

class ScriptureManager
{
    private Dictionary<string, string> scriptures;

    public ScriptureManager()
    {
        scriptures = new Dictionary<string, string>
        {
            { "1", "John 3:16: For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life." },
            { "2", "Proverbs 3:5-6: Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight." },
            { "3", "Psalm 23:1: The Lord is my shepherd, I lack nothing." }
        };
    }

    public bool ContainsScripture(string key)
    {
        return scriptures.ContainsKey(key);
    }

    public string GetScriptureText(string key)
    {
        return scriptures[key];
    }
}

class Program
{
    static void Main()
    {
        ScriptureManager scriptureManager = new ScriptureManager();

        Console.Clear();

        Console.WriteLine("Enter the number of the scripture to begin or type 'quit' to exit:");
        string userInput = Console.ReadLine().Trim();
        while (userInput.ToLower() != "quit")
        {
            if (scriptureManager.ContainsScripture(userInput))
            {
                string scriptureText = scriptureManager.GetScriptureText(userInput);
                List<string> words = new List<string>(scriptureText.Split(' '));
                List<bool> hidden = new List<bool>(new bool[words.Count]);

                Console.Clear();
                DisplayScripture(userInput, words, hidden);

                Console.WriteLine("Press Enter to hide words or type 'quit'x2 to exit:");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    HideWords(words, hidden);
                    Console.Clear();
                    DisplayScripture(userInput, words, hidden);

                    while (!AllWordsHidden(hidden))
                    {
                        Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "quit")
                            break;

                        HideWords(words, hidden);
                        Console.Clear();
                        DisplayScripture(userInput, words, hidden);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'quit' to exit.");
            }

            userInput = Console.ReadLine().Trim();
        }
    }

    static void HideWords(List<string> words, List<bool> hidden)
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count / 2); // Randomly hide 1 to half of the words

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            hidden[index] = true;
        }
    }

    static void DisplayScripture(string userInput, List<string> words, List<bool> hidden)
    {
        Console.WriteLine($"Scripture {userInput}:");
        for (int i = 0; i < words.Count; i++)
        {
            if (hidden[i])
            {
                Console.Write("***** ");
            }
            else
            {
                Console.Write($"{words[i]} ");
            }
        }
        Console.WriteLine();
    }

    static bool AllWordsHidden(List<bool> hidden)
    {
        foreach (bool isHidden in hidden)
        {
            if (!isHidden)
                return false;
        }

        return true;
    }
}