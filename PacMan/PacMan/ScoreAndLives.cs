using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class ScoreAndLives
    {
        public int Lives { get; set; }
        public int Score { get; set; }

        public event Action GameOver;

        public ScoreAndLives(GameState game)
        {
            this.Lives = game.Score.Lives;
            this.Score = game.Score.Score;
        }

        public void DeadPacman()
        {
            this.Lives--;
        }


        private 
        public void IncrementScore(ICollidable collidable)
        {
            this.Score += collidable.Points;
        }
    }
}
