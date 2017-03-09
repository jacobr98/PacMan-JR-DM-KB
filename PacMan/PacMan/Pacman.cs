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
        public Vector2 Position { get { return pos; } set { pos = value; } }
        private Vector2 pos;
        public Pacman(GameState controller)
        {
            this.controller = controller;
            this.maze = this.controller.Maze;
        }

        public void Move (Direction dir)
        {
            int x = (int)pos.X;
            int y = (int)pos.Y;

            switch (dir)
            {
                case Direction.Up:
                    if(maze[x,y- 1].CanEnter())
                    {
                        pos = new Vector2(Position.X, Position.Y-1);
                        CheckCollisions();
                    }
                    break;
                case Direction.Down:
                    if (maze[x, y + 1].CanEnter())
                    {
                        pos = new Vector2(Position.X, Position.Y + 1);
                        CheckCollisions();
                    }
                    break;
                case Direction.Left:
                    if (maze[x - 1, y].CanEnter())
                    {
                        pos = new Vector2(Position.X - 1, Position.Y);
                        CheckCollisions();
                    }
                    break;
                case Direction.Right:
                    if (maze[x + 1, y].CanEnter())
                    {
                        pos = new Vector2(Position.X + 1, Position.Y);
                        CheckCollisions();
                    }
                    break;
            }
        }

        public void CheckCollisions()
        {

            foreach (var g in controller.Ghostpack)
            {
                if (controller.Ghostpack.CheckCollideGhosts(Position))
                {
                    g.Collide();
                    break;
                }
            }

            maze[(int)pos.X, (int)pos.Y].Collide(); 


            
        }
    }
}
