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
        public static Vector2 ReleasePosition;

        //pending type for GUI
        private Color colour;
        public Color Colour { get; }

        private IGhostState currentState;
        private static Timer scared;

        //Events
        public event Action PacmanDied;
        public event Action<ICollidable> Collision;

        //Properties
        public Vector2 Position { get; set; }
        public Direction Direction { get { return this.direction; }set { this.direction = value;} }
        public GhostState CurrentState { get; private set; }
        public int Points { get; set; }

        public Ghost(GameState g, int x, int y, Vector2 target, GhostState start, Color colour)
        {
            this.target = target;
            this.colour = colour;
            this.pen = g.Pen;
            this.maze = g.Maze;
            this.pacman = g.Pacman;
            //dont set timer in constructor it is supposed to be static so can't instantate it
            //I'll set it in the gamestate
        //set tim
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void ChangeState(GhostState state)
        {

            this.CurrentState = state;
            switch (state) {
                case GhostState.Scared:
                    currentState = new Scared(this, this.maze);
                    break;
                case GhostState.Chase:
                    currentState = new Chase(this, maze, target, pacman);
                    
                    break;
            }
        }

        public void Move()
        {
            currentState.Move();
            switch (direction) {
                case Direction.Up:
                    Position = new Vector2(Position.X, Position.Y - 1);
                    break;
                case Direction.Down:
                    Position = new Vector2(Position.X, Position.Y + 1);
                    break;
                case Direction.Left:
                    Position = new Vector2(Position.X -1, Position.Y );
                    break;
                case Direction.Right:
                    Position = new Vector2(Position.X + 1, Position.Y);
                    break;
            }
        }


        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
