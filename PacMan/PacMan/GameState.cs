using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public enum Direction {Left, Right, Up, Down}

    public enum GhostState { Scared, Chase, Released}

    public class GameState
    {

        public Pacman Pacman { get { return this.pacman; } }
        private Pacman pacman;

        public GhostPack Ghostpack { get { return this.ghostpack; } }
        private GhostPack ghostpack;

        public Maze Maze { get { return this.maze; } }
        private Maze maze;

        public Pen Pen { get { return this.pen; } }
        private Pen pen;

        public ScoreAndLives Score { get { return this.score; } }
        private ScoreAndLives score; 

        public GameState()
        {

        }

        public static GameState Parse(string filecontent)
        {
            GameState g = new GameState();
            Pacman pac = new Pacman(g);
            Pen pen = new Pen();
            Maze maze = new Maze();
            GhostPack gp = new GhostPack();
            ScoreAndLives sl = new ScoreAndLives(g);

            g.pacman = pac;
            g.pen = pen;
            g.maze = maze;
            g.ghostpack = gp;
            g.score = sl;
            Ghost gh;
            string[][] parse = getElements(filecontent);
            Tile[,] array = new Tile[parse.GetLength(1),parse.GetLength(0)];
            for (int y=0; y<parse.GetLength(0); y++)
            {
                for(int x=0; x<parse.GetLength(1); y++)
                {
                    switch (parse[y][x])
                    {
                        case "w":
                            array[x, y] = new Wall(x, y);
                            break;
                        case "p":
                            Pellet p = new PacMan.Pellet(10);
                            p.Collision += g.score.IncrementScore;
                            array[x, y] = new Path(x, y, p);
                            break;
                        case "e":
                            Energizer e = new Energizer(g.Ghostpack, 100);
                            e.Collision += g.score.IncrementScore;
                            array[x, y] = new Path(x, y, e);
                            break;
                        case "m":
                            array[x, y] = new Path(x,y,null);
                            break;
                        case "x":
                            array[x, y] = new Path(x,y,null);
                            g.pen.AddTile(array[x, y]);
                            break;
                        case "P":
                            array[x, y] = new Path(x, y,null);
                            g.pacman.Position = new Vector2(x,y);
                            break;
                        case "1":
                            gh = new Ghost(g,x,y,new Vector2(1,1),GhostState.Chase, new Color(255,0,0));
                            Ghost.ReleasePosition = new Vector2(x,y);
                            gh.Collision += g.score.IncrementScore;
                            gh.PacmanDied += g.score.DeadPacman;
                            g.ghostpack.Add(gh);
                            array[x, y] = new Path(x, y, null);
                            break;
                        case "2":
                            gh = new Ghost(g, x, y, new Vector2(1, 1), GhostState.Chase, new Color(255, 192, 203));
                            gh.Collision += g.score.IncrementScore;
                            gh.PacmanDied += g.score.DeadPacman;
                            g.ghostpack.Add(gh);
                            array[x, y] = new Path(x, y, null);
                            g.pen.AddTile(array[x, y]);
                            g.pen.AddToPen(gh);
                            break;
                        case "3":
                            gh = new Ghost(g, x, y, new Vector2(1, 1), GhostState.Chase, new Color(64, 224, 208));
                            gh.Collision += g.score.IncrementScore;
                            gh.PacmanDied += g.score.DeadPacman;
                            g.ghostpack.Add(gh);
                            array[x, y] = new Path(x, y, null);
                            g.pen.AddTile(array[x, y]);
                            g.pen.AddToPen(gh);
                            break;
                        case "4":
                            gh = new Ghost(g, x, y, new Vector2(1, 1), GhostState.Chase, new Color(255, 165, 0));
                            gh.Collision += g.score.IncrementScore;
                            gh.PacmanDied += g.score.DeadPacman;
                            g.ghostpack.Add(gh);
                            array[x, y] = new Path(x, y, null);
                            g.pen.AddTile(array[x, y]);
                            g.pen.AddToPen(gh);
                            break;
                    }
                }
            }
            g.maze.SetTiles(array);
            return g;
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
