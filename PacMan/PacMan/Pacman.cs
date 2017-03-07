using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Pacman
    {
        private GameState controller;
        private Maze maze;
        public Vector2 position { get; set; }
        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.maze = this.controller.Maze;
        }

        public void Move (Direction dir)
        {

        }

        public void CheckCollisions()
        {

        }
    }
}
