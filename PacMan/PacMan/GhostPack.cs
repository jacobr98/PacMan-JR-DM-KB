using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class GhostPack : Ghost
    {
        List<Ghost> ghosts;

        public GhostPack()
        {
            ghosts = new List<Ghost>();
        }

        public bool CheckCollideGhosts(Vector2 v)
        {
            throw new NotImplementedException();
        }

        public void ResetGhosts()
        {
            throw new NotImplementedException();
        }

        public void ScareGhost()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Add(Ghost g)
        {
            this.ghosts.Add(g);
        }

        
    }
}
