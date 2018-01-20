namespace SnkrBot
{
    partial class Form5
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
            this.CharityLV = new System.Windows.Forms.ListView();
            this.EnterTB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Enter Charity ID:";
            // 
            // SearchTB
            // 
            this.SearchTB.Location = new System.Drawing.Point(174, 306);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(235, 20);
            this.SearchTB.TabIndex = 25;
            // 
            // SearchBT
            // 
            this.SearchBT.Location = new System.Drawing.Point(434, 303);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(75, 23);
            this.SearchBT.TabIndex = 24;
            this.SearchBT.Text = "Search";
            this.SearchBT.UseVisualStyleBackColor = true;
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(174, 234);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(75, 23);
            this.RemoveBT.TabIndex = 23;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            // 
            // EditBT
            // 
            this.EditBT.Location = new System.Drawing.Point(93, 234);
            this.EditBT.Name = "EditBT";
            this.EditBT.Size = new System.Drawing.Size(75, 23);
            this.EditBT.TabIndex = 22;
            this.EditBT.Text = "Edit";
            this.EditBT.UseVisualStyleBackColor = true;
            // 
            // AddBT
            // 
            this.AddBT.Location = new System.Drawing.Point(12, 234);
            this.AddBT.Name = "AddBT";
            this.AddBT.Size = new System.Drawing.Size(75, 23);
            this.AddBT.TabIndex = 21;
            this.AddBT.Text = "Add new";
            this.AddBT.UseVisualStyleBackColor = true;
            // 
            // CharityLV
            // 
            this.CharityLV.Location = new System.Drawing.Point(12, 28);
            this.CharityLV.Name = "CharityLV";
            this.CharityLV.Size = new System.Drawing.Size(555, 200);
            this.CharityLV.TabIndex = 20;
            this.CharityLV.UseCompatibleStateImageBehavior = false;
            this.CharityLV.SelectedIndexChanged += new System.EventHandler(this.CharityLV_SelectedIndexChanged);
            // 
            // EnterTB
            // 
            this.EnterTB.AutoSize = true;
            this.EnterTB.Location = new System.Drawing.Point(12, 12);
            this.EnterTB.Name = "EnterTB";
            this.EnterTB.Size = new System.Drawing.Size(78, 13);
            this.EnterTB.TabIndex = 19;
            this.EnterTB.Text = "List of Charities";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchTB);
            this.Controls.Add(this.SearchBT);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.EditBT);
            this.Controls.Add(this.AddBT);
            this.Controls.Add(this.CharityLV);
            this.Controls.Add(this.EnterTB);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Charity";
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
        private System.Windows.Forms.ListView CharityLV;
        private System.Windows.Forms.Label EnterTB;
    }
}