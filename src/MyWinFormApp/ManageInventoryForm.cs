using MyWinFormApp.Mis_Clases;
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
    public partial class ManageInventoryForm : Form
    {
        public ManageInventoryForm()
        {
            InitializeComponent();
        }

        private void ManageInventoryForm_Load(object sender, EventArgs e)
        {
            RefreshItemListBox();
        }

        public void RefreshItemListBox()
        {
            List<Item> items = Item.all();
            itemDataGridView.Rows.Clear();
            foreach (Item item in items)
            {
                int n = itemDataGridView.Rows.Add();
                itemDataGridView.Rows[n].Cells[0].Value = item.id;
                itemDataGridView.Rows[n].Cells[1].Value = item.data["nombre"];
                itemDataGridView.Rows[n].Cells[2].Value = (Convert.ToDecimal(item.data["precio"])).ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
                itemDataGridView.Rows[n].Cells[3].Value = item.data["cantidad"];
            }
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            CreateItemForm form = new CreateItemForm(this);
            form.ShowDialog();
        }

        private void itemDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = itemDataGridView.CurrentCell.RowIndex;
            List<Item> items = Item.all();

            CreateItemForm form;
            if (row_index >= items.Count)
                form = new CreateItemForm(this);
            else
                form = new CreateItemForm(GetIdFromSelectedItem(), this);
            form.ShowDialog();
        }

        private void editItemButton_Click(object sender, EventArgs e)
        {
            CreateItemForm form = new CreateItemForm(GetIdFromSelectedItem(), this);
            form.ShowDialog();
        }

        private int GetIdFromSelectedItem()
        {
            int row_index = itemDataGridView.CurrentCell.RowIndex;
            DataGridViewRow row = itemDataGridView.Rows[row_index];
            return Convert.ToInt32(row.Cells["Id"].Value);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            int item_id = GetIdFromSelectedItem();
            Item item = Item.find(item_id);

            DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar el artículo " + item.data["nombre"] + "?", "Alerta",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Item.destroy(item_id);
                MessageBox.Show("El artículo " + item.data["nombre"] + " ha sido removido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshItemListBox();
            }
        }

        private void itemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = itemDataGridView.CurrentCell.RowIndex;
            List<Item> items = Item.all();

            if (row_index >= items.Count)
            {
                editItemButton.Enabled = false;
                removeItemButton.Enabled = false;
            }
            else
            {
                editItemButton.Enabled = true;
                removeItemButton.Enabled = true;
            }
        }
    }
}
