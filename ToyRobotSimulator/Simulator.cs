using System;
using ToyRobot;
using ToyRobot.Common;
using ToyRobotSimulator.Model;

namespace ToyRobotSimulator
{
    public class Simulator
    {
        private Robot _robot;

        public Simulator()
        {
            _robot = new Robot();
        }

        /// <summary>
        /// This method reads commands from an array and sends to robot object.
        /// </summary>
        /// <param name="lines">array of robot commands</param>
        public void FeedCommands(string[] lines)
        {
            try
            {
                // Display the file contents by using a foreach loop.
                System.Console.WriteLine("Contents of text.txt = ");
                foreach (string line in lines)
                {
                    Console.WriteLine("command# : " + line);
                    ExecuteSingleCommand(line);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sends incoming command to robot.
        /// </summary>
        /// <param name="userInput">command for robot</param>
        /// <returns></returns>
        public string ExecuteSingleCommand(string userInput)
        {
            try
            {
                string output = userInput;
                CommandArguments arguments = new CommandArguments();
                if (ParseCommand(userInput, ref arguments))
                {
                    switch (arguments.Instruction)
                    {
                        case Command.PLACE:
                            _robot.Place(arguments.X, arguments.Y, arguments.Face);
                            break;
                        case Command.MOVE:
                            _robot.Move();
                            break;
                        case Command.LEFT:
                            _robot.Left();
                            break;
                        case Command.RIGHT:
                            _robot.Right();
                            break;
                        case Command.REPORT:
                            output = _robot.Report();
                            Console.WriteLine(output);
                            break;
                        default:
                            break;
                    }
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Parse the incoming command 
        /// </summary>
        /// <param name="command">command for robot</param>
        /// <param name="cmdArgs">returns command arguments</param>
        /// <returns></returns>
        private bool ParseCommand(string command, ref CommandArguments cmdArgs)
        {
            try
            {
                Command inputCommand;
                string robotCmd = string.Empty;
                string[] argDelimiter = command.Split(' ');

                //Check for valid command
                //Empty command or command with more than 2 string parts is invalid. It also checks spelling
                if (argDelimiter.Length > 0 && argDelimiter.Length < 3 && Enum.TryParse<Command>(argDelimiter[0], true, out inputCommand))
                {
                    cmdArgs.Instruction = inputCommand;
                }
                else
                    return false;

                //PLACE command without coordinates is invalid
                //non-PLACE command with extra characters/words is invalid
                if ((cmdArgs.Instruction.Equals(Command.PLACE) && argDelimiter.Length == 1) || (!cmdArgs.Instruction.Equals(Command.PLACE) && argDelimiter.Length == 2))
                {
                    return false;
                }
                else if (cmdArgs.Instruction.Equals(Command.PLACE) && argDelimiter.Length == 2)
                {
                    return ParseArguments(argDelimiter[1], ref cmdArgs);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Parse the arguments passed to PLACE command
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="cmdArgs"></param>
        /// <returns></returns>
        private bool ParseArguments(string arguments, ref CommandArguments cmdArgs)
        {
            try
            {
                var subArgs = arguments.Split(',');
                int x, y;
                Direction face;

                if (subArgs.Length == 3 &&
                    int.TryParse(subArgs[0], out x) &&
                    int.TryParse(subArgs[1], out y) &&
                    Enum.TryParse<Direction>(subArgs[2], true, out face))
                {
                    cmdArgs.X = x;
                    cmdArgs.Y = y;
                    cmdArgs.Face = face;
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
