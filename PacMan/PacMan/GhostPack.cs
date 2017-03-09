using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PacMan
{
    public class GhostPack : IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;

        //look into it
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
            foreach (Ghost g in ghosts) {
                g.Reset();
            }
        }

        public void ScareGhosts(ICollidable ic)
        {
            foreach (Ghost g in ghosts) {
                g.ChangeState(GhostState.Scared);
            }
        }

        public void Move()
        {
            foreach (Ghost g in ghosts)
            {
                g.Move();
            }
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
