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
    public partial class SelectClientForm : Form
    {
        public CreateBillForm parent;
        public SelectClientForm()
        {
            InitializeComponent();
        }

        private void SelectClientForm_Load(object sender, EventArgs e)
        {
            RefreshClientListBox();
        }

        public void RefreshClientListBox()
        {
            List<Client> clients = Client.all();
            List<string> _items = new List<string>();
            foreach (Client client in clients)
            {
                _items.Add(client.id + "\t" + client.data["nombre"] + "\t" + client.data["correo"] + "\r\n");
            }
            clientsListBox.DataSource = _items;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectClient()
        {
            string selectedClient = clientsListBox.GetItemText(clientsListBox.SelectedItem);
            int client_id = Int32.Parse(selectedClient.Split('\t')[0]);
            this.parent.setClient(client_id);
            this.Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectClient();
        }

        private void clientsListBox_DoubleClick(object sender, EventArgs e)
        {
            SelectClient();
        }
    }
}
