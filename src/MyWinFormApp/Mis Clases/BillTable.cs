using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormApp.Mis_Clases
{
    class BillTable
    {
        public static float[] ColumnSizes = new float[] { 112F, 27F, 83F, 84F, 66F, 103F, 57F, 114F, 65F };
        public static float RowSize = 45F;
        public enum Taxes { None, Default };
        public static string[] TaxLabels = { "0%", "12%" };

        public int count = 0;

        public List<TextBox> itemTextBox = new List<TextBox>();
        public List<Button> addItemButton = new List<Button>();
        public List<TextBox> priceTextBox = new List<TextBox>();
        public List<TextBox> discountTextBox = new List<TextBox>();
        public List<ComboBox> taxComboBox = new List<ComboBox>();
        public List<RichTextBox> descriptionRichTextBox = new List<RichTextBox>();
        public List<NumericUpDown> quantityNumericUpDown = new List<NumericUpDown>();
        public List<Label> totalLabel = new List<Label>();
        public List<Button> removeItemButton = new List<Button>();
        public List<decimal> priceList = new List<decimal>();

        public void AddRow(TextBox item, Button addItem, TextBox price, TextBox discount,
            ComboBox tax, RichTextBox desc, NumericUpDown quant, Label total, Button remove)
        {
            itemTextBox.Add(item);
            addItemButton.Add(addItem);
            priceTextBox.Add(price);
            discountTextBox.Add(discount);
            taxComboBox.Add(tax);
            descriptionRichTextBox.Add(desc);
            quantityNumericUpDown.Add(quant);
            totalLabel.Add(total);
            removeItemButton.Add(remove);

            priceList.Add(0);

            quantityNumericUpDown[count].Enabled = false;

            count++;
        }

        public void CreateNewRowInPanel(TableLayoutPanel panel)
        {
            this.AddRow(
                new TextBox(), new Button(), new TextBox(), new TextBox(), new ComboBox(),
                new RichTextBox(), new NumericUpDown(), new Label(), new Button());

            int last = count - 1;

            itemTextBox[last].Width = 106;
            itemTextBox[last].Height = 20;
            itemTextBox[last].Enabled = false;

            addItemButton[last].Text = "+";
            removeItemButton[last].Text = "-";
            totalLabel[last].Text = "BsF. 0,00";
            priceTextBox[last].Enabled = false;

            removeItemButton[last].Width = 21;
            removeItemButton[last].Height = 23;

            List<Control> elements = this.GetRow(last);

            foreach (float size in BillTable.ColumnSizes)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, size));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, BillTable.RowSize));

            for (int i = 0; i < elements.Count; i++)
                panel.Controls.Add(elements[i], i, count);
        }

        public List<Control> GetRow(int index)
        {
            return new List<Control>
            {
                itemTextBox[index], addItemButton[index], priceTextBox[index], discountTextBox[index],
                taxComboBox[index], descriptionRichTextBox[index], quantityNumericUpDown[index],
                totalLabel[index], removeItemButton[index]
            };
        }

        public void SetRowValues(int row, Item item)
        {
            priceList[row] = decimal.Parse(item.data["precio"]);

            itemTextBox[row].Text = item.data["nombre"];
            priceTextBox[row].Text = decimal.Parse(item.data["precio"])
                .ToString("C", CultureInfo.InvariantCulture).Substring(1);
            discountTextBox[row].Text = "0";
            descriptionRichTextBox[row].Text = item.data["descr"];
            totalLabel[row].Text = priceList[row]
                .ToString("C", CultureInfo.CreateSpecificCulture("es-VE"));
            quantityNumericUpDown[row].Value = 1;
            quantityNumericUpDown[row].Minimum = 1;
            quantityNumericUpDown[row].Enabled = true;

            taxComboBox[row].Enabled = true;
            foreach (string label in BillTable.TaxLabels)
                taxComboBox[row].Items.Add(label);
            taxComboBox[row].SelectedIndex = (int)BillTable.Taxes.None;
        }

        public decimal CalculateTotalFromRow(int row)
        {
            decimal discount = decimal.Parse(discountTextBox[row].Text) / 100;
            decimal tax = 0;

            int selectedIndex = taxComboBox[row].SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < BillTable.TaxLabels.Length)
            {
                string taxStr = BillTable.TaxLabels[taxComboBox[row].SelectedIndex];
                tax = decimal.Parse(taxStr.Substring(0, taxStr.Length - 1)) / 100;
            }
            decimal total = priceList[row] * quantityNumericUpDown[row].Value * (1 - discount) * (1 + tax);

            return total;
        }

        public void RemoveRow(int row)
        {
            itemTextBox.RemoveAt(row);
            addItemButton.RemoveAt(row);
            priceTextBox.RemoveAt(row);
            discountTextBox.RemoveAt(row);
            taxComboBox.RemoveAt(row);
            descriptionRichTextBox.RemoveAt(row);
            quantityNumericUpDown.RemoveAt(row);
            totalLabel.RemoveAt(row);
            removeItemButton.RemoveAt(row);
            priceList.RemoveAt(row);

            count--;
        }
    }
}
