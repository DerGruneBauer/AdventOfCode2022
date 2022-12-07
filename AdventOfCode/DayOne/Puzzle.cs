namespace AdventOfCode.DayOne
{
    public class Puzzle
    {
        public void SolveDayOnePuzzlePartOne()
        {
            var largestCaloriesOnOneElf = GetHighestCalorieElf();

            Console.WriteLine($"The elf carrying the most calories is carrying {largestCaloriesOnOneElf} calories.");
        }

        public void SolveDayOnePuzzlePartTwo()
        {
            var caloriesOfAllElves = GetElvesTotalCalories();

            var totalCaloriesOfTopThreeElves = caloriesOfAllElves.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine(
                $"The top three elves carrying the most calories are carrying {totalCaloriesOfTopThreeElves} calories combined.");
        }

        private int GetHighestCalorieElf()
        {
            const string path =
                "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayOne/PuzzleInput";
            string? line;
            using var reader = new StreamReader(path);
            var highestCalorie = 0;

            var elf = new List<int>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    if (elf.Sum() > highestCalorie)
                    {
                        highestCalorie = elf.Sum();
                    }

                    elf.Clear();
                }
                else
                {
                    elf.Add(Convert.ToInt32(line));
                }
            }

            return highestCalorie;
        }

        private IEnumerable<int> GetElvesTotalCalories()
        {
            const string path =
                "/Users/Remington.Greenbauer/Documents/Fun Code/AdventOfCode/AdventOfCode/DayOne/PuzzleInput";
            var elves = new List<int>();
            string? line;
            using var reader = new StreamReader(path);
            var elfsTotalCalories = 0;

            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    elves.Add(elfsTotalCalories);
                    elfsTotalCalories = 0;
                }
                else
                {
                    elfsTotalCalories += Convert.ToInt32(line);
                }
            }

            return elves;
        }
    }
}