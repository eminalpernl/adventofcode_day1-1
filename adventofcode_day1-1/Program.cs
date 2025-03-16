
//string filePath = @"filePath.txt";
//string[] lines = File.ReadAllLines(filePath);

//List<int> firstNumbers = new List<int>();
//List<int> secondNumbers = new List<int>();

//foreach (string line in lines)
//{
//    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//    if (parts.Length == 2 && int.TryParse(parts[0], out int firstNumber) && int.TryParse(parts[1], out int secondNumber))
//    {
//        firstNumbers.Add(firstNumber);
//        secondNumbers.Add(secondNumber);
//    }
//}

//firstNumbers.Sort();
//secondNumbers.Sort();

//int totaalDifference = 0;

//for (int i = 0; i < firstNumbers.Count; i++)
//{
//    totaalDifference += Math.Abs(firstNumbers[i] - secondNumbers[i]);
//}

//Console.WriteLine(totaalDifference);




//////////////////////////////////     LINQ     //////////////////////////////////////
///


using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "filePath.txt";

        var numberPairs = File.ReadLines(filePath)
                          .Where(s => !string.IsNullOrWhiteSpace(s)) 
                          .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToArray())
                          .Where(a => a.Length == 2)
                          .ToList();


        var firstNumbers = numberPairs.Select(a => a[0]).OrderBy(x => x).ToArray();
        var secondNumbers = numberPairs.Select(a => a[1]).OrderBy(x => x).ToArray();

        int totalDifference = firstNumbers.Zip(secondNumbers, (a, b) => Math.Abs(a - b)).Sum();

        Console.WriteLine("Totaal abs: " + totalDifference);
    }
}
