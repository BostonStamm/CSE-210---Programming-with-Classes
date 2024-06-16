using System;

class Program
{
    static void Main(string[] args)
    {
        bool loop = true;
        List<int> list = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while(loop){
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if(number == 0){
                loop = false;
            }else{
                list.Add(number);
            }
        }
        if(list.Count() > 0){
            Console.WriteLine($"The sum is {list.Sum()}");
            Console.WriteLine($"The average is {list.Average()}");
            Console.WriteLine($"The largest number is {list.Max()}");
        }else{
            Console.WriteLine("The list is empty.");
        }
    }
}