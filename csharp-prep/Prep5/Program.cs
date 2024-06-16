using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        var userName = PromptUserName();
        var favNum = PromptUserNumber();
        var sqNum = SquareNumber(favNum);
        DisplayResult(userName, sqNum);
    }

    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num){
        return num * num;
    }
    static void DisplayResult(string userName, int sqNum){
        Console.WriteLine($"{userName}, the square of your number is {sqNum}");
    }

}