using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageHopkins_PP_1_Game_Of_Life
{
    /*
     * Cells - The heart of the game is a 2d array of cells. A cell must be able to assume
     * one of two different states: alive or dead. In it's simplest form a cell could be
     * represented by a Boolean. It might also be represented by a simple struture or class
     * containing a Boolean. A structure or class would allow the cell to store additional 
     * information like how many generations it's been alive.
     */
    public class Cell
    {
        public int gensAlive { get; set; }
        public bool isAlive { get; set; }
        public (int x, int y) position;
        public Cell((int x, int y) pos, bool isAlive=true)
        {
            this.position.x = pos.x;
            this.position.y = pos.y;
            this.isAlive = isAlive;
        }
        public int countNeighbors(Universe universe)
        {
            int neighbors = 0;
            for (int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    neighbors += universe.getCell((position.x + i, position.y + j)).isAlive ? 1 : 0; 
                }
            }
            neighbors -= universe.getCell((position.x, position.y)).isAlive ? 1 : 0;
            return neighbors;
        }
    }
}
