using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter numbers (Type '0' when finished):");

        while (true)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
                break;

            numbers.Add(input);
        }

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            int max = numbers.Max();
            double average = numbers.Average();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Highest number: {max}");
            Console.WriteLine($"Average: {average}");
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    }
}