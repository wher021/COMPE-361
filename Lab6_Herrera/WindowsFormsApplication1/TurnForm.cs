using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NimForm
{
    public partial class TurnForm : Form
    {
        public bool turn, newgame;
        
        public TurnForm()
        {
           InitializeComponent();
            
            Invalidate();
        }

        private void TurnForm_Load(object sender, EventArgs e)
        {
        }

        private void MyTurnButton_Click(object sender, EventArgs e)
        {
            turn = true;
            
            
        }

        private void PCTurn_Click(object sender, EventArgs e)
        {
            turn = false;
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
