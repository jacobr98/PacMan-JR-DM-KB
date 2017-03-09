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
            if (collidable != null)
            {
                if ((collidable is Ghost))
                {
                    if (((Ghost)collidable).CurrentState == GhostState.Scared)
                    {
                        this.Score += collidable.Points;
                    }
                }
                else
                {
                    this.Score += collidable.Points;
                }
            }
        }
    }
}
