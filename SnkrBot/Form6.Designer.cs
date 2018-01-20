namespace SnkrBot
{
    partial class Form6
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CCLV = new System.Windows.Forms.ListView();
            this.RemoveBT = new System.Windows.Forms.Button();
            this.SetPrBT = new System.Windows.Forms.Button();
            this.FirstNametb = new System.Windows.Forms.TextBox();
            this.LastNametb = new System.Windows.Forms.TextBox();
            this.CardNumbertb = new System.Windows.Forms.TextBox();
            this.Securitytb = new System.Windows.Forms.TextBox();
            this.VisaRb = new System.Windows.Forms.RadioButton();
            this.MasterRb = new System.Windows.Forms.RadioButton();
            this.SaveBT = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.resetBT = new System.Windows.Forms.Button();
            this.closeBt = new System.Windows.Forms.Button();
            this.ExMYtb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Card Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Expired Month/Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Security Code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "List of Credit Cards";
            // 
            // CCLV
            // 
            this.CCLV.Location = new System.Drawing.Point(20, 216);
            this.CCLV.Name = "CCLV";
            this.CCLV.Size = new System.Drawing.Size(402, 106);
            this.CCLV.TabIndex = 7;
            this.CCLV.UseCompatibleStateImageBehavior = false;
            this.CCLV.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(165, 328);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(75, 23);
            this.RemoveBT.TabIndex = 8;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.RemoveBT_Click);
            // 
            // SetPrBT
            // 
            this.SetPrBT.Location = new System.Drawing.Point(19, 327);
            this.SetPrBT.Name = "SetPrBT";
            this.SetPrBT.Size = new System.Drawing.Size(133, 23);
            this.SetPrBT.TabIndex = 9;
            this.SetPrBT.Text = "Set As Primary Card";
            this.SetPrBT.UseVisualStyleBackColor = true;
            // 
            // FirstNametb
            // 
            this.FirstNametb.Location = new System.Drawing.Point(122, 17);
            this.FirstNametb.Name = "FirstNametb";
            this.FirstNametb.Size = new System.Drawing.Size(100, 20);
            this.FirstNametb.TabIndex = 10;
            // 
            // LastNametb
            // 
            this.LastNametb.Location = new System.Drawing.Point(122, 49);
            this.LastNametb.Name = "LastNametb";
            this.LastNametb.Size = new System.Drawing.Size(100, 20);
            this.LastNametb.TabIndex = 11;
            // 
            // CardNumbertb
            // 
            this.CardNumbertb.Location = new System.Drawing.Point(122, 76);
            this.CardNumbertb.Name = "CardNumbertb";
            this.CardNumbertb.Size = new System.Drawing.Size(200, 20);
            this.CardNumbertb.TabIndex = 12;
            // 
            // Securitytb
            // 
            this.Securitytb.Location = new System.Drawing.Point(122, 162);
            this.Securitytb.Name = "Securitytb";
            this.Securitytb.Size = new System.Drawing.Size(100, 20);
            this.Securitytb.TabIndex = 13;
            this.Securitytb.UseSystemPasswordChar = true;
            // 
            // VisaRb
            // 
            this.VisaRb.AutoSize = true;
            this.VisaRb.Checked = true;
            this.VisaRb.Location = new System.Drawing.Point(122, 107);
            this.VisaRb.Name = "VisaRb";
            this.VisaRb.Size = new System.Drawing.Size(45, 17);
            this.VisaRb.TabIndex = 14;
            this.VisaRb.TabStop = true;
            this.VisaRb.Text = "Visa";
            this.VisaRb.UseVisualStyleBackColor = true;
            // 
            // MasterRb
            // 
            this.MasterRb.AutoSize = true;
            this.MasterRb.Location = new System.Drawing.Point(188, 107);
            this.MasterRb.Name = "MasterRb";
            this.MasterRb.Size = new System.Drawing.Size(57, 17);
            this.MasterRb.TabIndex = 15;
            this.MasterRb.Text = "Master";
            this.MasterRb.UseVisualStyleBackColor = true;
            // 
            // SaveBT
            // 
            this.SaveBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBT.Location = new System.Drawing.Point(347, 164);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(75, 23);
            this.SaveBT.TabIndex = 17;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // resetBT
            // 
            this.resetBT.Location = new System.Drawing.Point(347, 130);
            this.resetBT.Name = "resetBT";
            this.resetBT.Size = new System.Drawing.Size(75, 23);
            this.resetBT.TabIndex = 18;
            this.resetBT.Text = "Reset";
            this.resetBT.UseVisualStyleBackColor = true;
            this.resetBT.Click += new System.EventHandler(this.resetBT_Click);
            // 
            // closeBt
            // 
            this.closeBt.Location = new System.Drawing.Point(347, 328);
            this.closeBt.Name = "closeBt";
            this.closeBt.Size = new System.Drawing.Size(75, 23);
            this.closeBt.TabIndex = 19;
            this.closeBt.Text = "Close";
            this.closeBt.UseVisualStyleBackColor = true;
            this.closeBt.Click += new System.EventHandler(this.closeBt_Click);
            // 
            // ExMYtb
            // 
            this.ExMYtb.Location = new System.Drawing.Point(122, 132);
            this.ExMYtb.Name = "ExMYtb";
            this.ExMYtb.Size = new System.Drawing.Size(100, 20);
            this.ExMYtb.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(229, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Format: mm/yy";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ExMYtb);
            this.Controls.Add(this.closeBt);
            this.Controls.Add(this.resetBT);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.MasterRb);
            this.Controls.Add(this.VisaRb);
            this.Controls.Add(this.Securitytb);
            this.Controls.Add(this.CardNumbertb);
            this.Controls.Add(this.LastNametb);
            this.Controls.Add(this.FirstNametb);
            this.Controls.Add(this.SetPrBT);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.CCLV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Card";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView CCLV;
        private System.Windows.Forms.Button RemoveBT;
        private System.Windows.Forms.Button SetPrBT;
        private System.Windows.Forms.TextBox FirstNametb;
        private System.Windows.Forms.TextBox LastNametb;
        private System.Windows.Forms.TextBox CardNumbertb;
        private System.Windows.Forms.TextBox Securitytb;
        private System.Windows.Forms.RadioButton VisaRb;
        private System.Windows.Forms.RadioButton MasterRb;
        private System.Windows.Forms.Button SaveBT;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button resetBT;
        private System.Windows.Forms.Button closeBt;
        private System.Windows.Forms.TextBox ExMYtb;
        private System.Windows.Forms.Label label8;
    }
}