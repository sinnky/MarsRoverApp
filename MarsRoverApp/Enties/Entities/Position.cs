using Enums;
using Helpers;
using System;

namespace MarsRoverApp.Enties
{
    public class Position : IEntity
    {
        public Position(int pos_x, int pos_y,DirectionEnum direction)
        {
            this.Pos_X = pos_x;
            this.Pos_Y = pos_y;
            this.Direction = direction;
        }
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}