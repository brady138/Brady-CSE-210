using System;
using System.Collections.Generic;

class NumberSorter
{
    protected List<int> numbers;

    public NumberSorter(List<int> numbers)
    {
        this.numbers = numbers;
    }

    public virtual void SortNumbers()
    {
        Console.WriteLine("Numbers:");

        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

class OddNumberSorter : NumberSorter
{
    public OddNumberSorter(List<int> numbers) : base(numbers)
    {
    }

    public override void SortNumbers()
    {
        Console.WriteLine("Odd Numbers:");

        foreach (int number in numbers)
        {
            if (number % 2 != 0)
                Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

class EvenNumberSorter : NumberSorter
{
    public EvenNumberSorter(List<int> numbers) : base(numbers)
    {
    }

    public override void SortNumbers()
    {
        Console.WriteLine("Even Numbers:");

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
                Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

class PrimeNumberSorter : NumberSorter
{
    public PrimeNumberSorter(List<int> numbers) : base(numbers)
    {
    }

    public override void SortNumbers()
    {
        Console.WriteLine("Prime Numbers:");

        foreach (int number in numbers)
        {
            if (IsPrime(number))
                Console.Write(number + " ");
        }

        Console.WriteLine();
    }

    private bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        NumberSorter numberSorter = new NumberSorter(numbers);
        numberSorter.SortNumbers();

        OddNumberSorter oddNumberSorter = new OddNumberSorter(numbers);
        oddNumberSorter.SortNumbers();

        EvenNumberSorter evenNumberSorter = new EvenNumberSorter(numbers);
        evenNumberSorter.SortNumbers();

        PrimeNumberSorter primeNumberSorter = new PrimeNumberSorter(numbers);
        primeNumberSorter.SortNumbers();
    }
}