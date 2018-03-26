using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Common
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public enum Turn
    {
        LEFT,
        RIGHT
    }

    public enum Command
    {       
        PLACE,
        MOVE,
        REPORT,
        LEFT,
        RIGHT
    }
}
