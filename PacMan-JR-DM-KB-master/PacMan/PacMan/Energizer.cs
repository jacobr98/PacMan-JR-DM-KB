using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    /// <summary>
    /// Authors : Danny Manzato-Tates, Jacob Riendeau, Kevin Bui
    /// </summary>
    public class Energizer : ICollidable
    {
        private int points;
        public int Points { get { return points; } set { this.points = value; } }
        GhostPack ghosts;

        public event Action<ICollidable> Collision;
        /// <summary>
        /// Constructor instantiates the ghosts, the points 
        /// and subscribe the ghosts to the Collision 
        /// </summary>
        public Energizer(GhostPack ghosts, int point)
        {
            this.ghosts = ghosts;
            this.points = point;
        }

        /// <summary>
        /// Triggers the Collision event and scares the ghost
        /// </summary>
        public void Collide()
        {
            onCollision(this);
            this.ghosts.ScareGhosts();
        }

        /// <summary>
        /// Event handler for collision
        /// </summary>
        protected void onCollision(ICollidable ic)
        {
            Collision?.Invoke(this);
        } 
    }
}
