namespace AdventOfCode.DayFour;

public class Puzzle
{
    public void SolveDayThreePuzzlePartTwo()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayFour/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);

        var overlappingAssignmentPairs = 0;
        while ((line = reader.ReadLine()) != null)
        {
            var seperatedCamps = GetTwoSeparateCampStrings(line);
            var campOne = GetCampBeginningAndEnd(seperatedCamps.Item1);
            var campTwo = GetCampBeginningAndEnd(seperatedCamps.Item2);
            
            if (GetPairOverlappingStatus(campOne, campTwo))
            {
                overlappingAssignmentPairs += 1;
            }
        }
        Console.WriteLine($"There are {overlappingAssignmentPairs} overlapping pairs.");
    }
    public void SolveDayThreePuzzlePartOne()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayFour/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);

        var overlappingAssignmentPairs = 0;
        while ((line = reader.ReadLine()) != null)
        {
            var seperatedCamps = GetTwoSeparateCampStrings(line);
            var campOne = GetCampBeginningAndEnd(seperatedCamps.Item1);
            var campTwo = GetCampBeginningAndEnd(seperatedCamps.Item2);
            
            if (GetPairCoverStatus(campOne, campTwo))
            {
                overlappingAssignmentPairs += 1;
            }
        }
        Console.WriteLine($"There are {overlappingAssignmentPairs} pairs that completely overlap each other.");
    }
    
    private bool GetPairOverlappingStatus(Tuple<string, string> campOne, Tuple<string, string> campTwo)
    {
        int beginningCampOne = Int32.Parse(campOne.Item1);
        var endCampOne = Int32.Parse(campOne.Item2);
        var beginningCampTwo = Int32.Parse(campTwo.Item1);
        var endCampTwo = Int32.Parse(campTwo.Item2);
        
        if (beginningCampTwo >= beginningCampOne && beginningCampTwo <= endCampOne)
        {
            return true;
        }

        if (beginningCampOne >= beginningCampTwo && beginningCampOne <= endCampTwo)
        {
            return true;
        }

        return false;
    }
    private bool GetPairCoverStatus(Tuple<string, string> campOne, Tuple<string, string> campTwo)
    {
        int beginningCampOne = Int32.Parse(campOne.Item1);
        var endCampOne = Int32.Parse(campOne.Item2);
        var beginningCampTwo = Int32.Parse(campTwo.Item1);
        var endCampTwo = Int32.Parse(campTwo.Item2);
        
        if (beginningCampOne >= beginningCampTwo && endCampOne <= endCampTwo)
        {
            return true;
        }

        if (beginningCampTwo >= beginningCampOne && endCampTwo <= endCampOne)
        {
            return true;
        }

        return false;
    }
    private Tuple<string, string> GetTwoSeparateCampStrings(string line)
    {
        var campOne = "";
        var campTwo = "";

        var addingToCampOne = true;

        foreach (var character in line)
        {
            if (character == ',')
            {
                addingToCampOne = false;
                continue;
            }

            if (addingToCampOne)
            {
                campOne += character;
            }
            else
            {
                campTwo += character;
            }
        }

        return new Tuple<string, string>(campOne, campTwo);
    }
    private Tuple<string, string> GetCampBeginningAndEnd(string camp)
    {
        bool findingFirstNumber = true;
        var firstNumber = "";
        var secondNumber = "";
        foreach (var character in camp)
        {
            if (character == '-')
            {
                findingFirstNumber = false;
                continue;
            }

            if (findingFirstNumber)
            {
                firstNumber += character;
            }
            else
            {
                secondNumber += character;
            }
        }
        return new Tuple<string, string>(firstNumber, secondNumber);
    }
}