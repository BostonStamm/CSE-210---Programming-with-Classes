using System;

class Program
{
    static void Main(string[] args)
    {
        bool loop = true;
        Random rand = new Random();
        int guesses = 0;
        var randomNumber = rand.Next(1, 20);
        while(loop){
            Console.WriteLine("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());
            if(guess == randomNumber){
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guesses} guesses to get it right.");
                loop = false;
            }else if(guess > randomNumber){
                Console.WriteLine("Lower");
                guesses += 1;
            }else if(guess < randomNumber){
                Console.WriteLine("Higher");
                guesses += 1;
            }else{
                Console.WriteLine("Error");
            }
        }
    }
}