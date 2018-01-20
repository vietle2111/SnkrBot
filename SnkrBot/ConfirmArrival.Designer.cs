namespace SnkrBot
{
    partial class ConfirmArrival
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmArrival));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ConfirmBT = new System.Windows.Forms.Button();
            this.CancelBT = new System.Windows.Forms.Button();
            this.YesRB = new System.Windows.Forms.RadioButton();
            this.NoRB = new System.Windows.Forms.RadioButton();
            this.sneakerIDtb = new System.Windows.Forms.TextBox();
            this.SneakernameTB = new System.Windows.Forms.TextBox();
            this.ResellPricetb = new System.Windows.Forms.TextBox();
            this.ArrivalDTP = new System.Windows.Forms.DateTimePicker();
            this.StaffIDcb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ConfirmBT
            // 
            resources.ApplyResources(this.ConfirmBT, "ConfirmBT");
            this.ConfirmBT.Name = "ConfirmBT";
            this.ConfirmBT.UseVisualStyleBackColor = true;
            this.ConfirmBT.Click += new System.EventHandler(this.ConfirmBT_Click);
            // 
            // CancelBT
            // 
            resources.ApplyResources(this.CancelBT, "CancelBT");
            this.CancelBT.Name = "CancelBT";
            this.CancelBT.UseVisualStyleBackColor = true;
            this.CancelBT.Click += new System.EventHandler(this.CancelBT_Click);
            // 
            // YesRB
            // 
            resources.ApplyResources(this.YesRB, "YesRB");
            this.YesRB.Name = "YesRB";
            this.YesRB.UseVisualStyleBackColor = true;
            // 
            // NoRB
            // 
            resources.ApplyResources(this.NoRB, "NoRB");
            this.NoRB.Checked = true;
            this.NoRB.Name = "NoRB";
            this.NoRB.TabStop = true;
            this.NoRB.UseVisualStyleBackColor = true;
            // 
            // sneakerIDtb
            // 
            resources.ApplyResources(this.sneakerIDtb, "sneakerIDtb");
            this.sneakerIDtb.Name = "sneakerIDtb";
            // 
            // SneakernameTB
            // 
            resources.ApplyResources(this.SneakernameTB, "SneakernameTB");
            this.SneakernameTB.Name = "SneakernameTB";
            // 
            // ResellPricetb
            // 
            resources.ApplyResources(this.ResellPricetb, "ResellPricetb");
            this.ResellPricetb.Name = "ResellPricetb";
            // 
            // ArrivalDTP
            // 
            this.ArrivalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.ArrivalDTP, "ArrivalDTP");
            this.ArrivalDTP.Name = "ArrivalDTP";
            // 
            // StaffIDcb
            // 
            this.StaffIDcb.FormattingEnabled = true;
            resources.ApplyResources(this.StaffIDcb, "StaffIDcb");
            this.StaffIDcb.Name = "StaffIDcb";
            this.StaffIDcb.SelectedIndexChanged += new System.EventHandler(this.StaffIDcb_SelectedIndexChanged);
            // 
            // ConfirmArrival
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StaffIDcb);
            this.Controls.Add(this.ArrivalDTP);
            this.Controls.Add(this.ResellPricetb);
            this.Controls.Add(this.SneakernameTB);
            this.Controls.Add(this.sneakerIDtb);
            this.Controls.Add(this.NoRB);
            this.Controls.Add(this.YesRB);
            this.Controls.Add(this.CancelBT);
            this.Controls.Add(this.ConfirmBT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmArrival";
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
        private System.Windows.Forms.Button ConfirmBT;
        private System.Windows.Forms.Button CancelBT;
        private System.Windows.Forms.RadioButton YesRB;
        private System.Windows.Forms.RadioButton NoRB;
        private System.Windows.Forms.TextBox sneakerIDtb;
        private System.Windows.Forms.TextBox SneakernameTB;
        private System.Windows.Forms.TextBox ResellPricetb;
        private System.Windows.Forms.DateTimePicker ArrivalDTP;
        private System.Windows.Forms.ComboBox StaffIDcb;
    }
}