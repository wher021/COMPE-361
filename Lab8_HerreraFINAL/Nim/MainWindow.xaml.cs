using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Nim
{
    public partial class MainWindow : Window
    {
        Brush brushColor = Brushes.Black;
        Brush selTokenColor = Brushes.Red;
        int length = 10, rowsel;
        int n=5, m=5;//max row and max tokens
        int numsel = 0, mousedNum = 0;
        float cellWidth, cellHeight;
        Random rand = new Random();
        System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
        bool computerMove = false, playerMove = false;
        Point pos;
        bool playerwin = false;
        int pscore, cscore;
        Score s;
        
        RadialGradientBrush myBrush = new RadialGradientBrush();//Radiant Brush for generation
        int row;
        Ellipse [,] ellipseArray;
        int amountRow;
        List<int> amountPerCol = new List<int>();
        DispatcherTimer timer1 = new DispatcherTimer();
        int xorValue, mostSigDigit = 1, selectedRow = 0, RemoveInCanvas = 0;

        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Tick += timer1_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Startup();
            MessageBox.Show("please read the instructions before playing the game");
        }

        private void Startup()
        {
            canvas1.Children.Clear();
            setdimensions();
            settokens();
        }
        private void GenerateGameButton_Click(object sender, RoutedEventArgs e)
        {
            amountPerCol.Clear();
            try
            {
                n = int.Parse(nTextbox.Text) +1;
                m = int.Parse(mTextbox.Text) +1;
                //if (n >11 || m>11)
                //{
                //    throw new Exception();

                //}

                Startup();
            }
            catch
            {
                MessageBox.Show("Invalid Entry! Please specify max rows and max tokens/row");
            }      

        }

        private void setdimensions()
        {
            cellHeight = (float)canvas1.ActualHeight/ n;
            cellWidth = (float)canvas1.ActualWidth /m;
        }

        private void settokens()
        {
            ellipseArray = new Ellipse[100, 100];///stores all the ellipses
            amountRow = rand.Next(2, n);//1 row is not allowed, minimum value of rows are 2

            for (int i = 0; i < amountRow; i++)
            {
                amountPerCol.Add(rand.Next(1, m));///m is max tokens per row
            }

            for (int i = 0; i < amountRow; i++)///n=max rows
            {
                pos.Y = cellHeight * i;

                for (int j = 0; j<amountPerCol[i]; j++)///amount per col is randomly generated
                {
                    Ellipse newEllipse = new Ellipse();
                    ellipseArray[i,j] = newEllipse;

                    pos.X = cellWidth * j;
                    paintGTokens(myBrush, pos, newEllipse);
                }
            }

            Console.WriteLine(canvas1.Children.Count);

        }

        private void selectPaintToken(Brush tokencolor, Point position, Ellipse newEllipse)//select paint
        {
            newEllipse.Fill = tokencolor;
        }

        private void paintGTokens(RadialGradientBrush gradtoken, Point position, Ellipse newEllipse)
        {
            int k = n;//ratio
           ////fixa dimensioneringen
            newEllipse.Width = length-(k*0.2);
            newEllipse.Height = (length * 3)-(k*(0.7));

            myBrush.GradientOrigin = new Point(0.0, 1.1);
            myBrush.GradientStops.Add(new GradientStop(Colors.AliceBlue, 0.1));
            myBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 1.0));

            newEllipse.Fill = myBrush;
            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);

            canvas1.Children.Add(newEllipse);
           
        }

        private void BackGroundColorChange_Click(object sender, RoutedEventArgs e)//change bakground
        {
            ColorChooser dlg = new ColorChooser();
            Nullable<bool> dr;
            dr = dlg.ShowDialog();
            if (dr == true)
            {
                brushColor = dlg.colorLabel.Background;
                canvas1.Background = brushColor;
            }

        }

        private void TokenColorChange_Click(object sender, RoutedEventArgs e)////change token color
        {
            ColorChooser dlg = new ColorChooser();
            Nullable<bool> dr;
            dr = dlg.ShowDialog();
            if (dr == true)
            {
                brushColor = dlg.colorLabel.Background;
                for (int i = 0; i < canvas1.Children.Count; i++)
                {
                    ((Ellipse)canvas1.Children[i]).Fill = brushColor;                
                }
            }
        }

        private void SelectTokenColorChange_Click(object sender, RoutedEventArgs e)///selected token color change
        {
            ColorChooser dlg = new ColorChooser();
            Nullable<bool> dr;
            dr = dlg.ShowDialog();
            if (dr == true)
            {
                brushColor = dlg.colorLabel.Background;
                    selTokenColor = brushColor;
            }
        }

        private void insButton_Click(object sender, RoutedEventArgs e)
        {
            instructions ins = new instructions();
            ins.Show();
        }

        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            generateButton.IsEnabled = false;
            if (computerMove == false & playerMove == false)
                return;
            else if (playerMove == true)
            {
                for (int i = 0; i < canvas1.Children.Count; i++)
                {
                    Point p = e.GetPosition(canvas1);

                    if (canvas1.Children[i].IsMouseDirectlyOver)
                    {

                        mousedNum++;
                        if (mousedNum == 1)
                        {
                            checkrow(p);
                            selectPaintToken(selTokenColor, p,(Ellipse)canvas1.Children[i]);
                           
                            numsel++;
                        }
                        else if (mousedNum >= 2)
                        {
                            for (int j = 0; j < amountRow; j++)
                            {
                                if (p.Y >= cellHeight * j & p.Y <= cellHeight * (j + 1))
                                    rowsel = j;
                            }

                            if (row == rowsel)
                            {
                                selectPaintToken(selTokenColor, p, (Ellipse)canvas1.Children[i]);
                              
                               // paintTokens(selTokenColor, p);
                                numsel++;
                            }
                            else
                            {
                                MessageBox.Show("Must choose another token in the same row!");
                                return;
                            }
                        }
                    }
                }
            }

        }
        public void removeToken()
        {
            int removed = 0;

            for (int k = 0; k < canvas1.Children.Count; k++)
            {
                if ((canvas1.Children[k] as Ellipse).Fill == selTokenColor)
                {
                    //Console.WriteLine(k);
                    canvas1.Children.Remove(canvas1.Children[k]);
                    k = -1;
                    removed++;
                }
            }

            Console.WriteLine(removed);
            amountPerCol[row] -= removed;
            Console.WriteLine(amountPerCol[row]);
        }

        private void checkrow(Point p)
        {
            for (int i = 0; i < amountRow; i++)
            {
                if (p.Y >= cellHeight * i & p.Y <= cellHeight * (i + 1))
                    row = i;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            removeToken();
            if (mousedNum == 0)
            {
                MessageBox.Show("You must make a move!");
                return;
            }
            mousedNum = 0;
            numsel = 0;

            computerMove = true;
            playerMove = false;

            mycomputer();

        }

        private void playerButton_Click(object sender, RoutedEventArgs e)
        {
            playerMove = true;
            computerMove = false;
            stackPanel1.Visibility = Visibility.Hidden;
        }

        private void compButton_Click(object sender, RoutedEventArgs e)
        {
            computerMove = true;
            mycomputer();
            stackPanel1.Visibility = Visibility.Hidden;
        }

        public void mycomputer()
        {
            mostSigDigit = 1; selectedRow = 0; RemoveInCanvas = 0;
            rowsel = rand.Next(0, 10);

            //Nim Strategy

            xorValue = amountPerCol[0];

            for (int i = 1; i < amountRow; i++)
                xorValue = xorValue ^ amountPerCol[i];

            if (xorValue != 0 && playerwin!=true)
            {
                for (int i = 1; i <= xorValue; i = i * 2)
                    mostSigDigit = i;

                //Finds row to subtract from
                for (int i = 0; i < amountPerCol.Count; i++)
                {
                    if ((amountPerCol[i] & mostSigDigit) != 0)
                        selectedRow = i;
                }

                //Finds index in cavas1.Children to start removing
                for (int i = 0; i < selectedRow; i++)
                {

                    RemoveInCanvas += amountPerCol[i];
                    // ((Ellipse)canvas1.Children[amountPerCol[i]]).Fill = selTokenColor;

                }

                //Removes tokens
                for (int i = 0; i < amountPerCol[selectedRow] - (amountPerCol[selectedRow] ^ xorValue); i++)
                {
                    Ellipse ellipse = (Ellipse)canvas1.Children[RemoveInCanvas + i];
                    ellipse.Fill = selTokenColor;
                }
                playerwin = false;

            }
            else
            {
               // MessageBox.Show("Player Winning position");
                while (true)
                {
                    for (int i = 0; i < canvas1.Children.Count; i++)
                    {
                        if (canvas1.Children[i] != null)
                        {
                            canvas1.Children.Remove(canvas1.Children[i]);
                            playerwin = true;
                            break;
                        }
                    }
                    break;
                }
            }

            timer1.IsEnabled = true;
            
            Console.WriteLine(canvas1.Children.Count);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (playerwin != true)
            {
                for (int i = 0; i < amountPerCol[selectedRow] - (amountPerCol[selectedRow] ^ xorValue); i++)
                {
                    canvas1.Children.Remove(canvas1.Children[RemoveInCanvas]);

                }
                //Sets new number of tokens in selected row
                amountPerCol[selectedRow] = amountPerCol[selectedRow] ^ xorValue;
            }

            playerMove = true;
            // Console.WriteLine(canvas1.Children.Count);
            if (canvas1.Children.Count == 0 && playerwin==false)
            {
                cscore++;
                Console.WriteLine("Computer Wins {0}", cscore);
                MessageBox.Show("Computer Wins");
                stackPanel1.Visibility = Visibility.Visible;

                highscore();
            }
            else if (canvas1.Children.Count == 0 && playerwin == true)
            {
                pscore++;
                Console.WriteLine("Player Wins {0}", pscore);
                stackPanel1.Visibility = Visibility.Visible;
                MessageBox.Show("Player Wins");
                highscore();
            }
            timer1.IsEnabled = false;
        }

        private void highscore()
        {
            Nullable<bool> dr;
            s = new Score(pscore, cscore);
            dr = s.ShowDialog();
            generateButton.IsEnabled = true;
            if (dr == true)
            {
                s.Close();
            }
            if (dr == false)
            {
                newgame();
            }
        }
        void newgame()
        {
            pscore = 0;
            cscore = 0;
            Startup();
        }

    }
}
