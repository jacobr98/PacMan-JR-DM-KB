using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacMan;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStaticParseGS()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            Assert.AreNotEqual(g.Pen, null);
            Assert.AreNotEqual(g.Ghostpack, null);
            Assert.AreNotEqual(g.Maze, null);
            Assert.AreNotEqual(g.Pacman, null);
            Assert.AreNotEqual(g.Score, null); 
        }
    }
}
