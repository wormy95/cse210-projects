using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> journalEntries = new List<string>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to My Journal!");

        while (true)
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("Which option would you like to choose? ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    SaveEntries();
                    break;
                case "4":
                    LoadEntries();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        List<string> prompts = new List<string>()
        {
            "What is your favorite color?",
            "What is your favorite food?",
            "What is your favorite book?",
            "What is your favorite movie?",
            "What is your favorite hobby?",
            "Write about a time when you felt proud of yourself.",
            "What is something that you have been avoiding, and why?",
            "Describe a person who has influenced your life and how.",
            "What is something that you would like to improve about yourself, and why?",
            "Write about a place that holds special meaning for you.",
            "What is something that you're looking forward to, and why?",
            "Describe a moment when you had to make a difficult decision and what you learned from it.",
            "Write about a time when you felt grateful for something or someone.",
            "What is a goal that you have set for yourself, and how do you plan to achieve it?",
            "Describe a challenge that you have overcome and what you learned from it."
        };

        // Select a random prompt
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine(randomPrompt);
        string entry = Console.ReadLine();
        DateTime currentTime = DateTime.Now;
        journalEntries.Add($"{currentTime.ToString()} - {entry}");
    }

    static void DisplayEntries()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            foreach (string entry in journalEntries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    static void SaveEntries()
    {
        Console.WriteLine("Please enter a file name:");
        string fileName = Console.ReadLine();
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            foreach (string entry in journalEntries)
            {
                writer.WriteLine(entry);
            }
        }

        Console.WriteLine($"Entries saved to {fileName}.");
    }

    static void LoadEntries()
    {
        Console.WriteLine("Please enter a file name:");
        string fileName = Console.ReadLine();
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File not found: {fileName}");
            return;
        }

        List<string> entriesFromFile = new List<string>();
        using (StreamReader reader = new StreamReader(fullPath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                entriesFromFile.Add(line);
            }
        }

        journalEntries = entriesFromFile;
        Console.WriteLine($"Entries loaded from {fileName}.");
    }
}