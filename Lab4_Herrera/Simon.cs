using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SimonGame
{
    public class Simon
    {
        //private Color []sequence;
        public Simon() { }
        Random rand = new Random();
        private Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };

        public Color[] Colors
        {
            get { return colors; }
            //set { colors = value; }
        }

        //   public Color[] Sequence
        //    {
        //         set { sequence = value; }
        //  }

        public Color[] newSequence(int length)
        {
            Color[] generator = new Color[length];
            for (int i = 0; i < length; i++)
            {
                generator[i] = colors[new Random().Next(0, 3)];//// store random sequence in array

            }
            return generator;
        }

        public int Compare(Color[] user_colors, Color[] generated)
        {
            for (int i = 0; i < user_colors.Length; i++)
            {
                if (user_colors[i] == generated[i])
                {
                    //single match
                }
                else
                {
                    //no match
                    return -1;
                }
            }

            //all matched
            if (user_colors.Length == generated.Length)
            {
                return 1;
            }
            else
            { //partial match
                return 0;
            }
        }

    }
}
    
