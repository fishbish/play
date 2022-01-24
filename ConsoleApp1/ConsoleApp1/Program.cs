using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
  class Solution
  {
    static decimal Calc(string value1, string value2, string calcOperator, out string errorMessage)
    {
      errorMessage = "";
      decimal v1;
      decimal v2;
      if (!decimal.TryParse(value1, out v1) || !decimal.TryParse(value2, out v2))
      {
        errorMessage = "Values must be numeric.";
        return -9999;
      }
      decimal returnValue = 0M;

      try
      {

        switch (calcOperator)
        {
          case "Add":
            returnValue = v1 + v2;
            break;
          case "Subtract":
            returnValue = v1 - v2;
            break;
          case "Multiply":
            returnValue = v1 * v2;
            break;
          case "Divide":
            returnValue = v1 / v2;
            break;
          default:
            errorMessage = "Incorrect operator";
            returnValue = -9999;
            break;
        }
      }
      catch (Exception ex)
      {
        errorMessage = ex.Message;
        returnValue = -9999;
      }

      return returnValue;
    }
    static void Main(string[] args)
    {
      string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
      TextWriter tw = new StreamWriter(@fileName, true);

      string input = Console.ReadLine();
      string[] arr = input.Split(',');

      string errorMessage = "";
      decimal testValue = Calc(arr[0], arr[1], arr[2], out errorMessage);

      if (testValue == -9999M)
        tw.WriteLine(errorMessage);
      else
        tw.WriteLine(testValue);
      tw.Flush();
      tw.Close();
    }
  }
}