using System;

abstract class Business
{
    public string Name { get; set; }
    public string SaleType { get; set; }

    public abstract void DisplayInfo();

    public abstract void PerformTask();
    public string Start { get; set; }
}

class Restaurant : Business
{
    public int Capacity { get; set; }
    public string Category { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Restaurant: {Name}");
        Console.WriteLine($"Capacity: {Capacity} seats");
        Console.WriteLine($"Sale Type: {SaleType}");
    }

    public override void PerformTask()
    {
        Console.WriteLine($"Client since {Start}");
    }
}

class RetailStore : Business
{
    public string Category { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Retail Store: {Name}");
        Console.WriteLine($"Sale Type: {SaleType}");
    }

    public override void PerformTask()
    {
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Sale Type: {SaleType}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Restaurant restaurant = new Restaurant()
        {
            Name = "TGI Fridays",
            Capacity = 50,
            Category = "Fast Food",
            SaleType = "Frozen Meat",
            Start = "2005"
        };

        RetailStore retailStore = new RetailStore()
        {
            Name = "Broulims",
            Category = "Grocery",
            SaleType = "All Types",
            Start = "2015"
        };

        Console.WriteLine("=== Business Information ===");
        restaurant.DisplayInfo();
        Console.WriteLine();
        retailStore.DisplayInfo();
        Console.WriteLine();

        Console.WriteLine("=== Special Info ===");
        restaurant.PerformTask();
        Console.WriteLine();
        retailStore.PerformTask();
    }
}