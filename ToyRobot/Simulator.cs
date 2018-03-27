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
        /// 
        /// </summary>
        /// <param name="lines"></param>
        public void FeedCommands(string[] lines)
        {
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of text.txt = ");
            foreach (string line in lines)
            {
                Console.WriteLine("command# : " + line);
                ExecuteSingleCommand(line);
            }
        }

        /// <summary>
        /// Executes the incoming command.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public string ExecuteSingleCommand(string userInput)
        {
            string output = userInput;
            CommandArguments arguments = new CommandArguments();
            if(ParseCommand(userInput, ref arguments))
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

        /// <summary>
        /// Parse the incoming command 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cmdArgs"></param>
        /// <returns></returns>
        private bool ParseCommand(string command, ref CommandArguments cmdArgs)
        {
            Command inputCommand;
            string robotCmd = string.Empty;
            string[] argDelimiter = command.Split(' ');

            //Check for valid command
            if (argDelimiter.Length > 0 && argDelimiter.Length < 3 && Enum.TryParse<Command>(argDelimiter[0], true, out inputCommand))
            {
                cmdArgs.Instruction = inputCommand;
            }
            else
                return false;

            //Check for non-PLACE commands
            if (cmdArgs.Instruction.Equals(Command.PLACE) && argDelimiter.Length == 1)
            {
                return false;
            }
            else if (cmdArgs.Instruction.Equals(Command.PLACE) && argDelimiter.Length == 2)
            {
                return ParseArguments(argDelimiter[1], ref cmdArgs);
            }

            return true;
        }

        /// <summary>
        /// Parse the arguments passed to PLACE command
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="cmdArgs"></param>
        /// <returns></returns>
        private bool ParseArguments(string arguments, ref CommandArguments cmdArgs)
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
    }
}
