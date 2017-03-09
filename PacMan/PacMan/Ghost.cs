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
        private Vector2 position;

        //pending type for GUI
        private Color colour;
        public Color Colour { get; }

        private IGhostState currentState;
        public static Timer scared;

        //Events
        public event Action PacmanDied;
        public event Action<ICollidable> Collision;

        //Properties
        public Vector2 Position { get { return this.position; } set { this.position = value; } }
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
            this.position = new Vector2(x, y);

            switch (start)
            {
                case GhostState.Chase:
                    this.currentState = new Chase(this, maze, target, pacman);
                    break;
                case GhostState.Scared:
                    this.currentState = new Scared(this,maze);
                    break;
            }
        }

        public void Reset()
        {
            pen.AddToPen(this);
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
                case GhostState.Released:
                    position = ReleasePosition;
                    currentState = new Chase(this, maze, target, pacman);
                    break;
            }
        }

        public void Move()
        {
            currentState.Move();
        }


        public void Collide()
        {

            if (CurrentState == GhostState.Scared)
            {
                OnCollision(this);
            }
            else if(CurrentState == GhostState.Chase)
            {
                OnPacmanDied();
            }
        }

        protected void OnPacmanDied()
        {
            PacmanDied?.Invoke();
        }

        protected void OnCollision(ICollidable i)
        {
            Collision?.Invoke(i);
        }
    }
}
