﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Timers;

namespace PacMan
{
    /// <summary>
    /// Authors : Danny Manzato-Tates, Jacob Riendeau, Kevin Bui
    /// </summary>
    public class GhostPack : IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;
        private Timer scared;
        private Timer scatter;
        /// <summary>
        /// Constructor that instantiates a new List of ghosts.
        /// </summary>
        public GhostPack()
        {
            ghosts = new List<Ghost>();
        }

        /// <summary>
        /// Checks if there is a collision with ghosts
        /// </summary>
        /// <param name="v">Vector in which the ghost is going</param>
        public bool CheckCollideGhosts(Vector2 v)
        {
            foreach (var g in ghosts)
            {
                //Checks to see if each ghosts position matches the V (pacmans position)
                if (g.Position == v)
                {
                    if (g.CurrentState == GhostState.Chase)
                    {
                        g.Collide();
                        ResetGhosts();
                        return true;
                    }
                    else if (g.CurrentState == GhostState.Scared)
                    {
                        g.Collide();
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// Calls reset and puts all the ghosts in Pen.
        /// </summary>
        public void ResetGhosts()
        {
            foreach (Ghost g in ghosts)
            {
                g.Reset();
            }
        }

        /// <summary>
        /// Sets all the ghosts to scared state
        /// </summary>
        public void ScareGhosts()
        {
            foreach (Ghost g in ghosts)
            {
                if (g.CurrentState == GhostState.Chase)
                    g.ChangeState(GhostState.Scared);
            }
            scared = new Timer(6000);
            scared.Elapsed += DisableScared;
            scared.Start();
        }

        /// <summary>
        /// When the timer is off, all ghosts turn back to chase state
        /// </summary>
        /// <param name="sender">The object that holds the timer</param>
        /// <param name="e">The timer event</param>
        private void DisableScared(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;

            foreach (var g in ghosts)
            {
                if (g.CurrentState == GhostState.Scared)
                    g.ChangeState(GhostState.Chase);
            }
            scared = null;
        }

        /// <summary>
        /// When the timer is off, all ghosts turn back to chase state
        /// </summary>
        /// <param name="sender">The object that holds the timer</param>
        /// <param name="e">The timer event</param>
        private void checkCollideGhost(Ghost g)
        {
            if (g.Position == g.PacmanPosition)
            {
                if (g.CurrentState == GhostState.Chase)
                {
                    g.Collide();
                    ResetGhosts();
                }
                else if (g.CurrentState == GhostState.Scared)
                {
                    g.Collide();
                }
            }
        }

        /// <summary>
        /// Tells the ghosts where to move
        /// </summary>
        public void Move()
        {
            foreach (Ghost g in ghosts)
            {
                g.Move();
                checkCollideGhost(g);
            }
        }

        /// <summary>
        /// Changes the states of the ghosts to Scatter mode
        /// </summary>
        public void ScatterGhosts()
        {
            foreach (Ghost g in ghosts)
            {
                if (g.CurrentState == GhostState.Chase)
                    g.ChangeState(GhostState.Scatter);
            }
            scatter = new Timer(8000);
            scatter.Elapsed += DisableScared;
            scatter.Start();
        }

        /// <summary>
        /// Disables the scatter mode
        /// </summary>
        public void DisableScatter(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;

            foreach (var g in ghosts)
            {
                if (g.CurrentState == GhostState.Scatter)
                    g.ChangeState(GhostState.Chase);
            }

            scared = null;
        }
        /// <summary>
        /// Adds ghosts to the List
        /// </summary>
        /// <param name="g">The ghost to be added to the list</param>
        public void Add(Ghost g)
        {
            this.ghosts.Add(g);
        }

        /// <summary>
        /// Implements the IEnumerable
        /// </summary>
        /// <returns name="Enumerator"> Ghosts enumerators</returns>

        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
        /// <summary>
        /// Implements the IEnumerable
        /// </summary>
        /// <returns name="Enumerator"> Ghosts enumerators</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
    }
}
