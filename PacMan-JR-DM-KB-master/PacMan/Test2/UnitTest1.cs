using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacMan;
using Microsoft.Xna.Framework;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStaticParseGS()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            //A lot of the testing for the gamestate was done in TestWithConsole (Console Application)
        }

        [TestMethod]
        public void TestPacmanMove()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");


            Assert.AreEqual(g.Pacman.Position, new Vector2(11,17));

            //the movement should work because on the left of Pacman there is a path
            g.Pacman.Move(Direction.Left);
            Assert.AreEqual(g.Pacman.Position, new Vector2(10,17));

            //the movement shouldn't work because up of Pacman there is a wall and same for down
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            Assert.AreEqual(g.Pacman.Position, new Vector2(11, 17));

            g.Pacman.Move(Direction.Down);
            Assert.AreEqual(g.Pacman.Position, new Vector2(11, 17));

        }
        [TestMethod]
        public void TestScoreAfterCollision()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");

            Console.WriteLine(g.Pacman.Position);

            //Trying to get to an energizer and adding the pellets in the path
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Down);
            g.Pacman.Move(Direction.Down);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);


            Assert.AreEqual(g.Score.Score, 230);

        }

        [TestMethod]
        public void TestPacmanCheckCollision()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Vector2 v = g.Pacman.Position;
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Left);
            g.Pacman.Move(Direction.Left);
            g.Pacman.Move(Direction.Left);
            //ghost hit
            g.Pacman.Move(Direction.Left);

            //check if it collided with the pellets
            //checks also isEmpty
            Assert.AreEqual(g.Maze[(int)v.X + 1, (int)v.Y].isEmpty(), true);

            //Checks if loses a life when colliding a ghost. Part of deadpacman
            Assert.AreEqual(g.Score.Lives, 2);

            //check if it collides with pellet and raise the event
            Assert.AreEqual(g.Score.Score, 60);

            //check that pacman did reset position
            Assert.AreEqual(g.Pacman.Position, g.Pacman.initPosition);


        }

        [TestMethod]
        public void TestPacmanCheckCollisionWithEnergizer()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Vector2 v = g.Pacman.Position;
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Left);
            g.Pacman.Move(Direction.Left);
            //test energizer collision
            g.Maze[21, 3].Collide();
            g.Pacman.Move(Direction.Left);
            //ghost hit
            g.Pacman.Move(Direction.Left);

            //check if it collided with the pellets
            Assert.AreEqual(g.Maze[(int)v.X + 1, (int)v.Y].isEmpty(), true);

            //Checks if loses a life when colliding a ghost.
            Assert.AreEqual(g.Score.Lives, 3);

            //energizer gives 100 and the ghosts give 200
            Assert.AreEqual(g.Score.Score, 360);

            //check that pacman didnt reset position
            Assert.AreEqual(g.Pacman.Position, new Vector2(11,8));


        }

        [TestMethod]
        public void TestPacmanAtNoLives()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Vector2 v = g.Pacman.Position;

            //move pacman a little
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Up);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);
            g.Pacman.Move(Direction.Right);

            bool triggered = false;

            g.Score.GameOver += (x) => triggered = true;

            Assert.AreNotEqual(g.Pacman.Position, g.Pacman.initPosition);

            g.Score.DeadPacman();
            g.Score.DeadPacman();
            g.Score.DeadPacman();

            //check it reseted the pacman position
            Assert.AreEqual(g.Pacman.Position, g.Pacman.initPosition);

            Assert.AreEqual(triggered, true);
        }


        [TestMethod]
        public void TestPacmanWon()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");

            bool triggered = false;

            g.Maze.PacmanWon += (x) => triggered = true;

            //collide with all the pellets and energizer to check win
            for(int i=0; i<g.Maze.Size; i++)
            {
                for(int j=0; j<g.Maze.Size; j++)
                {
                    if(g.Maze[j,i].Member is Path)
                    {
                        g.Maze[j, i].Collide();
                    }
                }
            }

            g.Maze.CheckMembersLeft();

            Assert.AreEqual(triggered, true);
        }
        
    }
}
