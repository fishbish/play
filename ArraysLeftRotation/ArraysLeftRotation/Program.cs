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


namespace ArraysLeftRotation
{
  class Program
  {
    // Complete the rotLeft function below.
    static int[] rotLeft(int[] a, int d)
    {
      int l = a.Length;
      int moves = d % l;
      int[] tmp = new int[l];
      for (int i = 0; i < l; i++)
      {
        int newIndex = i - moves;
        if(newIndex < 0)
        {
          tmp[l + newIndex] = a[i];
        }
        else
        {
          tmp[newIndex] = a[i];
        }
      }
      return tmp;
    }

    static void Main(string[] args)
    {
      //string[] nd = Console.ReadLine().Split(' ');
      System.IO.StreamReader file = new System.IO.StreamReader(@"C:\TEMP\ArrayRotate.txt");
      string[] nd = file.ReadLine().Split(' ');

      int n = Convert.ToInt32(nd[0]);

      int d = Convert.ToInt32(nd[1]);

      int[] a = Array.ConvertAll(file.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

      int[] result = rotLeft(a, d);

      Console.WriteLine(string.Join(" ", result));

      // Keep the console window open in debug mode.
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }
  }
}
