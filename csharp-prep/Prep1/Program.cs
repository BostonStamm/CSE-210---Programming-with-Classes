using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        var fName = Console.ReadLine();
        Console.WriteLine("What is your last name? ");
        var lName = Console.ReadLine();
        Console.WriteLine($"Your name is {lName}, {fName} {lName}.");
    }
}