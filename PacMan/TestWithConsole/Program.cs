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
            foreach(var s  in g.Ghostpack)
            {
                Console.WriteLine(s);
            }
        }
    }
}
