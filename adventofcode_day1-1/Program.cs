
string filePath = @"filePath.txt";
string[] lines = File.ReadAllLines(filePath);

List<int> firstNumbers = new List<int>();
List<int> secondNumbers = new List<int>();

foreach (string line in lines)
{
    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2 && int.TryParse(parts[0], out int firstNumber) && int.TryParse(parts[1], out int secondNumber))
    {
        firstNumbers.Add(firstNumber);
        secondNumbers.Add(secondNumber);
    }
}

firstNumbers.Sort();
secondNumbers.Sort();

int totaalDifference = 0;

for (int i = 0; i < firstNumbers.Count; i++)
{
    totaalDifference += Math.Abs(firstNumbers[i] - secondNumbers[i]);
}

Console.WriteLine(totaalDifference);