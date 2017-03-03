using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TempTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = File.ReadAllLines("levels.csv");

            
        }
    }

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
        }

    }

    public class Pacman
    {
        private GameState controller;
        private Maze maze;

        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.maze = this.controller.Maze;
        }

        public void Move(Direction dir)
        {

        }

        public void CheckCollisions()
        {

        }
    }

    public class ScoreAndLives
    {
        public int Lives { get; set; }
        public int Score { get; set; }

        public ScoreAndLives(GameState game)
        {
            this.Lives = game.Score.Lives;
            this.Score = game.Score.Score;
            foreach (Ghost g in game.Ghostpack.ghosts)
            {
                g.PacmanDied += deadPacman;
            }
        }

        public void deadPacman()
        {
            this.Lives--;
        }

        public void incrementScore(ICollidable collidable)
        {
            this.Score += collidable.Points;
        }
    }
}
