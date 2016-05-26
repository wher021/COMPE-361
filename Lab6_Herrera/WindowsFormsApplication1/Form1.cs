using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NimForm
{
    public partial class Form1 : Form
    {
        Rectangle[,] rectArray;
        TurnForm turnbox;
        Random rander = new Random();
        Point[] select;//select array
        Pen pen = new Pen(Color.Blue, 3);
        Pen selectPen = new Pen(Color.Green, 3);
        int rows, columns;
        int Userwin = 0, AIwin = 0;
        bool newgame = false;
        int k = 0;//keeps track of how many selects
        bool firstchoice = true;
        bool turn = true;
        bool endflag=false;
        int first = 0;
        int tmp = 0;

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (newgame == true)
            {
                Graphics g = e.Graphics;
                for (int c = 0; c < columns; c++)
                    for (int r = 0; r < rows; r++)
                        g.DrawRectangle(pen, rectArray[c, r]);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Size y = new Size(10, 10);
            Size non = new Size(0, 0);
            float dx = (float)this.ClientSize.Width / (columns + 1);
            float dy = this.ClientSize.Height / (rows + 1.0F);

            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (rectArray[c, r].Size != non)
                    {
                        rectArray[c, r].Location = new Point((int)(dx + c * dx), (int)(dy + r * dy)); //((int)(dx + c * dx), (int)(dy + r * dy));//, 10, 10);
                        rectArray[c, r].Size = y; //constant 10x10
                    }
                }
            }
            Invalidate();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (newgame == true && turn == true) //Allows user to choose if it is their turn
            {
                Graphics g = this.CreateGraphics();
                for (int c = 0; c < columns; c++)
                    for (int r = 0; r < rows; r++)
                    {
                        if (rectArray[c, r].Contains(e.Location))
                        {

                            if (firstchoice == true) //Flag to see if user has picked a row
                            {
                                first = r;
                                firstchoice = false;
                            }

                            tmp = r;
                            if (tmp == first)
                            {
                                select[k] = e.Location;
                                g.DrawRectangle(selectPen, rectArray[c, r]);
                                if (k > 1) //After the first select
                                {
                                    if (select[k] != select[k - 1])
                                        k++;//Do not forget to reset at the end of game
                                    else if (k == (rows * columns - 2))
                                        k = 0;

                                }
                                else k++; //Increments the first element
                            }
                            else if (tmp != first)
                                MessageBox.Show("cannot change row");
                        }
                    }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewGame_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            k = 0;
            turnbox = new TurnForm();
            DialogResult dr = turnbox.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                turn = turnbox.turn;
            }
            this.DoubleBuffered = true;
            newgame = true;
            lblrow.Visible = false;
            lbltoken.Visible = false;
            NewGame.Enabled = false;
            NewGame.Visible = false;
            label1.Visible = false;
            maxToken.Visible = false;
            maxRows.Visible = false;
            maxRows.Enabled = false;
            maxToken.Enabled = false;
            endflag = false;
            try
            {
                rows = int.Parse(maxRows.Text);//max amount of rows
                columns = int.Parse(maxToken.Text);// max amount of tokens per row
            }
            catch
            {
                MessageBox.Show("You forgot one or two of the Inputs. Defaulting to 10,10");
                rows = 10;
                columns = 10;
            }
            select = new Point[1000];
            rectArray = new Rectangle[columns, rows];
            int dx = this.ClientSize.Width / (columns + 1);
            int dy = this.ClientSize.Height / (rows + 1);

            Size sizezero = new Size(0, 0);
            for (int c = 0; c < columns; c++)//set max tokens
            {
                for (int r = 0; r < rows; r++)//set max rows
                {
                    rectArray[c, r] = new Rectangle(dx + c * dx, dy + r * dy, 10, 10);
                }
            }
            for (int r = 0; r < rows; r++)//set max tokens
            {
                for (int c = 0; c < rnd.Next(1, columns+1); c++)//set max rows
                {
                    rectArray[c, r].Size = sizezero;
                }
            }
            Invalidate();

            if (turn == false) //Initial AI move
            {
                DialogResult dlg = MessageBox.Show("AI's TURN!", "ATTENTION!", MessageBoxButtons.OK);
                Thread.Sleep(100);
                AIStrategy();
            }
            

            
        }

        private void endTurnToolStripMenuItem_Click(object sender, EventArgs e)//delete button
        {
            if (turn == true)
            {
                firstchoice = true;
                
                Size non = new Size(0, 0);
                for (int c = 0; c < columns; c++)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        for (int n = 0; n < select.Length; n++)
                        {
                            if (rectArray[c, r].Contains(select[n]))
                                rectArray[c, r].Size = non;
                        }
                    }

                }
                Invalidate();
                CheckEndGame();
                if (endflag == false)
                {
                    DialogResult dlg = MessageBox.Show("AI's TURN!", "ATTENTION!", MessageBoxButtons.OK);
                    turn = false;
                    Thread.Sleep(100);
                    AIStrategy();
                }
                
            }
        }

        private void AIStrategy()
        {

            Thread.Sleep(900);//Waits a second
            int n = 0, airow=0,aichoice=0;
            int[] rowcount=new int [rows];
            Size ainon = new Size(0, 0);

            while(n<rows)//initializes rowcount
            {
                rowcount[n]=0;
                n++;
            }
            

            for (int r = 0; r < rows; r++) //Counts the number of rects in the rows
            {
                for (int c = 0; c < columns; c++)
                {
                    if (rectArray[c, r].Size != ainon)
                        rowcount[r]++;
                }
            }



            while (true)
            {
                airow = rander.Next(0, rows);
                if (rowcount[airow] != 0)
                    break;
            }


            int aitoken = rander.Next(1, rowcount[airow]+1);
            n = 0;
            
            while (n < aitoken)
            {
                aichoice = rander.Next(0, columns);

                if (rectArray[aichoice, airow].Size != ainon)
                {
                    rectArray[aichoice, airow].Size = ainon;
                    n++;
                    
                }
                Invalidate();
            }

            CheckEndGame();
            if (endflag == false)
            {
                turn = true;
                Invalidate();
                Thread.Sleep(500);
                DialogResult dlg = MessageBox.Show("USER's TURN!", "ATTENTION!", MessageBoxButtons.OK);
            }

         }

        private void CheckEndGame()
        {
            int sum = 0,n=0;
            int[] rowcount = new int[rows];
            Size ainon = new Size(0, 0);
            while (n < rows)//initializes rowcount
            {
                rowcount[n] = 0;
                n++;
            }

            for (int r = 0; r < rows; r++) //Counts the number of rects in the rows
            {
                for (int c = 0; c < columns; c++)
                {
                    if (rectArray[c, r].Size != ainon)
                        rowcount[r]++;
                }
            }
            n = 0;
            while (n < rows)
            {
                sum = rowcount[n] + sum;
                n++;
            }
            if ((sum == 1 || sum==0) && turn == false) //AI wins
            {
                AIwin++;
                string s = "AI WINS! USER SCORE " + Userwin.ToString() + " AI SCORE " + AIwin.ToString();
                MessageBox.Show(s);
                newgame = false;
                lblrow.Visible = true;
                lbltoken.Visible = true;
                NewGame.Enabled = true;
                NewGame.Visible = true;
                label1.Visible = true;
                maxToken.Visible = true;
                maxRows.Visible = true;
                maxRows.Enabled = true;
                maxToken.Enabled = true;
                endflag = true;
                for (int c = 0; c < columns; c++)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        rectArray[c, r].Size = ainon;
                    }
                }
                Invalidate();
            }
            if ((sum == 1 || sum == 0) && turn == true) //AI wins
            {
                Userwin++;
                string s = "USER WINS! USER SCORE " + Userwin.ToString() + " AI SCORE " + AIwin.ToString();
                MessageBox.Show(s);
                newgame = false;
                lblrow.Visible = true;
                lbltoken.Visible = true;
                NewGame.Enabled = true;
                NewGame.Visible = true;
                label1.Visible = true;
                maxToken.Visible = true;
                maxRows.Visible = true;
                maxRows.Enabled = true;
                maxToken.Enabled = true;
                endflag = true;
                for (int c = 0; c < columns; c++)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        rectArray[c, r].Size = ainon;
                    }
                }
                Invalidate();
            }
                

        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult dr = dlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
                BackColor = dlg.Color;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult dr = dlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
                pen =new Pen( dlg.Color,3);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult dr = dlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
                selectPen = new Pen(dlg.Color, 3);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            DialogResult dr = dlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                label1.Font= dlg.Font;
                lblrow.Font = dlg.Font;
                lbltoken.Font = dlg.Font;
                maxRows.Font = dlg.Font;
                maxToken.Font = dlg.Font;
                NewGame.Font = dlg.Font;
            }
            Invalidate();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutString =
@"Welcome to the Game of Nim to play the game please enter
the max rows, and maximum columns(called tokens in the main menu)
then click new game you will be prompted by a dialogue box with the choice
of whose turn you should begin with. Pick the button you wish and press OK to
begin. When in your turn select the rectangles you wish to remove and click end
turn to remove.";
            MessageBox.Show(aboutString);

        }
    }
}


