using System;
using System.Linq;
using System.Transactions;



class Program
{
    static void Main()
    {
        ConsoleKeyInfo d;
        do
        {


            Console.WriteLine("___!!!____Welcome_____to_____the_____Game____!!!___" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Press Enter to Start");
            Console.WriteLine("Or Press ESC if u wanna quit" + Environment.NewLine);
            
            



            ConsoleKeyInfo t;

            do
            {
                t = (Console.ReadKey(true));
            } while ((t.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));



            if (t.Key.ToString() == "Enter")
            {



                string v;
                do
                {
                    Random r = new Random();
                    v = (r.Next(1000,9999)).ToString();
                } while (v[0] == v[1] || v[0] == v[2] || v[0] == v[3] || v[1] == v[2] || v[1] == v[3] || v[2] == v[3]);
                Console.WriteLine(v);
                Console.WriteLine("Number of symbols: " + v.Length + Environment.NewLine);

                string x;



                do
                {
                    int g;

                    do
                    {
                        Console.WriteLine("(___if u wanna quit input 'exit'___)"+Environment.NewLine);
                        Console.Write("Write a number: ");
                        x = Console.ReadLine();
                        if (x == "exit")
                        {
                            Console.WriteLine("Bye");
                            return;
                        }

                        else
                        {


                            if (!int.TryParse(x, out g) || (x.Length != v.Length))

                            {
                                Console.WriteLine("That's incorrect input" + Environment.NewLine +
                                    "Try again" + Environment.NewLine);
                            }
                        }
                        


                    } while ((!int.TryParse(x, out g) || (x.Length != v.Length))&(x!="exit"));

                    int b = 0;
                    int k = 0;
                    for (int i = 0; i < v.Length; i++)
                    {
                        for (int j = 0; j < v.Length; j++)
                        {
                            if ((v[i] == x[j]) && (i == j))
                            {
                                b += 1;
                            }
                            if (v[i] == x[j])
                            {
                                k += 1;
                            }
                        }
                    }
                    Console.WriteLine("Amount of cows: " + k);
                    Console.WriteLine("Amount of axes: " + b + Environment.NewLine);
                    
                } while (x != v);
                Console.WriteLine("Congratulations!!!");



            }
           
           
            if (t.Key.ToString() == "Escape")
            {
                Console.WriteLine(" You've just quit the Game" + Environment.NewLine +
                    "See you soon");
                return;
            }
            Console.WriteLine("If u wanna play again press Enter");

            do
            {
                d = (Console.ReadKey(true));
            } while ((d.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));
            Console.Clear();
        } while (d.Key.ToString() !="Escape");
    }

}


