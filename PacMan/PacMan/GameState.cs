using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class GameState
    {

        Pacman Pacman { get; }
        GhostPack Ghostpack { get; }
        Maze Maze { get; }
        Pen Pen { get; }
        ScoreAndLives Score { get; }

        public static GameState Parse(string filecontent)
        {
            string[] stringLines = File.ReadAllLines(filecontent);
        }

    }
}
