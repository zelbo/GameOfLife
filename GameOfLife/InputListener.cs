using System;
using System.Collections.Generic;
using System.Text;
using ConsoleLib;
using static ConsoleLib.NativeMethods;

namespace GameOfLife
{
    class InputListener
    {
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
