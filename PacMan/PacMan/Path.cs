using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacMan
{
    public class Path : Tile
    {
        private ICollidable member;

        public Path(int x, int y, ICollidable member) : base(x, y)
        {
            this.member = member;
        }

        public override bool CanEnter()
        {
            throw new NotImplementedException();
        }

        public override void Collide()
        {
            if(member != null)
            {
                member.Collide();
            }
        }

        public override float GetDistance(Vector2 goal)
        {
            throw new NotImplementedException();
        }

        public override bool isEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
