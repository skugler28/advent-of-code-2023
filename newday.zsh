#!/bin/zsh

# Benutzereingabe für den Tag
echo "Geben Sie den Tag für Advent of Code ein:"
read -r day_number

# Advent of Code Ordner erstellen
folder_name="adventofcode${day_number}"
mkdir "$folder_name"

# In den Ordner wechseln
cd "$folder_name"

# C# Dotnet Projekt erstellen
dotnet new console

# Leere txt Dateien erstellen
touch input.txt
touch test_input.txt

# Solution.cs erstellen
echo "namespace adventofcode2023 
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            string solution;

            // Hier kommt die Logik für den ersten Teil hin

            return solution;
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            string solution;

            // Hier kommt die Logik für den zweiten Teil hin

            return solution;
        }
    }
}" > Solution.cs

# Program.cs leeren und den gewünschten Code einfügen
echo "using System;
using System.Collections.Generic;
using System.IO;
using adventofcode2023;

class Program
{
    static void Main()
    {
        string[] lines;
        Console.WriteLine(\"testdata? => print (y) \");
        string testdata = \"\" + System.Console.ReadLine();
        if (testdata == \"y\")
        {
            lines = File.ReadAllLines(\"test_input.txt\");
        }
        else
        {
            lines = File.ReadAllLines(\"input.txt\");
        }

        var solution = new Solution();
        System.Console.WriteLine(solution.SolutionOfFirstPart(lines));
        // System.Console.WriteLine(solution.SolutionOfSecondPart(lines));

    }
}" > Program.cs

# Ins Überverzeichnis wechseln
cd ..

# Folder zu Git hinzufügen
git add "$folder_name"

# Commit erstellen
git commit -m "empty project init - day ${day_number}"

# Den Commit pushen
git push

# Nachricht ausgeben
echo "Advent of Code Projekt für Tag ${day_number} erstellt und gepusht!"

# In den Ordner wechseln und in VSCode öffnen
cd "$folder_name"
code .
