namespace MyWinFormApp
{
    partial class CreateBillForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.billIdLabel = new System.Windows.Forms.Label();
            this.clientLabel = new System.Windows.Forms.Label();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.clientButton = new System.Windows.Forms.Button();
            this.expireDateLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.billDateLabel = new System.Windows.Forms.Label();
            this.billDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.expireDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.itemsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.removeItemButton3 = new System.Windows.Forms.Button();
            this.removeItemButton2 = new System.Windows.Forms.Button();
            this.itemLabel = new System.Windows.Forms.Label();
            this.removeItemButton1 = new System.Windows.Forms.Button();
            this.totalLabel1 = new System.Windows.Forms.Label();
            this.totalLabel2 = new System.Windows.Forms.Label();
            this.totalLabel3 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.quantityNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.quantityNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionRichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.descriptionRichTextBox2 = new System.Windows.Forms.RichTextBox();
            this.descriptionRichTextBox3 = new System.Windows.Forms.RichTextBox();
            this.taxLabel = new System.Windows.Forms.Label();
            this.taxComboBox1 = new System.Windows.Forms.ComboBox();
            this.taxComboBox2 = new System.Windows.Forms.ComboBox();
            this.taxComboBox3 = new System.Windows.Forms.ComboBox();
            this.discountTextBox1 = new System.Windows.Forms.TextBox();
            this.discountTextBox2 = new System.Windows.Forms.TextBox();
            this.discountTextBox3 = new System.Windows.Forms.TextBox();
            this.priceTextBox2 = new System.Windows.Forms.TextBox();
            this.priceTextBox3 = new System.Windows.Forms.TextBox();
            this.itemTextBox1 = new System.Windows.Forms.TextBox();
            this.itemTextBox2 = new System.Windows.Forms.TextBox();
            this.itemTextBox3 = new System.Windows.Forms.TextBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.addItemButton1 = new System.Windows.Forms.Button();
            this.addItemButton2 = new System.Windows.Forms.Button();
            this.addItemButton3 = new System.Windows.Forms.Button();
            this.priceTextBox1 = new System.Windows.Forms.TextBox();
            this.subtotalLabel = new System.Windows.Forms.Label();
            this.totalDiscountLabel = new System.Windows.Forms.Label();
            this.subtotal2Label = new System.Windows.Forms.Label();
            this.subtotalCurrencyLabel = new System.Windows.Forms.Label();
            this.totalDiscountCurrencyLabel = new System.Windows.Forms.Label();
            this.subtotal2CurrencyLabel = new System.Windows.Forms.Label();
            this.addItemRowButton = new System.Windows.Forms.Button();
            this.totalTaxCurrencyLabel = new System.Windows.Forms.Label();
            this.totalTaxLabel = new System.Windows.Forms.Label();
            this.totalCurrencyLabel = new System.Windows.Forms.Label();
            this.total2Label = new System.Windows.Forms.Label();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.cancelBillButton = new System.Windows.Forms.Button();
            this.previewBillButton = new System.Windows.Forms.Button();
            this.saveBillButton = new System.Windows.Forms.Button();
            this.itemsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown3)).BeginInit();
            this.lowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(76, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // billIdLabel
            // 
            this.billIdLabel.AutoSize = true;
            this.billIdLabel.Location = new System.Drawing.Point(22, 25);
            this.billIdLabel.Name = "billIdLabel";
            this.billIdLabel.Size = new System.Drawing.Size(44, 13);
            this.billIdLabel.TabIndex = 1;
            this.billIdLabel.Text = "Número";
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(22, 51);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(39, 13);
            this.clientLabel.TabIndex = 3;
            this.clientLabel.Text = "Cliente";
            // 
            // clientTextBox
            // 
            this.clientTextBox.Enabled = false;
            this.clientTextBox.Location = new System.Drawing.Point(76, 48);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(162, 20);
            this.clientTextBox.TabIndex = 2;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(76, 74);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(192, 65);
            this.notesTextBox.TabIndex = 4;
            // 
            // notesLabel
            // 
            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new System.Drawing.Point(22, 77);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new System.Drawing.Size(35, 13);
            this.notesLabel.TabIndex = 5;
            this.notesLabel.Text = "Notas";
            // 
            // clientButton
            // 
            this.clientButton.Location = new System.Drawing.Point(244, 48);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(24, 23);
            this.clientButton.TabIndex = 6;
            this.clientButton.Text = "+";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // expireDateLabel
            // 
            this.expireDateLabel.AutoSize = true;
            this.expireDateLabel.Location = new System.Drawing.Point(408, 86);
            this.expireDateLabel.Name = "expireDateLabel";
            this.expireDateLabel.Size = new System.Drawing.Size(65, 13);
            this.expireDateLabel.TabIndex = 12;
            this.expireDateLabel.Text = "Vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Plazo";
            // 
            // billDateLabel
            // 
            this.billDateLabel.AutoSize = true;
            this.billDateLabel.Location = new System.Drawing.Point(408, 28);
            this.billDateLabel.Name = "billDateLabel";
            this.billDateLabel.Size = new System.Drawing.Size(37, 13);
            this.billDateLabel.TabIndex = 10;
            this.billDateLabel.Text = "Fecha";
            // 
            // billDateTimePicker
            // 
            this.billDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.billDateTimePicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.billDateTimePicker.Location = new System.Drawing.Point(481, 25);
            this.billDateTimePicker.Name = "billDateTimePicker";
            this.billDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.billDateTimePicker.TabIndex = 13;
            this.billDateTimePicker.ValueChanged += new System.EventHandler(this.billDateTimePicker_ValueChanged);
            // 
            // expireDateTimePicker
            // 
            this.expireDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expireDateTimePicker.Location = new System.Drawing.Point(481, 80);
            this.expireDateTimePicker.Name = "expireDateTimePicker";
            this.expireDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.expireDateTimePicker.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(481, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // itemsTableLayoutPanel
            // 
            this.itemsTableLayoutPanel.ColumnCount = 9;
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.itemsTableLayoutPanel.Controls.Add(this.removeItemButton3, 8, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.removeItemButton2, 8, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.itemLabel, 0, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.removeItemButton1, 8, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.totalLabel1, 7, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.totalLabel2, 7, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.totalLabel3, 7, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.totalLabel, 7, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.quantityLabel, 6, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.quantityNumericUpDown1, 6, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.quantityNumericUpDown2, 6, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.quantityNumericUpDown3, 6, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.descLabel, 5, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.descriptionRichTextBox1, 5, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.descriptionRichTextBox2, 5, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.descriptionRichTextBox3, 5, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.taxLabel, 4, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.taxComboBox1, 4, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.taxComboBox2, 4, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.taxComboBox3, 4, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.discountTextBox1, 3, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.discountTextBox2, 3, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.discountTextBox3, 3, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.priceTextBox2, 2, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.priceTextBox3, 2, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.itemTextBox1, 0, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.itemTextBox2, 0, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.itemTextBox3, 0, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.discountLabel, 3, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.priceLabel, 2, 0);
            this.itemsTableLayoutPanel.Controls.Add(this.addItemButton1, 1, 1);
            this.itemsTableLayoutPanel.Controls.Add(this.addItemButton2, 1, 2);
            this.itemsTableLayoutPanel.Controls.Add(this.addItemButton3, 1, 3);
            this.itemsTableLayoutPanel.Controls.Add(this.priceTextBox1, 2, 1);
            this.itemsTableLayoutPanel.Location = new System.Drawing.Point(10, 170);
            this.itemsTableLayoutPanel.Name = "itemsTableLayoutPanel";
            this.itemsTableLayoutPanel.RowCount = 4;
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.itemsTableLayoutPanel.Size = new System.Drawing.Size(671, 154);
            this.itemsTableLayoutPanel.TabIndex = 16;
            // 
            // removeItemButton3
            // 
            this.removeItemButton3.Location = new System.Drawing.Point(649, 111);
            this.removeItemButton3.Name = "removeItemButton3";
            this.removeItemButton3.Size = new System.Drawing.Size(21, 23);
            this.removeItemButton3.TabIndex = 44;
            this.removeItemButton3.Text = "-";
            this.removeItemButton3.UseVisualStyleBackColor = true;
            // 
            // removeItemButton2
            // 
            this.removeItemButton2.Location = new System.Drawing.Point(649, 66);
            this.removeItemButton2.Name = "removeItemButton2";
            this.removeItemButton2.Size = new System.Drawing.Size(21, 23);
            this.removeItemButton2.TabIndex = 43;
            this.removeItemButton2.Text = "-";
            this.removeItemButton2.UseVisualStyleBackColor = true;
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(3, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(44, 13);
            this.itemLabel.TabIndex = 17;
            this.itemLabel.Text = "Artículo";
            // 
            // removeItemButton1
            // 
            this.removeItemButton1.Location = new System.Drawing.Point(649, 21);
            this.removeItemButton1.Name = "removeItemButton1";
            this.removeItemButton1.Size = new System.Drawing.Size(21, 23);
            this.removeItemButton1.TabIndex = 42;
            this.removeItemButton1.Text = "-";
            this.removeItemButton1.UseVisualStyleBackColor = true;
            // 
            // totalLabel1
            // 
            this.totalLabel1.AutoSize = true;
            this.totalLabel1.Location = new System.Drawing.Point(535, 18);
            this.totalLabel1.Name = "totalLabel1";
            this.totalLabel1.Size = new System.Drawing.Size(52, 13);
            this.totalLabel1.TabIndex = 17;
            this.totalLabel1.Text = "BsF. 0,00";
            // 
            // totalLabel2
            // 
            this.totalLabel2.AutoSize = true;
            this.totalLabel2.Location = new System.Drawing.Point(535, 63);
            this.totalLabel2.Name = "totalLabel2";
            this.totalLabel2.Size = new System.Drawing.Size(52, 13);
            this.totalLabel2.TabIndex = 36;
            this.totalLabel2.Text = "BsF. 0,00";
            // 
            // totalLabel3
            // 
            this.totalLabel3.AutoSize = true;
            this.totalLabel3.Location = new System.Drawing.Point(535, 108);
            this.totalLabel3.Name = "totalLabel3";
            this.totalLabel3.Size = new System.Drawing.Size(52, 13);
            this.totalLabel3.TabIndex = 37;
            this.totalLabel3.Text = "BsF. 0,00";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(535, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(31, 13);
            this.totalLabel.TabIndex = 27;
            this.totalLabel.Text = "Total";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(478, 0);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.quantityLabel.TabIndex = 26;
            this.quantityLabel.Text = "Cantidad";
            // 
            // quantityNumericUpDown1
            // 
            this.quantityNumericUpDown1.Location = new System.Drawing.Point(478, 21);
            this.quantityNumericUpDown1.Name = "quantityNumericUpDown1";
            this.quantityNumericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.quantityNumericUpDown1.TabIndex = 33;
            // 
            // quantityNumericUpDown2
            // 
            this.quantityNumericUpDown2.Location = new System.Drawing.Point(478, 66);
            this.quantityNumericUpDown2.Name = "quantityNumericUpDown2";
            this.quantityNumericUpDown2.Size = new System.Drawing.Size(51, 20);
            this.quantityNumericUpDown2.TabIndex = 34;
            // 
            // quantityNumericUpDown3
            // 
            this.quantityNumericUpDown3.Location = new System.Drawing.Point(478, 111);
            this.quantityNumericUpDown3.Name = "quantityNumericUpDown3";
            this.quantityNumericUpDown3.Size = new System.Drawing.Size(51, 20);
            this.quantityNumericUpDown3.TabIndex = 35;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(375, 0);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(63, 13);
            this.descLabel.TabIndex = 25;
            this.descLabel.Text = "Descripción";
            // 
            // descriptionRichTextBox1
            // 
            this.descriptionRichTextBox1.Location = new System.Drawing.Point(375, 21);
            this.descriptionRichTextBox1.Name = "descriptionRichTextBox1";
            this.descriptionRichTextBox1.Size = new System.Drawing.Size(97, 39);
            this.descriptionRichTextBox1.TabIndex = 38;
            this.descriptionRichTextBox1.Text = "";
            // 
            // descriptionRichTextBox2
            // 
            this.descriptionRichTextBox2.Location = new System.Drawing.Point(375, 66);
            this.descriptionRichTextBox2.Name = "descriptionRichTextBox2";
            this.descriptionRichTextBox2.Size = new System.Drawing.Size(97, 39);
            this.descriptionRichTextBox2.TabIndex = 39;
            this.descriptionRichTextBox2.Text = "";
            // 
            // descriptionRichTextBox3
            // 
            this.descriptionRichTextBox3.Location = new System.Drawing.Point(375, 111);
            this.descriptionRichTextBox3.Name = "descriptionRichTextBox3";
            this.descriptionRichTextBox3.Size = new System.Drawing.Size(97, 39);
            this.descriptionRichTextBox3.TabIndex = 40;
            this.descriptionRichTextBox3.Text = "";
            // 
            // taxLabel
            // 
            this.taxLabel.AutoSize = true;
            this.taxLabel.Location = new System.Drawing.Point(309, 0);
            this.taxLabel.Name = "taxLabel";
            this.taxLabel.Size = new System.Drawing.Size(50, 13);
            this.taxLabel.TabIndex = 24;
            this.taxLabel.Text = "Impuesto";
            // 
            // taxComboBox1
            // 
            this.taxComboBox1.Enabled = false;
            this.taxComboBox1.FormattingEnabled = true;
            this.taxComboBox1.Location = new System.Drawing.Point(309, 21);
            this.taxComboBox1.Name = "taxComboBox1";
            this.taxComboBox1.Size = new System.Drawing.Size(60, 21);
            this.taxComboBox1.TabIndex = 17;
            // 
            // taxComboBox2
            // 
            this.taxComboBox2.Enabled = false;
            this.taxComboBox2.FormattingEnabled = true;
            this.taxComboBox2.Location = new System.Drawing.Point(309, 66);
            this.taxComboBox2.Name = "taxComboBox2";
            this.taxComboBox2.Size = new System.Drawing.Size(60, 21);
            this.taxComboBox2.TabIndex = 31;
            // 
            // taxComboBox3
            // 
            this.taxComboBox3.Enabled = false;
            this.taxComboBox3.FormattingEnabled = true;
            this.taxComboBox3.Location = new System.Drawing.Point(309, 111);
            this.taxComboBox3.Name = "taxComboBox3";
            this.taxComboBox3.Size = new System.Drawing.Size(60, 21);
            this.taxComboBox3.TabIndex = 32;
            // 
            // discountTextBox1
            // 
            this.discountTextBox1.Location = new System.Drawing.Point(225, 21);
            this.discountTextBox1.Name = "discountTextBox1";
            this.discountTextBox1.Size = new System.Drawing.Size(78, 20);
            this.discountTextBox1.TabIndex = 28;
            // 
            // discountTextBox2
            // 
            this.discountTextBox2.Location = new System.Drawing.Point(225, 66);
            this.discountTextBox2.Name = "discountTextBox2";
            this.discountTextBox2.Size = new System.Drawing.Size(78, 20);
            this.discountTextBox2.TabIndex = 29;
            // 
            // discountTextBox3
            // 
            this.discountTextBox3.Location = new System.Drawing.Point(225, 111);
            this.discountTextBox3.Name = "discountTextBox3";
            this.discountTextBox3.Size = new System.Drawing.Size(78, 20);
            this.discountTextBox3.TabIndex = 30;
            // 
            // priceTextBox2
            // 
            this.priceTextBox2.Enabled = false;
            this.priceTextBox2.Location = new System.Drawing.Point(142, 66);
            this.priceTextBox2.Name = "priceTextBox2";
            this.priceTextBox2.Size = new System.Drawing.Size(77, 20);
            this.priceTextBox2.TabIndex = 20;
            // 
            // priceTextBox3
            // 
            this.priceTextBox3.Enabled = false;
            this.priceTextBox3.Location = new System.Drawing.Point(142, 111);
            this.priceTextBox3.Name = "priceTextBox3";
            this.priceTextBox3.Size = new System.Drawing.Size(77, 20);
            this.priceTextBox3.TabIndex = 21;
            // 
            // itemTextBox1
            // 
            this.itemTextBox1.Enabled = false;
            this.itemTextBox1.Location = new System.Drawing.Point(3, 21);
            this.itemTextBox1.Name = "itemTextBox1";
            this.itemTextBox1.Size = new System.Drawing.Size(106, 20);
            this.itemTextBox1.TabIndex = 17;
            // 
            // itemTextBox2
            // 
            this.itemTextBox2.Enabled = false;
            this.itemTextBox2.Location = new System.Drawing.Point(3, 66);
            this.itemTextBox2.Name = "itemTextBox2";
            this.itemTextBox2.Size = new System.Drawing.Size(106, 20);
            this.itemTextBox2.TabIndex = 18;
            // 
            // itemTextBox3
            // 
            this.itemTextBox3.Enabled = false;
            this.itemTextBox3.Location = new System.Drawing.Point(3, 111);
            this.itemTextBox3.Name = "itemTextBox3";
            this.itemTextBox3.Size = new System.Drawing.Size(106, 20);
            this.itemTextBox3.TabIndex = 19;
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(225, 0);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(76, 13);
            this.discountLabel.TabIndex = 23;
            this.discountLabel.Text = "Descuento (%)";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(142, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(74, 13);
            this.priceLabel.TabIndex = 22;
            this.priceLabel.Text = "Precio unitario";
            // 
            // addItemButton1
            // 
            this.addItemButton1.Location = new System.Drawing.Point(115, 21);
            this.addItemButton1.Name = "addItemButton1";
            this.addItemButton1.Size = new System.Drawing.Size(21, 23);
            this.addItemButton1.TabIndex = 41;
            this.addItemButton1.Text = "+";
            this.addItemButton1.UseVisualStyleBackColor = true;
            // 
            // addItemButton2
            // 
            this.addItemButton2.Location = new System.Drawing.Point(115, 66);
            this.addItemButton2.Name = "addItemButton2";
            this.addItemButton2.Size = new System.Drawing.Size(21, 23);
            this.addItemButton2.TabIndex = 42;
            this.addItemButton2.Text = "+";
            this.addItemButton2.UseVisualStyleBackColor = true;
            // 
            // addItemButton3
            // 
            this.addItemButton3.Location = new System.Drawing.Point(115, 111);
            this.addItemButton3.Name = "addItemButton3";
            this.addItemButton3.Size = new System.Drawing.Size(21, 23);
            this.addItemButton3.TabIndex = 43;
            this.addItemButton3.Text = "+";
            this.addItemButton3.UseVisualStyleBackColor = true;
            // 
            // priceTextBox1
            // 
            this.priceTextBox1.Enabled = false;
            this.priceTextBox1.Location = new System.Drawing.Point(142, 21);
            this.priceTextBox1.Name = "priceTextBox1";
            this.priceTextBox1.Size = new System.Drawing.Size(77, 20);
            this.priceTextBox1.TabIndex = 17;
            // 
            // subtotalLabel
            // 
            this.subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLabel.Location = new System.Drawing.Point(430, 37);
            this.subtotalLabel.Name = "subtotalLabel";
            this.subtotalLabel.Size = new System.Drawing.Size(88, 13);
            this.subtotalLabel.TabIndex = 17;
            this.subtotalLabel.Text = "Subtotal";
            this.subtotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalDiscountLabel
            // 
            this.totalDiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDiscountLabel.Location = new System.Drawing.Point(431, 63);
            this.totalDiscountLabel.Name = "totalDiscountLabel";
            this.totalDiscountLabel.Size = new System.Drawing.Size(88, 13);
            this.totalDiscountLabel.TabIndex = 18;
            this.totalDiscountLabel.Text = "Descuento";
            this.totalDiscountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // subtotal2Label
            // 
            this.subtotal2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotal2Label.Location = new System.Drawing.Point(431, 91);
            this.subtotal2Label.Name = "subtotal2Label";
            this.subtotal2Label.Size = new System.Drawing.Size(88, 13);
            this.subtotal2Label.TabIndex = 19;
            this.subtotal2Label.Text = "Subtotal";
            this.subtotal2Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // subtotalCurrencyLabel
            // 
            this.subtotalCurrencyLabel.AutoSize = true;
            this.subtotalCurrencyLabel.Location = new System.Drawing.Point(536, 37);
            this.subtotalCurrencyLabel.Name = "subtotalCurrencyLabel";
            this.subtotalCurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.subtotalCurrencyLabel.TabIndex = 20;
            this.subtotalCurrencyLabel.Text = "BsF. 0,00";
            // 
            // totalDiscountCurrencyLabel
            // 
            this.totalDiscountCurrencyLabel.AutoSize = true;
            this.totalDiscountCurrencyLabel.Location = new System.Drawing.Point(536, 63);
            this.totalDiscountCurrencyLabel.Name = "totalDiscountCurrencyLabel";
            this.totalDiscountCurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.totalDiscountCurrencyLabel.TabIndex = 21;
            this.totalDiscountCurrencyLabel.Text = "BsF. 0,00";
            // 
            // subtotal2CurrencyLabel
            // 
            this.subtotal2CurrencyLabel.AutoSize = true;
            this.subtotal2CurrencyLabel.Location = new System.Drawing.Point(536, 91);
            this.subtotal2CurrencyLabel.Name = "subtotal2CurrencyLabel";
            this.subtotal2CurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.subtotal2CurrencyLabel.TabIndex = 22;
            this.subtotal2CurrencyLabel.Text = "BsF. 0,00";
            // 
            // addItemRowButton
            // 
            this.addItemRowButton.Location = new System.Drawing.Point(3, 3);
            this.addItemRowButton.Name = "addItemRowButton";
            this.addItemRowButton.Size = new System.Drawing.Size(75, 23);
            this.addItemRowButton.TabIndex = 23;
            this.addItemRowButton.Text = "Agregar";
            this.addItemRowButton.UseVisualStyleBackColor = true;
            this.addItemRowButton.Click += new System.EventHandler(this.addItemRowButton_Click);
            // 
            // totalTaxCurrencyLabel
            // 
            this.totalTaxCurrencyLabel.AutoSize = true;
            this.totalTaxCurrencyLabel.Location = new System.Drawing.Point(536, 119);
            this.totalTaxCurrencyLabel.Name = "totalTaxCurrencyLabel";
            this.totalTaxCurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.totalTaxCurrencyLabel.TabIndex = 25;
            this.totalTaxCurrencyLabel.Text = "BsF. 0,00";
            // 
            // totalTaxLabel
            // 
            this.totalTaxLabel.Location = new System.Drawing.Point(431, 119);
            this.totalTaxLabel.Name = "totalTaxLabel";
            this.totalTaxLabel.Size = new System.Drawing.Size(88, 13);
            this.totalTaxLabel.TabIndex = 24;
            this.totalTaxLabel.Text = "Impuestos";
            this.totalTaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalCurrencyLabel
            // 
            this.totalCurrencyLabel.AutoSize = true;
            this.totalCurrencyLabel.Location = new System.Drawing.Point(536, 147);
            this.totalCurrencyLabel.Name = "totalCurrencyLabel";
            this.totalCurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.totalCurrencyLabel.TabIndex = 27;
            this.totalCurrencyLabel.Text = "BsF. 0,00";
            // 
            // total2Label
            // 
            this.total2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total2Label.Location = new System.Drawing.Point(431, 147);
            this.total2Label.Name = "total2Label";
            this.total2Label.Size = new System.Drawing.Size(88, 13);
            this.total2Label.TabIndex = 26;
            this.total2Label.Text = "Total";
            this.total2Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.cancelBillButton);
            this.lowerPanel.Controls.Add(this.previewBillButton);
            this.lowerPanel.Controls.Add(this.saveBillButton);
            this.lowerPanel.Controls.Add(this.addItemRowButton);
            this.lowerPanel.Controls.Add(this.totalCurrencyLabel);
            this.lowerPanel.Controls.Add(this.subtotalLabel);
            this.lowerPanel.Controls.Add(this.total2Label);
            this.lowerPanel.Controls.Add(this.totalDiscountLabel);
            this.lowerPanel.Controls.Add(this.totalTaxCurrencyLabel);
            this.lowerPanel.Controls.Add(this.subtotal2Label);
            this.lowerPanel.Controls.Add(this.totalTaxLabel);
            this.lowerPanel.Controls.Add(this.subtotalCurrencyLabel);
            this.lowerPanel.Controls.Add(this.subtotal2CurrencyLabel);
            this.lowerPanel.Controls.Add(this.totalDiscountCurrencyLabel);
            this.lowerPanel.Location = new System.Drawing.Point(10, 330);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(671, 241);
            this.lowerPanel.TabIndex = 28;
            // 
            // cancelBillButton
            // 
            this.cancelBillButton.Location = new System.Drawing.Point(362, 183);
            this.cancelBillButton.Name = "cancelBillButton";
            this.cancelBillButton.Size = new System.Drawing.Size(91, 45);
            this.cancelBillButton.TabIndex = 30;
            this.cancelBillButton.Text = "Cancelar";
            this.cancelBillButton.UseVisualStyleBackColor = true;
            // 
            // previewBillButton
            // 
            this.previewBillButton.Location = new System.Drawing.Point(459, 183);
            this.previewBillButton.Name = "previewBillButton";
            this.previewBillButton.Size = new System.Drawing.Size(91, 45);
            this.previewBillButton.TabIndex = 29;
            this.previewBillButton.Text = "Vista Previa";
            this.previewBillButton.UseVisualStyleBackColor = true;
            // 
            // saveBillButton
            // 
            this.saveBillButton.Location = new System.Drawing.Point(559, 183);
            this.saveBillButton.Name = "saveBillButton";
            this.saveBillButton.Size = new System.Drawing.Size(91, 45);
            this.saveBillButton.TabIndex = 28;
            this.saveBillButton.Text = "Guardar";
            this.saveBillButton.UseVisualStyleBackColor = true;
            // 
            // CreateBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(705, 583);
            this.Controls.Add(this.lowerPanel);
            this.Controls.Add(this.itemsTableLayoutPanel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.expireDateTimePicker);
            this.Controls.Add(this.billDateTimePicker);
            this.Controls.Add(this.expireDateLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.billDateLabel);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.notesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.clientTextBox);
            this.Controls.Add(this.billIdLabel);
            this.Controls.Add(this.textBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateBillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Nueva Factura";
            this.Load += new System.EventHandler(this.CreateBillForm_Load);
            this.itemsTableLayoutPanel.ResumeLayout(false);
            this.itemsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown3)).EndInit();
            this.lowerPanel.ResumeLayout(false);
            this.lowerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label billIdLabel;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.Label expireDateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label billDateLabel;
        private System.Windows.Forms.DateTimePicker billDateTimePicker;
        private System.Windows.Forms.DateTimePicker expireDateTimePicker;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel itemsTableLayoutPanel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox3;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox2;
        private System.Windows.Forms.TextBox discountTextBox1;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label taxLabel;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox itemTextBox3;
        private System.Windows.Forms.TextBox itemTextBox2;
        private System.Windows.Forms.TextBox priceTextBox1;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.TextBox priceTextBox3;
        private System.Windows.Forms.TextBox priceTextBox2;
        private System.Windows.Forms.TextBox discountTextBox2;
        private System.Windows.Forms.TextBox discountTextBox3;
        private System.Windows.Forms.ComboBox taxComboBox2;
        private System.Windows.Forms.ComboBox taxComboBox3;
        private System.Windows.Forms.Label totalLabel1;
        private System.Windows.Forms.Label totalLabel2;
        private System.Windows.Forms.Label totalLabel3;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown1;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown2;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown3;
        private System.Windows.Forms.ComboBox taxComboBox1;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox1;
        private System.Windows.Forms.Label subtotalLabel;
        private System.Windows.Forms.Label totalDiscountLabel;
        private System.Windows.Forms.Label subtotal2Label;
        private System.Windows.Forms.Label subtotalCurrencyLabel;
        private System.Windows.Forms.Label totalDiscountCurrencyLabel;
        private System.Windows.Forms.Label subtotal2CurrencyLabel;
        private System.Windows.Forms.Button addItemRowButton;
        private System.Windows.Forms.Label totalTaxCurrencyLabel;
        private System.Windows.Forms.Label totalTaxLabel;
        private System.Windows.Forms.Label totalCurrencyLabel;
        private System.Windows.Forms.Label total2Label;
        private System.Windows.Forms.Panel lowerPanel;
        private System.Windows.Forms.Button cancelBillButton;
        private System.Windows.Forms.Button previewBillButton;
        private System.Windows.Forms.Button saveBillButton;
        private System.Windows.Forms.Button addItemButton1;
        private System.Windows.Forms.Button addItemButton2;
        private System.Windows.Forms.Button addItemButton3;
        private System.Windows.Forms.Button removeItemButton3;
        private System.Windows.Forms.Button removeItemButton2;
        private System.Windows.Forms.Button removeItemButton1;
        private System.Windows.Forms.TextBox itemTextBox1;
    }
}