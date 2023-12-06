


using System.Diagnostics;

namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            List<Race> races = new();
            //TestInput(ref races);
            RealInput(ref races);

            CalculateWinPossibilities(races);

            return TotalCombinedWins(races);
        }

        private string TotalCombinedWins(List<Race> races)
        {
            long multipliedWinCount = 1;
            foreach(Race race in races)
            {
                Debug.WriteLine(race.ReturnWins());
                multipliedWinCount *= race.ReturnWins();
            }
            return multipliedWinCount.ToString();
        }

        private void CalculateWinPossibilities(List<Race> races)
        {
            foreach(Race race in races)
            {
                race.CalculateWins();
            }
        }

        private static void RealInput(ref List<Race> races)
        {
            races.Add(new Race{Time = 51, Distance = 222});
            races.Add(new Race{Time = 92, Distance = 2031});
            races.Add(new Race{Time = 68, Distance = 1126});
            races.Add(new Race{Time = 90, Distance = 1225});
        }

        private static void TestInput(ref List<Race> races)
        {
            races.Add(new Race{Time = 7, Distance = 9});
            races.Add(new Race{Time = 15, Distance = 40});
            races.Add(new Race{Time = 30, Distance = 200});
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            List<Race> races = new();
            //TestInput(ref races);
            //RealInput(ref races);
            races.Add(new Race{Time = 51926890, Distance = 222203111261225});

            CalculateWinPossibilities(races);

            return TotalCombinedWins(races);
        }
    }
}
