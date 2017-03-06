using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface ICollidable
    {

        event Action<ICollidable> Collision;

        int Points { get; set; }

        void Collide(ICollidable ic);
    }
}
