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

        public GameState()
        {

        }

        public static GameState Parse(string filecontent)
        {
            GameState g = new GameState();
            Pacman pac = new Pacman(g, 11,16);
            Pen pen = new Pen();
            Maze maze = new Maze();
            GhostPack gp = new GhostPack();
            ScoreAndLives sl = new ScoreAndLives(g);

            string[][] parse = getElements(filecontent);
            
            for(int y=0; y<parse.GetLength(0); y++)
            {
                for(int x=0; x<parse.GetLength(1); y++)
                {
                    switch (parse[y][x])
                    {
                        case "w":
                            break;
                        case "p":
                            break;
                        case "e":
                            break;
                        case "x":
                            break;
                        case "P":
                            break;
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                            break;
                       

                    }
                }
            }   

        }

        public static string[][] getElements(string filecontent)
        {
            string[] stringLines = File.ReadAllLines(filecontent);
            string[][] parseStr = new string[stringLines.Length][];
            char[] c = new char[] {' ', '\n'};
            for (int i=0; i<stringLines.Length; i++)
            {
                parseStr[i] = stringLines[i].Split(c, StringSplitOptions.RemoveEmptyEntries);
            }

            return parseStr;
        }

    }
}
