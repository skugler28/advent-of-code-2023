namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] allInputLines)
        {
            int sum = 0;

            foreach (string singleLine in allInputLines)
            {
                char[] allLettersOfThisLine = singleLine.ToCharArray();
                string resultOfThisRound = GetFirstNumberInLine(allLettersOfThisLine, out int indexOfFirstNumber) + GetLastNumberInLine(allLettersOfThisLine, out int indexOfLastNumber);
                if(resultOfThisRound != "")
                {
                    sum += Convert.ToInt32(resultOfThisRound);
                }
            }
            return sum.ToString();
        }

        public string SolutionOfSecondPart(string[] allInputLines)
        {
            int sum = 0;

            foreach (string singleLine in allInputLines)
            {
                char[] allLettersOfThisLine = singleLine.ToCharArray();
                string resultOfThisRound = CheckForWordBefore(ref allLettersOfThisLine, GetFirstNumberInLine(allLettersOfThisLine, out int indexOfFirstNumber), indexOfFirstNumber) + CheckForWordAfter(ref allLettersOfThisLine, GetLastNumberInLine(allLettersOfThisLine, out int indexOfLastNumber), indexOfLastNumber);
                if(resultOfThisRound != "")
                {
                    sum += Convert.ToInt32(resultOfThisRound);
                }
            }
            return sum.ToString();
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
                    string? possibleStartingNumber = GetPossibleNumberBeforeStartingNumber(preLine);
                    if (possibleStartingNumber != null)
                    {
                        return possibleStartingNumber;
                    }
                    string tmp = preLine.Remove(0, 1);
                    preLine = tmp;
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
                    string? possibleEndingNumber = GetPossibleNumberAfterEndingNumber(preLine);
                    if (possibleEndingNumber != null)
                    {
                        return possibleEndingNumber;
                    }
                    string tmp = preLine.Remove(preLine.Length - 1);
                    preLine = tmp;
                }
            }
            return digitNumber;
        }

        private static string? GetPossibleNumberAfterEndingNumber(string preLine)
        {
            return GetPossibleNumber(preLine, fromStart: false);
        }
        
        private static string? GetPossibleNumberBeforeStartingNumber(string preLine)
        {
            return GetPossibleNumber(preLine, fromStart: true);
        }

        private static string? GetPossibleNumber(string line, bool fromStart){
            string[] possibleValues = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            foreach(string value in possibleValues )
            {
                if(fromStart && line.StartsWith(value))
                {
                    return Convert.ToString(Array.IndexOf(possibleValues, value) + 1);
                }
                else if (!fromStart && line.EndsWith(value))
                {
                    return Convert.ToString(Array.IndexOf(possibleValues, value) + 1);
                }
            }
            return null;
        }

        private static string GetFirstNumberInLine(char[] inputLine, out int index)
        {
            return GetNumberInLine(inputLine, out index, fromStart: true);
        }

        private static string GetLastNumberInLine(char[] inputLine, out int index)
        {
            return GetNumberInLine(inputLine, out index, fromStart: false);
        }

        private static string GetNumberInLine(char[] inputLine, out int index, bool fromStart)
        {
            int start = fromStart ? 0 : inputLine.Length - 1;
            int step = fromStart ? 1 : -1;

            for (int counter = start; counter >= 0 && counter < inputLine.Length; counter += step)
            {
                string charToCheck = Convert.ToString(inputLine[counter]);
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