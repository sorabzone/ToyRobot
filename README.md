# ToyRobot
Toy Robot Simulator

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




Error Logging
-----------------------------------------------------------------------------------------------------------------------------------
- There is a custom error logger to handle exceptions and errors.
- All unhandled exceptions and errors will be displayed on console.
- Logger can be configured to log exceptions in file or display in console. But for now it will only display errors in console

