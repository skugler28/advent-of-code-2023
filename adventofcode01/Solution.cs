using System;
using System.Data;
using System.Text.RegularExpressions;

namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int finalCounter = 0;

            foreach (string line in lines)
            {
                char[] lineLetters = line.ToCharArray();
                string resultThisRound = FirstNumberOfLine(lineLetters, out int index) + LastNumberOfLine(lineLetters, out int index2);
                if(resultThisRound != "")
                {
                    finalCounter += Convert.ToInt32(resultThisRound);
                }
                
            }
            return finalCounter.ToString();
        }




        public string SolutionOfSecondPart(string[] lines)
        {
            int finalCounter = 0;

            foreach (string line in lines)
            {
                char[] lineLetters = line.ToCharArray();
                string resultThisRound = CheckForWordBefore(ref lineLetters, FirstNumberOfLine(lineLetters, out int index), index) + CheckForWordAfter(ref lineLetters, LastNumberOfLine(lineLetters, out int index2), index2);

                if(resultThisRound != "")
                {
                    finalCounter += Convert.ToInt32(resultThisRound);
                }
            }

            return finalCounter.ToString();
        }



        private string CheckForWordBefore(ref char[] line, string digitNumber, int index)
        {
            if(!(digitNumber != "" && index == 0))
            {
                if(index == 0)
                {
                    index = line.Length - 1;
                }
                string preLine = "";
                for (int i = 0; i <= index; i++)
                {
                    preLine += line[i].ToString();
                }
                while(preLine.Length >= 3)
                {
                    if(preLine.StartsWith("one"))
                    {
                        return "1";
                    }
                    else if(preLine.StartsWith("two"))
                    {
                        return "2";
                    }
                    else if(preLine.StartsWith("three"))
                    {
                        return "3";
                    }
                    else if(preLine.StartsWith("four"))
                    {
                        return "4";
                    }
                    else if(preLine.StartsWith("five"))
                    {
                        return "5";
                    }
                    else if(preLine.StartsWith("six"))
                    {
                        return "6";
                    }
                    else if(preLine.StartsWith("seven"))
                    {
                        return "7";
                    }
                    else if(preLine.StartsWith("eight"))
                    {
                        return "8";
                    }
                    else if(preLine.StartsWith("nine"))
                    {
                        return "9";
                    }
                    else
                    {
                        string tmp = preLine.Remove(0, 1);
                        preLine = tmp;
                    }
                }

            }
            return digitNumber;
        }

        private string CheckForWordAfter(ref char[] line, string digitNumber, int index)
        {
            if(!(digitNumber != "" && index == line.Length-1))
            {
                string preLine = "";
                for (int i = index; i <= line.Length-1; i++)
                {
                    preLine += line[i].ToString();
                }
                while(preLine.Length >= 3)
                {
                    if(preLine.EndsWith("one"))
                    {
                        return "1";
                    }
                    else if(preLine.EndsWith("two"))
                    {
                        return "2";
                    }
                    else if(preLine.EndsWith("three"))
                    {
                        return "3";
                    }
                    else if(preLine.EndsWith("four"))
                    {
                        return "4";
                    }
                    else if(preLine.EndsWith("five"))
                    {
                        return "5";
                    }
                    else if(preLine.EndsWith("six"))
                    {
                        return "6";
                    }
                    else if(preLine.EndsWith("seven"))
                    {
                        return "7";
                    }
                    else if(preLine.EndsWith("eight"))
                    {
                        return "8";
                    }
                    else if(preLine.EndsWith("nine"))
                    {
                        return "9";
                    }
                    else
                    {
                        string tmp = preLine.Remove(preLine.Length - 1);
                        preLine = tmp;
                    }
                }

            }
            return digitNumber;
        }




        private static string FirstNumberOfLine(char[] inputline, out int index)
        {
            for (int counter = 0; counter < inputline.Length; counter++)
            {
                string charToCheck = Convert.ToString(inputline[counter]);
                if (char.IsDigit(charToCheck[0]))
                {
                    index = counter;
                    return charToCheck;
                }
            }
            index = 0;
            return "";
        }
        private static string LastNumberOfLine(char[] inputline, out int index)
        {
            for (int counter = inputline.Length - 1; counter >= 0; counter--)
            {
                string charToCheck = Convert.ToString(inputline[counter]);
                if (char.IsDigit(charToCheck[0]))
                {
                    index = counter;
                    return charToCheck;
                }
            }
            index = 0;
            return "";
        }
    }
}
