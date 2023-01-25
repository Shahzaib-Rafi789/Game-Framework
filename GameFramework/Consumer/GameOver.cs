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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void TryAgain_Click(object sender, EventArgs e)
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

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
    }
}
