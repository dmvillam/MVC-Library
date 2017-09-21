using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void createBillButton_Click(object sender, EventArgs e)
        {
            CreateBillForm form = new CreateBillForm();
            form.ShowDialog();
        }

        private void manageClientsButton_Click(object sender, EventArgs e)
        {
            ManageClientsForm form = new ManageClientsForm();
            form.ShowDialog();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            ManageInventoryForm form = new ManageInventoryForm();
            form.ShowDialog();
        }
    }
}
