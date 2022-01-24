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

namespace Fish
{
  class Program
  {

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
      int maxSum = -63;
      for (int i = 1; i < 5; i++)
      {
        for (int j = 1; j < 5; j++)
        {
          int sum = 0;
          sum += arr[i-1][j-1];
          sum += arr[i-1][j];
          sum += arr[i-1][j+1];
          sum += arr[i][j];
          sum += arr[i + 1][j - 1];
          sum += arr[i + 1][j];
          sum += arr[i + 1][j + 1];
          maxSum = sum < maxSum ? maxSum : sum;
        }
      }
      return maxSum;
    }
    static void Main(string[] args)
    {

      int[][] arr = new int[6][];

      for (int i = 0; i < 6; i++)
      {
        arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
      }

      int result = hourglassSum(arr);

      Console.WriteLine(result);

      // Keep the console window open in debug mode.
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }
  }
}
