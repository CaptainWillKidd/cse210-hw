using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Please, enter your grade in numbers: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("You passed the course! Congratulation! Continue the good job!");
        }
        else
        {
            Console.WriteLine("You failed the course! Don't give up! Try again! We will help you!");
        }
    }
}