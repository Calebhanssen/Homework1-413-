using System;


namespace Homework1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            // Get user input for the number of dice rolls to simulate
            Console.Write("How many dice rolls would you like to simulate? ");
            int numberOfRolls = int.Parse(Console.ReadLine());

            // Simulate dice rolls and get the results array
            int[] results = DiceRoller.SimulateDiceRolls(numberOfRolls);

            // Print the histogram
            PrintHistogram(results, numberOfRolls);

            Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
        }

        private static void PrintHistogram(int[] results, int totalRolls)
        {
            Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {totalRolls}.");

            for (int i = 2; i <= 12; i++)
            {
                int percentage = results[i] * 100 / totalRolls;
                string asterisks = new string('*', percentage);
                Console.WriteLine($"{i}: {asterisks} ({percentage}%)");
            }
        }

    }
}
