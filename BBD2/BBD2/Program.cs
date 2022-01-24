using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
  static void PrintResults(TextWriter tw, List<Time> time)
  {
    TimeWorked timeWorked = new TimeWorked();
    List<Time> tmp = new List<Time>();
    tmp.AddRange(time);
    timeWorked.PrintTimePlusOT(tw, time);
    tw.WriteLine(" ");
    timeWorked.PrintTotalWithoutOTime(tw, tmp);
  }



  static void Main(String[] args)
  {

    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\TEMP\test_cases_fcc1ma3tqb8\input001.txt");
    string fileName = "C:\\TEMP\\test_cases_fcc1ma3tqb8\\test.txt";
    TextWriter tw = new StreamWriter(@fileName, true);

    int _lines_size = 0;
    _lines_size = Convert.ToInt32(file.ReadLine());

    List<Time> time = new List<Time>();
    string _lines_item;
    for (int _lines_i = 0; _lines_i < _lines_size; _lines_i++)
    {
      _lines_item = file.ReadLine();
      string[] arr = _lines_item.Split(',');
      time.Add(new Time() { Description = arr[0], Date = Convert.ToDateTime(arr[1]), TimeWorked = Convert.ToDecimal(arr[2]) });
    }

    PrintResults(tw, time);
    tw.WriteLine(" ");

    tw.Flush();
    tw.Close();
  }
  class Time
  {
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal TimeWorked { get; set; }
  }

  class TimeWorked
  {
    public void PrintTimePlusOT(TextWriter tw, List<Time> hours)
    {
      decimal workedHours = 0M;
      decimal otHours = 0M;
      hours.ForEach(x => workedHours += x.TimeWorked);
      List<Time> overtimeHours = getOvertime(hours);
      overtimeHours.ForEach(x => otHours += x.TimeWorked);
      hours.AddRange(overtimeHours);
      hours.Sort((a, b) => a.Date.CompareTo(b.Date));
      tw.WriteLine("----------Itemised time statement----------");
      hours.ForEach(x => tw.WriteLine(string.Format("{0} {1} {2:N} Hours", x.Description, x.Date.ToString("yyyy-MM-dd"), x.TimeWorked)));
      tw.WriteLine("-------------------------------------------");
      tw.WriteLine(string.Format("Work hours: {0} - Overtime hours: {1}", workedHours, otHours));
      tw.WriteLine("-------------------------------------------");
    }
    List<Time> getOvertime(List<Time> hours)
    {
      List<Time> overtime = new List<Time>();
      foreach (var x in hours)
      {
        if (x.Date.ToString("dddd") == "Saturday" || x.Date.ToString("dddd") == "Sunday")
          overtime.Add(new Time() { Date = x.Date, Description = "OT", TimeWorked = (x.TimeWorked * 0.5M) });
      }
      return overtime;

    }
    public void PrintTotalWithoutOTime(TextWriter tw, List<Time> hours)
    {
      decimal totalHours = 0M;
      hours.ForEach(x => totalHours += x.TimeWorked);
      tw.WriteLine("---------Aggregated time statement---------");
      tw.WriteLine(string.Format("Total {0:N} Hours Worked - (No Overtime)", totalHours));
      totalHours = 0M;
      getOvertime(hours).ForEach(x => totalHours += x.TimeWorked);
      tw.WriteLine(string.Format("Total {0:N} Overtime Hours Worked", totalHours));
      tw.WriteLine("-------------------------------------------");
    }
  }
}