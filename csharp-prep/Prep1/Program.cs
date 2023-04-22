using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        String firstname = Console.ReadLine();

        Console.Write("What is y our second name? ");
        String secondname = Console.ReadLine();
        
        Console.WriteLine(" ");
        
        Console.WriteLine($"Your name is {secondname}, {firstname} {secondname}");
        



    }
}