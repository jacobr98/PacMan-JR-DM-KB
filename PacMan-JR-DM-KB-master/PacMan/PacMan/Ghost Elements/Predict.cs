using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class Predict : IGhostState
    {
        public Vector2 Target { get { return target; } }
        public Predict(Ghost g, Maze m , Pacman pacman) {
            this.target = pacman.Position;
        }
        private Vector2 target;
        public void Move()
        {
            
        }
    }
}
