

using System.Diagnostics;
using System.Net.Security;

namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            FindSInInput(lines, out int x, out int y);
            if(x == -1 || y == -1) return "S not found";
            int steps = 1;
            GoTroughLoop(lines, x, y, ref steps, true);

            Debug.WriteLineIf(true, steps);

            return (steps/2).ToString();
        }

        private static int GoTroughLoop(string[] lines, int x, int y, ref int steps, bool isStart = false)
        {
            Debug.WriteLineIf(false, steps);
            // direction: 0 = up, 1 = right, 2 = down, 3 = left

            // | = vertical connection
            // - = horizontal connection
            // L = top, right
            // J = top, left
            // 7 = bottom, left
            // F = bottom, right
            // . = empty

            // lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
            Debug.WriteLineIf(false, " ");
            Debug.WriteLineIf(false, "now at: " + lines[y][x]);
            // Debug.WriteLineIf(false, "oben: " + lines[y-1][x]);
            // Debug.WriteLineIf(false, "rechts: " + lines[y][x+1]);
            // Debug.WriteLineIf(false, "unten: " + lines[y+1][x]);
            // Debug.WriteLineIf(false, "links: " + lines[y][x-1]);


            if (!isStart && lines[y][x] == 'S')
            {
                return steps;
            }
            if (isStart)
            {
                // lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
                if (lines[y-1][x] == '|' || lines[y-1][x] == '7' || lines[y-1][x] == 'F')
                {
                    Debug.WriteLineIf(false, "oben");
                    steps++;
                    return GoTroughLoop(lines, x, y-1, ref steps);
                }
                else if (lines[y][x+1] == '-' || lines[y][x+1] == 'J' || lines[y][x+1] == '7')
                {
                    Debug.WriteLineIf(false, "rechts");
                    steps++;
                    return GoTroughLoop(lines, x+1, y, ref steps);
                }
                else if (lines[y+1][x] == '|' || lines[y+1][x] == 'L' || lines[y+1][x] == 'J')
                {
                    Debug.WriteLineIf(false, "unten");
                    steps++;
                    return GoTroughLoop(lines, x, y+1, ref steps);
                }
                else if (lines[y][x-1] == '-' || lines[y][x-1] == 'L' || lines[y][x-1] == 'F')
                {
                    Debug.WriteLineIf(false, "links");
                    steps++;
                    return GoTroughLoop(lines, x-1, y, ref steps);
                }
            }
            if (y > 0 && (lines[y-1][x] == '|' || lines[y-1][x] == '7' || lines[y-1][x] == 'F') && (lines[y][x] == 'J' || lines[y][x] == 'L' || lines[y][x] == '|' ))
            {
                Debug.WriteLineIf(false, "oben");
                lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
                steps++;
                return GoTroughLoop(lines, x, y-1, ref steps);
            }
            else if (x < lines[y].Length &&(lines[y][x+1] == '-' || lines[y][x+1] == 'J' || lines[y][x+1] == '7') && (lines[y][x] == '-' || lines[y][x] == 'L' || lines[y][x] == 'F' ))
            {
                Debug.WriteLineIf(false, "rechts");
                lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
                steps++;
                return GoTroughLoop(lines, x+1, y, ref steps);
            }
            else if (y < lines.Length && (lines[y+1][x] == '|' || lines[y+1][x] == 'L' || lines[y+1][x] == 'J') && (lines[y][x] == 'F' || lines[y][x] == '7' || lines[y][x] == '|' ))
            {
                Debug.WriteLineIf(false, "unten");
                lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
                steps++;
                return GoTroughLoop(lines, x, y+1, ref steps);
            }
            else if (x > 0 && (lines[y][x-1] == '-' || lines[y][x-1] == 'L' || lines[y][x-1] == 'F') && (lines[y][x] == '-' || lines[y][x] == '7' || lines[y][x] == 'J' ))
            {
                Debug.WriteLineIf(false, "links");
                lines[y] = lines[y].Remove(x, 1).Insert(x, "X");
                steps++;
                return GoTroughLoop(lines, x-1, y, ref steps);
            }
            return -1;
        }

        private static void FindSInInput(string[] lines, out int x, out int y)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains('S'))
                {
                    x = lines[i].IndexOf("S");
                    y = i;
                    return;
                }
            }

            // If 'S' is not found, set default values
            x = -1;
            y = -1;
        }





        public string SolutionOfSecondPart(string[] lines)
        {
            string solution = "";

            // Hier kommt die Logik für den zweiten Teil hin

            return solution;
        }
    }
}
