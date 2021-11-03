using System;
using System.Dynamic;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] Drives = Environment.GetLogicalDrives();

        foreach (string s in Drives)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine(Directory.GetCurrentDirectory());
        Directory.SetCurrentDirectory(@"C:\");
        Console.WriteLine(Directory.GetCurrentDirectory());
        if (Directory.GetCurrentDirectory() == @"C:" + @"\")
        {
            Console.WriteLine("lol");
        }


    }
}

