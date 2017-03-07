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
            switch (dir)
            {
                case Direction.Up:
                    if(maze[(int)pos.X,(int)pos.Y - 1] is Path)
                    {
                        pos = new Vector2(Position.X, Position.Y-1);
                        CheckCollisions();
                    }
                    break;
                case Direction.Down:
                    if (maze[(int)pos.X, (int)pos.Y + 1] is Path)
                    {
                        pos = new Vector2(Position.X, Position.Y + 1);
                        CheckCollisions();
                    }
                    break;
                case Direction.Left:
                    if (maze[(int)pos.X - 1, (int)pos.Y] is Path)
                    {
                        pos = new Vector2(Position.X - 1, Position.Y);
                        CheckCollisions();
                    }
                    break;
                case Direction.Right:
                    if (maze[(int)pos.X + 1, (int)pos.Y] is Path)
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

            ICollidable t = maze[(int)pos.X, (int)pos.Y].Member;
            if(t != null)
            {
                t.Collide();
            }
            
        }
    }
}
