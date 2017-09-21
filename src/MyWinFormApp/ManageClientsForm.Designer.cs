namespace MyWinFormApp
{
    partial class ManageClientsForm
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
            this.createClientButton = new System.Windows.Forms.Button();
            this.editClientButton = new System.Windows.Forms.Button();
            this.removeClientButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.clientDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchClientButton = new System.Windows.Forms.Button();
            this.searchClientTextBox = new System.Windows.Forms.TextBox();
            this.searchClientLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // createClientButton
            // 
            this.createClientButton.Location = new System.Drawing.Point(12, 303);
            this.createClientButton.Name = "createClientButton";
            this.createClientButton.Size = new System.Drawing.Size(94, 23);
            this.createClientButton.TabIndex = 1;
            this.createClientButton.Text = "Registrar nuevo";
            this.createClientButton.UseVisualStyleBackColor = true;
            this.createClientButton.Click += new System.EventHandler(this.createClientButton_Click);
            // 
            // editClientButton
            // 
            this.editClientButton.Location = new System.Drawing.Point(112, 303);
            this.editClientButton.Name = "editClientButton";
            this.editClientButton.Size = new System.Drawing.Size(94, 23);
            this.editClientButton.TabIndex = 2;
            this.editClientButton.Text = "Modificar Cliente";
            this.editClientButton.UseVisualStyleBackColor = true;
            this.editClientButton.Click += new System.EventHandler(this.editClientButton_Click);
            // 
            // removeClientButton
            // 
            this.removeClientButton.Location = new System.Drawing.Point(212, 303);
            this.removeClientButton.Name = "removeClientButton";
            this.removeClientButton.Size = new System.Drawing.Size(94, 23);
            this.removeClientButton.TabIndex = 3;
            this.removeClientButton.Text = "Eliminar Cliente";
            this.removeClientButton.UseVisualStyleBackColor = true;
            this.removeClientButton.Click += new System.EventHandler(this.removeClientButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(361, 303);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(94, 42);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Listo";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // clientDataGridView
            // 
            this.clientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CName,
            this.Mail});
            this.clientDataGridView.Location = new System.Drawing.Point(12, 39);
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.Size = new System.Drawing.Size(445, 258);
            this.clientDataGridView.TabIndex = 5;
            this.clientDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientDataGridView_CellClick);
            this.clientDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientDataGridView_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 80;
            // 
            // CName
            // 
            this.CName.Frozen = true;
            this.CName.HeaderText = "Nombre";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            this.CName.Width = 160;
            // 
            // Mail
            // 
            this.Mail.Frozen = true;
            this.Mail.HeaderText = "Correo";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 160;
            // 
            // searchClientButton
            // 
            this.searchClientButton.Location = new System.Drawing.Point(380, 13);
            this.searchClientButton.Name = "searchClientButton";
            this.searchClientButton.Size = new System.Drawing.Size(75, 23);
            this.searchClientButton.TabIndex = 7;
            this.searchClientButton.Text = "Buscar";
            this.searchClientButton.UseVisualStyleBackColor = true;
            // 
            // searchClientTextBox
            // 
            this.searchClientTextBox.Location = new System.Drawing.Point(94, 13);
            this.searchClientTextBox.Name = "searchClientTextBox";
            this.searchClientTextBox.Size = new System.Drawing.Size(280, 20);
            this.searchClientTextBox.TabIndex = 6;
            // 
            // searchClientLabel
            // 
            this.searchClientLabel.AutoSize = true;
            this.searchClientLabel.Location = new System.Drawing.Point(12, 18);
            this.searchClientLabel.Name = "searchClientLabel";
            this.searchClientLabel.Size = new System.Drawing.Size(78, 13);
            this.searchClientLabel.TabIndex = 8;
            this.searchClientLabel.Text = "Buscar Cliente:";
            // 
            // ManageClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 369);
            this.Controls.Add(this.searchClientLabel);
            this.Controls.Add(this.searchClientButton);
            this.Controls.Add(this.searchClientTextBox);
            this.Controls.Add(this.clientDataGridView);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.removeClientButton);
            this.Controls.Add(this.editClientButton);
            this.Controls.Add(this.createClientButton);
            this.Name = "ManageClientsForm";
            this.Text = "Administrar Clientes";
            this.Load += new System.EventHandler(this.ManageClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createClientButton;
        private System.Windows.Forms.Button editClientButton;
        private System.Windows.Forms.Button removeClientButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.DataGridView clientDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.Button searchClientButton;
        private System.Windows.Forms.TextBox searchClientTextBox;
        private System.Windows.Forms.Label searchClientLabel;
    }
}