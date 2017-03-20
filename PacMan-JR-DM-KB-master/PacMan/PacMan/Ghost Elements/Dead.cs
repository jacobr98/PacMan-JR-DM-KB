using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    //State for when pacman eats a ghost
    class Dead : IGhostState
    {
        private Pen pen;
        private Maze maze;

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
