using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanditLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string");
            string input = Console.ReadLine();

            string solution = BanditConverter(input);

            Console.WriteLine(solution);
        }

        static string BanditConverter(string input)
        {
            string vowels = "aeiouAEIOU";
            string newString = "";

            for (int i = 0; i < input.Length; i++)
            {
                // if the char is a vowel just add to new string
                if (vowels.IndexOf(input[i]) != -1)
                {
                    newString = newString + (input[i]);
                }
                // if its a consonant, same thing but with an o and consonant
                else
                {
                    newString = newString + (input[i] + "o" + input[i]);
                }
            }
            return newString;
        }
    }
}
