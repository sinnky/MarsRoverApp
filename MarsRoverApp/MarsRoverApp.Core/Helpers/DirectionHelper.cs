using Enums;
using System;

namespace Helpers
{
    public class DirectionHelper
    {
        /// <summary>
        /// New direction information is found when rover is turned left
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DirectionEnum LeftOf(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.North:
                    return DirectionEnum.West;

                case DirectionEnum.East:
                    return DirectionEnum.North;

                case DirectionEnum.South:
                    return DirectionEnum.East;

                case DirectionEnum.West:
                    return DirectionEnum.South;

                default:
                    return direction;
            }
        }

        /// <summary>
        /// New direction information is found when rover is turned right
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DirectionEnum RigthOf(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.North:
                    return DirectionEnum.East;

                case DirectionEnum.East:
                    return DirectionEnum.South;

                case DirectionEnum.South:
                    return DirectionEnum.West;

                case DirectionEnum.West:
                    return DirectionEnum.North;

                default:
                    return direction;
            }
        }

        /// <summary>
        /// Entered command informatin converted to DirectionEnum
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DirectionEnum? RoverDirectionFromChar(char command)
        {
            switch (char.ToUpper(command))
            {
                case 'N':
                    return DirectionEnum.North;
                case 'E':
                    return DirectionEnum.East;
                case 'S':
                    return DirectionEnum.South;
                case 'W':
                    return DirectionEnum.West;
                default:
                    return null;
            }
        }
    }
}