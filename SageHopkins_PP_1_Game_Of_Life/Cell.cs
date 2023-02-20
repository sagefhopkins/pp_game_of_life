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
        //Define the publically accessible (bool) isAlive variable. This is used to track the current state of the Cell.
        public bool isAlive;
        //Define the publically accessible (tuple) position variable. This is used to track the current position of the Cell.
        public (int x, int y) position;

        /*
         * The Cell Constructor is used to create instances of the Cell class. It takes the position of the given cell, and can be overloaded 
         * if the given Cell is dead.
         */
        public Cell((int x, int y) pos, bool isAlive=true)
        {
            //Assign the x position of the Cell based on the inputted tuple.
            this.position.x = pos.x;
            //Assign the y position of the Cell based on the inputted tuple
            this.position.y = pos.y;
            //Assign the current state of the Cell based on the inputted bool.
            this.isAlive = isAlive;
        }

        /*
         * The countNeighbors function takes a given Universe and counts the current neighbors of the instance of the Cell class.
         */
        public int countNeighbors(Universe universe)
        {
            //Define variable for the current neighbors of the Cell.
            int neighbors = 0;

            //Loop through the two adject rows of the Cell, as well as the Cells row. 
            for (int i = -1; i <= 1; i++)
            {
                //Loop through the two adject columns of the Cell, as well as the Cells column.
                for(int j = -1; j <= 1; j++)
                {
                    //If any of the adject Cells is alive, add 1 to the neighbors count. Uses a Ternary operator to simplify the code, and replace an if else chain.
                    neighbors += universe.getCell((position.x + i, position.y + j)) ? 1 : 0; 
                }
            }
            //The neighbors count should not include the Cell counting it's neighbors. Therefore check if the couting Cell is alive using a Ternary operator, if so, remove 1 from the neighbors count.
            neighbors -= universe.getCell((position.x, position.y)) ? 1 : 0;

            //Return the count of the neighbors.
            return neighbors;
        }
    }
}
