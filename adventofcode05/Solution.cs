namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            List<long> seeds = new();
            List<long> locations = new();
            foreach (string seed in lines[0].Split(":")[1].Split(" ").Skip(1))
                seeds.Add(long.Parse(seed));

            foreach (long seed in seeds)
                locations.Add(CalcLocation(lines, seed));

            return locations.Min().ToString();
        }

        private static long CalcLocation(string[] lines, long seed)
        {
            int lineCounter = 3;
            while (lineCounter < lines.Length)
            {
                seed = CalcNew(lines, ref lineCounter, seed);
                while (lineCounter < lines.Length && lines[lineCounter] != "")
                    lineCounter++;
                lineCounter += 2;
            }
            return seed;
        }

        private static long CalcNew(string[] lines, ref int lineCounter, long seed)
        {
            long destinationRangeStart, sourceRangeStart, rangeLength;
            while (lineCounter < lines.Length && lines[lineCounter] != "")
            {
                destinationRangeStart = long.Parse(lines[lineCounter].Split(" ")[0]);
                sourceRangeStart = long.Parse(lines[lineCounter].Split(" ")[1]);
                rangeLength = long.Parse(lines[lineCounter].Split(" ")[2]);
                if (seed >= sourceRangeStart && seed < sourceRangeStart + rangeLength)
                    return seed - sourceRangeStart + destinationRangeStart;

                lineCounter++;
            }
            return seed;
        }

        public static string SolutionOfSecondPart(string[] lines)
        {
            long[] seedlist = ParseArrayStringToLong(lines[0].Split(":")[1].Split(" ").Skip(1).ToArray());

            List<long[]> seedToSoil = GenerateMap("seed-to-soil map:", lines);
            List<long[]> soiLToFertilizer = GenerateMap("soil-to-fertilizer map:", lines);
            List<long[]> fertilizerToWater = GenerateMap("fertilizer-to-water map:", lines);
            List<long[]> waterToLight = GenerateMap("water-to-light map:", lines);
            List<long[]> lightToTemperature = GenerateMap("light-to-temperature map:", lines);
            List<long[]> temperatureToHumidity = GenerateMap("temperature-to-humidity map:", lines);
            List<long[]> humidityToLocation = GenerateMap("humidity-to-location map:", lines);

            long tmp;

            for (long i = 0; i < long.MaxValue; i++)
            {
                tmp = ReverseCalcWithMap(humidityToLocation, i);
                tmp = ReverseCalcWithMap(temperatureToHumidity, tmp);
                tmp = ReverseCalcWithMap(lightToTemperature, tmp);
                tmp = ReverseCalcWithMap(waterToLight, tmp);
                tmp = ReverseCalcWithMap(fertilizerToWater, tmp);
                tmp = ReverseCalcWithMap(soiLToFertilizer, tmp);
                tmp = ReverseCalcWithMap(seedToSoil, tmp);
                if (CheckSeedInRange(tmp, seedlist)) return i.ToString();
            }

            return "something went wrong";
        }

        private static long[] ParseArrayStringToLong(string[] strings)
        {
            long[] result = new long[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                result[i] = long.Parse(strings[i]);
            }
            return result;
        }

        private static bool CheckSeedInRange(long seed, long[] seedlist)
        {

            for (int i = 0; i < seedlist.Length - 1; i += 2)
            {
                if (seed >= seedlist[i] && seed < seedlist[i] + seedlist[i + 1])
                    return true;
            }
            return false;
        }

        private static long ReverseCalcWithMap(List<long[]> seedMap, long seed)
        {
            foreach (long[] rules in seedMap)
            {
                if (seed >= rules[0] && seed < rules[0] + rules[2])
                    return seed - rules[0] + rules[1];
            }
            return seed;
        }


        private static List<long[]> GenerateMap(string startphrase, string[] lines)
        {
            List<long[]> result = new();
            int lineCounter = 0;
            long[] tmp;
            while (lines[lineCounter] != startphrase) lineCounter++;
            lineCounter++;
            while (lineCounter < lines.Length && lines[lineCounter] != "")
            {
                tmp = new long[3];
                tmp[0] = long.Parse(lines[lineCounter].Split(" ")[0]);
                tmp[1] = long.Parse(lines[lineCounter].Split(" ")[1]);
                tmp[2] = long.Parse(lines[lineCounter].Split(" ")[2]);
                result.Add(tmp);
                lineCounter++;
            }
            return result;
        }
    }
}