/* Conway's Game of Life
 * https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
 */

namespace GameOfLife
{
    public struct Change
	{
		// need to implement getters and setters instead of defaulting to public all the time
		public int x;
		public int y;
		public bool status;
	}
}

