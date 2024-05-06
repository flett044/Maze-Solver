using System;
using System.Linq.Expressions;
using System.Resources;
using System.Threading.Tasks;

namespace cis237_assignment_2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Solves the maze starting at the passed X and Y cords.
        /// </summary>
        /// <param name="maze"></param>Maze to be solved
        /// <param name="xStart"></param>X value to start at
        /// <param name="yStart"></param>Y value to start at
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.

            // Holds bool value if maze is solved or not
            bool _isSolved = false;

            // Displays intial maze before solving
            this.DisplayMaze(maze, true);

            // Starts traversing the maze for an exit
            this.MazeTraversal(xStart, yStart, ref maze, ref _isSolved);
        }


        /// <summary>
        /// Recursively traverses the maze looking for an exit. Marks the path to the exit with X. Marks
        /// bad paths with an O. Each time it moves around in the maze it will print it current point. Prints the final
        /// cordinates of the exit. If no exit is found it will print an error message. 
        /// </summary>
        /// <param name="currentX"></param>X value the maze is currently checking
        /// <param name="currentY"></param>Y value the maze is currently checking
        /// <param name="maze"></param>Maze being traversed
        /// <param name="isSolved"></param>Bool flag stipulating if the maze has been solved
        private void MazeTraversal(int currentX, int currentY, ref char[,] maze, ref bool isSolved)
        {
            const char PATH_CHAR = '.';

            const char VALID_PATH_CHAR = 'X';

            const char INVALID_PATH_CHAR = 'O';

            // Holds the initial starting point.
            int startX = currentX;

            int startY = currentY;

            // Checks if maze is solved. If its not continue recursing. Stops all current recursion if solved
            if (!isSolved) 
            {
                // Mark current position with an X because it is valid
                maze[currentX, currentY] = VALID_PATH_CHAR;

                // Base Case. Checks if at exit point. Checks all 4 sides. If not an exit continue checking next point
                if ((currentY == 0) || // Check right boundry 
                    (currentY == maze.GetLength(1) - 1) || // Check left boundry
                    (currentX == 0) || // Check bottom boundry
                    (currentX == maze.GetLength(0) - 1)) // Check top boundry 
                {

                    // Marks the exit with an X
                    maze[currentX, currentY] = VALID_PATH_CHAR;

                    // Displays solution after recursion is finished
                    this.DisplayMaze(maze, true);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine();

                    Console.WriteLine("-------DONE!-------");

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    // Oututs the cords of the exit
                    Console.WriteLine($"Exit Found At: ({currentX}, {currentY})");

                    Console.ResetColor();

                    // Display solved maze for 1 second
                    System.Threading.Thread.Sleep(1000);

                    // Flags maze as solved. Flags all instances of recursion as solved
                    isSolved = true;
                }
                else
                {
                    // Displays the maze every time a point is checked or recusion is returned
                    this.DisplayMaze(maze, true);

                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    // Cords of the current point being checked
                    Console.WriteLine($"Exploring Point: ({currentX}, {currentY})");

                    // Checks if the next point down is a valid point
                    if (maze[currentX, currentY - 1] == PATH_CHAR) // Up
                    {
                        // Move to the valid point and continue checking for valid points
                        this.MazeTraversal(currentX, currentY - 1, ref maze, ref isSolved);
                    }

                    // Checks if the next point up is a valid point
                    if (maze[currentX, currentY + 1] == PATH_CHAR) // Down
                    {
                        // Move to the valid point and continue checking for valid points
                        this.MazeTraversal(currentX, currentY + 1, ref maze, ref isSolved);
                    }

                    // Checks if the next point right is a valid point
                    if (maze[currentX + 1, currentY] == PATH_CHAR) // Right
                    {
                        // Move to the valid point and continue checking for valid points
                        this.MazeTraversal(currentX + 1, currentY, ref maze, ref isSolved);
                    }

                    // Checks if the next point left is a valid point
                    if (maze[currentX - 1, currentY] == PATH_CHAR) // Left
                    {
                        // Move to the valid point and continue checking for valid points
                        this.MazeTraversal(currentX - 1, currentY, ref maze, ref isSolved);
                    }

                    // Checks if the maze is solved.
                    if (!isSolved)
                    {
                        // Mark the current point as bad and all subsequent points back to the next valid move
                        maze[currentX, currentY] = INVALID_PATH_CHAR;
                    }

                    // Check if no exit is found. Output an error when undoing recursion
                    if ((!isSolved) && (currentX == startX) && (currentY == startY))
                    {
                        // Display an error if an exit is not found
                        this.DisplayMaze(maze, true);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("NO EXIT");
                    }

                    Console.ResetColor();

                }
            }
        }

        /// <summary>
        /// Displays the maze
        /// </summary>
        /// <param name="maze"></param>Maze to be displayed
        /// <param name="shouldClearConsole"></param>Bool flag stipulating if the console output should be cleared before displaying
        /// the maze
        public void DisplayMaze(char[,] maze, bool shouldClearConsole)
        {
            const char PATH_CHAR = '.';

            const char VALID_PATH_CHAR = 'X';

            const char INVALID_PATH_CHAR = 'O';

            const char WALL_CHAR = '#';

            // Only clear console if should clear console is passed to method as true
            if (shouldClearConsole)
            {
                System.Threading.Thread.Sleep(500);

                Console.Clear();
            }

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    switch (maze[i, j])
                    {
                        case VALID_PATH_CHAR:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;

                                break;
                            }
                        case INVALID_PATH_CHAR:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                break;
                            }
                        case WALL_CHAR:
                            {
                                Console.ForegroundColor = ConsoleColor.White;

                                break;
                            }
                        case PATH_CHAR:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                break;
                            }
                    }

                    // Concatenate a space to make the maze bigger
                    Console.Write(maze[i, j] + " ");

                  Console.ResetColor();

                }

                Console.WriteLine();

            }
        }
    }
}
