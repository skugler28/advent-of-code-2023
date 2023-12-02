namespace adventofcode2023
{
    public class Solution
    {
        public static string SolutionOfFirstPart(string[] lines)
        {
            int sumOfIds = 0;

            foreach (string game in lines)
            {
                int redCubes = 12;
                int greenCubes = 13;
                int blueCubes = 14;
                int gameID = 0;
                bool gameIsPossible = true;

                string[] cubes = game.Split(',', ';', ':');

                foreach (string cube in cubes)
                {
                    if (cube == cubes[0])
                    {
                        gameID = Convert.ToInt32(cube[5..]);
                    }
                    else
                    {
                        string[] drawing = cube.Split(' ');
                        if (drawing[0] != "")
                        {
                            throw new System.Exception("drawing[0] is not empty");
                        }
                        switch (drawing[2])
                        {
                            case "red":
                                if (redCubes < Convert.ToInt32(drawing[1]))
                                {
                                    gameIsPossible = false;
                                }
                                break;
                            case "green":
                                if (greenCubes < Convert.ToInt32(drawing[1]))
                                {
                                    gameIsPossible = false;
                                }
                                break;
                            case "blue":
                                if (blueCubes < Convert.ToInt32(drawing[1]))
                                {
                                    gameIsPossible = false;
                                }
                                break;
                        }
                    }
                    if (redCubes < 0 || greenCubes < 0 || blueCubes < 0)
                    {
                        gameIsPossible = false;
                    }
                    if (!gameIsPossible)
                    {
                        break;
                    }
                }

                if (gameIsPossible)
                {
                    sumOfIds += gameID;
                }
            }
            return sumOfIds.ToString();
        }

        public static string SolutionOfSecondPart(string[] lines)
        {
            int powerOfBalls = 0;

            foreach (string game in lines)
            {
                int redCubes = 0;
                int greenCubes = 0;
                int blueCubes = 0;

                string[] cubes = game.Split(';', ':'); // ','

                foreach (string cube in cubes)
                {
                    if (cube == cubes[0])
                    {
                        continue;
                    }
                    else
                    {
                        string[] pulls = cube.Split(',');
                        foreach (string pull in pulls)
                        {
                            string[] drawing = pull.Split(' ');
                            if (drawing[0] != "")
                            {
                                Console.WriteLine(drawing[0]);
                                throw new System.Exception("drawing[0] is not empty");
                            }
                            switch (drawing[2])
                            {
                                case "red":
                                    if (redCubes < Convert.ToInt32(drawing[1]))
                                    {
                                        redCubes = Convert.ToInt32(drawing[1]);
                                    }
                                    break;
                                case "green":
                                    if (greenCubes < Convert.ToInt32(drawing[1]))
                                    {
                                        greenCubes = Convert.ToInt32(drawing[1]);
                                    }
                                    break;
                                case "blue":
                                    if (blueCubes < Convert.ToInt32(drawing[1]))
                                    {
                                        blueCubes = Convert.ToInt32(drawing[1]);
                                    }
                                    break;
                            }
                        }
                    }
                }
                powerOfBalls += redCubes * greenCubes * blueCubes;
            }
            return powerOfBalls.ToString();
        }
    }
}
