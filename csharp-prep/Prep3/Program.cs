using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int Number = randomGenerator.Next(1, 10);
        bool Guess = false;
        int guessCount = 0;

        while (!Guess)
        {
            Console.Write("Enter your guesses (between 1 and 10): ");
            string input = Console.ReadLine();
            guessCount ++;
            if (guessCount == 3)
            {
                Console.WriteLine($"Sorry, you are out of guesses, the number was {Number}.");
                Console.WriteLine("Thank you for playing the game. Press any key to exit.");
                Console.ReadKey();
            }

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (guess < 1 && guess > 10)
            {
                Console.WriteLine("Please enter a number between 1 and 10.");
                continue;
            }

            if (guess == Number)
            {
                Console.WriteLine("Congratulations! You guessed the correct number.");
                Guess = true;
            }
            else if (guess < Number)
            {
                Console.WriteLine("Too low. Try again.");
            }
            else
            {
                Console.WriteLine("Too high. Try again.");
            }
            int printed = (3 - guessCount);
            Console.WriteLine($"You have {printed} guesses left.");
        }

        Console.WriteLine("Thank you for playing the game. Press any key to exit.");
        Console.ReadKey();
    }
}