namespace SnkrBot
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.SaveBT = new System.Windows.Forms.Button();
            this.SetPrBT = new System.Windows.Forms.Button();
            this.RemoveBT = new System.Windows.Forms.Button();
            this.PaypalLV = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paypal Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paypal Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paypal Password:";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(146, 22);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(195, 20);
            this.NameTB.TabIndex = 3;
            // 
            // AddressTB
            // 
            this.AddressTB.Location = new System.Drawing.Point(146, 53);
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.Size = new System.Drawing.Size(195, 20);
            this.AddressTB.TabIndex = 4;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(146, 83);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(195, 20);
            this.PasswordTB.TabIndex = 5;
            this.PasswordTB.UseSystemPasswordChar = true;
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(266, 109);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(75, 23);
            this.SaveBT.TabIndex = 6;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // SetPrBT
            // 
            this.SetPrBT.Location = new System.Drawing.Point(297, 181);
            this.SetPrBT.Name = "SetPrBT";
            this.SetPrBT.Size = new System.Drawing.Size(75, 52);
            this.SetPrBT.TabIndex = 7;
            this.SetPrBT.Text = "Set As Primary";
            this.SetPrBT.UseVisualStyleBackColor = true;
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(297, 250);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(75, 23);
            this.RemoveBT.TabIndex = 8;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.RemoveBT_Click);
            // 
            // PaypalLV
            // 
            this.PaypalLV.Location = new System.Drawing.Point(11, 169);
            this.PaypalLV.Name = "PaypalLV";
            this.PaypalLV.Size = new System.Drawing.Size(280, 130);
            this.PaypalLV.TabIndex = 9;
            this.PaypalLV.UseCompatibleStateImageBehavior = false;
            this.PaypalLV.SelectedIndexChanged += new System.EventHandler(this.PaypalLV_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "List of Paypal Accounts";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PaypalLV);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.SetPrBT);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.AddressTB);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paypal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button SaveBT;
        private System.Windows.Forms.Button SetPrBT;
        private System.Windows.Forms.Button RemoveBT;
        private System.Windows.Forms.ListView PaypalLV;
        private System.Windows.Forms.Label label4;
    }
}