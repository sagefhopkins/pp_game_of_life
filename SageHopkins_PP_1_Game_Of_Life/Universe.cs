using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageHopkins_PP_1_Game_Of_Life
{
    /*
     * Universe and the Scratch Pad - Cells exist in a 2 dimensional universe. Programmatically
     * the simplest represtation of this universe would be a 2d array of cells. When the game
     * starts running we will need two such arrays: one to represent the current universe and a 
     * second to function as a kind of scratch pad in which to calculate the next generation. 
     * Both arrays need to be the same size. Let's say 100 cells width and 100 cells high. From
     * here on out we'll refer to one as the universe and the second as the scratch pad.
     */
    public class Universe
    {
        //Empty variable to publically store universe.
        public Cell[,] universe;
        //Variable to publically store the number of livings cells.
        public int livingCells = 0;
        //Empty variable to publically store the scratch version of the universe. This variable is used to write changes to the Universe before these changes are displayed and recalculated.
        public Cell[,] scratch;
        //Variable used to determine which boundary rule is being used. True = Toroidal, False = Finite.
        public bool toroidalBoundary = true;
        //Empty variable used to store Random class. Starts as Empty because the Random Class is updated based on a few different cases which are handled further down.
        Random rand;
        //Empty variable to publically store the seed of the Universe. This is undefined because a few cases must be handled before this is assigned. It is handled further down.
        public int seed;

        /*
         * This function returns the current status (bool) of a given cell. It also applies a rules defined below in order to handle different Universe boundaries (Toroidial, Finite).
         */
        public bool getCell((int x, int y) pos)
        {
            //Stores the state of the above-given cell.
            bool status;

            //Check if the boundary is Torodial
            if (toroidalBoundary)
            {
                //Check if the x position of the given cell is below the minimum width of the Universe. If so, place it onto the oposite side of the Universe.
                if (pos.x < 0)
                {
                    //Place the cell on the oposite side of the Universe.
                    pos.x = universe.GetLength(0) + pos.x;
                }

                //Check if the y position of the given cell is below the minimum height of the Universe. If so, place it onto the opposite side of the Universe.
                if (pos.y < 0)
                {
                    //Place the cell on the opposite side of the Universe.
                    pos.y = universe.GetLength(1) + pos.y;
                }

                //Check if the x position of the given cell is above the maximum width of the Universe. If so, place it onto the opposite side of the Universe.
                if (pos.x > universe.GetLength(0) - 1)
                {
                    //Place the cell on the opposite side of the Universe.
                    pos.x = universe.GetLength(0) - pos.x;
                }

                //Check if the y position of the given cell is above the maximum height of the Universe. If so, place it onto the opposite side of the Universe.
                if (pos.y > universe.GetLength(1) - 1)
                {
                    //Place the cell on the opposite side of the Universe.
                    pos.y = universe.GetLength(1) - pos.y;
                }

                //Return the current status (bool) of the given cell.
                status = universe[pos.x, pos.y].isAlive;
            }
            //If the boundary is not Torodial, apply the finite boundary rules.
            else
            {

                //Check if the given cells x, or y position is less than or greater than the bounds of the Universe. If so, change the status of the cell to dead.
                if (pos.x < 0 || pos.x > universe.GetLength(0) - 1 || pos.y < 0 || pos.y > universe.GetLength(1) - 1)
                {
                    //Kill the cell.
                    status = false;
                }
                //Check if the given cell has not left the bounds of the Universe. If so, the cell remains in the status it's currently in.
                else
                {
                    //Return the current status (bool) of the given cell.
                    status = universe[pos.x, pos.y].isAlive;
                }
            }

            //Return the status of the cell, based on either set of the above-applied rules.
            return status;
        }

        /*
         * This is the Universe Constructor. It takes given parameters (int seedValue, int width, int height) and creates a Universe based on a few different rules.
         * When given a seedValue of -1, the Universe Constructor generates a Universe based on time.
         * When given a seedValue of 0, the Universe Constructor generates an empty Universe.
         * When given a seedValue of greater than 0, the Universe Constructor generates a Universe based on the given seed.
         */
        public Universe(int seedValue, int width, int height)
        {
            //Take given seedValue, and apply it to the publically assessible seed variable for the Universe class.
            this.seed = seedValue;
            //Create an empty array of Cells based on the given height, and width.
            universe = new Cell[width, height];

            //Check if the seed will be generated based on time. If so, generate the seed based on the current time.
            if(seed == -1)
            {
                //Generate the seed based on time. The default for the Random class is to generate based on time, so no need for flags or parameters.
                this.rand = new Random();
                //Assign a seed to the publically assessible Universe seed variable.
                this.seed = rand.Next(0, 1000000);
            }

            //Create the instance of the Random class based on the seed.
            this.rand = new Random(seed);

            //Loop through the width of the Universe.
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                //Loop through the height of the Universe.
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    //Check if the seed is 0. If so, generate a Universe of dead cells.
                    if(seed == 0)
                    {
                        //Create instance of Cell, which is dead.
                        this.universe[i, j] = new Cell((i, j), false);
                    }
                    //Otherwise, if the seed is anything else, generate a Universe based on the above-defined seed.
                    else
                    {
                        //Generate a random number between 0 and 3.
                        int num = rand.Next(0, 3);
                        //Define the default state of the of the Cell.
                        bool alive = false;

                        //Check if the number generated above is 0. If so, the Cell status is alive.
                        if (num == 0)
                        {
                            //Set the status of the Cell to alive.
                            alive = true;
                            //Update the current count of living Cells.
                            livingCells += 1;
                        }

                        //Create new instance of Cell based on the above logic, then store it into the Universe array.
                        this.universe[i, j] = new Cell((i, j), alive);
                    }
                    
                }
            }
            //Set the Scratch Pad array to be the same as the current Universe.
            scratch = universe;
        }

        /*
         * The copyGeneration function is used to translate chages made in the Scratch Pad array to the current Universe array.
         */
        public void copyGeneration(Cell[,] array)
        {
            //Create a new instance of the Universe array based on the current width and height of the previous generations Universe.
            universe = new Cell[universe.GetLength(0), universe.GetLength(1)];

            //Loop through the width of the Universe.
            for (int i = 0; i < array.GetLength(0); i++)
            {
                //Loop through the height of the Universe.
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    //Create an instance of the Cell based on the status of the Cell in the Scratch Pad array, to the Universe array.
                    universe[i, j] = new Cell((i, j), scratch[i, j].isAlive);
                }
            }
        }

        /*
         * The clear function is used to "Clear" the Universe, or rather set the status of all Cells in the Universe to dead.
         */
        public void clear()
        {
            //Loop through the width of the Universe.
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                //Loop through the height of the Universe.
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    //Create an instance of a dead Cell, to the Universe Array.
                    universe[i, j] = new Cell((i, j), false);
                }
            }
        }

        /*
         * The nextGeneration function is used to apply the rules of The Game of Life to the current Universe. It does this by making calculations based on the current Universe, and applying
         * it's changes into the Scratch Pad array. Once the function looped through the entire Universe, the Scratch Pad array is made the current Universe using the copyGeneration function.
         */
        public void nextGeneration()
        {
            //Because a new count of the living cells must be taken, set the current living cells to 0.
            livingCells = 0;

            //Loop through the width of the Universe.
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                //Loop through the height of the Universe.
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    //Count the current neighbors of the given cell, and assign it to the neighbors variable using the countNeighbors function of the Cell class.
                    int neighbors = universe[i, j].countNeighbors(this);
                    //Assign the given cell to the currentCell variable.
                    Cell currentCell = universe[i, j];

                    //Check if the current neighbors are less than 2. If so, the given cell dies.
                    if (currentCell.isAlive == true && neighbors < 2)
                    {
                        //Kill the given cell.
                        scratch[i, j].isAlive = false;
                    }

                    //Check if the given Cell is alive and has more than 3 neighbors. If so, the given cell dies.
                    else if (currentCell.isAlive == true && neighbors > 3)
                    {
                        //Kill the given cell.
                        scratch[i, j].isAlive = false;
                    }

                    //Check if the given Cell is dead and has 3 neighbors. If so, the given cell is alive.
                    else if (currentCell.isAlive == false && neighbors == 3)
                    {
                        //The given cell is alive.
                        scratch[i, j].isAlive = true;
                    }

                    //If none of the above rules applied to the given Cell, the Cell remains in the state it's currently in.
                    else
                    {
                        //The given cell remains in it's current state.
                        scratch[i, j].isAlive = currentCell.isAlive;
                    }

                    //Check if the given Cell is alive. If so, count it in the living Cells count.
                    if (currentCell.isAlive)
                    {
                        //Count the Cell.
                        livingCells += 1;
                    }
                }
            }

            //Replace the current Universe with the Scratch Pad array.
            copyGeneration(scratch);
        }
    }
}
