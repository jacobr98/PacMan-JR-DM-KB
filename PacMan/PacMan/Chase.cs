using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    class Chase : IGhostState
    {
        public void Move()
        {
            throw new NotImplementedException();
        }

        private Ghost ghost;
        private Maze maze;
        private Vector2 target;
        private Pacman pacman;

        public Chase(Ghost ghost, Maze maze, Vector2 target, Pacman pacman)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.target = target;
            this.pacman = pacman;
        }

    }
}
