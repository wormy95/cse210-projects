using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        // String number = Console.ReadLine();
        // int magicNumber = int.Parse(number);

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);


    
    int guess = -1;

    // while (guess!= magicNumber)
    do
    {
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());

        if (guess > magicNumber)

        {
            Console.WriteLine("Lower");
        }

        else if (guess < magicNumber)

        {
            Console.WriteLine("Higher");
        }

        else if (guess == magicNumber)

        {
            Console.WriteLine("Congratulations, you guessed it!");
        }

    } while (guess != magicNumber);

    



    }
}