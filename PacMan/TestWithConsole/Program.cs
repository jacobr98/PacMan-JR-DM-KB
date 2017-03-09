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
            Console.WriteLine(g.Score.Score);

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
