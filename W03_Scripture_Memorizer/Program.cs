using System;

class Program
{
    static void Main()
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        var scripture = new Scripture(reference, text);

        Console.Clear();
        Console.WriteLine("Scripture Memorizer (press Enter to hide words, type 'quit' to exit)\n");

        while (true)
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nPress Enter to hide more, or type 'quit': ");
            string? input = Console.ReadLine();
            Console.Clear();

            if (input != null && input.Trim().ToLower() == "quit") break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Great job!");
                break;
            }
        }
    }
}
