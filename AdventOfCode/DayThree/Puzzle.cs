namespace AdventOfCode.DayThree;

public class Puzzle
{

    public void SolveDayThreePuzzlePartTwo()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayThree/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);

        var totalPriorityValue = 0;
        var rucksackOne = "";
        var rucksackTwo= "";
        var rucksackThree= "";
        
        var lineCounter = 0;
        var rucksackCounter = 0;
        while ((line = reader.ReadLine()) != null)
        {
            lineCounter++;
            rucksackCounter++;
            switch (rucksackCounter)
            {
                case 1:
                    rucksackOne = line;
                    break;
                case 2:
                    rucksackTwo = line;
                    break;
            }
            
            if ((lineCounter % 3) == 0)
            {
                rucksackThree = line;
                var repeatBadgeType = getRepeatBadgeItemType(rucksackOne, rucksackTwo, rucksackThree);
                totalPriorityValue += getPriorityValue(repeatBadgeType);
                rucksackCounter = 0;
                Console.WriteLine($"The total priority value of the rucksacks is {totalPriorityValue}");
            }
        }
    }
    
    public void SolveDayThreePuzzlePartOne()
    {
        const string path =
            "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayThree/PuzzleInput";
        string? line;
        using var reader = new StreamReader(path);

        var totalPriorityValue = 0;
        while ((line = reader.ReadLine()) != null)
        {
            var halfLineLength = line.Length / 2;
            var compartmentOne = line.Substring(0, halfLineLength);
            var compartmentTwo = line.Substring(halfLineLength);

            var repeatLetter = getRepeatLetter(compartmentOne, compartmentTwo);

            totalPriorityValue += getPriorityValue(repeatLetter);
            Console.WriteLine($"The total priority value of the rucksacks is {totalPriorityValue}");
        }
    }

    private char getRepeatBadgeItemType(string rucksackOne, string rucksackTwo, string rucksackThree)
    {
        //way to optimize this?
        foreach (var item in rucksackOne)
        {
            if (rucksackTwo.Any(anotherItem => item == anotherItem))
            {
                if (rucksackThree.Any(badge => item == badge))
                {
                    return item;   
                }
            }
        }

        return '0';
    }
    private int getPriorityValue(char repeatLetter)
    {
        var alphabet = new List<char>()
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z'
        };

        foreach (var character in alphabet)
        {
            if (repeatLetter == character)
            {
                return alphabet.IndexOf(character)+1;
            }

            if (repeatLetter == char.ToUpper(character))
            {
                return (alphabet.IndexOf(character)) + 27;
            }
        }

        return 0;
    }
    private char getRepeatLetter(string compartmentOne, string compartmentTwo)
    {
        //way to optimize this?
        foreach (var item in compartmentOne)
        {
            if (compartmentTwo.Any(anotherItem => item == anotherItem))
            {
                return item;
            }
        }

        return '0';
    }
    
}