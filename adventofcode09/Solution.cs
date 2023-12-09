
namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            return Solve(lines, ExtrapolateRight).ToString();
        }
        public string SolutionOfSecondPart(string[] lines)
        {
            return Solve(lines, ExtrapolateLeft).ToString();
        }



        public static long Solve(string[] lines, Func<long[], long> extrapolate)
        {
            long[][] parsedNumbers = lines.Select(ParseNumbers).ToArray();
            long[] extrapolatedNumbers = parsedNumbers.Select(extrapolate).ToArray();

            return extrapolatedNumbers.Sum();
        }

        public static long[] ParseNumbers(string line)
        {
            long[] parsedValues = line.Split(" ").Select(long.Parse).ToArray();
            return parsedValues;
        }

        public static long[] Diff(long[] numbers)
        {
            long[] differences = numbers.Zip(numbers.Skip(1), (long first, long second) => second - first).ToArray();
            return differences;
        }

        public long ExtrapolateRight(long[] numbers)
        {
            if (numbers.Length == 0) return 0;

            long[] differences = Diff(numbers);
            return ExtrapolateRight(differences) + numbers.Last();
        }

        public long ExtrapolateLeft(long[] numbers)
        {
            long[] reversedNumbers = numbers.Reverse().ToArray();
            return ExtrapolateRight(reversedNumbers);
        }
    }
}
