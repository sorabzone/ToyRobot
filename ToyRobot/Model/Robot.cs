using System;
using ToyRobot.Common;
using System.Configuration;

namespace ToyRobot.Model
{
    class Robot
    {
        /// <summary>
        /// Table size is readonly, read at the begining of program from appsettings
        /// Default value is 5
        /// </summary>
        private readonly int TABLE_SIZE = string.IsNullOrEmpty(ConfigurationManager.AppSettings["TableSize"]) ? 5 : Convert.ToInt32(ConfigurationManager.AppSettings["TableSize"]);

        //x,y coordinates and direction of robot
        private int _x, _y;
        private Direction _face;

        #region Constructors

        /// <summary>
        /// Constructor initializing robot to (0,0) position and facing east
        /// </summary>
        public Robot()
        {
            this._x = 0;
            this._y = 0;
            this._face = Direction.EAST;
        }

        /// <summary>
        /// Initialiazes robot with coordinates and direction provided by user
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="startDirection"></param>
        public Robot(int x, int y, Direction startDirection)
        {
            this._x = x;
            this._y = x;
            this._face = startDirection;
        }

        #endregion

        #region Private Methods
        private bool IsValidNewPosition(int x, int y)
        {
            if (x < TABLE_SIZE && y < TABLE_SIZE)
                return true;
            else
                return false;
        }

        private bool IsValidPosition()
        {
            if (this._x < TABLE_SIZE && this._y < TABLE_SIZE)
                return true;
            else
                return false;
        }
        #endregion

        #region Commands

        /// <summary>
        /// Prints current posotion of robot on console
        /// </summary>
        public void Report()
        {
            Console.Write("Current Positon: X = " + this._x + " Y = " + this._y + " Face = " + Enum.GetName(typeof(Direction), this._face));
        }

        /// <summary>
        /// Place robot in new position and direction. Do nothing if new state is not valid
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordonate</param>
        /// <param name="newDirection">Direction</param>
        public void Place(int x, int y, Direction newDirection)
        {
            if (IsValidNewPosition(x, y))
            {
                this._x = x;
                this._y = x;
                this._face = newDirection;
            }
        }

        /// <summary>
        /// Turn to left
        /// </summary>
        public void Left()
        {
            if (this._face.Equals(Direction.NORTH))
                this._face = Direction.WEST;
            else
                this._face = (Direction)Enum.Parse(typeof(Direction), ((int)this._face - 1).ToString(), true);
        }

        /// <summary>
        /// Turn to right
        /// </summary>
        public void Right()
        {
            if (this._face.Equals(Direction.WEST))
                this._face = Direction.NORTH;
            else
                this._face = (Direction)Enum.Parse(typeof(Direction), ((int)this._face + 1).ToString(), true);

        }

        /// <summary>
        /// Moves robot one position ahead in facing direction
        /// </summary>
        public void Move()
        {
            switch (this._face)
            {
                case Direction.NORTH:
                    this._y = this._y == (TABLE_SIZE - 1) ? this._y : this._y + 1;
                    break;
                case Direction.EAST:
                    this._x = this._x == (TABLE_SIZE - 1) ? this._x : this._x + 1;
                    break;
                case Direction.SOUTH:
                    this._y = this._y == 0 ? this._y : this._y - 1;
                    break;
                case Direction.WEST:
                    this._x = this._x == 0 ? this._x : this._x - 1;
                    break;
            }
        }

        #endregion
    }
}
