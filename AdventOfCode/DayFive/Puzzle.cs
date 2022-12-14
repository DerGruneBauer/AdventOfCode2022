using System.Reflection.PortableExecutable;

namespace AdventOfCode.DayFive;

public class Puzzle
{
    public void SolveDayFivePuzzlePartOne()
    {
        var stacks = TransformTextFile();
        var stacksDictionary = new Dictionary<int, Stack<char>>();

        for (var i = stacks.Length-1; i >= 0 ; i--)
        {
            if (stacks[i] != ' ' && stacks[i] != '\n')
            {
                var stackNumber = GetStackNumber(i);
                AddOrUpdateToStack(stacksDictionary, stackNumber, stacks[i]);
            }
        }
        ReadInstructions(ref stacksDictionary);
        
        ViewCrates(stacksDictionary);
    }

    public void SolveDayFivePuzzlePartTwo()
    {
        
    }

    private void ViewCrates(Dictionary<int, Stack<char>> stacks)
    {
        Console.WriteLine($"Stack One: {stacks[1].Peek()}");
        Console.WriteLine($"Stack Two: {stacks[2].Peek()}");
        Console.WriteLine($"Stack Three: {stacks[3].Peek()}");
        Console.WriteLine($"Stack Four: {stacks[4].Peek()}");
        Console.WriteLine($"Stack Five: {stacks[5].Peek()}");
        Console.WriteLine($"Stack Six: {stacks[6].Peek()}");
        Console.WriteLine($"Stack Seven: {stacks[7].Peek()}");
        Console.WriteLine($"Stack Eight: {stacks[8].Peek()}");
        Console.WriteLine($"Stack Nine: {stacks[9].Peek()}");
    }
    private void MoveCrates(ref Dictionary<int, Stack<char>> stacks, int numCratesToMove, int stackMoveFrom, int stackMoveTo)
    {
        for (var i = 0; i < numCratesToMove; i++)
        {
            var savedCrate = stacks[stackMoveFrom].Pop();
            stacks[stackMoveTo].Push(savedCrate);
        }
    }
    private void ReadInstructions(ref Dictionary<int, Stack<char>> stacks)
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayFive/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);
        int counter = 0;
        
        int numOfCratesMoved = 0;
        int stackMoveFrom;
        int stackMoveTo;
        
        while ((line = reader.ReadLine()) != null)
        {
            counter++;

            if (counter >= 11)
            {
                numOfCratesMoved = int.Parse(GetNumberOfCratesMoved(line));
                stackMoveFrom = int.Parse(GetStackToMoveFrom(line));
                stackMoveTo = int.Parse(GetStackToMoveTo(line));
                MoveCrates(ref stacks, numOfCratesMoved, stackMoveFrom, stackMoveTo);
            }
        }
    }
    private static string GetStackToMoveTo(string line)
    {
        if (line[17] == ' ')
        {
            return line[18].ToString();
        }

        return line[17].ToString();
    }
    private static string GetStackToMoveFrom(string line)
    {
        if (line[12] == ' ')
        {
            return line[13].ToString();
        }

        return line[12].ToString();
    }
    private static string GetNumberOfCratesMoved(string line)
    {
        if (line[6] == ' ')
        {
            return line[5].ToString();
        }

        string number = line[5].ToString();
        number += line[6].ToString();

        return number;
    }
    private static int GetStackNumber(int i)
    {
        int stackNumber;
        if (i.ToString().Length == 1)
        {
            stackNumber = i;
        }
        else
        {
            var stringIndex = i.ToString()[1];
            stackNumber = stringIndex - '0';
        }

        return stackNumber+1;
    }
    private static void AddOrUpdateToStack(Dictionary<int, Stack<char>> targetDictionary, int key, char entry)
    {
        if (!targetDictionary.ContainsKey(key))
            targetDictionary.Add(key, new Stack<char>());

        targetDictionary[key].Push(entry);
    }
    private static string TransformTextFile()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayFive/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);
        
        var newImage = "";
        var rowCounter = 0;
        var charCounter = 0;

        while ((line = reader.ReadLine()) != null)
        {
            rowCounter++;
            if (rowCounter == 9)
            {
                break;
            }

            foreach (var character in line)
            {
                charCounter++;
                if (charCounter % 2 == 0)
                {
                    newImage += character;
                }
            }

            charCounter = 0;
            newImage += "\n";
        }

        var stacksWithNoSpaces = "";
        //remove rest of extra spaces
        foreach (var character in newImage)
        {
            charCounter++;
            if (charCounter % 2 != 0)
            {
                stacksWithNoSpaces += character;
            }

            if (charCounter % 18 == 0)
            {
                stacksWithNoSpaces += "\n";
            }
        }

        return stacksWithNoSpaces;
    }
}