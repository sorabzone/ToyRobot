using System;
using System.Configuration;
using ToyRobot.Common;
using ToyRobot.Interface;

namespace ToyRobot
{
    /// <summary>
    /// This class represents Robot that can move around a square table. 
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Table size is readonly, read at the begining of program from appsettings
        /// Default value is 5
        /// </summary>
        private readonly int TABLE_SIZE = string.IsNullOrEmpty(ConfigurationManager.AppSettings["TableSize"]) ? 5 : Convert.ToInt32(ConfigurationManager.AppSettings["TableSize"]);

        //x,y coordinates and direction of robot
        private int _x, _y;
        private Direction _face;
        public bool _inValidState;

        #region Constructor

        /// <summary>
        /// Constructor initializing robot to (-1,-1) position
        /// </summary>
        public Robot()
        {
            this._x = -1;
            this._y = -1;
            _inValidState = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Validates if position is valid or not
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        private bool IsValidNewPosition(int x, int y)
        {
            try
            {
                if (x < TABLE_SIZE && y < TABLE_SIZE)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Prints current position of robot in console
        /// </summary>
        public string Report()
        {
            try
            {
                return _inValidState ? this._x + "," + this._y + "," + Enum.GetName(typeof(Direction), this._face) : "";
            }
            catch (Exception)
            {
                throw;

            }
        }

        /// <summary>
        /// Place robot in new position and direction. Do nothing if new state is not valid
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordonate</param>
        /// <param name="newDirection">Direction</param>
        public void Place(int x, int y, Direction newDirection)
        {
            try
            {
                if (IsValidNewPosition(x, y))
                {
                    this._x = x;
                    this._y = y;
                    this._face = newDirection;
                    _inValidState = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Turn to left
        /// </summary>
        public void Left()
        {
            try
            {
                if (_inValidState)
                {
                    if (this._face.Equals(Direction.NORTH))
                        this._face = Direction.WEST;
                    else
                        this._face = (Direction)Enum.Parse(typeof(Direction), ((int)this._face - 1).ToString(), true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Turn to right
        /// </summary>
        public void Right()
        {
            try
            {
                if (_inValidState)
                {
                    if (this._face.Equals(Direction.WEST))
                        this._face = Direction.NORTH;
                    else
                        this._face = (Direction)Enum.Parse(typeof(Direction), ((int)this._face + 1).ToString(), true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Moves robot one position ahead in facing direction
        /// </summary>
        public void Move()
        {
            try
            {
                if (_inValidState)
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
