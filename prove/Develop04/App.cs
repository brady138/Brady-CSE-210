using System;

public class WellnessActivity
{
   static void Main()
   {
    Console.WriteLine("Welcome to the Wellness program!");
    Console.Clear();
    Console.WriteLine("Menu Options:");
    Console.WriteLine(" 1. Breathing Activity");
    Console.WriteLine(" 2. Reflecting Activity");
    Console.WriteLine(" 3. Listing Activity");
    Console.WriteLine(" 4. Quit");
    Console.WriteLine("Please choose an option:");
    string input = Console.ReadLine();
    while (input != "4")
    { 
        if (input == "1")
        {
            BreathingActivity();
            break;
        }
        if (input == "2")
        {
            ReflectionActivity();
            break;
        }
        if (input == "3")
        {
            ListingActivity();
        }
    }
    static void BreathingActivity()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Breathing Activity!");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        for (int i = 5; i > 0; i--)
        {
            List<string> animationStrings = new List<string>();
            animationStrings.Add("");
            animationStrings.Add(":");
            animationStrings.Add(":-");
            animationStrings.Add(":-)");
            foreach (string s in animationStrings)
            {
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b \b");
            }
         }
        Console.Clear();
        Console.WriteLine("Get ready to breath!");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine($"Breathe in ...");
            for (int x = 5; x > 0; x--)
            {
                Console.Write(x);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine("Breath out...");
            for (int y = 5; y > 0; y--)
            {
                Console.Write(y);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        Console.Clear();
        Console.WriteLine("Great Job!!! You completed the 30 second breathing activity!");
        for (int i = 5; i > 0; i--)
        {
            List<string> animationStrings = new List<string>();
            animationStrings.Add("");
            animationStrings.Add(":");
            animationStrings.Add(":-");
            animationStrings.Add(":-)");
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b \b");
            }
        }
    
    }
    static void ReflectionActivity()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Reflection Activity!");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        for (int i = 5; i > 0; i--)
        {
            List<string> animationStrings = new List<string>
            {
                "",
                ":",
                ":-",
                ":-)"
            };

            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b \b");
            }
        }

        Console.Clear();
        List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        RandomizePrompts(prompts);

        if (prompts.Count > 0)
        {
            string prompt = prompts[0];
            prompts.RemoveAt(0);

            Console.WriteLine(prompt);
        }
        List<string> questions = new List<string>
        {
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
        for (int q = 3; q > 0; q--)
        {
            for (int i = 5; i > 0; i--)
            {
                List<string> animationStrings = new List<string>();
                animationStrings.Add("");
                animationStrings.Add(":");
                animationStrings.Add(":-");
                animationStrings.Add(":-)");
                foreach (string s in animationStrings)
                {
                    Console.Write(s);
                    Thread.Sleep(250);
                    Console.Write("\b \b \b");
                }
            }
            RandomizeQuestions(questions);

            if (questions.Count > 0)
            {
                string question = questions[0];
                questions.RemoveAt(0);

                Console.WriteLine(question);
            }
            }

    static void RandomizePrompts(List<string> prompts)
    {
        Random random = new Random();
        int n = prompts.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            string value = prompts[k];
            prompts[k] = prompts[n];
            prompts[n] = value;
        }
    }
    static void RandomizeQuestions(List<string> questions)
    {
        Random random = new Random();
        int n = questions.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            string value = questions[k];
            questions[k] = questions[n];
            questions[n] = value;
        }
    }
    Console.WriteLine("Thank you for participating in the Reflection Activity!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
    }
    static void ListingActivity()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Listing Activity!");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();
        int promptIndex = random.Next(prompts.Count);
        string prompt = prompts[promptIndex];

        Console.WriteLine("\nPrompt: " + prompt);
        Console.WriteLine("You will have 30 seconds to list as many items as you can.");

        Console.WriteLine("\nPrepare to start listing. Get ready...");

        Countdown(10);

        Console.WriteLine("\nStart listing now!");

        List<string> items = new List<string>();

        // Get user input for the specified duration (30 seconds)
        int durationInSeconds = 30;
        DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine("\nTime's up!");

        Console.WriteLine("\nYou listed " + items.Count + " items.");

        Console.WriteLine("\nThank you for participating in the Listing Activity!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    }

}