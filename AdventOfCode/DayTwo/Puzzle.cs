namespace AdventOfCode.DayTwo;

public class Puzzle
{
    public void SolveDayTwoPuzzlePartOne()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayTwo/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);

        var elfScore = 0;
        var myScore = 0;

        while ((line = reader.ReadLine()) != null)
        {
            var elfShape = line[0];
            var myShape = line[2];

            elfScore += GetShapeScore(elfShape);
            myScore += GetShapeScore(myShape);

            GetWinner(elfShape, myShape, ref elfScore, ref myScore);
        }

        Console.WriteLine("Part One: ");
        Console.WriteLine($"Elf Score {elfScore} :  My Score {myScore}");
    }
    
    public void SolveDayTwoPuzzlePartTwo()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayTwo/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);
        
        var elfScore = 0;
        var myScore = 0;
        
        while ((line = reader.ReadLine()) != null)
        {
            var elfShape = line[0];
            var myShape = FindMyShape(line[2], elfShape);

            elfScore += GetShapeScore(elfShape);
            myScore += GetShapeScore(myShape);

            GetWinner(elfShape, myShape, ref elfScore, ref myScore);
        }
        Console.WriteLine("Part Two: ");
        Console.WriteLine($"Elf Score {elfScore} :  My Score {myScore}");
    }

    private char FindMyShape(char myShape, char elfShape)
    {
        return myShape switch
        {
            'Y' => elfShape switch
            {
                'A' => 'X',
                'B' => 'Y',
                _ => 'Z'
            },
            'X' => elfShape switch
            {
                'A' => 'Z',
                'B' => 'X',
                _ => 'Y'
            },
            _ => elfShape switch
            {
                'A' => 'Y',
                'B' => 'Z',
                _ => 'X'
            }
        };
    }
    private int GetShapeScore(char shape)
    {
        switch (shape)
        {
            case 'A':
            case 'X':
                return 1;
            case 'B':
            case 'Y':
                return 2;
            default:
                return 3;
        }
    }
    private void GetWinner(char elfShape, char myShape, ref int elfScore, ref int myScore)
    {
        if ((elfShape == 'A' && myShape == 'X') || (elfShape == 'B' && myShape == 'Y') || (elfShape == 'C' && myShape == 'Z'))
        {
            elfScore += 3;
            myScore += 3;
        }
        else if ((elfShape == 'A' && myShape == 'Z') || (elfShape == 'B' && myShape == 'X') || (elfShape == 'C' && myShape == 'Y'))
        {
            elfScore += 6;
        }
        else
        {
            myScore += 6;
        }
    }
}