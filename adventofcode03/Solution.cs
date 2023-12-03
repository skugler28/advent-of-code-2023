using System.ComponentModel.Design;
using System.Diagnostics;

namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines, out List<NumberObject> numberList)
        {
            bool iWannaDebugThis = false;
            int solution = 0;
            int localline = 0;
            numberList = new();

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string singleLine = lines[lineIndex];

                for (int charIndex = 0; charIndex < singleLine.Length; charIndex++)
                {
                    if (CheckifNumber(singleLine[charIndex]))
                    {
                        CollectNumber(singleLine, charIndex, out int length);
                        numberList.Add(new NumberObject
                        {
                            Number = int.Parse(singleLine.Substring(charIndex, length)),
                            Line = localline,
                            Index = charIndex,
                            Length = length,
                            Status = false,
                            Gear = false
                        });
                        charIndex += length - 1;
                    }
                }
                localline++;
            }

            foreach (NumberObject numberObject in numberList)
            {
                // Checke horizontal
                Debug.WriteLineIf(iWannaDebugThis, "links");
                CheckNeighborIfSymbol(numberObject, 0, -1, ref lines); // links
                Debug.WriteLineIf(iWannaDebugThis, "rechts");
                CheckNeighborIfSymbol(numberObject, 0, numberObject.Length, ref lines); // rechts


                // Checke vertikal
                Debug.WriteLineIf(iWannaDebugThis, "unten");
                for (int i = 0; i < numberObject.Length; i++)
                {
                    CheckNeighborIfSymbol(numberObject, 1, i, ref lines); // unten
                }
                Debug.WriteLineIf(iWannaDebugThis, "oben");
                for (int i = 0; i < numberObject.Length; i++)
                {
                    CheckNeighborIfSymbol(numberObject, -1, i, ref lines); // oben
                }

                // Checke diagonal
                Debug.WriteLineIf(iWannaDebugThis, "unten rechts");
                CheckNeighborIfSymbol(numberObject, 1, numberObject.Length, ref lines); // unten rechts
                Debug.WriteLineIf(iWannaDebugThis, "oben links");
                CheckNeighborIfSymbol(numberObject, -1, -1, ref lines); // oben links
                Debug.WriteLineIf(iWannaDebugThis, "unten links");
                CheckNeighborIfSymbol(numberObject, 1, -1, ref lines); // unten links
                Debug.WriteLineIf(iWannaDebugThis, "unten rechts");
                CheckNeighborIfSymbol(numberObject, -1, numberObject.Length, ref lines); // oben rechts
            
                Debug.WriteLineIf(iWannaDebugThis, $"Number: {numberObject.Number} Line: {numberObject.Line} Index: {numberObject.Index} Length: {numberObject.Length} Status: {numberObject.Status} \n");
            }


            foreach (NumberObject numberObject in numberList)
            {
                if (numberObject.Status || numberObject.Gear)
                {
                    solution += numberObject.Number;
                }
            }
            return solution.ToString();
        }

        private static void CheckNeighborIfSymbol(NumberObject numberObject, int offsetRowIndex, int offsetCharIndex, ref string[] lines)
        {
            bool iWannaDebugThis = false;
            int rowIndex = numberObject.Line + offsetRowIndex;
            int charIndex = numberObject.Index + offsetCharIndex;
            if (rowIndex < 0 || rowIndex >= lines.Length)
            {
                return;
            }
            if (charIndex < 0 || charIndex >= lines[rowIndex].Length)
            {
                return;
            }
            Debug.WriteLineIf(iWannaDebugThis, $"     this is the char: {lines[rowIndex][charIndex]}");
            if(lines[rowIndex][charIndex] == '*')
            {
                numberObject.Gear = true;
                numberObject.GearCords = new GearSet
                {
                    GearLine = rowIndex,
                    GearIndex = charIndex
                };
            }
            else if (lines[rowIndex][charIndex] != '.' && !char.IsDigit(lines[rowIndex][charIndex]))
            {
                numberObject.Status = IsValid();
            }
        }



        private static int CollectNumber(string line, int i, out int length)
        {
            length = 1;
            while (i + length < line.Length && char.IsDigit(line[i + length]))
            {
                length++;
            }
            return int.Parse(line.Substring(i, length));
        }

        private static bool CheckifNumber(char v)
        {
            return char.IsDigit(v);
        }
        private static bool IsValid()
        {
            return true;
        }











        public string SolutionOfSecondPart(string[] lines, List<NumberObject> numberList)
        {
            bool iWannaDebugThis = true;
            int solution = 0;

            for (int i = numberList.Count - 1; i >= 0; i--)
            {
                NumberObject numberObject = numberList[i];
                if (numberObject.Status || !numberObject.Gear)
                {
                    numberList.RemoveAt(i);
                }
                
            }

            List<NumberObject> gearList = numberList.Where(x => x.Gear).ToList();
            const int nullIndexOfList = 0;
            while ( nullIndexOfList <= gearList.Count - 1)
            {
                NumberObject numberObject = gearList[nullIndexOfList];
                Debug.WriteLineIf(iWannaDebugThis, $"{numberObject.Number}");
                if (numberObject.Gear)
                {
                    NumberObject otherPart = gearList.FirstOrDefault(x =>
                        x.GearCords.GearLine == numberObject.GearCords.GearLine &&
                        x.GearCords.GearIndex == numberObject.GearCords.GearIndex &&
                        (x.Index != numberObject.Index ||
                        x.Line != numberObject.Line))!;

                    if (otherPart != null)
                    {
                        Debug.WriteLineIf(iWannaDebugThis, $"{numberObject.Number} * {otherPart.Number}");
                        solution += (numberObject.Number * otherPart.Number);

                        // Lösche die beiden Objekte aus der Liste
                        gearList.RemoveAt(nullIndexOfList);
                        gearList.Remove(otherPart);
                    }
                    else
                    {
                        gearList.RemoveAt(nullIndexOfList);
                    }
                }
            }

            return solution.ToString();

        }
    }
}
