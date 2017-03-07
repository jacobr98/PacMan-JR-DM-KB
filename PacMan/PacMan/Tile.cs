using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class Tile
    {
        public Vector2 Position { get; set; }
        public abstract ICollidable Member { get; set; }

        public Tile(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public abstract bool CanEnter();

        public abstract void Collide();

        public abstract bool isEmpty();

        public float GetDistance(Vector2 goal)
        {
            return Vector2.Distance(this.Position, goal);
        }
    }
}
