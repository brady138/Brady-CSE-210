using System;

namespace student_info
{
    class Program
    {
        static void Main(string[] args)
        {
         Assignment one = new Assignment("Jack Sparrow", "Math");
         Console.WriteLine(one.GetSummary());
         
         MathAssignment two = new MathAssignment("Randy", "numbers","5", "1-10");
         Console.WriteLine(two.GetSummary());
         Console.WriteLine(two.GetHomeworkList());

         WritingAssignment three = new WritingAssignment("John Smith", "The stone age", "tools");
         Console.WriteLine(three.GetSummary());
         Console.WriteLine(three.GetWritingInformation());
        }
    }
}