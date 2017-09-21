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
    public partial class EditClientForm : Form
    {
        private ManageClientsForm parentForm;
        private int client_id;
        public EditClientForm(int id, ManageClientsForm form)
        {
            InitializeComponent();

            client_id = id;
            parentForm = form;
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            Client client = Client.find(client_id);

            nameTextBox.Text = client.data["nombre"];
            mailTextBox.Text = client.data["correo"];
            telfTextBox.Text = client.data["telf1"];
            celTextBox.Text = client.data["cel"];

            this.Text = "Editando cliente: (" + client_id + ") " + client.data["nombre"];
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editClientButton_Click(object sender, EventArgs e)
        {
            if ( ! string.IsNullOrEmpty(nameTextBox.Text))
            {
                Client client = Client.find(client_id);

                client.data["nombre"] = nameTextBox.Text;
                client.data["correo"] = mailTextBox.Text;
                client.data["telf1"] = telfTextBox.Text;
                client.data["cel"] = celTextBox.Text;
                client.save();

                this.parentForm.RefreshClienListBox();

                MessageBox.Show("El cliente \"" + client.data["nombre"] + "\"ha sido actualizado.", "Éxito");
                this.Close();
            }
            else MessageBox.Show("Error: el campo del nombre del cliente no puede quedar vacío.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
