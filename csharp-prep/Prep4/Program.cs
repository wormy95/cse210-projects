using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();
        String UserName =  AskForName();
        int UserNumber = AskForNumber();
        int SquareResult = SquareNumber(UserNumber);

        DisplayFinalMessage(UserName, UserNumber, SquareResult);



    
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string AskForName()

    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        return name;
    }

    static int AskForNumber()

    {Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    static void DisplayFinalMessage(string name, int number, int square)

    {
        Console.WriteLine($"{name}, the square of your favourite number {number} is {square}");
    }
}