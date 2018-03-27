using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;

namespace ToyRobotTest
{
    [TestClass]
    public class UnitTestSimulator
    {
        [TestMethod]
        public void Simuator_Placed_Moved_Turned_Report()
        {
            var simulator = new Simulator();
            string[] commands = {"PLACE 1,2,EAST",
                                "MOVE",
                                "MOVE",
                                "LEFT",
                                "MOVE"};
            simulator.FeedCommands(commands);
            var result = simulator.ExecuteSingleCommand("REPORT");

            Assert.AreEqual("3,3,NORTH", result);
        }
    }
}
