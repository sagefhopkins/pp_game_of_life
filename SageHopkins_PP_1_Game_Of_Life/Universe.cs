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
        public Cell[,] universe;
        public int livingCells = 0;
        Cell[,] scratch;
        Random rand;

        public Cell getCell((int x, int y) pos)
        {
            if (pos.x < 0)
            {
                pos.x = universe.GetLength(0) + pos.x;
            }
            if (pos.y < 0)
            {
                pos.y = universe.GetLength(1) + pos.y;
            }
            if (pos.x > universe.GetLength(0) - 1)
            {
                pos.x = universe.GetLength(0) - pos.x;
            }
            if (pos.y > universe.GetLength(1) - 1)
            {
                pos.y = universe.GetLength(1) - pos.y;
            }
            return universe[pos.x, pos.y];
        }
        public Universe(int seed, int size)
        {
            universe = new Cell[size, size];
            this.rand = new Random(seed);
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    if(seed == 0)
                    {
                        this.universe[i, j] = new Cell((i, j), false);
                    }
                    else
                    {
                        int num = rand.Next(0, 3);
                        bool alive = false;
                        if (num == 0)
                        {
                            alive = true;
                            livingCells += 1;
                        }
                        this.universe[i, j] = new Cell((i, j), alive);
                    }
                    
                }
            }
            scratch = universe;
        }
        /*
         * Next Generation – To calculate the next generation of cells we need to iterate through 
         * the universe using a couple of nested for loops and apply a few simple rules to decide 
         * whether the corresponding cell in the scratch pad should be turned on or off.
         */
        public void copyGeneration(Cell[,] array)
        {
            universe = new Cell[universe.GetLength(0), universe.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    universe[i, j] = new Cell((i, j), scratch[i, j].isAlive);
                }
            }
        }
        public void clear()
        {
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    universe[i, j] = new Cell((i, j), false);
                }
            }
        }
        public void nextGeneration()
        {
            livingCells = 0;
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    int neighbors = universe[i, j].countNeighbors(this);
                    Cell currentCell = universe[i, j];

                    if (currentCell.isAlive == true && neighbors < 2)
                    {
                        scratch[i, j].isAlive = false;
                    }
                    else if (currentCell.isAlive == true && neighbors > 3)
                    {
                        scratch[i, j].isAlive = false;
                    }
                    else if (currentCell.isAlive == false && neighbors == 3)
                    {
                        scratch[i, j].isAlive = true;
                    }
                    else
                    {
                        scratch[i, j].isAlive = currentCell.isAlive;
                    }
                    if (currentCell.isAlive)
                    {
                        livingCells += 1;
                    }
                }
            }
            copyGeneration(scratch);
        }
    }
}
