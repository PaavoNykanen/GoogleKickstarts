using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickstart1
{
    class Program
    {
        
        /// <summary>
        /// Checks if given string has a palindrome in it
        /// </summary>
        /// <param name="input">string in which the palindrome is</param>
        /// <param name="start"> starting point for palindrome</param>
        /// <param name="end">ending point for palindrome</param>
        /// <returns></returns>
        public static bool makePalindrome(String input, int start, int end)
        {
            char[] cA = new char[end-start+1]; //ABAACCA

            if (cA.Length == 0 || cA.Length == 1) return true;
            int i;
            int j = start;
            for (i = 0; i<cA.Length; i++)
            {
                cA[i] = input[j-1];
                j++;
            }
            int move = cA.Length-1; // 3
            //palindromi
            //AACC
            char help;
            i = 0;
            for (j = cA.Length-1; j > 0; j--) //ACCA move:1 i= 0
            {

                if (cA[i] != cA[j])
                {

                    if (i >= j) return true;
                    move--;

                    if (i == move)
                    {
                        help = cA[i];
                        cA[i] = cA[i++];
                        cA[i++] = help;
                        move = cA.Length - 1;
                    }
                    help = cA[j];
                    cA[j] = cA[move];
                    cA[j] = help;
                }
                i++;
                move = cA.Length - 1;
            }
            return false;
        }

        /// <summary>
        /// This application checks if given strings have palindromes in them
        /// User gives the string and starting and ending points for the palindrome
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int tests;
            tests = Convert.ToInt32(Console.ReadLine());
            int[] yesAnswers = new int[tests];

            String[] blockAndQuest;
            int blocks;
            int quests;
            bool palin = false;


            for (int i = 0; i < tests; i++)
            {
                String text = Console.ReadLine();
                blockAndQuest = text.Split(' ');
                blocks = Convert.ToInt32(blockAndQuest[0]);
                quests = Convert.ToInt32(blockAndQuest[1]);

                text = Console.ReadLine(); /// teksti


                for (int j = 0; j < quests; j++)
                {
                    String input = Console.ReadLine();
                    String[] startAndEnd = input.Split(' ');
                    int start = Convert.ToInt32(startAndEnd[0]);
                    int end = Convert.ToInt32(startAndEnd[1]);

                    palin = makePalindrome(text, start, end);
                    if (palin == true)
                    {
                        yesAnswers[i]++;
                    }

                }

            }
            for (int i = 0; i < tests; i++)
            {
                Console.WriteLine("Case #" + (i + 1) + ": " + yesAnswers[i]);
            }
            while (true)
            {

                if (Console.ReadKey().Key == ConsoleKey.Enter) break;
            }
        }
    }
}
