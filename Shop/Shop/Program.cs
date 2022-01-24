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

class Solution
{

  // Complete the verifyItems function below.
  static int verifyItems(string[] origItems, float[] origPrices, string[] items, float[] prices)
  {
    int wrongPrices = 0;

    for(int i = 0; i <= origItems.Length -1; i++)
    {
      for(int m = 0; m <= items.Length -1; m++)
      {
        if(origItems[i] == items[m] && origPrices[i] != prices[m])
        {
          wrongPrices++;
        }
      }
    }

    return wrongPrices;

  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int origItemsCount = Convert.ToInt32(Console.ReadLine());

    string[] origItems = new string[origItemsCount];

    for (int i = 0; i < origItemsCount; i++)
    {
      string origItemsItem = Console.ReadLine();
      origItems[i] = origItemsItem;
    }

    int origPricesCount = Convert.ToInt32(Console.ReadLine());

    float[] origPrices = new float[origPricesCount];

    for (int i = 0; i < origPricesCount; i++)
    {
      float origPricesItem = Convert.ToSingle(Console.ReadLine());
      origPrices[i] = origPricesItem;
    }

    int itemsCount = Convert.ToInt32(Console.ReadLine());

    string[] items = new string[itemsCount];

    for (int i = 0; i < itemsCount; i++)
    {
      string itemsItem = Console.ReadLine();
      items[i] = itemsItem;
    }

    int pricesCount = Convert.ToInt32(Console.ReadLine());

    float[] prices = new float[pricesCount];

    for (int i = 0; i < pricesCount; i++)
    {
      float pricesItem = Convert.ToSingle(Console.ReadLine());
      prices[i] = pricesItem;
    }

    int res = verifyItems(origItems, origPrices, items, prices);

    textWriter.WriteLine(res);

    textWriter.Flush();
    textWriter.Close();
  }
}
