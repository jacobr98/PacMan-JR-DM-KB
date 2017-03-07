using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacMan;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            GameState g = GameState.Parse("../../../PacMan/levelsPen.csv");
            
        }
    }
}
