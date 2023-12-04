using System.Diagnostics;

namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            bool wantToDebug = true;
            int solution = 0;
            List<int> winningNumbers = new();

            foreach (string game in lines)
            {
                string[] numbers = game.Split(" ");

                FillListWithWinningNumbers(ref winningNumbers, numbers);

                solution += CalculatePoints(winningNumbers, numbers);

                ClearList(ref winningNumbers);
            }
            return solution.ToString();
        }

        private static void ClearList(ref List<int> winningNumbers)
        {
            winningNumbers = new();
        }

        private static int CalculatePoints(List<int> winningNumbers, string[] numbers)
        {
            bool foundRegularNumbers = false;
            int points = 0;
            foreach (string number in numbers)
            {
                if(foundRegularNumbers && number != "")
                {
                    if (CheckForWin(ref winningNumbers, number))
                    {
                        if(points == 0)
                        {
                            points = 1;
                        }
                        else
                        {
                            points *= 2;
                        }
                    }
                }
                else
                {
                    if (number == "|")
                    {
                        foundRegularNumbers = true;
                    }
                }
            }
            return points;
        }

        private static bool CheckForWin(ref List<int> winningNumbers, string number)
        {
            foreach (int winningNumber in winningNumbers)
            {
                if (number == winningNumber.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private static void FillListWithWinningNumbers(ref List<int> winningNumbers, string[] numbers)
        {
            bool foundWinningNumbers = false;
            foreach (string number in numbers)
            {
                if(foundWinningNumbers)
                {
                    if (number == "|")
                    {
                        break;
                    }
                    if (number != "")
                    {
                        winningNumbers.Add(int.Parse(number));
                    }
                }
                else
                {
                    if (number.EndsWith(":"))
                    {
                        foundWinningNumbers = true;
                    }
                }
            }
        }








        public string SolutionOfSecondPart(string[] lines)
        {
            string solution = "";

            // Hier kommt die Logik für den zweiten Teil hin

            return solution;
        }
    }
}
