using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArraysLeftRotation
{
  class Program
  {
    public class DataProcessor
    {
      private Stack<int> sharedStore;
      private Stack<int> answers;

      public DataProcessor()
      {
        this.sharedStore = new Stack<int>();
        this.answers = new Stack<int>();
      }
      public void InititialiseData(IEnumerable<int> input)
      {
        foreach (int i in input)
          sharedStore.Push(i);
      }
      public IEnumerable<int> GetResults()
      {
        while (answers.Count > 0)
          yield return answers.Pop();
      }
      //Call Calculate in the parent class to perform the calculation.
      //Do not calculate in this method
      public void CalculateData()
      {
        int number = sharedStore.Pop();
        answers.Push(Calculate(number, sharedStore.Count));
      }
    }
    static void Main(String[] args)
    {

      System.IO.StreamReader file = new System.IO.StreamReader(@"C:\TEMP\input001.txt");

      string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
      //TextWriter tw = new StreamWriter(@fileName, true);

      int inputCount = 0;
      inputCount = Convert.ToInt32(file.ReadLine());
      List<int> data = new List<int>();
      for (int i = 0; i < inputCount; i++)
      {
        data.Add(Convert.ToInt32(file.ReadLine()));
      }


      DataProcessor processor = new DataProcessor();
      processor.InititialiseData(data);
      //New threaded Code
      Parallel.For(0, data.Count, i => { processor.CalculateData(); });

      //Old Slow code
      //for (int i = 0; i < data.Count; i++)
      //{
      //    processor.CalculateData();
      //}

      foreach (int a in processor.GetResults().OrderBy(i => i))
        Console.WriteLine(a);
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }
    public static int Calculate(int a, int b)
    {
      Thread.Sleep(2);
      return a * b;
    }
  }
}
