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
using System.Windows.Shapes;

namespace Nim
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        
        public Score()
        {
            InitializeComponent();
        }
        public Score(int pscore, int cscore)
        {
            InitializeComponent();
            displayc.Content =displayc.Content+cscore.ToString();
            displayp.Content =displayp.Content+pscore.ToString();

        }


        private void Button_OK(object sender, RoutedEventArgs e)
        {
            
            DialogResult = true;
        }

        private void new_game_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
