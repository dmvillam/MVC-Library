namespace MyWinFormApp
{
    partial class CreateClientForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.mailLabel = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.telfLabel = new System.Windows.Forms.Label();
            this.telfTextBox = new System.Windows.Forms.TextBox();
            this.celLabel = new System.Windows.Forms.Label();
            this.celTextBox = new System.Windows.Forms.TextBox();
            this.createClientButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(109, 20);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(247, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(91, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Nombre y apellido";
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(12, 49);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(38, 13);
            this.mailLabel.TabIndex = 3;
            this.mailLabel.Text = "Correo";
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(109, 46);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(247, 20);
            this.mailTextBox.TabIndex = 2;
            // 
            // telfLabel
            // 
            this.telfLabel.AutoSize = true;
            this.telfLabel.Location = new System.Drawing.Point(12, 75);
            this.telfLabel.Name = "telfLabel";
            this.telfLabel.Size = new System.Drawing.Size(49, 13);
            this.telfLabel.TabIndex = 5;
            this.telfLabel.Text = "Teléfono";
            // 
            // telfTextBox
            // 
            this.telfTextBox.Location = new System.Drawing.Point(67, 72);
            this.telfTextBox.Name = "telfTextBox";
            this.telfTextBox.Size = new System.Drawing.Size(100, 20);
            this.telfTextBox.TabIndex = 4;
            // 
            // celLabel
            // 
            this.celLabel.AutoSize = true;
            this.celLabel.Location = new System.Drawing.Point(201, 75);
            this.celLabel.Name = "celLabel";
            this.celLabel.Size = new System.Drawing.Size(39, 13);
            this.celLabel.TabIndex = 7;
            this.celLabel.Text = "Celular";
            // 
            // celTextBox
            // 
            this.celTextBox.Location = new System.Drawing.Point(256, 72);
            this.celTextBox.Name = "celTextBox";
            this.celTextBox.Size = new System.Drawing.Size(100, 20);
            this.celTextBox.TabIndex = 6;
            // 
            // createClientButton
            // 
            this.createClientButton.Location = new System.Drawing.Point(176, 126);
            this.createClientButton.Name = "createClientButton";
            this.createClientButton.Size = new System.Drawing.Size(87, 36);
            this.createClientButton.TabIndex = 8;
            this.createClientButton.Text = "Crear";
            this.createClientButton.UseVisualStyleBackColor = true;
            this.createClientButton.Click += new System.EventHandler(this.createClientButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(269, 126);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CreateClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 174);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createClientButton);
            this.Controls.Add(this.celLabel);
            this.Controls.Add(this.celTextBox);
            this.Controls.Add(this.telfLabel);
            this.Controls.Add(this.telfTextBox);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Name = "CreateClientForm";
            this.Text = "Crear nuevo cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label telfLabel;
        private System.Windows.Forms.TextBox telfTextBox;
        private System.Windows.Forms.Label celLabel;
        private System.Windows.Forms.TextBox celTextBox;
        private System.Windows.Forms.Button createClientButton;
        private System.Windows.Forms.Button cancelButton;
    }
}