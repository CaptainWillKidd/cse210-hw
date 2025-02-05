using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());

        Console.WriteLine("\n");

        MathAssignment math1 = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());

        WritingAssignment writing1 = new WritingAssignment("The Causes of World War II by Mary Waters", "Mary Waters", "European History");
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInformation());
    }
}