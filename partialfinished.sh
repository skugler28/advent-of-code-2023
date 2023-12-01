#!/bin/zsh

# Benutzereingabe für den Tag
echo "Geben Sie den Tag für Advent of Code ein:"
read -r day_number

# Advent of Code Ordner erstellen
folder_name="adventofcode${day_number}"

# Folder zu Git hinzufügen
git add $folder_name

# Commit erstellen
git commit -m "partial working - day $day_number"

# Den Commit pushen
git push

# Nachricht ausgeben
echo "Advent of Code Projekt für Tag $day_number gepusht!"