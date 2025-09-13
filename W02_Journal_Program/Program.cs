using System;

// EXCEEDS REQUIREMENTS:
// - Added _mood field to Entry; captured during write; displayed & persisted.
// - Implemented Journal.Search(term) to search by date/prompt/response/mood.
// This demonstrates abstraction extensions (Entry knows its extra state;
// Journal encapsulates persistence and querying; Program orchestrates).

class Program
{
    static void Main()
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option (1-6): ");

            string choice = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = prompts.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine() ?? "";

                Console.Write("Mood (e.g., happy, tired, grateful): ");
                string mood = Console.ReadLine() ?? "";

                var entry = new Entry
                {
                    _date = DateTime.Now.ToString("yyyy-MM-dd"),
                    _prompt = prompt,
                    _response = response,
                    _mood = mood
                };

                journal.AddEntry(entry);
                Console.WriteLine("Entry added.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save (e.g., journal.txt): ");
                string name = Console.ReadLine() ?? "journal.txt";
                journal.SaveToFile(name);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load (e.g., journal.txt): ");
                string name = Console.ReadLine() ?? "journal.txt";
                journal.LoadFromFile(name);
            }
            else if (choice == "5")
            {
                Console.Write("Search term (date, keyword, or mood): ");
                string term = Console.ReadLine() ?? "";
                journal.Search(term);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.\n");
            }
        }
    }
}
