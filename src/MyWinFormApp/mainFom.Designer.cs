namespace MyWinFormApp
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.manageClientsButton = new System.Windows.Forms.Button();
            this.createBillButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageClientsButton
            // 
            this.manageClientsButton.Location = new System.Drawing.Point(664, 53);
            this.manageClientsButton.Name = "manageClientsButton";
            this.manageClientsButton.Size = new System.Drawing.Size(118, 40);
            this.manageClientsButton.TabIndex = 0;
            this.manageClientsButton.Text = "Administrar clientes";
            this.manageClientsButton.UseVisualStyleBackColor = true;
            this.manageClientsButton.Click += new System.EventHandler(this.manageClientsButton_Click);
            // 
            // createBillButton
            // 
            this.createBillButton.Location = new System.Drawing.Point(664, 99);
            this.createBillButton.Name = "createBillButton";
            this.createBillButton.Size = new System.Drawing.Size(118, 40);
            this.createBillButton.TabIndex = 1;
            this.createBillButton.Text = "Facturar";
            this.createBillButton.UseVisualStyleBackColor = true;
            this.createBillButton.Click += new System.EventHandler(this.createBillButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.Location = new System.Drawing.Point(664, 145);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(118, 40);
            this.inventoryButton.TabIndex = 2;
            this.inventoryButton.Text = "Inventario";
            this.inventoryButton.UseVisualStyleBackColor = true;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 437);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.createBillButton);
            this.Controls.Add(this.manageClientsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Software de Facturación v0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button manageClientsButton;
        private System.Windows.Forms.Button createBillButton;
        private System.Windows.Forms.Button inventoryButton;
    }
}

