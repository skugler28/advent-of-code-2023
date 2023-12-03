using System;
using System.Collections.Generic;
using System.IO;
using adventofcode2023;

class Program
{
    static void Main()
    {
        string[] lines;
        Console.WriteLine("testdata? => print (y) ");
        string testdata = "" + System.Console.ReadLine();
        if (testdata == "y")
        {
            lines = File.ReadAllLines("test_input.txt");
        }
        else
        {
            lines = File.ReadAllLines("input.txt");
        }

        var solution = new Solution();
        System.Console.WriteLine(solution.SolutionOfFirstPart(lines));
        // System.Console.WriteLine(solution.SolutionOfSecondPart(lines));

    }
}
