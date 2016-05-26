namespace NimForm
{
    partial class TurnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.MyTurnButton = new System.Windows.Forms.Button();
            this.PCTurn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Whose turn shall it be first?";
            // 
            // MyTurnButton
            // 
            this.MyTurnButton.Location = new System.Drawing.Point(23, 97);
            this.MyTurnButton.Name = "MyTurnButton";
            this.MyTurnButton.Size = new System.Drawing.Size(99, 44);
            this.MyTurnButton.TabIndex = 1;
            this.MyTurnButton.Text = "MINE";
            this.MyTurnButton.UseVisualStyleBackColor = true;
            this.MyTurnButton.Click += new System.EventHandler(this.MyTurnButton_Click);
            // 
            // PCTurn
            // 
            this.PCTurn.Location = new System.Drawing.Point(149, 97);
            this.PCTurn.Name = "PCTurn";
            this.PCTurn.Size = new System.Drawing.Size(99, 44);
            this.PCTurn.TabIndex = 2;
            this.PCTurn.Text = "AI\'s";
            this.PCTurn.UseVisualStyleBackColor = true;
            this.PCTurn.Click += new System.EventHandler(this.PCTurn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TurnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PCTurn);
            this.Controls.Add(this.MyTurnButton);
            this.Controls.Add(this.label1);
            this.Name = "TurnForm";
            this.Text = "TurnForm";
            this.Load += new System.EventHandler(this.TurnForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MyTurnButton;
        private System.Windows.Forms.Button PCTurn;
        private System.Windows.Forms.Button button1;
    }
}