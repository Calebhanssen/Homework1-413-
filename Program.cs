using System;

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

    private class DiceRoller
    {
        public static int[] SimulateDiceRolls(int numberOfRolls)
        {
            int[] results = new int[13]; // Index 0 is not used, results[2] to results[12] will be used

            Random random = new Random();

            for (int i = 0; i < numberOfRolls; i++)
            {
                int dice1 = random.Next(1, 7);
                int dice2 = random.Next(1, 7);

                int sum = dice1 + dice2;
                results[sum]++;
            }

            // Additional probabilities for specific combinations
            results[2] += results[12]; // 1+1 and 6+6
            results[3] += results[11] + results[9]; // 2+1, 1+2 and 3+3, 4+5, 5+4
            results[7] += results[6] + results[5] + results[4] + results[3] + results[2] + results[1]; // 1+6, 2+5, 3+4, 4+3, 5+2, 6+1

            return results;
        }
    }
}
