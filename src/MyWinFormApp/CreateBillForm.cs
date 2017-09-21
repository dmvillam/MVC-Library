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
    public partial class CreateBillForm : Form
    {
        private Client billClient;
        private BillTable table;

        public CreateBillForm()
        {
            InitializeComponent();
        }

        private void CreateBillForm_Load(object sender, EventArgs e)
        {
            table = new BillTable();
            table.AddRow(
                itemTextBox1, addItemButton1, priceTextBox1, discountTextBox1, taxComboBox1,
                descriptionRichTextBox1, quantityNumericUpDown1, totalLabel1, removeItemButton1);
            table.AddRow(
                itemTextBox2, addItemButton2, priceTextBox2, discountTextBox2, taxComboBox2,
                descriptionRichTextBox2, quantityNumericUpDown2, totalLabel2, removeItemButton2);
            table.AddRow(
                itemTextBox3, addItemButton3, priceTextBox3, discountTextBox3, taxComboBox3,
                descriptionRichTextBox3, quantityNumericUpDown3, totalLabel3, removeItemButton3);

            table.addItemButton[0].Click += new System.EventHandler(this.addItemButton_Click);
            table.addItemButton[1].Click += new System.EventHandler(this.addItemButton_Click);
            table.addItemButton[2].Click += new System.EventHandler(this.addItemButton_Click);

            table.removeItemButton[0].Click += new System.EventHandler(this.removeItemButton_Click);
            table.removeItemButton[1].Click += new System.EventHandler(this.removeItemButton_Click);
            table.removeItemButton[2].Click += new System.EventHandler(this.removeItemButton_Click);

            table.quantityNumericUpDown[0].ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);
            table.quantityNumericUpDown[1].ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);
            table.quantityNumericUpDown[2].ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);

            table.discountTextBox[0].TextChanged += new System.EventHandler(this.discountTextBox_TextChanged);
            table.discountTextBox[1].TextChanged += new System.EventHandler(this.discountTextBox_TextChanged);
            table.discountTextBox[2].TextChanged += new System.EventHandler(this.discountTextBox_TextChanged);

            table.taxComboBox[0].SelectedIndexChanged += new System.EventHandler(this.taxComboBox_SelectedIndexChanged);
            table.taxComboBox[1].SelectedIndexChanged += new System.EventHandler(this.taxComboBox_SelectedIndexChanged);
            table.taxComboBox[2].SelectedIndexChanged += new System.EventHandler(this.taxComboBox_SelectedIndexChanged);
        }

        private void addItemRowButton_Click(object sender, EventArgs e)
        {
            itemsTableLayoutPanel.RowCount++;
            itemsTableLayoutPanel.Height += 45;
            table.CreateNewRowInPanel(itemsTableLayoutPanel);

            table.addItemButton[table.count - 1].Click += new System.EventHandler(this.addItemButton_Click);
            table.removeItemButton[table.count - 1].Click += new System.EventHandler(this.removeItemButton_Click);
            table.quantityNumericUpDown[table.count - 1].ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);
            table.discountTextBox[table.count - 1].TextChanged += new System.EventHandler(this.discountTextBox_TextChanged);
            table.taxComboBox[table.count - 1].SelectedIndexChanged += new System.EventHandler(this.taxComboBox_SelectedIndexChanged);

            lowerPanel.Location = new Point { X = lowerPanel.Location.X, Y = lowerPanel.Location.Y + 45 };
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            SelectClientForm form = new SelectClientForm();
            form.parent = this;
            form.ShowDialog();
        }

        public void setClient(int client_id)
        {
            billClient = Client.find(client_id);
            this.clientTextBox.Text = billClient.data["nombre"];
        }

        public void setItem(int item_id, int row)
        {
            Item item = Item.find(item_id);
            table.SetRowValues(row, item);
            UpdateBillTotals(table);
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            SelectItemForm form = new SelectItemForm();
            form.parent = this;
            form.row_index = itemsTableLayoutPanel.GetRow((Button)sender) - 1;
            form.ShowDialog();
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            Button remover = (Button)sender;
            int rowToRemove = itemsTableLayoutPanel.GetRow(remover) - 1;

            table.RemoveRow(rowToRemove);
            RebuildPanel(itemsTableLayoutPanel);

            lowerPanel.Location = new Point { X = lowerPanel.Location.X, Y = 330 + 45 * (table.count - 3) };
            UpdateBillTotals(table);
        }

        private void RebuildPanel(TableLayoutPanel panel)
        {
            List<Label> labels = new List<Label> {
                (Label)panel.GetControlFromPosition(0,0),
                (Label)panel.GetControlFromPosition(1,0),
                (Label)panel.GetControlFromPosition(2,0),
                (Label)panel.GetControlFromPosition(3,0),
                (Label)panel.GetControlFromPosition(4,0),
                (Label)panel.GetControlFromPosition(5,0),
                (Label)panel.GetControlFromPosition(6,0),
                (Label)panel.GetControlFromPosition(7,0),
                (Label)panel.GetControlFromPosition(8,0)
            };

            panel.Controls.Clear();
            panel.RowStyles.Clear();

            foreach (float size in BillTable.ColumnSizes)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, size));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));

            for (int i = 0; i < labels.Count; i++)
                if (labels[i] != null)
                    panel.Controls.Add(labels[i], i, 0);

            for (int row = 0; row<table.count; row++)
            {
                List<Control> elements = table.GetRow(row);

                foreach (float size in BillTable.ColumnSizes)
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, size));
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, BillTable.RowSize));

                for (int i = 0; i < elements.Count; i++)
                    panel.Controls.Add(elements[i], i, row+1);
            }
            panel.RowCount = table.count;
        }

        private void UpdateBillTotals(BillTable table)
        {
            decimal subtotal = 0, discount = 0, tax = 0;
            for (int i = 0; i < table.priceList.Count; i++)
            {
                decimal item_subtotal = table.priceList[i] * table.quantityNumericUpDown[i].Value;
                subtotal += item_subtotal;
                string item_discount = (table.discountTextBox[i].Text == "") ? "0" : table.discountTextBox[i].Text;
                discount += decimal.Parse(item_discount) / 100 * item_subtotal;

                int index = table.taxComboBox[i].SelectedIndex;
                if (index >= 0 && index < BillTable.TaxLabels.Length)
                {
                    string taxStr = BillTable.TaxLabels[table.taxComboBox[i].SelectedIndex];
                    decimal item_tax = decimal.Parse(taxStr.Substring(0, taxStr.Length - 1));
                    tax += item_tax / 100 * item_subtotal;
                }
            }
            subtotalCurrencyLabel.Text = subtotal.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            totalDiscountCurrencyLabel.Text = discount.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            subtotal2CurrencyLabel.Text = (subtotal - discount).ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            totalTaxCurrencyLabel.Text = tax.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            totalCurrencyLabel.Text = (subtotal - discount + tax).ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
        }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int row = itemsTableLayoutPanel.GetRow((NumericUpDown)sender) - 1;
            decimal total = table.CalculateTotalFromRow(row);
            table.totalLabel[row].Text = total.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            UpdateBillTotals(table);
        }

        private void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            int row = itemsTableLayoutPanel.GetRow((TextBox)sender) - 1;
            decimal total = table.CalculateTotalFromRow(row);
            table.totalLabel[row].Text = total.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            UpdateBillTotals(table);
        }

        private void taxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = itemsTableLayoutPanel.GetRow((ComboBox)sender) - 1;
            decimal total = table.CalculateTotalFromRow(row);
            table.totalLabel[row].Text = total.ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            UpdateBillTotals(table);
        }

        private void billDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime result = billDateTimePicker.Value;
            MessageBox.Show(result.ToString());
        }
    }
}
