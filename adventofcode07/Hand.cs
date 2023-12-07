using System.Runtime.InteropServices;

namespace adventofcode2023
{
    public class Game
    {
        public string? Hand { get; set; }
        public int Bid { get; set; }
        public Rank Rank { get; set; }


        public static Game CreateNewGame(string hand, int bid, bool withJoker)
        {
            Game game = new()
            {
                Hand = hand,
                Bid = bid,
                Rank = AnalyzeHand(hand, withJoker)
            };
            return game;
        }

        private static Rank AnalyzeHand(string hand, bool withJoker)
        {
            if (withJoker)
            {
                return AnalyzeHandWithJoker(hand);
            }
            else
            {
                return AnalyzeHandWithoutJoker(hand);
            }
        }

        private static Rank AnalyzeHandWithJoker(string hand)
        {
            int jokerCount = CountJokers(hand);
            if(jokerCount == 0)
            {
                return AnalyzeHandWithoutJoker(hand);
            }
            else
            {
                return true switch
                {
                    var _ when IsFiveOfAKindWithJoker(hand, jokerCount) => Rank.FiveOfAKind,
                    var _ when IsFourOfAKindWithJoker(hand, jokerCount) => Rank.FourOfAKind,
                    var _ when IsFullHouseWithJoker(hand, jokerCount) => Rank.FullHouse,
                    var _ when IsThreeOfAKindWithJoker(hand, jokerCount) => Rank.ThreeOfAKind,
                    var _ when IsTwoPairWithJoker(hand, jokerCount) => Rank.TwoPair,
                    _ => Rank.OnePair,
                };
            }
        }

        private static int CountJokers(string hand)
        {
            int jokers = 0;
            foreach (char x in hand)
            {
                if (x == 'J')
                {
                    jokers++;
                }
            }
            return jokers;
        }

        private static Rank AnalyzeHandWithoutJoker(string hand)
        {
            return true switch
            {
                var _ when IsFiveOfAKind(hand) => Rank.FiveOfAKind,
                var _ when IsFourOfAKind(hand) => Rank.FourOfAKind,
                var _ when IsFullHouse(hand) => Rank.FullHouse,
                var _ when IsThreeOfAKind(hand) => Rank.ThreeOfAKind,
                var _ when IsTwoPair(hand) => Rank.TwoPair,
                var _ when IsOnePair(hand) => Rank.OnePair,
                _ => Rank.HighCard,
            };
        }

        private static bool IsFiveOfAKind(string hand)
        {
            if (hand[0] == hand[1] && hand[1] == hand[2] && hand[2] == hand[3] && hand[3] == hand[4])
            {
                return true;
            }
            return false;
        }

        private static bool IsFourOfAKind(string hand)
        {
            char[] charArray = GetSortedCharArray(hand);
            for (int i = 0; i <= charArray.Length - 4; i++)
            {
                if (charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2] && charArray[i + 2] == charArray[i + 3])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsFullHouse(string hand)
        {
            char[] charArray = GetSortedCharArray(hand);
            if ((charArray[0] == charArray[1] && charArray[1] == charArray[2] && charArray[3] == charArray[4]) || (charArray[0] == charArray[1] && charArray[2] == charArray[3] && charArray[3] == charArray[4]))
            {
                return true;
            }
            return false;
        }

        private static bool IsThreeOfAKind(string hand)
        {
            char[] charArray = GetSortedCharArray(hand);
            for (int i = 0; i <= charArray.Length - 3; i++)
            {
                if (charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsTwoPair(string hand)
        {
            char[] charArray = GetSortedCharArray(hand);

            if(charArray[0] == charArray[1] || charArray[1] == charArray[2])
            {
                if(charArray[2] == charArray[3] || charArray[3] == charArray[4])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsOnePair(string hand)
        {
            char[] charArray = GetSortedCharArray(hand);
            for (int i = 0; i <= charArray.Length - 2; i++)
            {
                if (charArray[i] == charArray[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static char[] GetSortedCharArray(string hand)
        {
            char[] charArray = new char[5];
            for (int i = 0; i < hand.Length; i++)
            {
                charArray[i] = hand[i];
            }
            Array.Sort(charArray);
            return charArray;
        }




        // TODO!!!!!!!!!!!!!

        private static bool IsFiveOfAKindWithJoker(string hand, int jokerCount)
        {
            if (jokerCount > 3)
            {
                return true;
            }
            else if (jokerCount == 3)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 2; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            else if (jokerCount == 2)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 3; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            else if (jokerCount == 1)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 4; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2] && charArray[i + 2] == charArray[i + 3] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            return false;
                
        }
        
        private static bool IsFourOfAKindWithJoker(string hand, int jokerCount)
        {
            if (jokerCount > 2)
            {
                return true;
            }
            else if (jokerCount == 2)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 2; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            else if (jokerCount == 1)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 3; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsFullHouseWithJoker(string hand, int jokerCount)
        {
            if (jokerCount == 1)
            {
                char[] charArray = GetSortedCharArray(hand);

                if((charArray[0] == charArray[1] || charArray[1] == charArray[2]) && charArray[1] != 'J')
                {
                    if((charArray[2] == charArray[3] || charArray[3] == charArray[4]) && charArray[3] != 'J')
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private static bool IsThreeOfAKindWithJoker(string hand, int jokerCount)
        {
            if (jokerCount < 2)
            {
                char[] charArray = GetSortedCharArray(hand);

                for (int i = 0; i <= charArray.Length - 2; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        private static bool IsTwoPairWithJoker(string hand, int jokerCount)
        {
            if (jokerCount == 1)
            {
                char[] charArray = GetSortedCharArray(hand);
                for (int i = 0; i <= charArray.Length - 2; i++)
                {
                    if (charArray[i] == charArray[i + 1] && charArray[i] != 'J')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }


    public enum Rank
    {
        FiveOfAKind = 7,    // AAAAA
        FourOfAKind = 6,    // AA8AA
        FullHouse = 5,      // 23332
        ThreeOfAKind = 4,   // TTT98
        TwoPair = 3,        // 23432
        OnePair = 2,        // A23A4
        HighCard = 1,       // 98765
    }
}