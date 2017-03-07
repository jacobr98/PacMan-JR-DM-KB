using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Pellet : ICollidable
    {
        private int points;
        public int Points { get { return points; } set { this.points = value; } }

        public event Action<ICollidable> Collision;

        public Pellet(int point)
        {
            this.points = point;
        }

        public void Collide()
        {
            onCollision(this);
        }

        protected void onCollision(ICollidable ic)
        {
            Collision?.Invoke(this);
        }
    }
}
