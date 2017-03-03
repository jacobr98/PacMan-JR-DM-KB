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
        public ICollidable Member { get; set; }

        public Tile(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public bool CanEnter()
        {
            throw new NotImplementedException();
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public float GetDistance(Vector2 goal)
        {
            throw new NotImplementedException();
        }
    }
}
