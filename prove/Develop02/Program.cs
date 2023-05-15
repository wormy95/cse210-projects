using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

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
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveEntries();
                    break;
                case "4":
                    journal.LoadEntries();
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
}

class Journal
{
    private List<Entry> journalEntries = new List<Entry>();
    private List<string> prompts = new List<string>()
    {
         
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
        // Add more prompts here...
    };

    public void WriteEntry()
    {
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine(randomPrompt);
        string content = Console.ReadLine();
        DateTime currentTime = DateTime.Now;

        Entry entry = new Entry(currentTime, content);
        journalEntries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            foreach (Entry entry in journalEntries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveEntries()
    {
        Console.WriteLine("Please enter a file name:");
        string fileName = Console.ReadLine();
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            foreach (Entry entry in journalEntries)
            {
                writer.WriteLine(entry.ToString());
            }
        }

        Console.WriteLine($"Entries saved to {fileName}.");
    }

    public void LoadEntries()
    {
        Console.WriteLine("Please enter a file name:");
        string fileName = Console.ReadLine();
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File not found: {fileName}");
            return;
        }

        List<Entry> entriesFromFile = new List<Entry>();
        using (StreamReader reader = new StreamReader(fullPath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Entry entry = Entry.Parse(line);
                if (entry != null)
                {
                    entriesFromFile.Add(entry);
                }
            }
        }

        journalEntries = entriesFromFile;
        Console.WriteLine($"Entries loaded from {fileName}.");
    }
}

class Entry
{
    public DateTime Time { get; set; }
    public string Content { get; set; }

    public Entry(DateTime time, string content)
    {
        Time = time;
        Content = content;
    }

    public override string ToString()
    {
        return $"{Time.ToString()} - {Content}";
    }

    public static Entry Parse(string entryString)
    {
        string[] parts = entryString.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
        {
            return null;
        }

        if (DateTime.TryParse(parts[0], out DateTime time))
        {
            return new Entry(time, parts[1]);
        }

        return null;
    }
}