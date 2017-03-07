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

        public event Action<string> GameOver;

        public ScoreAndLives(GameState game)
        {
            this.Lives = game.Score.Lives;
            this.Score = game.Score.Score;
        }

        public void DeadPacman()
        {
            if(this.Lives == 0)
            {
                onOver("Dead");
            }else
            {
                this.Lives--;
            }
        }

        protected void onOver(string state)
        {
            GameOver?.Invoke(state);
        }

        public void IncrementScore(ICollidable collidable)
        {
            this.Score += collidable.Points;

        }
    }
}
