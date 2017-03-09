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
                this.maze[x, y] = value;
            }
        }

        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction dir)
        {
            throw new NotImplementedException();
        }

        public void CheckMembersLeft()
        {

        }
        
    }
}
