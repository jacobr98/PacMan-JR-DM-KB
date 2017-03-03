using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public enum Direction {Left, Right, Up, Down}

    public enum GhostState { Scared, Chase, Release}

    public class GameState
    {

        public Pacman Pacman { get; }
        public GhostPack Ghostpack { get; }
        public Maze Maze { get; }
        public Pen Pen { get; }
        public ScoreAndLives Score { get; }

        public static GameState Parse(string filecontent)
        {
            string[] stringLines = File.ReadAllLines(filecontent);

            string[][] parseStr = 
        }

    }
}
