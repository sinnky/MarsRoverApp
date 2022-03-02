using Enums;
using System;

namespace Helpers
{
    public class RoverCommandHelper
    {
        /// <summary>
        /// Entered command information converted to RoverCommandEnum
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static RoverCommandEnum? RoverCommandFromChar(char command)
        {
            switch (char.ToUpper(command))
            {
                case 'L':
                    return RoverCommandEnum.Left;
                case 'R':
                    return RoverCommandEnum.Rigth;
                case 'M':
                    return RoverCommandEnum.Move;
                default:
                    return null;
            }
        }
    }
}
