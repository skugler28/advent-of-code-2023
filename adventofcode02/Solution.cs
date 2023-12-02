
namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            int sumOfIds = 0;

            foreach (string game in lines)
            {
                Dictionary<string, int> cubeAmounts = InitalizeCubeAmounts(new int[] { 12, 13, 14 });

                int gameID = 0;
                bool gameIsPossible = true;

                // Here we split up the game into its parts: The GameID and each color pull
                // and then extract the gameID which gets stated in the first "round" of the game
                string[] allPulls = game.Split(',', ';', ':');
                gameID = ExtractGameID(allPulls[0]);
                
                ProcessPulls(allPulls, cubeAmounts, ref gameIsPossible);

                if (gameIsPossible) sumOfIds += gameID;
            }

            return sumOfIds.ToString();
        }

        public static string SolutionOfSecondPart(string[] lines)
        {
            int powerOfBalls = 0;

            foreach (string game in lines)
            {
                Dictionary<string, int> cubeAmounts = InitalizeCubeAmounts();
                
                string[] allPulls = game.Split(';', ':');
                UpdateCubeAmounts(allPulls.Skip(1), cubeAmounts); //  skip the first round because it only contains the gameID

                CalculatePowerOfBalls(cubeAmounts, ref powerOfBalls);
            }

            return powerOfBalls.ToString();
        }






        private static void ProcessPulls(string[] allPulls, Dictionary<string, int> cubeAmounts, ref bool gameIsPossible)
        {
            for (int i = 1; i < allPulls.Length && gameIsPossible; i++)
            {
                string thisDrawRound = allPulls[i];
                string[] colorOfDrawing = thisDrawRound.Split(' ');

                if (cubeAmounts.TryGetValue(colorOfDrawing[2], out int availableAmount) && availableAmount < Convert.ToInt32(colorOfDrawing[1]))
                {
                    gameIsPossible = false;
                }
            }
        }
        private static int ExtractGameID(string firstRound)
        {
            return Convert.ToInt32(firstRound[5..]);
        }

        private static void CalculatePowerOfBalls(Dictionary<string, int> cubeAmounts, ref int powerOfBalls)
        {
            powerOfBalls += cubeAmounts["red"] * cubeAmounts["green"] * cubeAmounts["blue"];
        }

        private static void UpdateCubeAmounts(IEnumerable<string> pulls, Dictionary<string, int> cubeAmounts)
        {
            foreach (string thisPullRound in pulls)
            {
                string[] pullsThisRound = thisPullRound.Split(',');

                foreach (string pull in pullsThisRound)
                {
                    string[] drawing = pull.Split(' ');
                    
                    // exchange the entry in the dictionary if the new value is bigger
                    cubeAmounts[drawing[2]] = Math.Max(cubeAmounts[drawing[2]], Convert.ToInt32(drawing[1]));
                }
            }
        }

        private static Dictionary<string, int> InitalizeCubeAmounts(int[]? values = null)
        {
            if (values == null || values.Length != 3)
            {
                values = new int[] { 0, 0, 0 };
            }

            return new Dictionary<string, int>()
            {
                { "red", values[0] },
                { "green", values[1] },
                { "blue", values[2] }
            };
        }
    }
}
