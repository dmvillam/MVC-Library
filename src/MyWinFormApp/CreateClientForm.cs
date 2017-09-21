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
    public partial class CreateClientForm : Form
    {
        ManageClientsForm parentForm;
        public CreateClientForm(ManageClientsForm form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void createClientButton_Click(object sender, EventArgs e)
        {
            if ( ! string.IsNullOrEmpty(nameTextBox.Text))
            {
                Client client = Client.create(new Dictionary<string, string> {
                    {"nombre", nameTextBox.Text},
                    {"correo", mailTextBox.Text},
                    {"telf1", telfTextBox.Text},
                    {"cel", celTextBox.Text}
                });
                this.parentForm.RefreshClienListBox();
                MessageBox.Show("Cliente " + client.data["nombre"] + " creado con éxito.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("Error: el campo del nombre del cliente no puede quedar vacío.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
