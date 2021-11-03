using System;
using System.Collections.Generic;
using System.Text;


partial class Sled
{
    public static void SledFinding(double[][]matrix, int numberOfStrings)
    {
        double sled = 0.0;
        
        for (int i = 0; i < numberOfStrings; i++)
        {
            sled += matrix[i][i];
        }
        Console.WriteLine(sled);
    }
}

