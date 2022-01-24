using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class Solution
{
  static Dictionary<string, int> aggregateNames(string[] lines)
  {
    //Write your code here
    Dictionary<string, int> aggNames = new Dictionary<string, int>();
    for(int i = 0; i < lines.Length; i++)
    {
      if (aggNames.ContainsKey(lines[i])) {
        aggNames[lines[i]] += 1;
      }
      else
      {
        aggNames.Add(lines[i], 1);
      }
    }
    return aggNames;
  }
  static string ReverseWords(string input)
  {
    // TODO: implement this method
    return input.Reverse().ToArray().ToString();
  }

  static void Main(String[] args)
  {

    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\TEMP\Dict\input001.txt");

    Dictionary<string, int> res;

    int _lines_size = 0;
    _lines_size = Convert.ToInt32(file.ReadLine());
    string[] _lines = new string[_lines_size];
    string _lines_item;
    for (int _lines_i = 0; _lines_i < _lines_size; _lines_i++)
    {
      _lines_item = file.ReadLine();
      _lines[_lines_i] = _lines_item;
    }

    res = aggregateNames(_lines).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    foreach (var item in res)
    {
      Console.WriteLine(String.Format("{0} {1}", item.Key, item.Value));
    }
    
  }
}