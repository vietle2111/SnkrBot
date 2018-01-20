namespace SnkrBot
{
    partial class Form4
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
            this.label2 = new System.Windows.Forms.Label();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchBT = new System.Windows.Forms.Button();
            this.RemoveBT = new System.Windows.Forms.Button();
            this.EditBT = new System.Windows.Forms.Button();
            this.AddBT = new System.Windows.Forms.Button();
            this.StaffLV = new System.Windows.Forms.ListView();
            this.EnterTB = new System.Windows.Forms.Label();
            this.RefreshBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter Staff ID:";
            // 
            // SearchTB
            // 
            this.SearchTB.Location = new System.Drawing.Point(179, 299);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(235, 20);
            this.SearchTB.TabIndex = 17;
            // 
            // SearchBT
            // 
            this.SearchBT.Location = new System.Drawing.Point(439, 296);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(75, 23);
            this.SearchBT.TabIndex = 16;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(179, 227);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(75, 23);
            this.RemoveBT.TabIndex = 15;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.RemoveBT_Click);
            // 
            // EditBT
            // 
            this.EditBT.Location = new System.Drawing.Point(98, 227);
            this.EditBT.Name = "EditBT";
            this.EditBT.Size = new System.Drawing.Size(75, 23);
            this.EditBT.TabIndex = 14;
            this.EditBT.Text = "Edit";
            this.EditBT.UseVisualStyleBackColor = true;
            this.EditBT.Click += new System.EventHandler(this.EditBT_Click);
            // 
            // AddBT
            // 
            this.AddBT.Location = new System.Drawing.Point(17, 227);
            this.AddBT.Name = "AddBT";
            this.AddBT.Size = new System.Drawing.Size(75, 23);
            this.AddBT.TabIndex = 13;
            this.AddBT.Text = "Add new";
            this.AddBT.UseVisualStyleBackColor = true;
            this.AddBT.Click += new System.EventHandler(this.AddBT_Click);
            // 
            // StaffLV
            // 
            this.StaffLV.Location = new System.Drawing.Point(17, 21);
            this.StaffLV.Name = "StaffLV";
            this.StaffLV.Size = new System.Drawing.Size(555, 200);
            this.StaffLV.TabIndex = 12;
            this.StaffLV.UseCompatibleStateImageBehavior = false;
            this.StaffLV.SelectedIndexChanged += new System.EventHandler(this.StaffLV_SelectedIndexChanged);
            // 
            // EnterTB
            // 
            this.EnterTB.AutoSize = true;
            this.EnterTB.Location = new System.Drawing.Point(17, 5);
            this.EnterTB.Name = "EnterTB";
            this.EnterTB.Size = new System.Drawing.Size(65, 13);
            this.EnterTB.TabIndex = 11;
            this.EnterTB.Text = "List of Staffs";
            // 
            // RefreshBT
            // 
            this.RefreshBT.Location = new System.Drawing.Point(512, 227);
            this.RefreshBT.Name = "RefreshBT";
            this.RefreshBT.Size = new System.Drawing.Size(60, 23);
            this.RefreshBT.TabIndex = 19;
            this.RefreshBT.Text = "Refresh";
            this.RefreshBT.UseVisualStyleBackColor = true;
            this.RefreshBT.Click += new System.EventHandler(this.RefreshBT_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.RefreshBT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchTB);
            this.Controls.Add(this.SearchBT);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.EditBT);
            this.Controls.Add(this.AddBT);
            this.Controls.Add(this.StaffLV);
            this.Controls.Add(this.EnterTB);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.Button RemoveBT;
        private System.Windows.Forms.Button EditBT;
        private System.Windows.Forms.Button AddBT;
        private System.Windows.Forms.ListView StaffLV;
        private System.Windows.Forms.Label EnterTB;
        private System.Windows.Forms.Button RefreshBT;
    }
}