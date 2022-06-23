namespace CheckersMenu
{
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class GameSettings : Form
    {
        public GameSettings()
        {
            this.InitializeComponent();
        }

        internal int GetBoradSize()
        {
            int boradSize;
            if (this.six_lbl.Checked == true)
            {
                boradSize = 6;
            }
            else if (this.eight_lbl.Checked == true)
            {
                boradSize = 8;
            }
            else
            {
                boradSize = 10;
            }

            return boradSize;
        }

        private void PlayerTwoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PlayerTwoCheckBox.Checked)
            {
                this.player2TextBox.Enabled = true;
                this.player2TextBox.Text = string.Empty;
            }
            else
            {
                this.player2TextBox.Enabled = false;
            }
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            string player1 = this.player1TextBox.Text;
            string player2 = this.player2TextBox.Text;
            int boardSize = this.GetBoradSize();
            if (this.PlayerTwoCheckBox.Checked == false)
            {
                player2 = "PC";
            }

            FormGame formGame = new FormGame(boardSize, player1, player2);
            formGame.Text = "Checkers";
            formGame.Size = new Size((boardSize + 2) * 55, (boardSize + 2) * 55);
            formGame.ShowDialog();
        }
    }
}
