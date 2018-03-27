using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using ToyRobot.Common;

namespace ToyRobotTest
{
    [TestClass]
    public class UnitTestRobot
    {
        [TestMethod]
        public void Robot_Not_Placed_And_Moved()
        {
            var robot = new Robot();
            robot.Move();
            var result = robot.Report();
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void Robot_PlacedOutside()
        {
            var robot = new Robot();
            robot.Place(2, 5, Direction.EAST);
            robot.Move();
            var result = robot.Report();
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void Robot_PlacedInside_PlacedOutside()
        {
            var robot = new Robot();
            robot.Place(2, 2, Direction.EAST);
            robot.Place(6, 2, Direction.EAST);
            var result = robot.Report();
            Assert.AreEqual("2,2,EAST", robot.Report());
        }

        [TestMethod]
        public void Robot_Placed_Moved_Turned_Report()
        {
            var robot = new Robot();
            robot.Place(1, 2, Direction.EAST);
            robot.Move();
            robot.Move();
            robot.Left();
            robot.Move();
            Assert.AreEqual("3,3,NORTH", robot.Report());
        }
    }
}
