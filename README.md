Toy Robot Simulator
=======================

Description
-----------------------------------------------------------------------------------------------------------------------------------

- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units. The size of table is configuration via a key in app-setting.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
- Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

Robot will accept following commands:-

PLACE X,Y,F

MOVE

LEFT

RIGHT

REPORT
	
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command.
- The application should discard all commands in the sequence until a valid PLACE command has been executed.




Input
-----------------------------------------------------------------------------------------------------------------------------------

- This application can take commands as input from user via command prompt.
- This application can also read commands from a text file. File path is "ToyRobot\ToyRobotSimulator\bin\Debug\TestData\test.txt"
- Application will ask user to select the input mode:
	Select '1' and press enter to read from file
	Select any other key and press enter to read commands from command prompt



	
Invalid Commands Rules
-----------------------------------------------------------------------------------------------------------------------------------

- Spelling mistakes are considered invalid
- Commands with extra spaces are considered invalid
- Any PLACE command that places robot out of board is ignored
- Any MOVE command that places robot out of board is ignored
- All commands before a valid PLACE command are ignored
- PLACE 02,03,NORTH - this command is considered valid because Robot will interpret 02 & 03 as 2 & 3 respectively




Error Logging
-----------------------------------------------------------------------------------------------------------------------------------

- There is a custom error logger to handle exceptions and errors.
- All unhandled exceptions and errors will be displayed on console.
- Logger can be configured to log exceptions in file or display in console. But for now it will only display errors in console






Solution Structure
-----------------------------------------------------------------------------------------------------------------------------------

- Solution contains four projects
a) RLogger - This project provides custom logging capability. NLog nuget package is used to log error.
It can be configured to log error in file or to display in console. This application is configured to display errors in console.

b) ToyRobot - This project builds into a class library (DLL). Any application can refer this to create and use Toy Robot. The object of this class is self sufficient to receive any commands and track it's movements.

c) ToyRobotSimulator - This is a console application that creates a Robot and issues commands to it. User can execute/run this project and issue commands to robot.
	- Simulator can take individual commands(one command at a time) from user visa console. 
	- It is also designed to read commands from a text file.

d)ToyRobotTest - This project contains test cases to test robot and simulator. For more details check next section.

	
	
	
Unit Testing
-----------------------------------------------------------------------------------------------------------------------------------

- Solution contains a test project to verify individual robot movements.
- There are 2 sets of test cases:
	a) UnitTestRobot.cs - to input single command at a time to robot and track its movement.
	b) UnitTestSimulator.cs - to input collection of commands together to simulator.




Constraints
-----------------------------------------------------------------------------------------------------------------------------------

- The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot.
- Any move that would cause the robot to fall must be ignored.




Example Input and Output
-----------------------------------------------------------------------------------------------------------------------------------

### Example (a)

    PLACE 0,0,NORTH
    MOVE
    REPORT

Expected output:

    0,1,NORTH

	
### Example (b)

    PLACE 0,0,NORTH
    LEFT
    REPORT

Expected output:

    0,0,WEST

	
### Example (c)

    PLACE 1,2,EAST
    MOVE
    MOVE
    LEFT
    MOVE
    REPORT

Expected output

    3,3,NORTH
    
    
### Example (d)
	PLACE 5,7,EAST
        MOVE
        PLACE 1,2,EAST
        MOVE
        MO VE
        LEFT
        MOVE
	
Expected output

    2,3,NORTH
    
### Example (e)
	PLACE 5,7,EAST
        MOVE
        PLACE     1,2,EAST
        MOVE
        MO VE
        LEFT
        MOVE
	
Expected output - There will be no output because the robot is not on table

    
