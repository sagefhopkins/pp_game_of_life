using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SageHopkins_PP_1_Game_Of_Life
{
    public partial class Form1 : Form
    {
        Universe universe = new Universe(0, 50);
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;
        Timer timer = new Timer();
        int generations = 0;
        bool running = false;
        bool paused = false;
        bool stopped = true;
        bool next = false;
        int ms = 100;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = ms;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }
        /*
         * This function serves to update the status bar, as well as increment the generations past
         */
        private void NextGeneration()
        {
            generations++;
            toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = ms;

            if (running)
            {
                NextGeneration();
                universe.nextGeneration();
                graphicsPanel1.Invalidate();
            }
            else if (paused)
            {
                toolStripStatusLabelGenerations.Text = "Paused // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
                graphicsPanel1.Invalidate();
            }
            else if (stopped)
            {
                toolStripStatusLabelGenerations.Text = "Stopped // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
                graphicsPanel1.Invalidate();
            }
            else if (next)
            {
                NextGeneration();
                toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
                universe.nextGeneration();
                graphicsPanel1.Invalidate();
                next = false;
                paused = true;
                stopped = false;
                running = false;
            }
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            int cellWidth = 1000 / universe.universe.GetLength(0);
            int cellHeight = 1000 / universe.universe.GetLength(1);
            Pen gridPen = new Pen(gridColor, 1);
            Brush cellBrush = new SolidBrush(cellColor);
            this.Width = 1020;
            this.Height = 1120;
            for (int y = 0; y < universe.universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.universe.GetLength(0); x++)
                {
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;
                    if (universe.universe[x, y].isAlive == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);

                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, cellRect);
                    }
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    Font font = new Font("Arial Black", 9);
                    if (universe.universe[x, y].countNeighbors(universe) == 1)
                    {
                        e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Red, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                    }
                    else if (universe.universe[x, y].countNeighbors(universe) == 3)
                    {
                        e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Green, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                    }
                    else if (universe.universe[x, y].countNeighbors(universe) == 2)
                    {
                        e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Blue, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                    }
                    else if (universe.universe[x, y].countNeighbors(universe) > 3)
                    {
                        e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Orange, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                    }
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }
            gridPen.Dispose();
            cellBrush.Dispose();
        }
        /*
         * This function serves to allow the user to toggle the current state of a Cell within the Universe
         */
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.universe.GetLength(1);
                int x = e.X / cellWidth;
                int y = e.Y / cellHeight;
                universe.universe[x, y].isAlive = !universe.universe[x, y].isAlive;
                graphicsPanel1.Invalidate();
            }
        }
        /*
         * This function serves to allow the user to start the Universe, allowing it to move forward to the next generations based on the inputted tick interval
         */
        private void startButton_Click(object sender, EventArgs e)
        {
            this.running = true;
            this.paused = false;
            this.stopped = false;
        }
        /*
         * This function serves to allow the user to pause the Universe, preventing it from continuing to the next generation
         */
        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.running = false;
            this.paused = true;
            this.stopped = false;
        }
        /*
         * This function serves to allow the user to stop the Universe from moving forward to the next geneartion
         */
        private void stopButton_Click(object sender, EventArgs e)
        {
            this.running = false;
            this.paused = false;
            this.stopped = true;
        }
        /*
         * This function serves to allow the user to move the current generation one single generation forward
         */
        private void nextButton_Click(object sender, EventArgs e)
        {
            this.next = true;
            this.running = false;
            this.paused = false;
            this.stopped = false;
        }
        /*
         * This function serves to allow the user to generate a new empty universe
         */
        private void newButton_Click(object sender, EventArgs e)
        {
            universe.clear();
            graphicsPanel1.Invalidate();
            this.next = false;
            this.running = false;
            this.paused = false;
            this.stopped = true;
        }
        private void seedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
            {
                e.SuppressKeyPress = !int.TryParse(Convert.ToString((char)e.KeyData), out int _);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        /*
         * This function serves to take the user input, and generate a new universe based on the seed entered.
         */
        private void seedSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                universe = new Universe(int.Parse(seedTextBox.Text.ToString()), universe.universe.GetLength(0));
            }
            catch
            {
                seedTextBox.Text = string.Empty;
            }
        }
        /*
         * This function serves to take the user input for the miliseconds between new generations, and update the timer interval to reflect the input.
         */
        private void timerSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                ms = int.Parse(timerTextBox.Text.ToString());
            }
            catch
            {
                timerTextBox.Text = string.Empty;
            }
        }
        /*
         * This function serves to encode the current universe into a JSON array and store it based on the user's input in the Save Dialog
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Cells|*.cells";
            file.FilterIndex = 1;
            file.DefaultExt = "cells";
            if(DialogResult.OK == file.ShowDialog())
            {
                StreamWriter write = new StreamWriter(file.FileName);
                var json = "{ \"Height\" : \"" + universe.universe.GetLength(0) + "\",\"Width\" : \"" + universe.universe.GetLength(1) + "\",\"Cells\" : [";

                for(int i = 0; i < universe.universe.GetLength(0); i++)
                {
                    for(int j = 0; j < universe.universe.GetLength(1); j++)
                    {
                        if (i == universe.universe.GetLength(0)-1 && j == universe.universe.GetLength(1)-1)
                        {
                            json += "{\"isAlive\" : " + universe.universe[i, j].isAlive.ToString().ToLower() + ", \"posX\" : " + universe.universe[i, j].position.x + ",\"posY\" : " + universe.universe[i, j].position.y + "}";
                        }
                        else
                        {
                            json += "{\"isAlive\" : " + universe.universe[i, j].isAlive.ToString().ToLower() + ", \"posX\" : " + universe.universe[i, j].position.x + ",\"posY\" : " + universe.universe[i, j].position.y + "},";
                        }
                    }
                }
                json += "]}";
                write.Write(json);
                write.Close();
                }
            }
        /*
         * This function decodes an existing saved universe from a file into a JSON object, and then into the Universe object
         */
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Cells|*.cells";
            openFile.FilterIndex = 1;
            if(DialogResult.OK == openFile.ShowDialog())
            {
                StreamReader read = new StreamReader(openFile.FileName);
                string jsonData = read.ReadToEnd();
                var result = JsonConvert.DeserializeObject<dynamic>(jsonData);
                int height = result.Height;
                int width = result.Width;
                var cells = result.Cells;
                universe = new Universe(0, height);

                foreach(var cell in result.Cells)
                {
                    universe.universe[(int)cell.posX, (int)cell.posY] = new Cell(((int)cell.posX, (int)cell.posY), (bool)cell.isAlive);
                }
                read.Close();
                graphicsPanel1.Invalidate();
            }
        }
    }
}
