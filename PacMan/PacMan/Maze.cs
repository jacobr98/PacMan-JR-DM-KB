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

        public event Action PacmanWon;
        public int Size { get; set; }

        public Maze()
        {

        }

        public void SetTiles(Tile[,] maze)
        {
            this.maze = maze;
        }

        public Tile this[int x, int y]
        {
            get
            {
                if (x < 0 || x > maze.GetLength(1) || y < 0 || y > maze.GetLength(0))
                    throw new ArgumentOutOfRangeException("The indeces are out of range ({0},{1})", x, y.ToString());
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
