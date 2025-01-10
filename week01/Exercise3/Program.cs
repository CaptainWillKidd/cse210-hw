using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = -1;

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        while (guess != number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if (guess > number)
            {
                Console.WriteLine("Less!");
            }
            else if (guess < number)
            {
                Console.WriteLine("More!");
            }
            else
            {
                Console.WriteLine("Correct! Good Job!");
            }
        }
    }
}