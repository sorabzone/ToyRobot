using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLogger;
using NLog;

namespace ToyRobotSimulator
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Toy Robot Simulator");
                Console.WriteLine("-------------------");
                Console.WriteLine("");
                Console.WriteLine("Press 1 to read commands from test.txt file or press any other key to enter manual commands. And press Enter");
                Console.WriteLine("");
                string command = Console.ReadLine();

                Simulator robotSimulator = new Simulator();

                //If user selects "1" then simulator will commands from test.txt file in ToyRobot\ToyRobotSimulator\bin\Debug\TestData\ folder
                //Else user enter individual commands in console.
                if (command.Equals("1"))
                {
                    string[] lines = System.IO.File.ReadAllLines(@"TestData\test.txt");

                    robotSimulator.FeedCommands(lines);

                    command = Console.ReadLine();
                }
                else
                {
                    System.Console.WriteLine("Please enter commands. ");
                    while (true)
                    {
                        Console.Write("command# : ");
                        command = Console.ReadLine();

                        //User can type 'EXIT' and press enter to exit program
                        if (command.ToUpper() == "EXIT")
                        {
                            Environment.Exit(0);
                        }

                        robotSimulator.ExecuteSingleCommand(command);
                    }
                }
            }
            catch (Exception ex)
            {
                RLogger.RLogger.LogError(ex);
                Console.ReadLine();
            }
        }
    }
}
