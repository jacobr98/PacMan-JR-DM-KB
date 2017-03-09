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
        public void TestPacmanCheckCollision()
        {
            //To be done when ghost is done
        }

        [TestMethod]
        public void TestScoreAfterCollision()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");

            Console.WriteLine(g.Pacman.Position);

            //Trying to get to an energizer
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

            Console.WriteLine(g.Pacman.Position);
            Console.WriteLine(g.Score.Score);

            Assert.AreEqual(g.Score.Score, 230);

        }

        [TestMethod]
        public void Test
    }
}
