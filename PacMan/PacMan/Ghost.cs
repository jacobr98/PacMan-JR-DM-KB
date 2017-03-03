using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan
{
    public class Ghost : ICollidable, IMoveable
    {
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Direction direction;

        //pending type for GUI
        private Color colour;
        public Color Colour { get; }

        private IGhostState currentState;
        public IGhostState CurrentState;

        private static Timer scared;

        public event Action PacmanDied;
        public event Action Collision;
        
        /*public static Ghost()
        {
            Ask Dan for specification on what is written in uml
        }*/

        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState start, Color colour)
        {
            this.target = target;
            this.colour = colour;
            this.pen = g.Pen;
            this.maze = g.Maze;
            this.pacman = g.Pacman;

            //to finish
        }


        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void ChangeState(IGhostState state)
        {
            this.currentState = state;
        }

    }
}
