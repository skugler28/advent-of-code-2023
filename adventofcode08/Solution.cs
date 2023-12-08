
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2023;

namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            int solution = 0;

            char[] directionInstruction = GenerateDirectionInstruction(ref lines[0]);
            Dictionary<string, Direction> map = GenerateDirectionMap(ref lines);

            GetTroughtTheMap(ref directionInstruction, ref map, ref solution);

            return solution.ToString();
        }

        private bool GetTroughtTheMap(ref char[] directionInstruction, ref Dictionary<string, Direction> map, ref int solution, string location = "AAA", int index = 0)
        {
            if(index == directionInstruction.Length)
            {
                index = 0;
            }
            if (location == "ZZZ")
            {
                return true;
            }
            else 
            {
                solution++;
                if (directionInstruction[index] == 'L')
                {
                    return GetTroughtTheMap(ref directionInstruction, ref map, ref solution, map[location].Left, index + 1);
                }
                else
                {
                    return GetTroughtTheMap(ref directionInstruction, ref map, ref solution, map[location].Right, index + 1);
                }
            }
        }

        private Dictionary<string, Direction> GenerateDirectionMap(ref string[] lines)
        {
            Dictionary<string, Direction> map = new();
            for (int i = 2; i < lines.Length; i++)
            {
                AddThisLine(lines[i], ref map);
            }
            return map;
        }

        private void AddThisLine(string line, ref Dictionary<string, Direction> map)
        {
            map.Add(line[..3], new Direction
            {
                Left = line.Substring(7, 3),
                Right = line.Substring(12, 3)
            });
            Debug.WriteLine(line[..3] + " " + line.Substring(7, 3) + " " + line.Substring(12, 3));
        }

        private char[] GenerateDirectionInstruction(ref string line)
        {
            return line.ToCharArray();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            string solution = "";

            // Hier kommt die Logik für den zweiten Teil hin

            return solution;
        }
    }
}
