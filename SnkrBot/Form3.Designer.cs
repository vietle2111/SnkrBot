namespace SnkrBot
{
    partial class Form3
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
            this.SneakerLV = new System.Windows.Forms.ListView();
            this.AddBT = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.ExportCSVbt = new System.Windows.Forms.Button();
            this.RemoveBT = new System.Windows.Forms.Button();
            this.InfoTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "List of sneakers";
            // 
            // SneakerLV
            // 
            this.SneakerLV.Location = new System.Drawing.Point(15, 26);
            this.SneakerLV.Name = "SneakerLV";
            this.SneakerLV.Size = new System.Drawing.Size(555, 200);
            this.SneakerLV.TabIndex = 1;
            this.SneakerLV.UseCompatibleStateImageBehavior = false;
            this.SneakerLV.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // AddBT
            // 
            this.AddBT.Location = new System.Drawing.Point(15, 232);
            this.AddBT.Name = "AddBT";
            this.AddBT.Size = new System.Drawing.Size(75, 23);
            this.AddBT.TabIndex = 2;
            this.AddBT.Text = "Detail";
            this.AddBT.UseVisualStyleBackColor = true;
            this.AddBT.Click += new System.EventHandler(this.AddBT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExportCSVbt
            // 
            this.ExportCSVbt.Location = new System.Drawing.Point(96, 232);
            this.ExportCSVbt.Name = "ExportCSVbt";
            this.ExportCSVbt.Size = new System.Drawing.Size(112, 23);
            this.ExportCSVbt.TabIndex = 4;
            this.ExportCSVbt.Text = "Export a CSV file";
            this.ExportCSVbt.UseVisualStyleBackColor = true;
            this.ExportCSVbt.Click += new System.EventHandler(this.button2_Click);
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(214, 232);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(75, 23);
            this.RemoveBT.TabIndex = 5;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.button3_Click);
            // 
            // InfoTB
            // 
            this.InfoTB.Location = new System.Drawing.Point(146, 300);
            this.InfoTB.Name = "InfoTB";
            this.InfoTB.Size = new System.Drawing.Size(235, 20);
            this.InfoTB.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter Sneaker ID:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InfoTB);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.ExportCSVbt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddBT);
            this.Controls.Add(this.SneakerLV);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sneaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView SneakerLV;
        private System.Windows.Forms.Button AddBT;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ExportCSVbt;
        private System.Windows.Forms.Button RemoveBT;
        private System.Windows.Forms.TextBox InfoTB;
        private System.Windows.Forms.Label label2;
    }
}