using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("-------------------");
            Console.WriteLine("");
            Console.WriteLine("Press 1 to read commands from test text file or press any other key to enter manual commands. And Enter");
            Console.WriteLine("");
            string command = Console.ReadLine();

            Simulator robotSimulator = new Simulator();

            if (command.Equals("1"))
            {
                string[] lines = System.IO.File.ReadAllLines("test.txt");

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

                    if (command.ToUpper() == "EXIT")
                    {
                        Environment.Exit(0);
                    }

                    robotSimulator.ExecuteSingleCommand(command);
                }
            }

            
        }
    }
}
