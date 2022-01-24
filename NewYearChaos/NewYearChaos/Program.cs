using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace NewYearChaos
{
  class Program
  {
    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q)
    {
      int res = 0;
      for (int i = q.Length - 1; i >= 0; i--)
      {
        if (q[i] - (i + 1) > 2)
        {
          Console.WriteLine("Too chaotic");
          return;
        }
        for (int j = Math.Max(0, q[i] - 2); j < i; j++)
        {
          if (q[j] > q[i])
            res++;
        }

      }
      Console.WriteLine(res);

      // Keep the console window open in debug mode.
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }

    static void Main(string[] args)
    {

      System.IO.StreamReader file = new System.IO.StreamReader(@"C:\TEMP\NewYearChaos.txt");
      int t = Convert.ToInt32(file.ReadLine());

      for (int tItr = 0; tItr < t; tItr++)
      {
        int n = Convert.ToInt32(file.ReadLine());

        int[] q = Array.ConvertAll(file.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

        minimumBribes(q);

      }
    }
  }
}
