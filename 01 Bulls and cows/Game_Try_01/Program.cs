using System;
using System.Linq;
using System.Transactions;



class Program
{
    public static void StartExit(ConsoleKeyInfo x)
    {
        do
        {
            x = (Console.ReadKey(true));
        } while ((x.Key.ToString() != "Escape") & (x.Key.ToString() != "Enter"));
    }
    static void Main()
    {



        Console.WriteLine("___!!!____Welcome_____to_____the_____Game____!!!___" + Environment.NewLine + Environment.NewLine);
        Console.WriteLine("Press Enter to Start");
        Console.WriteLine("Or Press ESC if u wanna quit" + Environment.NewLine);


        ConsoleKeyInfo p;
        
        StartExit(t);



        if (t.Key.ToString() == "Enter")
        {



            string v;
            do
            {
                Random r = new Random();
                v = (r.Next(1000, 9999)).ToString();
            } while (v[0] == v[1] || v[0] == v[2] || v[0] == v[3] || v[1] == v[2] || v[1] == v[3] || v[2] == v[3]);

            Console.WriteLine("Number of symbols: " + v.Length + Environment.NewLine);

            string x;
            p = Console.ReadKey();
            do
            {


                do
                {
                    do
                    {

                        Console.Write("Write a number: ");
                        x = Console.ReadLine();
                        if (x.Length != v.Length)
                        {
                            Console.WriteLine("That's incorrect input" + Environment.NewLine +
                                "You must add " + v.Length + " numbers" + Environment.NewLine +
                                "Try again" + Environment.NewLine);
                        }

                    } while (v.Length != x.Length);

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
                    Console.WriteLine("Amount of axe: " + b + Environment.NewLine);
                    ///Console.WriteLine("___Press Enter to continue___"+Environment.NewLine);
                    ///Console.WriteLine("___Press ESC to quit___" + Environment.NewLine);
                    ///Console.ReadKey();
                } while (x != v);
                Console.WriteLine("Congratulations!!!");
            } while (p.Key.ToString() == "Enter");


        }
        if (t.Key.ToString() == "Escape")
        {
            Console.WriteLine(" You've just quit the Game" + Environment.NewLine +
                "See you soon");
        }
        else
        {
            Console.WriteLine(" yo fuck");
        }
    }
    

}


