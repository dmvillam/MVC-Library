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
    public partial class ManageClientsForm : Form
    {
        public ManageClientsForm()
        {
            InitializeComponent();
        }

        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            RefreshClienListBox();
        }

        private void createClientButton_Click(object sender, EventArgs e)
        {
            CreateClientForm clientForm = new CreateClientForm(this);
            clientForm.ShowDialog();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshClienListBox()
        {
            List<Client> clients = Client.all();
            clientDataGridView.Rows.Clear();
            foreach (Client client in clients)
            {
                int n = clientDataGridView.Rows.Add();
                clientDataGridView.Rows[n].Cells[0].Value = client.id;
                clientDataGridView.Rows[n].Cells[1].Value = client.data["nombre"];
                clientDataGridView.Rows[n].Cells[2].Value = client.data["correo"];
            }
        }

        private void editClientButton_Click(object sender, EventArgs e)
        {
            EditClientForm form = new EditClientForm(GetIdFromSelectedClient(), this);
            form.ShowDialog();
        }

        private int GetIdFromSelectedClient()
        {
            int row_index = clientDataGridView.CurrentCell.RowIndex;
            DataGridViewRow row = clientDataGridView.Rows[row_index];
            return Convert.ToInt32(row.Cells["Id"].Value);
        }

        private void removeClientButton_Click(object sender, EventArgs e)
        {
            int client_id = GetIdFromSelectedClient();
            Client client = Client.find(client_id);
            DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar el cliente " + client.data["nombre"] + "?", "Alerta",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Client.destroy(client_id);
                this.RefreshClienListBox();
                MessageBox.Show("El cliente " + client.data["nombre"] + " ha sido eliminado.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = clientDataGridView.CurrentCell.RowIndex;
            List<Client> clients = Client.all();

            if (row_index >= clients.Count)
            {
                CreateClientForm form = new CreateClientForm(this);
                form.ShowDialog();
            }
            else
            {
                EditClientForm form = new EditClientForm(GetIdFromSelectedClient(), this);
                form.ShowDialog();
            }
        }

        private void clientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = clientDataGridView.CurrentCell.RowIndex;
            List<Client> clients = Client.all();

            if (row_index >= clients.Count)
            {
                editClientButton.Enabled = false;
                removeClientButton.Enabled = false;
            }
            else
            {
                editClientButton.Enabled = true;
                removeClientButton.Enabled = true;
            }
        }
    }
}
