using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumer
{
    public partial class GameWin : Form
    {
        public GameWin()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Level1 form = new Level1();
            form.Closed += (s, args) => this.Close();

            form.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void GameWin_Load(object sender, EventArgs e)
        {

        }
    }
}
