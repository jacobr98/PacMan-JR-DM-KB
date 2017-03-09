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
        public override ICollidable Member
        {
            get { return member; }
            set { member = value; }
        }

        public Path(int x, int y, ICollidable member) : base(x, y)
        {
            this.member = member;
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Collide()
        {
            if(member != null)
            {
                member.Collide();
            }
            member = null;
        }

        public override bool isEmpty()
        {
            if (member == null)
                return true;
            else
                return false;
        }
    }
}
