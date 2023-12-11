

using System.Diagnostics;

namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            string[] newUniverse = ExpandUniverse(lines);
            Dictionary<int, Location> map = GetGalaxies(newUniverse);

            return "Part 1: " + CalculateSolution(map).ToString();
        }

        private static int CalculateSolution(Dictionary<int, Location> map)
        {
            int solution = 0;

            for (int i = 0; i < map.Count - 1; i++)
            {
                for (int j = i + 1; j < map.Count; j++)
                {
                    int deltaX = map[j].X - map[i].X;
                    int deltaY = map[j].Y - map[i].Y;

                    // <6,1> - <11,5> = 9
                    int distance = Math.Abs(deltaX) + Math.Abs(deltaY);
                    solution += distance;
                }
            }

            return solution;
        }

        private static Dictionary<int, Location> GetGalaxies(string[] newUniverse)
        {
            Dictionary<int, Location> map = new();
            int galaxyCounter = 0;
            for (int j = 0; j < newUniverse.Length; j++)
            {
                for (int i = 0; i < newUniverse[j].Length; i++)
                {
                    if (newUniverse[j][i] == '#')
                    {
                        Location location = new()
                        {
                            X = i,
                            Y = j
                        };
                        map.Add(galaxyCounter, location);
                        galaxyCounter++;
                    }
                }
            }
            return map;
        }

        private static string[] ExpandUniverse(string[] lines)
        {
            int debugvalue = 0;
            // Vertical duplication
            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines[0].Length; i++)
            {
                bool containsHash = false;

                // Check if '#' is present in the entire vertical column
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '#')
                    {
                        containsHash = true;
                        break;
                    }
                }

                // reguläres anhängen
                for (int j = 0; j < lines.Length; j++)
                {
                    // anhängen extra
                    newLines[j] += lines[j][i];
                }

                // If no '#' is found, duplicate the entire column
                if (!containsHash)
                {
                    debugvalue++;
                    for (int j = 0; j < lines.Length; j++)
                    {
                        newLines[j] += lines[j][i];
                    }
                }
            }
            Debug.WriteLine(debugvalue);
            debugvalue = 0;
            // Horizontal duplication
            List<string> expandedLines = new();
            foreach (string line in newLines)
            {
                expandedLines.Add(line);

                if (!line.Contains('#'))
                {
                    expandedLines.Add(line);
                    debugvalue++;
                }
            }
            Debug.WriteLine(debugvalue);
            return expandedLines.ToArray();
        }



        public static string SolutionOfSecondPart(string[] lines)
        {
            // die zeilen und stellen merken wo expanded wird und dann beim calculieren schauen ob diese line überschnitten wird
            ExpandUniversePositions(lines, out List<double> expandedRows, out List<double> expandedColumns);
            Dictionary<int, Location> map = GetGalaxies(lines);

            return "Part 2: " + CalculateSolutionExpanded(map, expandedColumns, expandedRows).ToString();
        }

        private static object CalculateSolutionExpanded(Dictionary<int, Location> map, List<double> expandedColumns, List<double> expandedRows)
        {
            ulong solution = 0;

            for (int i = 0; i < map.Count - 1; i++)
            {
                for (int j = i + 1; j < map.Count; j++)
                {
                    Debug.WriteLine("DISTANCE: " + i + " <" + map[i].X + "," + map[i].Y+"> - "+j+" <" + map[j].X + "," + map[j].Y + ">");
                    int deltaX = map[j].X - map[i].X;
                    int deltaY = map[j].Y - map[i].Y;
                    ulong expandedDistance = 0;

                    Debug.WriteLine("X-values: " + map[i].X + "->" + map[j].X);
                    foreach (double expandedColumn in expandedColumns)
                    {
                        Debug.WriteLine("expandedColumn: " + expandedColumn);
                        if ((map[i].X <= expandedColumn && map[j].X >= expandedColumn) || (map[j].X <= expandedColumn && map[i].X >= expandedColumn))
                        {
                            Debug.WriteLine("is in expandedColumn: add 9");
                            expandedDistance += 999999;
                        }
                    }

                    Debug.WriteLine("Y-values: " + map[i].Y+ "->" + map[j].Y);
                    foreach (double expandedRow in expandedRows)
                    {
                        Debug.WriteLine("expandedRow: " + expandedRow);
                        if ((map[i].Y <= expandedRow && map[j].Y >= expandedRow) || (map[j].Y <= expandedRow && map[i].Y >= expandedRow))
                        {
                            Debug.WriteLine("is in expandedRow: add 9");
                            expandedDistance += 999999;
                        }
                    }

                    // <0,3> - <1,7> = 5
                    // <6,1> - <11,5> = 9
                    int distance = Math.Abs(deltaX) + Math.Abs(deltaY);
                    solution += (ulong)distance + expandedDistance;
                    //Debug.WriteLine("DISTANCE without exp: " + distance + " | DISwithEXP: " + (distance + expandedDistance));
                    Debug.WriteLine("solution: " + solution);
                    Debug.WriteLine("");
                }
            }

            return solution;
        }

        private static void ExpandUniversePositions(string[] lines, out List<double> expandedRows, out List<double> expandedColumns)
        {
            expandedRows = new();
            expandedColumns = new();

            int debugvalue = 0;
            // Vertical duplication

            for (int i = 0; i < lines[0].Length; i++)
            {
                bool containsHash = false;

                // Check if '#' is present in the entire vertical column
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '#')
                    {
                        containsHash = true;
                        break;
                    }
                }

                // If no '#' is found, duplicate the entire column
                if (!containsHash)
                {
                    debugvalue++;
                    expandedColumns.Add((double)i);
                }
            }
            Debug.WriteLine(debugvalue);
            debugvalue = 0;
            // Horizontal duplication
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (!line.Contains('#'))
                {
                    expandedRows.Add((double)i);
                    debugvalue++;
                }
            }
            Debug.WriteLine(debugvalue);

        }
    }
}
