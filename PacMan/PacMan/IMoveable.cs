using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    interface IMoveable
    {
        Direction Direction { get; set; }

        Vector2 Position { get; set; }

        void Move();
    }
}
