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
	/// Interaction logic for ColorChooser.xaml
	/// </summary>
	public partial class ColorChooser : Window
	{
		public ColorChooser()
		{
			InitializeComponent();
			alphaSlider.Value = 255;
		}

		// handles the ValueChanged event for the Sliders
		private void slider_ValueChanged(object sender,
			RoutedPropertyChangedEventArgs<double> e)
		{
			// generates new color
			SolidColorBrush backgroundColor = new SolidColorBrush();
			backgroundColor.Color = Color.FromArgb(
				(byte)alphaSlider.Value, (byte)redSlider.Value,
				(byte)greenSlider.Value, (byte)blueSlider.Value);

			// set colorLabel's background to new color
			colorLabel.Background = backgroundColor;
		}

		private void buttonOK_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			//Close();
			
		}

      private void buttonCancel_Click(object sender, RoutedEventArgs e)
      {
         DialogResult = false;
      } // end method slider_ValueChanged

	}
}
