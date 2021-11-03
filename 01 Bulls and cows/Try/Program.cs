using System;
using System.Linq;
using System.Transactions;



class Program
{
    static void Main()
    {
        ConsoleKeyInfo d;
        do     
        //цикл на беспрерывное продолжение игры
        {


            Console.WriteLine("___!!!____Welcome_____to_____the_____Game____!!!___" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Press Enter to Start");
            Console.WriteLine("Or Press ESC if u wanna quit" + Environment.NewLine);





            ConsoleKeyInfo t;

            do
            //цикл для считывания клавиш Enter и ESC 
            //он нужен для того чтобы программа не реагировала на нажатия остальных клавиш
            {
                t = (Console.ReadKey(true));
            } while ((t.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));



            if (t.Key.ToString() == "Enter")
            {



                string v;
                do
                //цикл направленный на генерацию рандомного числа из 4-х элементов без повторяющихся цифр
                {
                    Random r = new Random();
                    v = (r.Next(1000, 9999)).ToString();
                } while (v[0] == v[1] || v[0] == v[2] || v[0] == v[3] || v[1] == v[2] || v[1] == v[3] || v[2] == v[3]);

                //данный ввод был предназначен для удобства тестирования проги
                //Console.WriteLine(v);

                Console.WriteLine("Number of symbols: " + v.Length + Environment.NewLine);

                string x;



                do
                //цикл на бесконечное количество попыток
                //иными словами цикл направлен на задание твоего числа до тех пор пока исходное число не будет угадано
                {
                    int g;

                    do
                    //цикл направленный на задание именно нужного типа данных
                    //иными словами программа будет просить вас вбить элемент до тех пор пока он не будет соответствовать нужному типу
                    {
                        Console.WriteLine("(___if u wanna quit input 'exit'___)" + Environment.NewLine);
                        Console.Write("Write a number: ");
                        x = Console.ReadLine();
                        if (x == "exit")
                        //ксли вместо твоего числа написать exit то программа зевершиться
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



                    } while ((!int.TryParse(x, out g) || (x.Length != v.Length)) & (x != "exit"));

                    int b = 0;
                    int k = 0;
                    //далее идет проверка на тождество каждой цифры
                    //и на основе этого формируется кол во коров и быков соответственно
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

            //далее игроку предоставляется возможность выхода из игры после угадывания числа
            if (t.Key.ToString() == "Escape")
            {
                Console.WriteLine(" You've just quit the Game" + Environment.NewLine +
                    "See you soon");
                return;
            }
            Console.WriteLine("If u wanna end this game press ESC"+Environment.NewLine+"if you wanna play again press any another bottom");
            

            do
            //цикл на ввод с клавиатуры нужной клавиши для завершения или продрлжения программы
            {
                d = (Console.ReadKey(true));
            } while ((d.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));
            
            if (d.Key.ToString() == "Escape")
            {
                Console.WriteLine(Environment.NewLine+"Bye");
                return;
            }
           
            
            else
            {
                Console.Clear();
                //чистка консоли и продолжение игры
            }
        } while (d.Key.ToString() != "Escape");
    }
    
}

