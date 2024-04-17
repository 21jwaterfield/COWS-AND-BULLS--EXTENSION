using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COWS_AND_BULLS__EXTENSION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boolean play = true;

            while (play == true)
            {
                Console.Write("HOW MANY DIGITS DO YOU WANT TO GUESS? (up to ten) ");
                int digits = Convert.ToInt32(Console.ReadLine());
                int attempts = 0;
                Boolean TorF = false;
                Random rnd = new Random();
                int[] num = new int[digits];
                while (TorF == false)
                {
                    for (int i = 0; i < num.Length; i++)
                    {
                        num[i] = rnd.Next(10);
                    }
                    TorF = true;
                    if (num.Length != num.Distinct().Count() | num[0] == 0)
                    {
                        TorF = false;
                    }
                }

                /* USE FOR TESTING 
                for (int t = 0; t < num.Length; t++) { 
                    Console.Write(num[t]); 
                } 
                Console.WriteLine();  */


                Boolean win = false;
                while (win == false)
                {
                    Boolean uTorF = false;
                    while (uTorF == false)
                    {
                        Console.Write("Guess a number (it has to be YOUR number of digits long and cannot contain repeated numbers): ");
                        int unumStr = Convert.ToInt32(Console.ReadLine());
                        int[] unum = Array.ConvertAll(unumStr.ToString().ToArray(), x => (int)x - 48);
                        uTorF = true;
                        attempts++;
                        if (unum.Length != unum.Distinct().Count() | unum.Length != digits )
                        {
                            uTorF = false;
                            Console.WriteLine("INVALID");
                            Console.WriteLine();
                            Console.WriteLine(""); Console.WriteLine("");
                            for (int y = 0; y < 100; y++)
                                Console.Write("-");
                        }


                        if (uTorF)
                        {
                            int bulls = 0;
                            int cows = 0;
                            for (int n = 0; n < digits; n++)
                            {
                                for (int u = 0; u < digits; u++)
                                {
                                    if (num[n] == unum[u])
                                    {
                                        if (u == n)
                                        {
                                            bulls++;
                                        }
                                        else
                                        {
                                            cows++;
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("COWS: " + cows);
                            Console.WriteLine("BULLS: " + bulls);


                            if (bulls == digits)
                            {
                                Console.WriteLine();
                                Console.Write("You won!!! The number is: ");
                                for (int w = 0; w < digits; w++)
                                {
                                    Console.Write(unum[w]);
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Number of attempts: " + attempts);
                                Console.WriteLine("");
                                win = true;
                                Console.Write("Type 'x' to play again! ");
                                char playagain = Convert.ToChar(Console.ReadLine());
                                if (playagain != 'x' && playagain != 'X')
                                {
                                    play = false;
                                }


                            }
                            Console.WriteLine(""); Console.WriteLine("");
                            for (int y = 0; y < 100; y++)
                                Console.Write("-");
                        }
                        Console.WriteLine(""); Console.WriteLine("");
                    }
                }
            }
        }
    }
}
