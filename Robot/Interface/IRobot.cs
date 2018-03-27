using ToyRobot.Common;

namespace ToyRobot.Interface
{
    interface IRobot
    {
        /// <summary>
        /// Prints current posotion of robot on console
        /// </summary>
        string Report();

        /// <summary>
        /// Place robot in new position and direction. Do nothing if new state is not valid
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordonate</param>
        /// <param name="newDirection">Direction</param>
        void Place(int x, int y, Direction newDirection);

        /// <summary>
        /// Turn to left
        /// </summary>
        void Left();

        /// <summary>
        /// Turn to right
        /// </summary>
        void Right();

        /// <summary>
        /// Moves robot one position ahead in facing direction
        /// </summary>
        void Move();
    };
}
