using System;

using System.Collections.Generic;

Console.WriteLine("Enter a list of numbers, type 0 when finished.");
List<int> numbers = new List<int>();
int number = 1;
while (number != 0)
{
    Console.Write("Enter a number: ");
    number = int.Parse(Console.ReadLine());
    numbers.Add(number);

    if (number == 0)
    {
        numbers.Remove(0);
    }

}
Console.WriteLine("The sum of the numbers is: " + numbers.Sum());
Console.WriteLine("The average of the numbers is: " + numbers.Average());
Console.WriteLine("The largest number is: " + numbers.Max());