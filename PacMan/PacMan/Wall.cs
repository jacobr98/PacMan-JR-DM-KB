using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacMan
{
    public class Wall : Tile
    {
        public override ICollidable Member { get; set; }

        public Wall(int x, int y) : base(x, y)
        {

        }

        public override bool CanEnter()
        {
            return false;
        }

        public override void Collide()
        {
            throw new NotImplementedException();
        }

        public override bool isEmpty()
        {
            return true;
        }
    }
}
