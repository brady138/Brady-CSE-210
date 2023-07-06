using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square s1 = new Square("Yellow", 5);
        shapes.Add(s1);
        Rectangle s2 = new Rectangle("Purple", 2, 6);
        shapes.Add(s2);
        Circle s3 = new Circle("Red", 2);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            string a = area.ToString("#.###");
            Console.WriteLine($"{color} area:  {a}");
        }
    }
}