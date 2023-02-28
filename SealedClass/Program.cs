using System;

interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Fullname()
    {
        return FirstName + " " + LastName;
    }

    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }
}

sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    public Executive()
    {
        Title = string.Empty;
        Salary = 0;
    }

    public Executive(int id, string firstName, string lastName, string title, double salary)
        : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }

    public override double Pay()
    {
        return Salary / 52;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee(1, "John", "Doe");
        Console.WriteLine($"Employee: {emp.Fullname()}");

        Executive exe = new Executive(2, "Jane", "Smith", "CEO", 1000000);
        Console.WriteLine($"Executive: {exe.Fullname()}, Title: {exe.Title}, Salary: {exe.Salary:C}");
        Console.WriteLine($"Weekly pay: {exe.Pay():C}");
    }
}
