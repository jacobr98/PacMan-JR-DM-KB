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
        private Vector2 position;
        public Pacman(GameState controller, int x, int y)
        {
            this.controller = controller;
            this.maze = this.controller.Maze;
            this.position = new Vector2(x, y);
        }

        public void Move (Direction dir)
        {

        }

        public void CheckCollisions()
        {

        }
    }
}
