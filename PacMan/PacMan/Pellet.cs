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
        public int Points { get; set; }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
