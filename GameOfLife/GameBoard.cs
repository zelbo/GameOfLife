using System;
using System.Collections.Generic;

/* Conway's Game of Life
 * https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
 */

namespace GameOfLife
{
    public class GameBoard
	{
		const bool STATUS_ALIVE = true;
		const bool STATUS_DEAD = false;
		const char DEAD_SYMBOL = ' ';
		const char LIVE_SYMBOL = 'X'; // look into some ascii blocks for this part
		const int POPULATION_MIN = 2;
		const int POPULATION_MAX = 3; // deceptive, actual max is this number + 1
		public static Random random = new Random();
		static double probability = 0.25; // between 0.0 and 1.0, fiddle with this a bit maybe
		static int height;
		static int width;
		public bool[,] cells;
		List<Change> changes = new List<Change>();
		
		public GameBoard()
		{
			height = 20;
			width = 80;
			cells = new bool[width, height];
			// until proper args parsing is implemented, randomize starting state
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					cells[x, y] = (random.NextDouble() <= probability);
				}
			}
		}

		public void Draw()
		{
			// render the game board to the console
			// stringbuilder row by row? 
			Console.Clear();
			for (int y = 0; y >= height; y++)
			{
				string row = "";
				for (int x = 0; x >= width; x++)
				{
					if (cells[x, y])
					{
						row += LIVE_SYMBOL;
					}
					else
					{
						row += DEAD_SYMBOL;
					}
				}
				Console.WriteLine(row);
			}

		}

		public int CountNeighbors(int x, int y)
		{
			// check each orthogonal and diagonal neighbor for life
			int count = 0;
			for (int yOffset = -1; yOffset <= 1; yOffset++)
			{
				for (int xOffset = -1; xOffset <= 1; xOffset++)
				{
					// bounds checking to stay inside game board limits
					int xToCheck = x + xOffset;
					int yToCheck = y + yOffset;
					if ((xToCheck >= 0 && xToCheck < width) && (yToCheck >= 0 && yToCheck < height))
					{
						if (cells[xToCheck, yToCheck])
						{
							count++;
						}
					}
				}

			}
			// don't count the center cell
			if (cells[x, y])
			{
				count--;
			}

			return count;
		}

		public void CheckRules()
		{
			// push changes to the list 
			Change change = new Change(); // is this just adding a reference to the same change each time?
			bool cell = false;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					cell = cells[x, y];

					if (cell)
					{
						int cell_count = CountNeighbors(x, y);
						if (cell_count < POPULATION_MIN)
						{
						// if countneighbors <2, die (Underpopulation)
							change.x = x;
							change.y = y;
							change.status = STATUS_DEAD;
							changes.Add(change);
						}
						else if (cell_count > POPULATION_MAX)
						{
							// if count >3, die (Overpopulation)
							// same code as above. refactor to a die() method?
							change.x = x;
							change.y = y;
							change.status = STATUS_DEAD;
							changes.Add(change);
						}
						else
						{
							// if count == 2 or == 3, live (Harmony) - do nothing
							// possibly log the value of count to a file to make sure this is only triggering on 2 or 3
						}

					}
					else
					{
						// if count == 3, live (Reproduction)
						// more duplicate code. refactor?
						int cell_count = CountNeighbors(x, y);
						if (cell_count == POPULATION_MAX)
						{
							change.x = x;
							change.y = y;
							change.status = STATUS_ALIVE;
							changes.Add(change);
						}
					}
				}
			}
		}

		public void ApplyChanges() // rename to Update()?
		{
			// for each change in changes, pop change and apply status to cell according to location
			// build a pop() function: https://stackoverflow.com/questions/24855908/how-to-dequeue-element-from-a-list
			foreach (var change in changes)
			{
				cells[change.x, change.y] = change.status;
			}
			changes.Clear();
		}
	}
}

