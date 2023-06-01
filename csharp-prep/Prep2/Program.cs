using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade(%)");
        string gradevalue = Console.ReadLine();
        

        int grade = int.Parse(gradevalue);
        
        
        if (grade > 69)
        {
            Console.WriteLine("You passed!");
        }
        else 
        {
            Console.WriteLine("You failed the class");
        }

        if (grade > 89)
        {
            if (grade > 96)
            {
                Console.WriteLine("You got an A+ congrats!");
            }   
            if (grade < 94)
            {
                Console.WriteLine("You got an A-");
            }
            else 
            {
                Console.Write("You got an A");
            }
            }
        else if ((grade > 79) && (grade < 90))
        {
            if (grade > 86)
            {   
                Console.WriteLine("You got a B+");
            }
            else if (grade < 84)
            {
                Console.WriteLine("You got a B-");
            }
            else
            {
                Console.WriteLine("You got a B");
            }
        }
        else if ((grade > 69) && (grade < 80))
        {
            if (grade > 76)
            {  
            Console.WriteLine("You got a C+");
            }
            else if (grade < 74)
            {
                Console.WriteLine("You got a C-");
            }
            else
            {
                Console.WriteLine("You got a C");
            }
        }

        else if ((grade > 59) && (grade < 70))
        {
            if (grade > 66)
            {  
            Console.WriteLine("You got a D+");
            }
            else if (grade < 64)
            {
                Console.WriteLine("You got a D-");
            }
            else
            {
                Console.WriteLine("You got a D");
            }
            }
        else if (grade < 60)
        {
            Console.WriteLine("You failed, apply yourself!");
            }
    }
}