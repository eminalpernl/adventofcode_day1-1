using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "filePath.txt";
        List<int> quantity = new List<int>();
        var numberPairs = File.ReadLines(filePath)
                          .Where(s => !string.IsNullOrWhiteSpace(s))
                          .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToArray())
                          .Where(a => a.Length == 2)
                          .ToList();


        int[] firstNumbers = numberPairs.Select(a => a[0]).ToArray();
        int[] secondNumbers = numberPairs.Select(a => a[1]).ToArray();

        int totaal = firstNumbers.Sum(x => x * secondNumbers.Count(y => y == x));

        //int totalDifference = firstNumbers.Zip(secondNumbers, (a, b) => Math.Abs(a - b)).Sum();

        Console.WriteLine("Totaal: " + totaal);

    }
}
