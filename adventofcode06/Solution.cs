namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart()
        {
            List<Race> races = InitializeList();

            CalculateWinPossibilities(races);
            return TotalCombinedWins(races);
        }

        private static string TotalCombinedWins(List<Race> races)
        {
            long multipliedWinCount = 1;
            foreach (Race race in races)
            {
                multipliedWinCount *= race.ReturnWins();
            }
            return multipliedWinCount.ToString();
        }

        private static void CalculateWinPossibilities(List<Race> races)
        {
            foreach (Race race in races)
            {
                race.CalculateWins();
            }
        }

        private static List<Race> InitializeList()
        {
            return new List<Race>
            {
                new() {Time = 51, Distance = 222},
                new() {Time = 92, Distance = 2031},
                new() {Time = 68, Distance = 1126},
                new() {Time = 90, Distance = 1225}
            };
        }

        public static string SolutionOfSecondPart()
        {
            List<Race> races = new()
            {
                new Race { Time = 51926890, Distance = 222203111261225 }
            };

            CalculateWinPossibilities(races);

            return TotalCombinedWins(races);
        }
    }
}
