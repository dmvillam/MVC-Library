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

            /*List<int> buying_items = new List<int> { 1, 3, 2, 4, 7, 2, 3 };
            Bill bill = Bill.create(new Dictionary<string, string> {
                {"notas", ""},
                {"id_cliente", ""}
            });*/

            /*Client
                .find(1).bills()
                .Add(Bill.create(new Dictionary<string, string>{
                    {"notas", "asdaddfgfhghjghjkggdg"},
                    {"id_cliente", "3"}
                }
                ));*/

            //Client.find(1).bills().attach(1);
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
