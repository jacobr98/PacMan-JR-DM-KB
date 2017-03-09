using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Maze
    {
        private Tile[,] maze;

        public event Action<ICollidable> PacmanWon;
        public int Size { get; set; }

        public Maze()
        {

        }

        public void SetTiles(Tile[,] maze)
        {
            this.maze = maze;
            this.Size = maze.GetLength(0);
        }

        public Tile this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= Size || y < 0 || y >= Size)
                    throw new ArgumentOutOfRangeException("The indeces are out of range (" + x + ", " + y + ")");
                return maze[x, y];
            }
            set
            {
                maze[x, y] = value;
            }
        }

        //can't do 180 turn
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:

                    break;
            }
        }

        public void CheckMembersLeft()
        {
            if (areMembersNull())
            {
                OnPacmanWon();
            }
        }

        protected void OnPacmanWon()
        {
            //temporary for this phase
            PacmanWon?.Invoke(null);
        }

        private bool areMembersNull()
        {
            foreach (Tile t in maze)
            {
                if (t is Path)
                {
                    if (t.Member != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
    }
}
