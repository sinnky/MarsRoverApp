using Enums;
using Helpers;
using System;

namespace MarsRoverApp.Enties
{
    public class Rover : IEntity
    {
        public Rover(Position position, PlateauSurface surface, string commands, int roverIndex)
        {
            this.Surface = surface;
            this.Position = position;
            this.Commands = commands;
            this.RoverIndex = roverIndex;
        }

        public Position Position { get; set; }

        public PlateauSurface Surface { get; set; }

        public string Commands { get; set; }

        public int RoverIndex { get; set; }

        // Rotation and motion operations of the rover
        #region Rover Operations

        /// <summary>
        /// Perform the command operation sent to the rover
        /// </summary>
        /// <param name="roverCommand"></param>
        public bool Act(RoverCommandEnum roverCommand)
        {
            switch (roverCommand)
            {
                case RoverCommandEnum.Left:
                    TurnLeft();
                    break;
                case RoverCommandEnum.Rigth:
                    TurnRigth();
                    break;
                case RoverCommandEnum.Move:
                    Move();
                    break;
            }
            return CheckRoverPosition();
        }

        /// <summary>
        /// The rover is making a Right turn.
        /// </summary>
        private void TurnRigth()
        {
            this.Position.Direction = DirectionHelper.RigthOf(this.Position.Direction);
        }

        /// <summary>
        /// The rover is making a Left turn.
        /// </summary>
        private void TurnLeft()
        {
            this.Position.Direction = DirectionHelper.LeftOf(this.Position.Direction);
        }

        /// <summary>
        /// The Rover moving one step forward.
        /// </summary>
        private void Move()
        {
            switch (this.Position.Direction)
            {
                case DirectionEnum.North:
                    this.Position.Pos_Y += 1;
                    break;

                case DirectionEnum.East:
                    this.Position.Pos_X += 1;
                    break;

                case DirectionEnum.South:
                    this.Position.Pos_Y -= 1;
                    break;

                case DirectionEnum.West:
                    this.Position.Pos_X -= 1;
                    break;
            }
        }

        /// <summary>
        /// Checking whether the rover is out of the plateau plane.
        /// </summary>
        private bool CheckRoverPosition()
        {
            if ((Position.Pos_X > Surface.Width ||
                Position.Pos_X < 0 ||
                Position.Pos_Y > Surface.Height ||
                Position.Pos_Y < 0))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}