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

class Result
{

  /*
   * Complete the 'countPalindromes' function below.
   *
   * The function is expected to return an INTEGER.
   * The function accepts STRING s as parameter.
   */

  public static int countPalindromes(string s)
  {
    int pals = s.Length;
    
    for(int i = 1; i <= s.Length - 1; i++)
    {
      int j = 1;
      while (j <= Math.Min(i, s.Length - 1 - i) && s[i-j] == s[i+j])
      {
        pals++;
        j++;
      }
      j = 1;
      while (j <= Math.Min(i, s.Length - i) && s[i - j] == s[i - 1 + j])
      {
        pals++;
        j++;
      }
    }

    return pals;
  }

}

class Solution
{
  public static void Main(string[] args)
  {
    //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string s = Console.ReadLine();

    int result = Result.countPalindromes(s);

    Console.WriteLine(result);


    // Keep the console window open in debug mode.
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();

  }
}
