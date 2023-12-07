using System.Diagnostics;

namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            Game[] games = new Game[lines.Length];

            foreach (string line in lines)
            {
                CreateGameAndInsert(line, ref games);
            }

            foreach (Game game in games)
            {
                Debug.WriteLine(game.Hand + " " + game.Rank);
            }
            Debug.WriteLine("Array Lenght: " + games.Length);


            return CalculatePoints(ref games);
        }

        private static string CalculatePoints(ref Game[] games)
        {
            int sum = 0;
            int multiplier = 1000;
            foreach (Game game in games)
            {
                sum += game.Bid * multiplier;
                multiplier--;
            }
            return sum.ToString();
        }

        private static void CreateGameAndInsert(string line, ref Game[] games, bool withJoker = false)
        {
            string hand = line[0..5];
            string bid = line[6..^0];
            Game game = Game.CreateNewGame(hand, int.Parse(bid), withJoker);
            InsertSorted(game, ref games, withJoker);
        }

        private static void InsertSorted(Game game, ref Game[] games, bool withJoker)
        {
            int index = 0;
            if (games[index] == null && index == 0)
            {
                games[index] = game;
                return;
            }
            while (games[index] != null && game.Rank < games[index].Rank)
            {
                index++;
            }
            while (games[index] != null && IsCardNotHigher(games[index], game, withJoker) && game.Rank == games[index].Rank)
            {
                index++;
            }
            SetCard(game, games, index);
        }

        private static void SetCard(Game game, Game[] games, int index)
        {
            if (games[index] == null)
            {
                games[index] = game;
            }
            else
            {
                int indexHandler = index;
                Game tmp = games[indexHandler];
                Game? tmp2 = null;
                while (games[indexHandler] != null && indexHandler + 1 < games.Length)
                {
                    tmp2 = games[indexHandler + 1];
                    games[indexHandler + 1] = tmp;
                    tmp = tmp2;
                    indexHandler++;
                }
                games[index] = game;
            }
        }

        private static bool IsCardNotHigher(Game ogGame, Game newGame, bool withJoker)
        {
            int cardOG = MakeDigit(ogGame.Hand[0], withJoker);
            int cardNG = MakeDigit(newGame.Hand[0], withJoker);

            for (int i = 1; i < 5; i++)
            {
                if (cardOG == cardNG)
                {
                    cardOG = MakeDigit(ogGame.Hand[i], withJoker);
                    cardNG = MakeDigit(newGame.Hand[i], withJoker);
                }
                else
                {
                    return cardNG < cardOG;
                }
            }
            return cardNG < cardOG;
        }

        private static int MakeDigit(char v, bool withJoker)
        {
            if (Char.IsDigit(v))
            {
                return int.Parse(v.ToString());
            }
            else
            {
                if (withJoker)
                {
                    return v switch
                    {
                        'T' => 10,
                        'J' => 1,
                        'Q' => 12,
                        'K' => 13,
                        'A' => 14,
                        _ => throw new Exception("NOT A VALID CARD AS IT SEEMS"),
                    };
                }
                else
                {
                    return v switch
                    {
                        'T' => 10,
                        'J' => 11,
                        'Q' => 12,
                        'K' => 13,
                        'A' => 14,
                        _ => throw new Exception("NOT A VALID CARD AS IT SEEMS"),
                    };
                }
            }
        }

        public static string SolutionOfSecondPart(string[] lines)
        {
            Game[] games = new Game[lines.Length];

            foreach (string line in lines)
            {
                CreateGameAndInsert(line, ref games, withJoker: true);
            }

            foreach (Game game in games)
            {
                Debug.WriteLine(game.Hand + " " + game.Rank);
            }
            Debug.WriteLine("Array Lenght: " + games.Length);


            return CalculatePoints(ref games);
        }
    }
}
