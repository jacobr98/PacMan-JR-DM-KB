using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Energizer
    {
        private int points;
        public int Points { get; set; }
        GhostPack ghosts;

        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts;
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
