using System;

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
                finalCounter += Convert.ToInt32(FirstNumberOfLine(lineLetters) + LastNumberOfLine(lineLetters));
            }

            return finalCounter.ToString();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            // Hier kommt die Logik für den zweiten Teil hin
            return ""; // Placeholder
        }

        private static string FirstNumberOfLine(char[] inputline)
        {
            for (int counter = 0; counter < inputline.Length; counter++)
            {
                string charToCheck = Convert.ToString(inputline[counter]);
                if (char.IsDigit(charToCheck[0]))
                {
                    return charToCheck;
                }
            }
            System.Console.WriteLine("Couldn't find any number in string!");
            return "";
        }

        private static string LastNumberOfLine(char[] inputline)
        {
            for (int counter = inputline.Length - 1; counter >= 0; counter--)
            {
                string charToCheck = Convert.ToString(inputline[counter]);
                if (char.IsDigit(charToCheck[0]))
                {
                    return charToCheck;
                }
            }
            System.Console.WriteLine("Couldn't find any number in string!");
            return "";
        }
    }
}
