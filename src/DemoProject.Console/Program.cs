using Microsoft.VisualBasic;
using System;
using System.Text.RegularExpressions;

namespace DemoProject;

public class Program
{
  public static void Main(string[] args)
  {
    Console.Write("Please enter the date in the following pattern: yyyy-MM-dd:");
    var Input = Console.ReadLine();

    Regex Regex = new Regex("\\d{4}-[01]\\d-[012]\\d");

    var Match = Regex.Match(Input);

    if (Match.Success)
    {
      int Year = Convert.ToInt32(Match.Groups[0].Value.Split('-')[0]); 
      int Month = Convert.ToInt32(Match.Groups[0].Value.Split('-')[1]);
      int Day = Convert.ToInt32(Match.Groups[0].Value.Split('-')[2]);

      Console.WriteLine($"The {Input} was a {CalculateDayOfWeek(Year, Month, Day)}");
    }
    else 
      Console.WriteLine("WRONG FORMAT");
  }

  private static DayOfWeek CalculateDayOfWeek(int year, int month, int day)
  {
    if (month < 3)
      year--;

    int weekDay = Convert.ToInt32((
      (day + Math.Floor(2.6 * ((month + 9) % 12 + 1 - 1) - 0.2) + year % 100 
      + Math.Floor(((double)year % 100 / 4)) + Math.Floor((double)year / 400) - 2
      * Math.Floor((double)year / 100) - 1) % 7 + 7) % 7 + 1);

    return (DayOfWeek)weekDay;
  }
}