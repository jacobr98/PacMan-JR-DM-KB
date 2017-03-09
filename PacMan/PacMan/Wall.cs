﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacMan
{
    public class Wall : Tile
    {
        //The member of a wall should be null and can't be set
        //because a wall should not contain something
        public override ICollidable Member {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Constructor instantiates the position in the base
        /// </summary>
        public Wall(int x, int y) : base(x, y)
        {

        }

        /// <summary>
        /// The element defines whether anything can enter the tile.
        /// </summary>
        /// <returns>Returns false</returns>
        public override bool CanEnter()
        {
            return false;
        }

        /// <summary>
        /// Calls the member's collide method and deletes the meber afterwards
        /// **Nothing should collide with a wall so the method throws a not implemented exception
        /// </summary>
        public override void Collide()
        {
            throw new NotImplementedException();
            //should never happen
        }

        /// <summary>
        /// The element defines whether there is a member within it.
        /// </summary>
        /// <returns>Returns true</returns>
        public override bool isEmpty()
        {
            return true;
        }
    }
}
