using Mindfulness;

Console.Clear();
while (true)
{
    Console.WriteLine("Mindfulness Program");
    Console.WriteLine("1. Breathing Activity");
    Console.WriteLine("2. Reflecting Activity");
    Console.WriteLine("3. Listing Activity");
    Console.WriteLine("4. Quit");
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
            return;
        default:
            Console.WriteLine("Invalid choice.\n");
            break;
    }

    Console.WriteLine("\nPress ENTER to return to the menu...");
    Console.ReadLine();
    Console.Clear();
}
