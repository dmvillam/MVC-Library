namespace MyWinFormApp
{
    partial class EditClientForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.editClientButton = new System.Windows.Forms.Button();
            this.celLabel = new System.Windows.Forms.Label();
            this.celTextBox = new System.Windows.Forms.TextBox();
            this.telfLabel = new System.Windows.Forms.Label();
            this.telfTextBox = new System.Windows.Forms.TextBox();
            this.mailLabel = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(270, 131);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editClientButton
            // 
            this.editClientButton.Location = new System.Drawing.Point(177, 131);
            this.editClientButton.Name = "editClientButton";
            this.editClientButton.Size = new System.Drawing.Size(87, 36);
            this.editClientButton.TabIndex = 18;
            this.editClientButton.Text = "Cambiar";
            this.editClientButton.UseVisualStyleBackColor = true;
            this.editClientButton.Click += new System.EventHandler(this.editClientButton_Click);
            // 
            // celLabel
            // 
            this.celLabel.AutoSize = true;
            this.celLabel.Location = new System.Drawing.Point(202, 80);
            this.celLabel.Name = "celLabel";
            this.celLabel.Size = new System.Drawing.Size(39, 13);
            this.celLabel.TabIndex = 17;
            this.celLabel.Text = "Celular";
            // 
            // celTextBox
            // 
            this.celTextBox.Location = new System.Drawing.Point(257, 77);
            this.celTextBox.Name = "celTextBox";
            this.celTextBox.Size = new System.Drawing.Size(100, 20);
            this.celTextBox.TabIndex = 16;
            // 
            // telfLabel
            // 
            this.telfLabel.AutoSize = true;
            this.telfLabel.Location = new System.Drawing.Point(13, 80);
            this.telfLabel.Name = "telfLabel";
            this.telfLabel.Size = new System.Drawing.Size(49, 13);
            this.telfLabel.TabIndex = 15;
            this.telfLabel.Text = "Teléfono";
            // 
            // telfTextBox
            // 
            this.telfTextBox.Location = new System.Drawing.Point(68, 77);
            this.telfTextBox.Name = "telfTextBox";
            this.telfTextBox.Size = new System.Drawing.Size(100, 20);
            this.telfTextBox.TabIndex = 14;
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(13, 54);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(38, 13);
            this.mailLabel.TabIndex = 13;
            this.mailLabel.Text = "Correo";
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(110, 51);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(247, 20);
            this.mailTextBox.TabIndex = 12;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(91, 13);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Nombre y apellido";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(110, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(247, 20);
            this.nameTextBox.TabIndex = 10;
            // 
            // EditClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 181);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editClientButton);
            this.Controls.Add(this.celLabel);
            this.Controls.Add(this.celTextBox);
            this.Controls.Add(this.telfLabel);
            this.Controls.Add(this.telfTextBox);
            this.Controls.Add(this.mailLabel);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Name = "EditClientForm";
            this.Text = "EditClientForm";
            this.Load += new System.EventHandler(this.EditClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button editClientButton;
        private System.Windows.Forms.Label celLabel;
        private System.Windows.Forms.TextBox celTextBox;
        private System.Windows.Forms.Label telfLabel;
        private System.Windows.Forms.TextBox telfTextBox;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}