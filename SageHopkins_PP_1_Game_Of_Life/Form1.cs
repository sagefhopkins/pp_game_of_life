using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        //Universe Assignment Variables Below:

        //Generate the default Universe based on Time, with a width of 50 and height of 50.
        Universe universe = new Universe(-1, 50, 50);
        int generations = 0;



        //Color Assignment Variables Below:

        //Assign the default color of the Grid as Black.
        Color gridColor = Color.Black;
        //Asign the default color of a living Cell as Gray.
        Color cellColor = Color.Gray;
        //Assign the default color of a dead Cell as White.
        Color deadCellColor = Color.White;
        //Assign the default color of the HUD outline as Black.
        Color hudColorOutline = Color.Black;
        //Assign the default color of the HUD Fill as Crimson.
        Color hudColorFill = Color.Crimson;



        //Time Assignment Variables Below:

        //Create a timer using the Timer class.
        Timer timer = new Timer();
        //Variable for tracking the time interval. Assign the default to 100
        int ms = 100;


        //Status of Universe Variables Below:

        //Variable for tracking if the Universe is running. Assign the default to false.
        bool running = false;
        //Variable for tracking if the Universe if paused. Assign the default to false.
        bool paused = false;
        //Variable for tracking if the Universe is stopped. Assign the default to true.
        bool stopped = true;
        //Variable for tracking if the Universe will proceed to the next generation. Assign the default to false.
        bool next = false;



        //Button Toggle Variables Below:

        //Variable for tracking if the Form will display the Grid. Assign the default to true.
        bool gridToggle = true;
        //Variable for tracking if the Form will display the neighbor count within each Cell. Assign the default to true.
        bool countNeighborsToggle = true;
        //Variable for tracking if the Form will display the Heads Up Display. Assign the default to false.
        bool headsUpDisplayToggle = false;
        

        /*
         * Form1 Constructor. Initializes the Form Components, sets the time interval based based on the above-defined ms variable, and enables the timer.
         */
        public Form1()
        {
            //Initialize Components of the Form.
            InitializeComponent();
            //Assign the timer Interval from the ms variable.
            timer.Interval = ms;
            //Assign the function for handling what happens at each Interval.
            timer.Tick += Timer_Tick;
            //Enable the timer.
            timer.Enabled = true;
        }

        /*
         * The NextGeneration function is used to track the generation count, as well as update the Status bar while the Universe is running.
         */
        private void NextGeneration()
        {
            //Add one to the generations past count.
            generations++;
            //Update the status bar.
            toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
        }

        /*
         * The Timer_Tick function is used define what happens each time the timer interval has occurred. It checks a variety of variables to find the current status of the Universe, and proceeds based on an if/else chain.
         */
        private void Timer_Tick(object sender, EventArgs e)
        {
            //The the Interval of the timer based on the ms variable. This is used to handle changes of the timing of the Universe when they occur.
            timer.Interval = ms;

            //Check if the Universe is running. If so, proceed to the next generation.
            if (running)
            {
                //Call the NextGeneration function in order to update the generation count, and update the status bar.
                NextGeneration();
                //Call the nextGeneartion function of the Universe in order to update the Universe based on the rules therein defined.
                universe.nextGeneration();
                //Invalidate the graphics panel in order to render the updated Universe.
                graphicsPanel1.Invalidate();
            }
            //Check if the Universe is paused. If so, the Universe does not proceed to the next generation.
            else if (paused)
            {
                //Update the status bar to show a Paused state.
                toolStripStatusLabelGenerations.Text = "Paused // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
                //Invalidate the graphics panel in order to display the updated Status bar.
                graphicsPanel1.Invalidate();
            }
            //Check if the Universe is stopped. If so, the Universe does not proceed to the next generation.
            else if (stopped)
            {
                //Update the status bar to show a Stopped state.
                toolStripStatusLabelGenerations.Text = "Stopped // Livings Cells: " + universe.livingCells.ToString() + " // Timing: " + ms.ToString() + " ms // Seed: " + universe.seed;
                //Invalidate the graphics panel in order to display the updated Status bar.
                graphicsPanel1.Invalidate();
            }
            //Check if the Universe is proceeding to the next generation. If so, proceed to the next generation, then set the Universe to paused.
            else if (next)
            {
                //Call the NextGeneration function in order to update the generation count, and update the status bar while the Universe is running.
                NextGeneration();
                //Call the nextGeneration function of the Universe in order to update the Universe based on the rules therein defined.
                universe.nextGeneration();
                //Invalidate the graphics panel in order to render the updated Universe.
                graphicsPanel1.Invalidate();
                //Set the next variable to false so the Universe does not proceed to the next Generation.
                next = false;
                //Set the paused variable to true, so the Universe becomes paused.
                paused = true;
                //Set the stopped variable to false, so the Universe is not stopped.
                stopped = false;
                //Set the running variable to false, so the Universe does not run.
                running = false;
            }
        }
        
        /*
         * The graphicsPanel1_Paint function handles making changes to the Form as they occur.
         */
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics Panel Settings Assignment Below:

            //These settings are added to allow the Outlined text below-defined to render properly.

            //Assign InterpolationMode to High.
            e.Graphics.InterpolationMode = InterpolationMode.High;
            //Assign SmoothingMode to HighQuality.
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //Assign TextRenderingHint to AntiAliasGridFit.
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //Assign CompositingQuality to HighQuality.
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            //Get the width of the Cell. This math is used to allow the Form to be resized.
            int cellWidth = graphicsPanel1.Width / universe.universe.GetLength(0);
            //Get the height of the Cell. This math is used to allow the Form to be resized.
            int cellHeight = graphicsPanel1.Height / universe.universe.GetLength(1);
            //Define an empty Pen variable for the gridPen.
            Pen gridPen;

            //Check if the gid is enabled. If so, assign the gridPen to the above-defined gridColor variable.
            if (gridToggle)
            {
                //Assign the gridPen to a new instance of the Pen class, based on the above-defined gridColor variable.
                gridPen = new Pen(gridColor, 1);
            }
            //Check if the grid is disabled. If so, assign the gridPen to white (does not show up).
            else
            {
                //Assign the gridPen to a new instance of the Pen class, with a brush color of white.
                gridPen = new Pen(Brushes.White, 1);
            }

            //Create a new instance of the SolidBrush class. Assign the color of the solid brush based on the cellColor variable above-defined.
            Brush cellBrush = new SolidBrush(cellColor);

            //Loop through the width of the Universe.
            for (int x = 0; x < universe.universe.GetLength(0); x++)
            {
                //Loop through the height of the Universe.
                for (int y = 0; y < universe.universe.GetLength(1); y++)
                {
                    //Rectangle Settings Assignment Below:

                    //Create an empty Rectangle instance for use below.
                    Rectangle cellRect = Rectangle.Empty;
                    //Calculate and define the x position of cellRect.
                    cellRect.X = x * cellWidth;
                    //Calculate and define the y position of cellRect.
                    cellRect.Y = y * cellHeight;
                    //Assign the width of cellRect based on the above-defined cellWidth variable.
                    cellRect.Width = cellWidth;
                    //Assign the height of cellRect based on the above-defined cellHeight variable.
                    cellRect.Height = cellHeight;

                    //Check if the given cell is alive. If so, fill the rectangle with the cellBrush (used for alive cells).
                    if (universe.universe[x, y].isAlive == true)
                    {
                        //Fill the rectangle with the cellBrush (used for alive cells).
                        e.Graphics.FillRectangle(cellBrush, cellRect);

                    }
                    //Check if the given cell is dead. If so, fill the rectangle with the deadCellColor.
                    else
                    {
                        //Create an instance of the SolidBursh class based on the above-defined deadCellColor variable.
                        Brush brush = new SolidBrush(deadCellColor);
                        //Fill the rectangle with the deadCellColor brush.
                        e.Graphics.FillRectangle(brush, cellRect);
                    }
                    //Create an instance of the StringFormat class.
                    StringFormat format = new StringFormat();
                    //Set the LineAlignment to center.
                    format.LineAlignment = StringAlignment.Center;
                    //Set the Alignment to center.
                    format.Alignment = StringAlignment.Center;
                    //Create an instance of the Font class with the font to be used.
                    Font font = new Font("Arial Black", 9);

                    //Check if the countNeighborsToggle is enabled. If so, display the neighbor count within the Cells.
                    if (countNeighborsToggle)
                    {

                        //Check if the neighbors of the given Cell is 1. If so, display the neighbor count as red, indicating the cell will die in the next generation.
                        if (universe.universe[x, y].countNeighbors(universe) == 1)
                        {
                            //Display the neighbors count in red, centerred within the cell.
                            e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Red, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                        }
                        //Check if the neighbors of the given Cell is 3. If so, display the neighbor count in green, indicating the Cell will either live, or be born into the next generation.
                        else if (universe.universe[x, y].countNeighbors(universe) == 3)
                        {
                            //Display the neighbors count in green, centerred within the cell.
                            e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Green, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                        }
                        //Check if the neighbors of the given Cell is 2. If so, display the neighbor count in blue, indicating the Cell with live into the next generation.
                        else if (universe.universe[x, y].countNeighbors(universe) == 2)
                        {
                            //Display the neighbor count in blue, centerred within the cell.
                            e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Blue, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                        }
                        //Check if the neighbors of the given Cell is greater than 3. If so, display the neighbor count in orange, indicating the Cell will die of over population in the next generation.
                        else if (universe.universe[x, y].countNeighbors(universe) > 3)
                        {
                            //Display the neighbor count in orange, centerred within the cell.
                            e.Graphics.DrawString(universe.universe[x, y].countNeighbors(universe).ToString(), font, Brushes.Orange, (x * cellWidth) + (cellWidth / 2), (y * cellHeight) + (cellHeight / 2), format);
                        }
                    }
                    //Draw cellRect based on the above-defined settings.
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            //Check if the headsUpDisplayToggle is enabled. If so draw heads up display, replaced e.Graphics.DrawString with a Graphics Path in order to provide support for outlining the text in order to make it more readible.
            if (headsUpDisplayToggle)
            {
                //Create instance of Pen class based on above-defined color settings. Make the pen draw 4 pixels.
                Pen hudPenOutline = new Pen(new SolidBrush(hudColorOutline), 4);
                //Create insstance of StringFormat class.
                StringFormat hudFormat = new StringFormat();
                //Define Alignment as Near.
                hudFormat.Alignment = StringAlignment.Near;
                //Define LineAlignment as Near.
                hudFormat.LineAlignment = StringAlignment.Near;
                //Create instance of Font class, define fontsize as 15, define FontStyle as bold.
                Font hudFont = new Font("Arial", 15, FontStyle.Bold);
                //Create instance of GraphicsPath.
                GraphicsPath path = new GraphicsPath();
                //Add generation count to path variable.
                path.AddString("Generations: " + generations.ToString(), FontFamily.GenericSansSerif,(int) FontStyle.Bold, e.Graphics.DpiY * 15 / 72, new Point(5, graphicsPanel1.Bottom - 140), hudFormat);
                //Add cell count to path variable.
                path.AddString("Cell Count: " + universe.livingCells.ToString(), FontFamily.GenericSansSerif, (int) FontStyle.Bold, e.Graphics.DpiY * 15 / 72, new Point(5, graphicsPanel1.Bottom - 120), hudFormat);
                //Add boundary type to path variable.
                path.AddString("Boundary Type: " + generations.ToString(), FontFamily.GenericSansSerif, (int) FontStyle.Bold, e.Graphics.DpiY * 15 / 72, new Point(5, graphicsPanel1.Bottom - 100), hudFormat);
                //Add universe size to path variable.
                path.AddString("Universe Size: " + universe.universe.GetLength(0) + ", " + universe.universe.GetLength(1), FontFamily.GenericSansSerif, (int)FontStyle.Bold, e.Graphics.DpiY * 15 / 72, new Point(5, graphicsPanel1.Bottom - 80), hudFormat);
                //Draw the path based on the above defined strings added to the path variable. This draws the outline of the strings.
                e.Graphics.DrawPath(hudPenOutline, path);
                //Fill in the path.
                e.Graphics.FillPath(new SolidBrush(hudColorFill), path);

                //Dispose of hudPenOutline.
                hudPenOutline.Dispose();
                //Dispose of hudFormat.
                hudFormat.Dispose();
                //Dispose of hudFont.
                hudFont.Dispose();
                //Dispose of path.
                path.Dispose();
            }
            //Dispose of gridPen.
            gridPen.Dispose();
            //Dispose of cellBrush.
            cellBrush.Dispose();
        }

        /*
         * The graphicsPanel1_MouseClick function serves to allow the user to toggle the state of the clicked Cell within the Universe.
         */
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //Check if left mouse button is down. If so, try to set toggle the state of the clicked cell. This uses a try statement to handle clicks that are not within the index bounds of the grid.
            if (e.Button == MouseButtons.Left)
            {
                //Handle clicks that are not within the index bounds of the grid.
                try
                {
                    //Calculate and define the cellWidth.
                    int cellWidth = graphicsPanel1.Width / universe.universe.GetLength(0);
                    //Calculate and define the cellHeight.
                    int cellHeight = graphicsPanel1.Height / universe.universe.GetLength(1);
                    //Calculate and define the x position of the cell clicked.
                    int x = e.X / cellWidth;
                    //Calculate and define the y position of the cell clicked.
                    int y = e.Y / cellHeight;
                    //Toggle the state of the cell clicked.
                    universe.universe[x, y].isAlive = !universe.universe[x, y].isAlive;
                    //Invalidate graphics panel in order to display toggled cell.
                    graphicsPanel1.Invalidate();
                }
                //Catch exceptions. No hanlding of exceptions given, try statement is to prevent application from crashing when user clicks outside of the bounds of the grid.
                catch
                {

                }
            }
        }

        /*
         * The startButton_click function serves to allow the user to start the Universe, allowing it to move forward to the next generations based on the inputted tick interval.
         */
        private void startButton_Click(object sender, EventArgs e)
        {
            //Set running variable to true.
            this.running = true;
            //Set paused variable to false.
            this.paused = false;
            //Set stopped variable to false.
            this.stopped = false;
        }

        /*
         * The pauseButton_Click function serves to allow the user to pause the Universe, preventing it from continuing to the next generation.
         */
        private void pauseButton_Click(object sender, EventArgs e)
        {
            //Set running variable to false.
            this.running = false;
            //Set paused variable to true.
            this.paused = true;
            //Set stopped variable to false.
            this.stopped = false;
        }

        /*
         * The stopButton_Click function serves to allow the user to stop the Universe from moving forward to the next geneartion.
         */
        private void stopButton_Click(object sender, EventArgs e)
        {
            //Set running variable to false.
            this.running = false;
            //Set paused variable to false.
            this.paused = false;
            //set stopped variable to true.
            this.stopped = true;
        }

        /*
         * The nextButton_Click function serves to allow the user to move the current generation one single generation forward.
         */
        private void nextButton_Click(object sender, EventArgs e)
        {
            //Set next variable to true.
            this.next = true;
            //Set running variable to false.
            this.running = false;
            //Set paused variable to false.
            this.paused = false;
            //Set stopped variable to false.
            this.stopped = false;
        }

        /*
         * The nextButton_Click function serves to allow the user to generate a new empty universe.
         */
        private void newButton_Click(object sender, EventArgs e)
        {
            //Use the clear function of the Universe class to set all Cells to dead.
            universe.clear();
            //Invalidate graphics panel to render changes to Universe.
            graphicsPanel1.Invalidate();
            //Set next variable to false.
            this.next = false;
            //Set running variable to false.
            this.running = false;
            //Set paused variable to false.
            this.paused = false;
            //Set stopped variable to true.
            this.stopped = true;
        }

        /*
         * The saveButton_Click function serves to save a copy of the current Universe to a Plaintext file based on the users desired directory.
         */
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Create instance of the SaveFileDialog class.
            SaveFileDialog file = new SaveFileDialog();
            //Define filter to only include .Cell files.
            file.Filter = "Cells|*.cells";
            //Define the default extension of the SaveFileDialog as cell files.
            file.DefaultExt = "cells";

            //Check if the results of the SaveFileDialog are valid. If so, write the Universe to file defined in the dialog.
            if(DialogResult.OK == file.ShowDialog())
            {
                //Create instance of the StreamWritter class based on the ShowFileDialog.
                StreamWriter write = new StreamWriter(file.FileName);
                //Write the current seed to the file.
                write.WriteLine("!Seed: " + universe.seed);
                //Write the current timing to the file.
                write.WriteLine("!Timing: " + ms);
                //Write the current generations count to the file.
                write.WriteLine("!Generations: " + generations);

                //Loop through the width of the Universe.
                for(int i = 0; i < universe.universe.GetLength(0); i++)
                {
                    //Create empty String variable. The row will be defined below.
                    string row = String.Empty;

                    //Loop through the height of the Universe.
                    for(int j = 0; j < universe.universe.GetLength(1); j++)
                    {
                        //Check if the given cell is alive. If so, add an "O" to the row variable, indicating the Cell is alive.
                        if (universe.universe[i, j].isAlive)
                        {
                            //Add an "O" to the row variable indicating the Cell is alive.
                            row += "O";
                        }
                        //Check if the given cell is dead. If so, add an "." to the row variable, indicating the Cell is dead.
                        else
                        {
                            //Add an "." to the row variable indicating the Cell is dead.
                            row += ".";
                        }
                    }
                    //Write the row of cells to the file.
                    write.WriteLine(row);
                }
                //Close the Stream Writer.
                write.Close();
                }
            }

        /*
         * The openButton_Click function decodes an existing saved universe from a file into the Universe object.
         */
        private void openButton_Click(object sender, EventArgs e)
        {
            //Define seed variable.
            int seed = 0;
            //Define timing variable.
            int timing = 0;
            //Define generation variable.
            int generation = 0;
            //Create instance of OpenFileDialog class.
            OpenFileDialog openFile = new OpenFileDialog();
            //Define filter of OpenFileDialog to include only .cells files.
            openFile.Filter = "Cells|*.cells";
            //Define default extension of OpenFileDialog as cells files.
            openFile.DefaultExt = "cells";

            //Check if the results of the OpenFileDialog are valid. If so, read the Universe from the file defined in the dialog.
            if (DialogResult.OK == openFile.ShowDialog())
            {
                //Create instance of StreamReader class based on the file provided from the OpenFileDialog.
                StreamReader read = new StreamReader(openFile.FileName);
                //Define height variable.
                int height = 0;
                //Define width variable.
                int width = 0;

                //Loop while not at the end of the file.
                while (!read.EndOfStream)
                {
                    //Read the current line to the row variable.
                    string row = read.ReadLine();

                    //Check if row does not contain an explaination point. If so, add 1 to the height variable and set the width variable to the length of the row.
                    if (!row.Contains("!"))
                    {
                        //Add 1 to the height variable.
                        height++;
                        //Sent the width variable to the length of the row.
                        width = row.Length;
                    }
                    //Chehck if the row includes an explaination point. If so, check if the explaination point is a setting.
                    else
                    {

                        //Check if the row starts with !Seed: . If you, attempt to split the string on the : and parse the second portion to an integer. Set the seed variable to this value.
                        if (row.StartsWith("!Seed:"))
                        {
                             int.TryParse(row.Split(':')[1], out seed);
                        }

                        //Check if the row starts with !Timing: . If you, attempt to split the string on the : and parse the second portion to an integer. Set the timing variable to this value.
                        if (row.StartsWith("!Timing:"))
                        {
                            int.TryParse(row.Split(':')[1], out timing);
                        }

                        //Check if the row starts with !Generations: . If you, attempt to split the string on the : and parse the second portion to an integer. Set the generation variable to this value.
                        if (row.StartsWith("!Generations:"))
                        {
                            int.TryParse(row.Split(':')[1], out generation);
                        }
                    }
                }

                //Create a new instanace of the Universe class based on the height and width of the row above-defined. Uses the 0 seed to create a Universe of dead cells.
                universe = new Universe(0, height, width);
                //Create a new instance of the StreamReader class.
                read = new StreamReader(openFile.FileName);
                //Define rowCount variable.
                int rowCount = 0;

                //Loop while not at the end of the file.
                while (!read.EndOfStream)
                {
                    //Read the current line to the row variable.
                    string row = read.ReadLine();
                    
                    //Check if the row starts with an explaination point. If not, decode Plaintext file format to the Universe array.
                    if (!row.StartsWith("!")) {
                        //Convert row string to a char array.
                        char[] rowToChar = row.ToCharArray();

                        //Loop through the width of the row.
                        for (int i = 0; i < width -1; i++)
                        {

                            //Check if given char is an "O". If so, create a Cell that is alive and assign it to the Universe.
                            if (rowToChar[i].ToString() == "O")
                            {
                                //Assign the given Cell to the Universe alive.
                                universe.universe[i, rowCount] = new Cell((i, rowCount), true);
                            }
                        }
                        //Add 1 to the rowCount variable.
                        rowCount++;
                    }
                }
                //Assign the above-defined seed to the Universe's seed variable.
                universe.seed = seed;
                //Assign the above-defined timing variable to the Forms ms variable.
                ms = timing;
                //Assign the above-defined generation variable to the Forms generations variable.
                generations = generation;
                //Close the StreamReader.
                read.Close();
                //Invalidate the graphics panel to render the loaded Universe.
                graphicsPanel1.Invalidate();
            }
        }

        /*
         * The toggleGridButton_Click function serves to toggle the status of the gridToggle variable in order to determine whether the grid is rendered.
         */
        private void toggleGridButton_Click(object sender, EventArgs e)
        {
            //Toggle gridToggle variable.
            gridToggle = !gridToggle;
            //Invalidate the graphics panel to render the updated status of the grid.
            graphicsPanel1.Invalidate();
        }
        /*
         * The toggleNeighborCountButton_Click function serves to toggle the status of the countNeighborsToggle variable in order to determine whether the neighbor count is displayed within the Cells.
         */
        private void toggleNeighborCountButton_Click(object sender, EventArgs e)
        {
            //Toggle countNeighborsToggle variable.
            countNeighborsToggle = !countNeighborsToggle;
            //Invalidate the graphics panel to render the udpated status of the neighbor count.
            graphicsPanel1.Invalidate();
        }

        /*
         * The intDialog function serves to create a dialog which can be customized and reused. 
         */
        private int intDialog(string label, string title, int defaultValue)
        {
            //Create instance of the Form class.
            Form dialog = new Form();
            //Define dialog title.
            dialog.Text = title;
            //Define width of dialog.
            dialog.Width = 500;
            //Define height of dialog.
            dialog.Height = 200;
            //Create instance of Label class.
            Label textLabel = new Label();
            //Define left position of textLabel.
            textLabel.Left = 50;
            //Define top position of textLabel.
            textLabel.Top = 20;
            //Define text of textLabel.
            textLabel.Text = label;
            //Create instance of NumbericUpDown class.
            NumericUpDown inputBox = new NumericUpDown();
            //Define left position of inputBox.
            inputBox.Left = 50;
            //Define top position of inputBox.
            inputBox.Top = 50;
            //Define width of inputBox.
            inputBox.Width = 400;
            //Define Maximum value of inputBox.
            inputBox.Maximum = int.MaxValue;
            //Define default value of inputBox.
            inputBox.Value = defaultValue;
            //Create instance of Button class.
            Button confirm = new Button();
            //Define left position of confirm.
            confirm.Left = 350;
            //Define top position of confirm.
            confirm.Top = 70;
            //Define width of confirm.
            confirm.Width = 100;
            //Define text of confirm.
            confirm.Text = "Okay";
            //Define functionality of confirm when clicked. Closes dialog.
            confirm.Click += (sender, e) => { dialog.Close(); };
            //Add confirm instance to dialog.
            dialog.Controls.Add(confirm);
            //Add textLabel instance to dialog.
            dialog.Controls.Add(textLabel);
            //Add inputBox instance to dialog.
            dialog.Controls.Add(inputBox);
            //Show Dialog.
            dialog.ShowDialog();

            //Return inputBox's value casted to an Integer.
            return (int)inputBox.Value;
        }
        /*
         * The tupleDialog function serves to create a dialog which can be customized and reused. It allows the input of two seprate values.
         */
        private (int, int) tupleDialog(string label1, string label2, string title, (int, int) defaultValue)
        {
            //Create instance of Form class.
            Form dialog = new Form();
            //Define text of dialog.
            dialog.Text = title;
            //Define width of dialog.
            dialog.Width = 500;
            //Define height of dialog.
            dialog.Height = 200;
            //Create instance of Label class.
            Label textLabel1 = new Label();
            //Define left position of textLabel1.
            textLabel1.Left = 50;
            //Define top position of textLabel1.
            textLabel1.Top = 20;
            //Define text of textLabel1.
            textLabel1.Text = label1;
            //Create second instance of Label class.
            Label textLabel2 = new Label();
            //Define left position of textLabel2.
            textLabel2.Left = 250;
            //Define top position of textLabel2.
            textLabel2.Top = 20;
            //Define text of textLabel2.
            textLabel2.Text = label2;
            //Create instance of NumericUpDown class.
            NumericUpDown inputBox1 = new NumericUpDown();
            //Define left position of inputBox1.
            inputBox1.Left = 50;
            //Define top position of inputBox1
            inputBox1.Top = 50;
            //Define width of inputBox1.
            inputBox1.Width = 200;
            //Define maxmium of inputBox1.
            inputBox1.Maximum = int.MaxValue;
            //Define minium of inputBox1.
            inputBox1.Minimum = 1;
            //Define default value of inputBox1.
            inputBox1.Value = defaultValue.Item1;
            //Create second instance of NumbericUpDown class.
            NumericUpDown inputBox2 = new NumericUpDown();
            //Define left position of inputBox2.
            inputBox2.Left = 250;
            //Define top position of inputBox2.
            inputBox2.Top = 50;
            //Define width of inputBox2.
            inputBox2.Width = 200;
            //Define maximum of inputBox2.
            inputBox2.Maximum = int.MaxValue;
            //Define minimum of inputBox2.
            inputBox2.Minimum = 1;
            //Define default value of inputBox2.
            inputBox2.Value = defaultValue.Item2;
            //Create instance of Button class.
            Button confirm = new Button();
            //Define left position of confirm.
            confirm.Left = 150;
            //Define top position of confirm.
            confirm.Top = 70;
            //Define width of confirm.
            confirm.Width = 100;
            //Define text of confirm.
            confirm.Text = "Okay";
            //Define functionality of confirm when clicked. Closes dialog.
            confirm.Click += (sender, e) => { dialog.Close(); };
            //Add confirm to dialog.
            dialog.Controls.Add(confirm);
            //Add textLabel1 to dialog.
            dialog.Controls.Add(textLabel1);
            //Add textLabel2 to dialog.
            dialog.Controls.Add(textLabel2);
            //Add inputBox1 to dialog.
            dialog.Controls.Add(inputBox1);
            //Add inputBox2 to dialog.
            dialog.Controls.Add(inputBox2);
            //Show dialog.
            dialog.ShowDialog();

            //Return inputBox1's value casted to an Integer and inputBox2's value casted as an Integer as well, in the form of a tuple.
            return ((int)inputBox1.Value, (int)inputBox2.Value);

        }

        /*
         * The timingButton_Click function serves display an intDialog in order to update the timing of timer.Interval.
         */
        private void timingButton_Click(object sender, EventArgs e)
        {
            //Update ms variable based on intDialog output.
            ms = intDialog("Timing", "Enter timing value in MS", ms);
            //Invalidate graphics panel in order to display updated timing.
            graphicsPanel1.Invalidate();
        }

        /*
         * The fromSeedButton_Click function serves to create a new Universe based on a given seed using the intDialog function.
         */
        private void fromSeedButton_Click(object sender, EventArgs e)
        {
            //Create new instance of the Universe class based on the inputted values from the intDialog.
            universe = new Universe(intDialog("Seed", "Enter seed value", universe.seed), universe.universe.GetLength(0), universe.universe.GetLength(1));
        }

        /*
         * The fromCurrentSeedButton_Click function serves to generate a new instance of the Universe based on the current seed of the Universe.
         */
        private void fromCurrentSeedButton_Click(object sender, EventArgs e)
        {
            //Create new instance of the Universe class based on the existing seed defined in the Universe class.
            universe = new Universe(universe.seed, universe.universe.GetLength(0), universe.universe.GetLength(1));
        }

        /*
         * The fromTimeButton_Click function serves to create a new Universe based on a seed generated based on the current time.
         */
        private void fromTimeButton_Click(object sender, EventArgs e)
        {
            //Create new instance of the Universe class based on a seed generated based on the current time.
            universe = new Universe(-1, universe.universe.GetLength(0), universe.universe.GetLength(1));
        }

        /*
         * The toggleHUDButton_Click function serves to toggle the headsUpDisplayToggle variable to determine if the HUD will be displayed.
         */
        private void toggleHUDButton_Click(object sender, EventArgs e)
        {
            //Toggle headsUpDisplayToggle variable
            headsUpDisplayToggle = !headsUpDisplayToggle;
            //Invalidate graphics panel in order to render the updated state of the HUD.
            graphicsPanel1.Invalidate();
        }

        /*
         * The universeSizeButton_click function serves to create a new Universe based on the given height and width using tupleDialog function.
         */
        private void universeSizeButton_click(object sender, EventArgs e)
        {
            //Calls the turpleDialog function and stores it in the size variable.
            (int, int) size = tupleDialog("Width", "Height", "Universe Size", (universe.universe.GetLength(0), universe.universe.GetLength(1)));
            //Create new instance of the Universe based on the size variable.
            universe = new Universe(universe.seed, size.Item1, size.Item2);
        }

        /*
         * The gridColorButton_Click function serves to change the color of the grid based on the user's selection using the ColorDialog class.
         */
        private void gridColorButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the gridColor variable.
            gridColor = color.Color;
        }

        /*
         * The backgroundCOlorButton_Click function serves to change the color of the background based on the user's selection using the Color Dialog class.
         */
        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the graphics panel backcolor.
            this.graphicsPanel1.BackColor = color.Color;
        }

        /*
         * The cellColorButton_Click function serves to change the color of the alive cell based on the user's selection using the Color Dialog class.
         */
        private void cellColorButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the cellColor variable.
            cellColor = color.Color;
        }

        /*
         * The deadCellButton_Click function serves to change the color of the dead cell based on the user's selection using the Color Dialog class.
         */
        private void deadCellButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the deadCellColor variable.
            deadCellColor = color.Color;
        }

        /*
         * The hudFillButton_Click function serves to change the color of the HUD text fill based on the user's selection using the Color Dialog class.
         */
        private void hudFillButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the hudColorFill variable.
            hudColorFill= color.Color;
        }

        /*
         * The hudOutLineButton_Click function serves to change the color of the HUD text outline based on the user's selection using the Color Dialog class.
         */
        private void hudOutlineButton_Click(object sender, EventArgs e)
        {
            //Create instance of the ColorDialog class.
            ColorDialog color = new ColorDialog();
            //Show the color dialog.
            color.ShowDialog();
            //Assign the color selected by the user to the hudColorOutline variable.
            hudColorOutline = color.Color;
        }

        /*
         * The boundaryToggleButton_click function serves to toggle the boundary type used by the Universe. It updates the text of the boundaryToggleButton based on toggled state.
         */
        private void boundaryToggleButton_Click(object sender, EventArgs e)
        {

            //Check if torodialBoundary is not true. If so, Set the text to "Toroidal Boundary.
            if (!universe.toroidalBoundary)
            {
                //Assign the text value of the boundaryToggleButton to "Torodial Boundary"
                boundaryToggleButton.Text = "Toroidal Boundary";
            }
            //Check if torodialBoundary is true. If so, set the text to "Finite Boundary"
            else
            {
                //Assign the text value of the boundaryToggleButton to "Finite Boundary"
                boundaryToggleButton.Text = "Finite Boundary";
            }
            //Toggle the value of the torodialBoundary from the Universe class.
            universe.toroidalBoundary = !universe.toroidalBoundary;
        }
    }
}
