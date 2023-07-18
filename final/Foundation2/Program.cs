using System;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual decimal CalculateWeeklyPay()
    {
        return 0; 
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Employee Information:");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }

    public override decimal CalculateWeeklyPay()
    {
        return HourlyRate * HoursWorked;
    }

    public void DisplayPay()
    {
        Console.WriteLine("Weekly Pay: $" + CalculateWeeklyPay());
    }
}

class SalaryEmployee : Employee
{
    private decimal weeklySalary;

    public decimal WeeklySalary
    {
        get { return weeklySalary; }
        set { weeklySalary = value; }
    }

    public override decimal CalculateWeeklyPay()
    {
        return WeeklySalary;
    }

    public void DisplayPay()
    {
        Console.WriteLine("Weekly Pay: $" + CalculateWeeklyPay());
    }
}

class Intern : Employee
{
    public decimal WeeklyPay { get; set; }

    public override decimal CalculateWeeklyPay()
    {
        return WeeklyPay;
    }

    public void DisplayPay()
    {
        Console.WriteLine("Weekly Pay: $" + CalculateWeeklyPay());
    }
}

class Program
{
    static void Main(string[] args)
    {
        HourlyEmployee hourlyEmployee = new HourlyEmployee()
        {
            Name = "Will Smith",
            Age = 25,
            HourlyRate = 15,
            HoursWorked = 40
        };

        SalaryEmployee salaryEmployee = new SalaryEmployee()
        {
            Name = "Moroni",
            Age = 30,
            WeeklySalary = 1000
        };

        Intern intern = new Intern()
        {
            Name = "Darth Vader",
            Age = 21,
            WeeklyPay = 600
        };

        Console.WriteLine("=== Hourly Employee ===");
        hourlyEmployee.DisplayInfo();
        hourlyEmployee.DisplayPay();
        Console.WriteLine();

        Console.WriteLine("=== Salary Employee ===");
        salaryEmployee.DisplayInfo();
        salaryEmployee.DisplayPay();
        Console.WriteLine();

        Console.WriteLine("=== Intern ===");
        intern.DisplayInfo();
        intern.DisplayPay();
        Console.WriteLine();
    }
}