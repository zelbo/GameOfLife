using System;
using System.Threading;
using ConsoleLib;
using static ConsoleLib.NativeMethods;

/* Conway's Game of Life
 * https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
 */

namespace GameOfLife
{

    class Program
	{
		static Versions myVersion = Versions.Console;
		//static int myVersion = (int)Versions.Console;
		static int sleepTime = 500; // in ms
		static void Main(string[] args)
		{
			/* Starting State Options
			 * 
				optional command line args
				life()
				life(startingPattern, numberOfStartingPoints, timeToRun)

			// use command line args, default to starting file, press <enter> to click edit, <enter> again to run
			// allow command line args to define starting seeds. generate files for interesting starting seeds
			// allow randomized starting state
			*/

			bool doExit = false;
			while(!doExit)
			{
				// get input
				// maybe this: https://stackoverflow.com/questions/57615/how-to-add-a-timeout-to-console-readline/2041489
				Console.WriteLine("Menu under construction. enter amount of game ticks to process.");
				int runTime = Int32.Parse(Console.ReadLine());
				int ticks = 0;
				GameBoard gameBoard = new GameBoard(myVersion); // initialize game state (get input from file or user)
				//gameBoard.Draw(); // draw starting board
				gameBoard.InitializeBoard();

				// game loop
				bool currentInput = false;
				while (!currentInput) // depending on the use of interface devices here - in a console app
				{
					//Console.ReadKey(); // debug
					gameBoard.CheckRules();
					gameBoard.ApplyChanges();
					gameBoard.Draw();

					// pause a couple ms
					Thread.Sleep(sleepTime);

					ticks++;
					if (ticks >= runTime)
					{
						// this is very sloppy. get proper input interupt working.
						currentInput = true;
					}
				}

				Console.SetCursorPosition(0, 20); // since we are going with hacky draw function
				Console.WriteLine("Press the any key to continue.");
				Console.ReadKey();
				doExit = true;
			}

		}

		static void InitConsoleListener()
		{
			/*
			 * getting mouse click in console from https://stackoverflow.com/users/4454665/swdv
			 * found here: https://stackoverflow.com/questions/1944481/console-app-mouse-click-x-y-coordinate-detection-comparison
			 * see here for further reading: https://www.medo64.com/2013/05/console-mouse-input-in-c/
			 * also examine raw input from microsoft:
			 * https://docs.microsoft.com/en-us/windows/win32/inputdev/about-raw-input?redirectedfrom=MSDN
			 * https://docs.microsoft.com/en-us/windows/win32/inputdev/raw-input?redirectedfrom=MSDN
			 * input from xbox controller?
			 */

			IntPtr inHandle = GetStdHandle(STD_INPUT_HANDLE);
			uint mode = 0;
			GetConsoleMode(inHandle, ref mode);
			mode &= ~ENABLE_QUICK_EDIT_MODE; //disable
			mode |= ENABLE_WINDOW_INPUT; //enable (if you want)
			mode |= ENABLE_MOUSE_INPUT; //enable
			SetConsoleMode(inHandle, mode);
		}
	}
}

