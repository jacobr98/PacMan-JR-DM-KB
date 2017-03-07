using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Energizer : ICollidable
    {
        private int points;
        public int Points { get { return points; } set { this.points = value; } }
        GhostPack ghosts;

        public event Action<ICollidable> Collision;
        public Energizer(GhostPack ghosts, int point)
        {
            this.ghosts = ghosts;
            this.points = point;
        }

        public void Collide()
        {
            if (Collision != null)
            {
                Collision(this);
            }
        }
    }
}
