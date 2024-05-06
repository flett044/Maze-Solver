# Recursion to solve a maze
## Description

This program recursively solves a maze stored as an array. It assumes that the maze has an exit and is unable to tell if there is not an exit. In addition to solving the maze as is, it will solve a transposition of the maze.

Each spot in the maze is represented by either a '#' or a '.' (dot). The #'s represent the walls of the maze, and the dots represent paths through the maze. Moves can be made only up, down, left, or right (not diagonally), one spot at a time, and only over paths (not into or across a wall).

The exit will be any spot that is on the outside of the array. The program attempts to find a path leading to the exit, it will place the character 'X' in each spot along the path. If a dead end is reached, the program will replace the X’s with '0'. But, the spots with '0' should be marked back to 'X' if these spots are part of a successful path leading to a final state.

## Screen Shots
https://imgur.com/knoPAel

