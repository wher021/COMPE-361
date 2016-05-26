using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Media;

namespace SimonGame
{
    public partial class Form1 : Form
    {
        int choice;
        private Button[] buttons;
        private Color[] generator;
        private List<Color> user_sequence = new List<Color> { };
        private int elapsed = 0;
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        private string[] rate = new string[5] { "1", "2", "3", "4", "5" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                genSequence();
            }
            catch
            {
                MessageBox.Show("please specify sequence and rate of change");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(rate);
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);

            buttons = new[] { button1, button2, button3, button4 };
            Simon game = new Simon();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].BackColor = game.Colors[i];
            }

        }

        public void genSequence()
        {
            int sequence_lenght = int.Parse(textBox1.Text);
            Random rand = new Random();
            generator = new Color[sequence_lenght];//{};
            comboBox1.Focus();
            aTimer.Interval = (500 / (int.Parse((comboBox1.SelectedItem.ToString()))));
            for (int i = 0; i < sequence_lenght; i++)
            {
                choice = rand.Next(0, 4);

                switch (choice)
                {
                    case 0:
                        {
                            this.Refresh();
                            Delay();
                            button1.BackColor = Color.White;
                            this.Refresh();
                            SoundPlayer redsound = new SoundPlayer(Properties.Resources.tone1);
                            redsound.Play();
                            //playSound(SimonGame.Properties.Resources.tone1);
                            Delay();
                            button1.BackColor = Color.Red;
                            this.Refresh();
                            generator[i] = Color.Red;
                            break;
                        }
                    case 1:
                        {
                            this.Refresh();
                            Delay();
                            button2.BackColor = Color.White;
                            this.Refresh();
                            SoundPlayer greensound = new SoundPlayer(Properties.Resources.tone2);
                            greensound.Play();
                            Delay();
                            button2.BackColor = Color.Green;
                            this.Refresh();
                            generator[i] = Color.Green;
                            break;
                        }

                    case 2:
                        {
                            this.Refresh();
                            Delay();
                            button3.BackColor = Color.White;
                            this.Refresh();
                            SoundPlayer bluesound = new SoundPlayer(Properties.Resources.tone3);
                            bluesound.Play();
                            Delay();
                            button3.BackColor = Color.Blue;
                            this.Refresh();
                            generator[i] = Color.Blue;
                            break;
                        }

                    case 3:
                        {
                            this.Refresh();
                            Delay();
                            button4.BackColor = Color.White;
                            this.Refresh();
                            SoundPlayer yellowsound = new SoundPlayer(Properties.Resources.tone4);
                            yellowsound.Play();
                            Delay();
                            button4.BackColor = Color.Yellow;
                            this.Refresh();
                            generator[i] = Color.Yellow;
                            break;
                        }
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Focus();
                aTimer.Interval = (500 / (int.Parse((comboBox1.SelectedItem.ToString()))));
                for (int i = 0; i < generator.Length; i++)
                {
                    if (generator[i] == Color.Red)
                    {
                        this.Refresh();
                        Delay();
                        button1.BackColor = Color.White;
                        this.Refresh();
                        SoundPlayer redsound = new SoundPlayer(Properties.Resources.tone1);
                        redsound.Play();
                        Delay();
                        button1.BackColor = Color.Red;
                        this.Refresh();
                    }
                    else if (generator[i] == Color.Green)
                    {
                        this.Refresh();
                        Delay();
                        button2.BackColor = Color.White;
                        this.Refresh();
                        SoundPlayer greensound = new SoundPlayer(Properties.Resources.tone2);
                        greensound.Play();
                        Delay();
                        button2.BackColor = Color.Green;
                        this.Refresh();
                    }
                    else if (generator[i] == Color.Blue)
                    {
                        this.Refresh();
                        Delay();
                        button3.BackColor = Color.White;
                        this.Refresh();
                        SoundPlayer bluesound = new SoundPlayer(Properties.Resources.tone3);
                        bluesound.Play();
                        Delay();
                        button3.BackColor = Color.Blue;
                        this.Refresh();
                    }
                    else if (generator[i] == Color.Yellow)
                    {
                        this.Refresh();
                        Delay();
                        button4.BackColor = Color.White;
                        this.Refresh();
                        SoundPlayer yellowsound = new SoundPlayer(Properties.Resources.tone4);
                        yellowsound.Play();
                        Delay();
                        button4.BackColor = Color.Yellow;
                        this.Refresh();
                    }
                }
            }
            catch
            {
                MessageBox.Show("please specify sequence and rate of change");
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            comboBox1.Focus();
            Button b = (Button)sender;
            user_sequence.Add(b.BackColor);
            Simon compare = new Simon();
            string s = "unknown button";
            aTimer.Interval = 100;
            if (b == button1)
            {
                button1.BackColor = Color.White;
                this.Refresh();
                Delay();
                SoundPlayer redsound = new SoundPlayer(Properties.Resources.tone1);
                redsound.Play();
                button1.BackColor = Color.Red;
                this.Refresh();
            }
            else if (b == button2)
            {
                button2.BackColor = Color.White;
                this.Refresh();
                Delay();
                SoundPlayer greensound = new SoundPlayer(Properties.Resources.tone2);
                greensound.Play();
                button2.BackColor = Color.Green;
                this.Refresh();
            }
            else if (b == button3)
            {
                button3.BackColor = Color.White;
                this.Refresh();
                Delay();
                SoundPlayer bluesound = new SoundPlayer(Properties.Resources.tone3);
                bluesound.Play();
                button3.BackColor = Color.Blue;
                this.Refresh();
            }
            else if (b == button4)
            {
                button4.BackColor = Color.White;
                this.Refresh();
                Delay();
                SoundPlayer yellowsound = new SoundPlayer(Properties.Resources.tone4);
                yellowsound.Play();
                button4.BackColor = Color.Yellow;
                this.Refresh();
            }
            int result = compare.Compare(user_sequence.ToArray(), generator);

            switch (result)
            {
                case 1:
                    Console.WriteLine("winner!");
                    MessageBox.Show("you won!");
                    SoundPlayer winsound = new SoundPlayer(Properties.Resources.win);
                    winsound.Play();
                    reset();
                    break;
                case 0:
                    //MessageBox.Show("good job, keep going...");
                    Console.WriteLine("good job, keep going...");
                    break;
                case -1:
                    Console.WriteLine("You lost!");
                    SoundPlayer lost = new SoundPlayer(Properties.Resources.lost);
                    lost.Play();
                    MessageBox.Show("You lost!!!");

                    reset();
                    break;
            }

        }
        private void reset()
        {
            user_sequence = new List<Color>();
        }

        public void Delay()
        {
            aTimer.Start();
            while (elapsed < 1)
            {

                //Console.WriteLine("elapsed={0}", elapsed);
            }
            aTimer.Stop();
            elapsed = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsed++;

        }

    }
}

