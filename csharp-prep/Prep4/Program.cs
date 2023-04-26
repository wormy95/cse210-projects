using System;

class Program
{
    static void Main(string[] args)
    {
         List<int> numbers = new List<int>();

         int userNumber = -1;

         do
         {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
         } while (userNumber != 0);

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum of the list is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)

        {
            if(number > max) 
            {
                max = number;
            }
        }

        Console.WriteLine($"The maximum number is {max}");





    }
   
}