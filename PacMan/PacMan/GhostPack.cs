using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PacMan
{
    public class GhostPack : Ghost, IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;

        //look into it
        public GhostPack() : base()
        {
            ghosts = new List<Ghost>();
        }

        public void CheckCollideGhosts(Vector2 v)
        {
            throw new NotImplementedException();
        }

        public void ResetGhosts()
        {
            throw new NotImplementedException();
        }

        public void ScareGhost()
        {
            foreach (Ghost g in ghosts) {
                g.ChangeState(GhostState.Scared);
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Add(Ghost g)
        {
            this.ghosts.Add(g);
        }

        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
    }
}
