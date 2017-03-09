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

        
        public GhostPack()
        {
            ghosts = new List<Ghost>();
        }

        public void CheckCollideGhosts(Vector2 v)
        {
            foreach(var g in ghosts)
            {
                if(g.Position == v)
                {
                    g.Collide();
                }
            }
        }

        public void ResetGhosts()
        {
            foreach (Ghost g in ghosts) {
                g.Reset();
            }
        }

        public void ScareGhosts()
        {

            foreach (Ghost g in ghosts)
            {
                g.ChangeState(GhostState.Scared);
            }
            Ghost.scared = new System.Timers.Timer();
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
