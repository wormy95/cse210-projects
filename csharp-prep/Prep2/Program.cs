using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your test score? ");
        String scoreFromUser = Console.ReadLine();

        int score = int.Parse(scoreFromUser);

        int a = 90 ;
        int b = 80 ;
        int c = 70 ;
        int d = 60 ;
        int f = 60 ;

        if (score >= a && score < 101)
        {
            Console.WriteLine("Congratulations, you passed with a Grade A!") ;
        }

        else if (score >= b && score < a)
        {
            Console.WriteLine("Congratulations, you passed with a Grade B!");
        }

        else if (score > c && score <b)
        {
            Console.WriteLine("Congratulations, you passed with a Grade C!") ;
        }

        else if (score > d && score <c)
        {
            Console.WriteLine("You did not pass, with a grade of D. Try again next time!");
        }

        else if (score < f)
        {
            Console.WriteLine("You did not pass, with a grade of F. Try again next time!");
        }

        else
        {
            Console.WriteLine("Please input a proper score");
        }
    }
}