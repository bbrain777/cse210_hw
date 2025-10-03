using Mindfulness;

/*
EXCEEDING REQUIREMENTS (100%):
- Added a fourth activity: VisualizationActivity (guided imagery).
- Ensured unique, non-repeating prompts/questions until each deck is exhausted (PromptDeck).
- Session logging to logs.csv (activity name, duration, timestamp) in base Activity.
- Breathing animation improved with progress bar visualization.
*/

Console.Clear();
while (true)
{
    Console.WriteLine("Mindfulness Program");
    Console.WriteLine("1. Breathing Activity");
    Console.WriteLine("2. Reflecting Activity");
    Console.WriteLine("3. Listing Activity");
    Console.WriteLine("4. Visualization Activity (NEW)");
    Console.WriteLine("5. Quit");
    Console.Write("Select a choice from the menu: ");

    var choice = Console.ReadLine();
    Console.Clear();

    switch (choice)
    {
        case "1":
            new BreathingActivity().Run();
            break;
        case "2":
            new ReflectingActivity().Run();
            break;
        case "3":
            new ListingActivity().Run();
            break;
        case "4":
            new VisualizationActivity().Run();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice.\n");
            break;
    }

    Console.WriteLine("\nPress ENTER to return to the menu...");
    Console.ReadLine();
    Console.Clear();
}
