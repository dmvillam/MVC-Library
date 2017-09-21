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
    public partial class SelectItemForm : Form
    {
        public CreateBillForm parent;
        public int row_index;
        public SelectItemForm()
        {
            InitializeComponent();
        }

        private void SelectItemForm_Load(object sender, EventArgs e)
        {
            RefreshItemListBox();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshItemListBox()
        {
            List<Item> items = Item.all();
            List<string> _items = new List<string>();
            foreach (Item item in items)
            {
                _items.Add(item.id + "\t" + item.data["nombre"] + "\t" + item.data["descr"] + "\r\n");
            }
            itemListBox.DataSource = _items;
        }

        private void SelectItem()
        {
            string selectedItem = itemListBox.GetItemText(itemListBox.SelectedItem);
            int item_id = Int32.Parse(selectedItem.Split('\t')[0]);
            this.parent.setItem(item_id, row_index);
            this.Close();
        }

        private void itemListBox_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectItem();
        }
    }
}
