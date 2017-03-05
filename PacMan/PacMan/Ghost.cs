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
        private static Timer scared;

        //Events
        public event Action PacmanDied;
        public event Action Collision;

        //Properties
        public Vector2 Position { get; set; }
        public Direction Direction { get; set; }
        public GhostState CurrentState { get; }
        public int Points { get; set; }

        public Ghost(GameState g, int x, int y, Vector2 target, GhostState start, Color colour)
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

        public void ChangeState(GhostState state)
        {
            this.CurrentState = state;
        }

        public void Move()
        {

        }

        public void Collide() { }

    }
}
