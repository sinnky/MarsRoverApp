using MarsRoverApp.Enties;
using Enums;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var roverList = GetRoverList();
            var checkRoverCrashed = false;

            foreach (var rover in roverList)
            {
                if (!checkRoverCrashed)
                {
                    foreach (var command in rover.Commands)
                    {
                        var commandType = RoverCommandHelper.RoverCommandFromChar(command);
                        if (!rover.Act(commandType.Value))
                        {
                            Console.WriteLine("Rover vehicle went out of plateau");
                            break;
                        }
                        else if (!CheckRoverAccidentStatus(rover, roverList))
                        {
                            checkRoverCrashed = true;
                            break;
                        }
                    }
                    Console.WriteLine($"{rover.Position.Pos_X} {rover.Position.Pos_Y} {EnumHelper<DirectionEnum>.GetDisplayValue(rover.Position.Direction)}");
                    Console.WriteLine("-------");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Getting plateau information for rover
        /// </summary>
        /// <returns></returns>
        static PlateauSurface GetPlateauSurface()
        {
            Console.WriteLine("Plateau surface size heigth and width (enter 2 number with space.):");
            while (true)
            {
                var sizeInput = Console.ReadLine();
                try
                {
                    var numbers = sizeInput.Split(" ");
                    var height = int.Parse(numbers[1]);
                    var width = int.Parse(numbers[0]);
                    return new PlateauSurface(height, width);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter in the correct format. (Enter 2 number with space.)");
                }
            }
        }

        /// <summary>
        /// Receiving position and direction information for the rover
        /// </summary>
        /// <returns></returns>
        static Position GetRoverPosition(int index)
        {
            Console.WriteLine($"Please enter {index}. Rover position as number and direction as a character (X position, Y position and direction)");
            while (true)
            {
                var position = Console.ReadLine();
                try
                {
                    var input = position.Split(" ");
                    var pos_x = int.Parse(input[0]);
                    var pos_y = int.Parse(input[1]);

                    var direction = DirectionHelper.RoverDirectionFromChar(Char.Parse(input[2]));
                    if (direction == null)
                        throw new Exception();

                    return new Position(pos_x, pos_y, direction.Value);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please enter in the correct position format for {index}. rover. (X position as number, space, Y position as number, space, and direction as a character. Enter direction information as N,W,E,S.)");
                }
            }
        }

        /// <summary>
        /// Receiving command information for rover
        /// </summary>
        /// <returns></returns>
        static string GetRoverCommands(int index)
        {
            Console.WriteLine($"Please enter {index}. Rover commands. (Please only enter L, R and M characters.)");
            while (true)
            {
                var commands = Console.ReadLine();
                try
                {
                    foreach (var item in commands)
                    {
                        if (RoverCommandHelper.RoverCommandFromChar(item) == null)
                            throw new Exception();
                    }
                    return commands;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please enter in the correct command format for {index}. Rover. (Please only enter L, R and M characters.)");
                }
            }
        }

        /// <summary>
        /// Retrieving rover information added in the application. If there is more than one rover, it is added here.
        /// </summary>
        /// <returns></returns>
        static List<Rover> GetRoverList()
        {
            var roverList = new List<Rover>();
            int roverIndex = 1;


            var surfaceSize = GetPlateauSurface();
            var roverPosition = GetRoverPosition(roverIndex);
            var roverCommands = GetRoverCommands(roverIndex);
            roverList.Add(new Rover(roverPosition, surfaceSize, roverCommands, roverIndex));
            while (true)
            {
                Console.WriteLine("Do you want to add a new Rover? Please enter Y for Yes and N for No.");
                var state = Console.ReadLine();
                try
                {
                    if (Char.Parse(state.ToUpper()) == 'Y')
                    {
                        roverIndex++;
                        var newRoverPosition = GetRoverPosition(roverIndex);
                        var newRoverCommands = GetRoverCommands(roverIndex);
                        roverList.Add(new Rover(newRoverPosition, surfaceSize, newRoverCommands, roverIndex));
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    roverIndex--;
                    Console.WriteLine("Please enter in the correct format. (X position as number, space Y position as number and position as character. Enter position information as N,W,E,S.)");
                }
            }
            return roverList;
        }

        /// <summary>
        /// The crash status of the rovers with each other is checked.
        /// </summary>
        /// <param name="activeRover"></param>
        /// <param name="roverList"></param>
        /// <returns></returns>
        static bool CheckRoverAccidentStatus(Rover activeRover, List<Rover> roverList)
        {
            var otherRoverList = roverList.Skip(activeRover.RoverIndex).ToList();
            foreach (var rover in otherRoverList)
            {
                if (activeRover.Position.Pos_X == rover.Position.Pos_X && activeRover.Position.Pos_Y == rover.Position.Pos_Y)
                {
                    Console.WriteLine($"{activeRover.RoverIndex }. Rover crashed with {rover.RoverIndex}. Rover");
                    return false;
                }
            }

            return true;
        }
    }
}
