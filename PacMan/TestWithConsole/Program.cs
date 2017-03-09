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
            //Console.WriteLine(g.Maze.Size);
            /*for(int i=0; i<g.Maze.Size; i++)
            {
                for(int j=0; j<g.Maze.Size; j++)
                {
                    Console.WriteLine(i + "," + j + "," + g.Maze[i,j]);
                }
            }*/
        }
    }
}
