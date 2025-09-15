using System;

class Program
{
    static void Main()
    {
        string playAgain;
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.Write("What is your guess? ");

            while (guess != magicNumber)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.Write("Please enter a valid number: ");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    Console.Write("What is your guess? ");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    Console.Write("What is your guess? ");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = (Console.ReadLine() ?? "").Trim().ToLower();

        } while (playAgain == "yes");
    }
}