using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SageHopkins_PP_1_Game_Of_Life
{
    public partial class Form1 : Form
    {
        Universe universe = new Universe(100, 50);
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
        private void NextGeneration()
        {
                generations++;
                toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms";
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
                toolStripStatusLabelGenerations.Text = "Paused // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms";
                graphicsPanel1.Invalidate();
            }
            else if (stopped)
            {
                toolStripStatusLabelGenerations.Text = "Stopped // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms";
                graphicsPanel1.Invalidate();
            }
            else if (next)
            {
                NextGeneration();
                toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms";
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
            int cellWidth = 15;
            int cellHeight = 15;
            Pen gridPen = new Pen(gridColor, 1);
            Brush cellBrush = new SolidBrush(cellColor);
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
        private void startButton_Click(object sender, EventArgs e)
        {
            this.running = true;
            this.paused = false;
            this.stopped = false;
        }
        private void pauseButton_Click(object sender, EventArgs e) 
        {
            this.running = false;
            this.paused = true;
            this.stopped = false;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            this.running = false;
            this.paused = false;
            this.stopped = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.next = true;
            this.running = false;
            this.paused = false;
            this.stopped = false;
        }

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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Cells|*.cells";
            saveFile.FilterIndex = 1;
            saveFile.DefaultExt = "cells";

            if (DialogResult.OK == saveFile.ShowDialog())
            {
                StreamWriter write = new StreamWriter(saveFile.FileName);
                for(int i = 0; i < universe.universe.GetLength(0); i++)
                {
                    String row = string.Empty;
                    for(int j = 0; j < universe.universe.GetLength(1); j++)
                    {
                        if (universe.universe[i, j].isAlive)
                        {
                            row += "0";
                        }
                        else
                        {
                            row += ".";
                        }
                    }
                    write.WriteLine(row);
                }
                write.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Cells|*.cells";
            openFile.FilterIndex = 1;

            if(DialogResult.OK == openFile.ShowDialog())
            {
                int height = 0;
                int width = 0;

                StreamReader read = new StreamReader(openFile.FileName);

                while(!read.EndOfStream)
                {
                    string row = read.ReadLine();
                    if(row.StartsWith("0") || row.StartsWith("."))
                    {
                        width = row.Length;
                        height++;
                    }
                }

                int rowCount = 0;
                Cell[,] temp = new Cell[height, height];
                while (!read.EndOfStream)
                {
                    string row = read.ReadLine();
                    if (row.StartsWith("0") || row.StartsWith("."))
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (row[i].ToString() == "0")
                            {
                                temp[i, rowCount] = new Cell((i, rowCount));
                            }
                            else
                            {
                                temp[i, rowCount] = new Cell((i, rowCount), false);
                            }
                        }
                        rowCount++;
                    }
                }
                universe.copyGeneration(temp);
                read.Close();
                graphicsPanel1.Invalidate();
            }
        }
    }
}
