using Microsoft.Xna.Framework;
using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");

            bool triggered = false;

            g.Maze.PacmanWon += (x) => triggered = true;

            //collide with all the pellets and energizer to check win
            for (int i = 0; i < g.Maze.Size; i++)
            {
                for (int j = 0; j < g.Maze.Size; j++)
                {
                    if (g.Maze[j, i].Member is Path)
                    {
                        g.Maze[j, i].Collide();
                    }
                }
            }

            g.Maze.CheckMembersLeft();

            Console.WriteLine(triggered);

            /*GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Vector2 v = g.Pacman.Position;
            Console.WriteLine(g.Pacman.Position + " initial");
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Left);
            g.Pacman.Move(Direction.Left);
            //g.Maze[21, 3].Collide();
            g.Pacman.Move(Direction.Left);
            g.Pacman.Move(Direction.Left);

            Console.WriteLine(g.Pacman.Position + " after");
            Console.WriteLine(g.Score.Lives + ", " + g.Score.Score);

            foreach(var gh in g.Ghostpack)
            {
                Console.WriteLine(gh.Position +  ", " + gh.CurrentState);
            }*/

            /*GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");

            Console.WriteLine(g.Pacman.Position);

            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Down);
            g.Pacman.Move(Direction.Down);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);

            Console.WriteLine(g.Pacman.Position);
            Console.WriteLine(g.Score.Score);*/

            /*GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Console.WriteLine(g.Pacman.Position);
            g.Pacman.Move(Direction.Left);
            Console.WriteLine(g.Pacman.Position);

            g.Pacman.Move(Direction.Left);
            Console.WriteLine(g.Pacman.Position);
            g.Pacman.Move(Direction.Right);

            Console.WriteLine(g.Pacman.Position);
            Console.WriteLine(g.Score.Score);*/



            /*for(int i=0; i<g.Maze.Size; i++)
            {
                for(int j=0; j<g.Maze.Size; j++)
                {
                    Console.Write(g.Maze[j,i]);
                }

                Console.WriteLine();
            }*/

        }
    }
}
