using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace MyWinFormApp
{
    public partial class LoadingForm : Form
    {
        private int i;
        public LoadingForm()
        {
            InitializeComponent();
        }
        private void LoadingForm_Load(object sender, EventArgs e)
        {
            introProgressBar.Minimum = 0;
            introProgressBar.Maximum = 40;
            introProgressBar.Step = 1;
            i = 0;
            introTimer.Enabled = true;
        }
        private void introTimer_Tick(object sender, EventArgs e)
        {
            if (introProgressBar.Value >= introProgressBar.Maximum)
            {
                i++;
                if (i == introProgressBar.Maximum)
                {
                    this.Hide();
                    MainForm form1 = new MainForm();
                    form1.ShowDialog();
                    introTimer.Enabled = false;
                    this.Close();
                }
                else if (i>introProgressBar.Maximum)
                    introTimer.Enabled = false;
            }
            else introProgressBar.PerformStep();
        }
    }
}
