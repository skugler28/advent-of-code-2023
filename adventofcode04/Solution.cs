using System.Diagnostics;

namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            int solution = 0;
            List<int> winningNumbers = new();

            foreach (string game in lines)
            {
                string[] numbers = game.Split(" ");

                FillListWithWinningNumbers(ref winningNumbers, numbers);

                solution += CalculatePoints(ref winningNumbers, numbers);

                ClearList(ref winningNumbers);
            }
            return solution.ToString();
        }

        public static string SolutionOfSecondPart(string[] lines)
        {
            int solution = 0;
            Scratchcard[] scratchcards = new Scratchcard[lines.Length];

            InitializeEachCard(ref scratchcards, ref lines);
            DuplicateTheWins(ref scratchcards);

            return solution.ToString();
        }



        private static void ClearList(ref List<int> winningNumbers)
        {
            winningNumbers = new();
        }

        private static int CalculatePoints(ref List<int> winningNumbers, string[] numbers)
        {
            bool foundRegularNumbers = false;
            int points = 0;

            foreach (string number in numbers)
            {
                if (foundRegularNumbers && number != "" && CheckForWin(ref winningNumbers, number))
                {
                    points = (points == 0) ? 1 : points * 2;
                }
                else if (number == "|")
                {
                    foundRegularNumbers = true;
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
                if (foundWinningNumbers)
                {
                    if (number == "|") break;

                    if (number != "")
                    {
                        winningNumbers.Add(int.Parse(number));
                    }
                        
                }
                else if (number.EndsWith(":"))
                {
                    foundWinningNumbers = true;
                }
            }
        }

        private static void DuplicateTheWins(ref Scratchcard[] scratchcards)
        {
            //karte von der wir ausgehen
            for (int thisSratchcard = 0; thisSratchcard < scratchcards.Length; thisSratchcard++)
            {
                //wie oft karte vorkommt
                for (int amount = 0; amount < scratchcards[thisSratchcard].Count; amount++)
                {
                    //dupliziere auf basis der gewinne der jetzigen karte
                    int duplicateTo = thisSratchcard + 1 + scratchcards[thisSratchcard].WinCount;
                    for (int duplicate = thisSratchcard + 1; duplicate < scratchcards.Length && duplicate < duplicateTo; duplicate++)
                    {
                        scratchcards[duplicate].Count++;
                    }
                }
            }
        }

        private static void InitializeEachCard(ref Scratchcard[] scratchcards, ref string[] lines)
        {
            bool foundGameNumber = false;
            bool foundRegularNumbers = false;
            int gameNumber = 0;
            int winCount = 0;
            int i = 0;
            List<int> winningNumbers = new();
            foreach (string game in lines)
            {
                string[] numbers = game.Split(" ");
                foreach (string item in numbers)
                {
                    if (foundGameNumber && item != "")
                    {
                        if (item != "|" && !foundRegularNumbers)
                        {
                            winningNumbers.Add(int.Parse(item));
                        }
                        else
                        {
                            if (foundRegularNumbers)
                            {
                                if (CheckForWin(ref winningNumbers, item))
                                {
                                    winCount++;
                                }
                            }
                            else
                            {
                                foundRegularNumbers = true;
                            }
                        }
                    }
                    else
                    {
                        if (item.EndsWith(":"))
                        {
                            foundGameNumber = true;
                            gameNumber = int.Parse(item[..^1]);
                        }
                    }
                }
                scratchcards[i] = GenerateScratchcard(gameNumber, winCount);
                foundGameNumber = false;
                foundRegularNumbers = false;
                winCount = 0;
                ClearList(ref winningNumbers);
                i++;
            }
        }

        private static Scratchcard GenerateScratchcard(int gameNumber, int winCount)
        {
            return new Scratchcard
            {
                GameNumber = gameNumber,
                Count = 1,
                WinCount = winCount
            };
        }
    }
}
