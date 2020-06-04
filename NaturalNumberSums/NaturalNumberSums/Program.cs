using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalNumberSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int convertedInput;
            int mainSumCount = 0;
            Console.WriteLine("Please input a natural number");
            string input = Console.ReadLine();
            try
            {
                convertedInput = Convert.ToInt32(input);
                if (Convert.ToInt32(input) > 0)
                {
                    Console.WriteLine("this is a natural number");
                    int output = RecursiveSum(1, 2, convertedInput, 0, 1);
                    Console.WriteLine($"number of sums: {output}");
                    Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not a natural number");
            }

        }

        public static int RecursiveSum(int start, int next, int goal, int numSums, int sum)
        {
            Console.WriteLine("sum + next = " + sum + " + " + next);
            // BASE CASE
            // exit completely once start is too large - there are no more potential sums
            if (start > (goal / 2))
            {
                return numSums;
            }
            // SUCCESS
            // valid sum. increment numSums and start at the next index
            else if (sum == goal)
            {
                numSums++;
                start++;
                Console.WriteLine("Successful Sum! Incre at sum = " + sum);
                Console.WriteLine("=======Start = " + start + "=======");
                return RecursiveSum(start, start + 1, goal, numSums, start);
            }
            // FAILURE
            // all sums after this point will be too large, start over with next starting index
            else if (next > (goal / 2))
            {
                start++;
                Console.WriteLine("Failure!!! at sum = " + sum);
                Console.WriteLine("=======Start = " + start + "=======");
                return RecursiveSum(start, start + 1, goal, numSums, start);
            }
            // IN PROGRESS
            // sum is less than goal, next is less than goal/2, potentially still a valid sum
            // add next to sum, call again 
            else
            {
                return RecursiveSum(start, next + 1, goal, numSums, sum + next);
            }
        }
    }
}
