using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormApp
{
    public partial class CreateItemForm : Form
    {
        private bool editMode;
        private Item item;
        private ManageInventoryForm parent;

        public CreateItemForm(ManageInventoryForm form)
        {
            InitializeComponent();
            parent = form;
            editMode = false;
        }

        public CreateItemForm(int id, ManageInventoryForm form)
        {
            InitializeComponent();
            parent = form;
            item = Item.find(id);
            this.Text = "Modificar artículo: " + item.data["nombre"];

            nameTextBox.Text = item.data["nombre"];
            descRichTextBox.Text = item.data["descr"];
            priceTextBox.Text = item.data["precio"];
            quantityNumericUpDown.Value = Int32.Parse(item.data["cantidad_inicial"]);

            createButton.Text = "Modificar";
            editMode = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                if (priceLabel.Text != "")
                {
                    decimal price;
                    if (decimal.TryParse(priceTextBox.Text, out price))
                    {
                        if (editMode)
                        {
                            item.data["nombre"] = nameTextBox.Text;
                            item.data["descr"] = descRichTextBox.Text;
                            item.data["precio"] = price.ToString();
                            item.data["cantidad_inicial"] = quantityNumericUpDown.Value.ToString();
                            item.data["cantidad"] = quantityNumericUpDown.Value.ToString();
                            item.save();

                            MessageBox.Show("El artículo " + item.data["nombre"] + " ha sido modificado con éxito!",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Item item = Item.create(new Dictionary<string, string> {
                                {"nombre", nameTextBox.Text},
                                {"descr", descRichTextBox.Text},
                                {"precio", price.ToString()},
                                {"cantidad_inicial", quantityNumericUpDown.Value.ToString()},
                                {"cantidad", quantityNumericUpDown.Value.ToString()}
                            });
                            MessageBox.Show("El artículo " + item.data["nombre"] + " ha sido creado con éxito!",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        parent.RefreshItemListBox();
                        this.Close();
                    }
                    else MessageBox.Show("El valor introducido en el campo de precio unitario no es válido.\n" +
                        "Por favor ingrese un número con un máximo de 2 decimales, utilizando un punto como separador",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("El campo de precio unitario no puede quedar vacío",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Error: el campo Nombre no puede quedar vacío.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
