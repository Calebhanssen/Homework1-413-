using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class DiceRoller
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

            return results;
        }
    }
}
