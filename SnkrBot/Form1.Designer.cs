namespace SnkrBot
{
    partial class Form1
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
                this.Name = "Sneaker Bot";


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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paypalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestAccountSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBillingInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIOBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportACSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listsRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sneakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersBillRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charityAcitityRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshBT = new System.Windows.Forms.Button();
            this.ManageTab = new System.Windows.Forms.TabControl();
            this.ReleasingTab = new System.Windows.Forms.TabPage();
            this.ScanSitesbt = new System.Windows.Forms.Button();
            this.noteLB = new System.Windows.Forms.Label();
            this.ManualPurchaseBT = new System.Windows.Forms.Button();
            this.AddReleaseBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newSnkrLV = new System.Windows.Forms.ListView();
            this.IncomingTab = new System.Windows.Forms.TabPage();
            this.NoteMS = new System.Windows.Forms.TextBox();
            this.Confirm_arrivalBT = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IncomingSnkrLV = new System.Windows.Forms.ListView();
            this.ResellingTab = new System.Windows.Forms.TabPage();
            this.SoldBT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SoldSnkrBT = new System.Windows.Forms.Button();
            this.SellingSnkrLV = new System.Windows.Forms.ListView();
            this.CharityTab = new System.Windows.Forms.TabPage();
            this.ManageCharityBT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CharityActLV = new System.Windows.Forms.ListView();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.charityRB = new System.Windows.Forms.RadioButton();
            this.supplierRB = new System.Windows.Forms.RadioButton();
            this.sneakrRB = new System.Windows.Forms.RadioButton();
            this.SearchBT = new System.Windows.Forms.Button();
            this.StopBT = new System.Windows.Forms.Button();
            this.ScanBT = new System.Windows.Forms.Button();
            this.twitterBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ManageTab.SuspendLayout();
            this.ReleasingTab.SuspendLayout();
            this.IncomingTab.SuspendLayout();
            this.ResellingTab.SuspendLayout();
            this.CharityTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.listsRecordsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paypalToolStripMenuItem,
            this.creditCardToolStripMenuItem,
            this.guestAccountSiteToolStripMenuItem,
            this.manageBillingInfoToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // paypalToolStripMenuItem
            // 
            this.paypalToolStripMenuItem.Name = "paypalToolStripMenuItem";
            this.paypalToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.paypalToolStripMenuItem.Text = "Paypal";
            this.paypalToolStripMenuItem.Click += new System.EventHandler(this.paypalToolStripMenuItem_Click);
            // 
            // creditCardToolStripMenuItem
            // 
            this.creditCardToolStripMenuItem.Name = "creditCardToolStripMenuItem";
            this.creditCardToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.creditCardToolStripMenuItem.Text = "Credit Card";
            this.creditCardToolStripMenuItem.Click += new System.EventHandler(this.creditCardToolStripMenuItem_Click);
            // 
            // guestAccountSiteToolStripMenuItem
            // 
            this.guestAccountSiteToolStripMenuItem.Name = "guestAccountSiteToolStripMenuItem";
            this.guestAccountSiteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.guestAccountSiteToolStripMenuItem.Text = "Guest Account (Site)";
            this.guestAccountSiteToolStripMenuItem.Visible = false;
            this.guestAccountSiteToolStripMenuItem.Click += new System.EventHandler(this.guestAccountSiteToolStripMenuItem_Click);
            // 
            // manageBillingInfoToolStripMenuItem
            // 
            this.manageBillingInfoToolStripMenuItem.Name = "manageBillingInfoToolStripMenuItem";
            this.manageBillingInfoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.manageBillingInfoToolStripMenuItem.Text = "Manage Billing-Shipping";
            this.manageBillingInfoToolStripMenuItem.Click += new System.EventHandler(this.manageBillingInfoToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aIOBotToolStripMenuItem,
            this.importCSVFileToolStripMenuItem,
            this.exportACSVFileToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // aIOBotToolStripMenuItem
            // 
            this.aIOBotToolStripMenuItem.Name = "aIOBotToolStripMenuItem";
            this.aIOBotToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aIOBotToolStripMenuItem.Text = "AIOBot";
            this.aIOBotToolStripMenuItem.Visible = false;
            this.aIOBotToolStripMenuItem.Click += new System.EventHandler(this.aIOBotToolStripMenuItem_Click);
            // 
            // importCSVFileToolStripMenuItem
            // 
            this.importCSVFileToolStripMenuItem.Name = "importCSVFileToolStripMenuItem";
            this.importCSVFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importCSVFileToolStripMenuItem.Text = "Import Target List";
            this.importCSVFileToolStripMenuItem.Click += new System.EventHandler(this.importCSVFileToolStripMenuItem_Click);
            // 
            // exportACSVFileToolStripMenuItem
            // 
            this.exportACSVFileToolStripMenuItem.Name = "exportACSVFileToolStripMenuItem";
            this.exportACSVFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exportACSVFileToolStripMenuItem.Text = "Export AIOBot file";
            this.exportACSVFileToolStripMenuItem.Click += new System.EventHandler(this.exportACSVFileToolStripMenuItem_Click);
            // 
            // listsRecordsToolStripMenuItem
            // 
            this.listsRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierToolStripMenuItem,
            this.sneakerToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.charityToolStripMenuItem,
            this.billRecordsToolStripMenuItem,
            this.customersBillRecordsToolStripMenuItem,
            this.charityAcitityRecordsToolStripMenuItem});
            this.listsRecordsToolStripMenuItem.Name = "listsRecordsToolStripMenuItem";
            this.listsRecordsToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.listsRecordsToolStripMenuItem.Text = "Lists/Records";
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.supplierToolStripMenuItem.Text = "Supplier";
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.supplierToolStripMenuItem_Click);
            // 
            // sneakerToolStripMenuItem
            // 
            this.sneakerToolStripMenuItem.Name = "sneakerToolStripMenuItem";
            this.sneakerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.sneakerToolStripMenuItem.Text = "Sneaker";
            this.sneakerToolStripMenuItem.Click += new System.EventHandler(this.sneakerToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.staffToolStripMenuItem.Text = "Staff";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // charityToolStripMenuItem
            // 
            this.charityToolStripMenuItem.Name = "charityToolStripMenuItem";
            this.charityToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.charityToolStripMenuItem.Text = "Charity";
            this.charityToolStripMenuItem.Click += new System.EventHandler(this.charityToolStripMenuItem_Click);
            // 
            // billRecordsToolStripMenuItem
            // 
            this.billRecordsToolStripMenuItem.Name = "billRecordsToolStripMenuItem";
            this.billRecordsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.billRecordsToolStripMenuItem.Text = "Receipt Records (Company)";
            // 
            // customersBillRecordsToolStripMenuItem
            // 
            this.customersBillRecordsToolStripMenuItem.Name = "customersBillRecordsToolStripMenuItem";
            this.customersBillRecordsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.customersBillRecordsToolStripMenuItem.Text = "Customer\'s Bill Records";
            // 
            // charityAcitityRecordsToolStripMenuItem
            // 
            this.charityAcitityRecordsToolStripMenuItem.Name = "charityAcitityRecordsToolStripMenuItem";
            this.charityAcitityRecordsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.charityAcitityRecordsToolStripMenuItem.Text = "Charity Acitity Records";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // RefreshBT
            // 
            this.RefreshBT.Location = new System.Drawing.Point(681, 0);
            this.RefreshBT.Name = "RefreshBT";
            this.RefreshBT.Size = new System.Drawing.Size(54, 23);
            this.RefreshBT.TabIndex = 26;
            this.RefreshBT.Text = "Refresh";
            this.RefreshBT.UseVisualStyleBackColor = true;
            this.RefreshBT.Click += new System.EventHandler(this.RefreshBT_Click);
            // 
            // ManageTab
            // 
            this.ManageTab.Controls.Add(this.ReleasingTab);
            this.ManageTab.Controls.Add(this.IncomingTab);
            this.ManageTab.Controls.Add(this.ResellingTab);
            this.ManageTab.Controls.Add(this.CharityTab);
            this.ManageTab.Location = new System.Drawing.Point(12, 29);
            this.ManageTab.Name = "ManageTab";
            this.ManageTab.SelectedIndex = 0;
            this.ManageTab.Size = new System.Drawing.Size(712, 406);
            this.ManageTab.TabIndex = 27;
            // 
            // ReleasingTab
            // 
            this.ReleasingTab.Controls.Add(this.ScanSitesbt);
            this.ReleasingTab.Controls.Add(this.noteLB);
            this.ReleasingTab.Controls.Add(this.ManualPurchaseBT);
            this.ReleasingTab.Controls.Add(this.AddReleaseBT);
            this.ReleasingTab.Controls.Add(this.label1);
            this.ReleasingTab.Controls.Add(this.newSnkrLV);
            this.ReleasingTab.Location = new System.Drawing.Point(4, 22);
            this.ReleasingTab.Name = "ReleasingTab";
            this.ReleasingTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReleasingTab.Size = new System.Drawing.Size(704, 366);
            this.ReleasingTab.TabIndex = 0;
            this.ReleasingTab.Text = "New Releases";
            this.ReleasingTab.UseVisualStyleBackColor = true;
            this.ReleasingTab.Click += new System.EventHandler(this.ReleasingTab_Click);
            // 
            // ScanSitesbt
            // 
            this.ScanSitesbt.Location = new System.Drawing.Point(15, 313);
            this.ScanSitesbt.Name = "ScanSitesbt";
            this.ScanSitesbt.Size = new System.Drawing.Size(66, 35);
            this.ScanSitesbt.TabIndex = 31;
            this.ScanSitesbt.Text = "Scan Sites";
            this.ScanSitesbt.UseVisualStyleBackColor = true;
            this.ScanSitesbt.Click += new System.EventHandler(this.ScanSitesbt_Click);
            // 
            // noteLB
            // 
            this.noteLB.AutoSize = true;
            this.noteLB.Location = new System.Drawing.Point(162, 324);
            this.noteLB.Name = "noteLB";
            this.noteLB.Size = new System.Drawing.Size(38, 13);
            this.noteLB.TabIndex = 30;
            this.noteLB.Text = "Notes:";
            // 
            // ManualPurchaseBT
            // 
            this.ManualPurchaseBT.Location = new System.Drawing.Point(552, 319);
            this.ManualPurchaseBT.Name = "ManualPurchaseBT";
            this.ManualPurchaseBT.Size = new System.Drawing.Size(133, 23);
            this.ManualPurchaseBT.TabIndex = 29;
            this.ManualPurchaseBT.Text = "Purchase Selected Shoe";
            this.ManualPurchaseBT.UseVisualStyleBackColor = true;
            this.ManualPurchaseBT.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AddReleaseBT
            // 
            this.AddReleaseBT.Location = new System.Drawing.Point(87, 313);
            this.AddReleaseBT.Name = "AddReleaseBT";
            this.AddReleaseBT.Size = new System.Drawing.Size(66, 35);
            this.AddReleaseBT.TabIndex = 28;
            this.AddReleaseBT.Text = "Add new";
            this.AddReleaseBT.UseVisualStyleBackColor = true;
            this.AddReleaseBT.Click += new System.EventHandler(this.AIOBotBT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "List of new releasing sneakers";
            // 
            // newSnkrLV
            // 
            this.newSnkrLV.Location = new System.Drawing.Point(15, 45);
            this.newSnkrLV.Name = "newSnkrLV";
            this.newSnkrLV.Size = new System.Drawing.Size(670, 250);
            this.newSnkrLV.TabIndex = 25;
            this.newSnkrLV.UseCompatibleStateImageBehavior = false;
            this.newSnkrLV.SelectedIndexChanged += new System.EventHandler(this.newSnkrLV_SelectedIndexChanged);
            this.newSnkrLV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.newSnkrLV_MouseDoubleClick);
            // 
            // IncomingTab
            // 
            this.IncomingTab.Controls.Add(this.NoteMS);
            this.IncomingTab.Controls.Add(this.Confirm_arrivalBT);
            this.IncomingTab.Controls.Add(this.button5);
            this.IncomingTab.Controls.Add(this.label2);
            this.IncomingTab.Controls.Add(this.IncomingSnkrLV);
            this.IncomingTab.Location = new System.Drawing.Point(4, 22);
            this.IncomingTab.Name = "IncomingTab";
            this.IncomingTab.Padding = new System.Windows.Forms.Padding(3);
            this.IncomingTab.Size = new System.Drawing.Size(704, 380);
            this.IncomingTab.TabIndex = 1;
            this.IncomingTab.Text = "AIO Purchases";
            this.IncomingTab.UseVisualStyleBackColor = true;
            this.IncomingTab.Click += new System.EventHandler(this.IncomingTab_Click);
            // 
            // NoteMS
            // 
            this.NoteMS.Location = new System.Drawing.Point(130, 302);
            this.NoteMS.Multiline = true;
            this.NoteMS.Name = "NoteMS";
            this.NoteMS.ReadOnly = true;
            this.NoteMS.Size = new System.Drawing.Size(441, 72);
            this.NoteMS.TabIndex = 33;
            // 
            // Confirm_arrivalBT
            // 
            this.Confirm_arrivalBT.Location = new System.Drawing.Point(584, 319);
            this.Confirm_arrivalBT.Name = "Confirm_arrivalBT";
            this.Confirm_arrivalBT.Size = new System.Drawing.Size(101, 23);
            this.Confirm_arrivalBT.TabIndex = 28;
            this.Confirm_arrivalBT.Text = "Confirm Arrival";
            this.Confirm_arrivalBT.UseVisualStyleBackColor = true;
            this.Confirm_arrivalBT.Click += new System.EventHandler(this.Confirm_arrivalBT_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 313);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 35);
            this.button5.TabIndex = 27;
            this.button5.Text = "Sneakers in Stock";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "List of Incoming sneakers";
            // 
            // IncomingSnkrLV
            // 
            this.IncomingSnkrLV.Location = new System.Drawing.Point(15, 45);
            this.IncomingSnkrLV.Name = "IncomingSnkrLV";
            this.IncomingSnkrLV.Size = new System.Drawing.Size(670, 250);
            this.IncomingSnkrLV.TabIndex = 25;
            this.IncomingSnkrLV.UseCompatibleStateImageBehavior = false;
            this.IncomingSnkrLV.SelectedIndexChanged += new System.EventHandler(this.IncomingSnkrLV_SelectedIndexChanged);
            this.IncomingSnkrLV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IncomingSnkrLV_MouseDoubleClick);
            // 
            // ResellingTab
            // 
            this.ResellingTab.Controls.Add(this.SoldBT);
            this.ResellingTab.Controls.Add(this.label3);
            this.ResellingTab.Controls.Add(this.SoldSnkrBT);
            this.ResellingTab.Controls.Add(this.SellingSnkrLV);
            this.ResellingTab.Location = new System.Drawing.Point(4, 22);
            this.ResellingTab.Name = "ResellingTab";
            this.ResellingTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResellingTab.Size = new System.Drawing.Size(704, 366);
            this.ResellingTab.TabIndex = 2;
            this.ResellingTab.Text = "Ebay Listings";
            this.ResellingTab.UseVisualStyleBackColor = true;
            this.ResellingTab.Click += new System.EventHandler(this.ResellingTab_Click);
            // 
            // SoldBT
            // 
            this.SoldBT.Location = new System.Drawing.Point(628, 319);
            this.SoldBT.Name = "SoldBT";
            this.SoldBT.Size = new System.Drawing.Size(57, 23);
            this.SoldBT.TabIndex = 29;
            this.SoldBT.Text = "Sold";
            this.SoldBT.UseVisualStyleBackColor = true;
            this.SoldBT.Click += new System.EventHandler(this.SoldBT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "List of Selling sneaker on Ebay";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SoldSnkrBT
            // 
            this.SoldSnkrBT.Location = new System.Drawing.Point(15, 313);
            this.SoldSnkrBT.Name = "SoldSnkrBT";
            this.SoldSnkrBT.Size = new System.Drawing.Size(125, 35);
            this.SoldSnkrBT.TabIndex = 27;
            this.SoldSnkrBT.Text = "Sold sneaker Record";
            this.SoldSnkrBT.UseVisualStyleBackColor = true;
            this.SoldSnkrBT.Click += new System.EventHandler(this.SoldSnkrBT_Click_1);
            // 
            // SellingSnkrLV
            // 
            this.SellingSnkrLV.Location = new System.Drawing.Point(15, 45);
            this.SellingSnkrLV.Name = "SellingSnkrLV";
            this.SellingSnkrLV.Size = new System.Drawing.Size(670, 250);
            this.SellingSnkrLV.TabIndex = 26;
            this.SellingSnkrLV.UseCompatibleStateImageBehavior = false;
            this.SellingSnkrLV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SellingSnkrLV_MouseDoubleClick);
            // 
            // CharityTab
            // 
            this.CharityTab.Controls.Add(this.ManageCharityBT);
            this.CharityTab.Controls.Add(this.label4);
            this.CharityTab.Controls.Add(this.CharityActLV);
            this.CharityTab.Location = new System.Drawing.Point(4, 22);
            this.CharityTab.Name = "CharityTab";
            this.CharityTab.Padding = new System.Windows.Forms.Padding(3);
            this.CharityTab.Size = new System.Drawing.Size(704, 366);
            this.CharityTab.TabIndex = 3;
            this.CharityTab.Text = "Charity Activities";
            this.CharityTab.UseVisualStyleBackColor = true;
            this.CharityTab.Click += new System.EventHandler(this.CharityTab_Click);
            // 
            // ManageCharityBT
            // 
            this.ManageCharityBT.Location = new System.Drawing.Point(15, 313);
            this.ManageCharityBT.Name = "ManageCharityBT";
            this.ManageCharityBT.Size = new System.Drawing.Size(125, 35);
            this.ManageCharityBT.TabIndex = 24;
            this.ManageCharityBT.Text = "Manage Charity list";
            this.ManageCharityBT.UseVisualStyleBackColor = true;
            this.ManageCharityBT.Click += new System.EventHandler(this.ManageCharityBT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Charity Activities";
            // 
            // CharityActLV
            // 
            this.CharityActLV.Location = new System.Drawing.Point(15, 45);
            this.CharityActLV.Name = "CharityActLV";
            this.CharityActLV.Size = new System.Drawing.Size(670, 250);
            this.CharityActLV.TabIndex = 22;
            this.CharityActLV.UseCompatibleStateImageBehavior = false;
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(105, 443);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(100, 20);
            this.searchTB.TabIndex = 32;
            this.searchTB.Text = "Enter ID/Code";
            this.searchTB.Click += new System.EventHandler(this.searchTB_Click);
            // 
            // charityRB
            // 
            this.charityRB.AutoSize = true;
            this.charityRB.Location = new System.Drawing.Point(355, 446);
            this.charityRB.Name = "charityRB";
            this.charityRB.Size = new System.Drawing.Size(57, 17);
            this.charityRB.TabIndex = 31;
            this.charityRB.TabStop = true;
            this.charityRB.Text = "Charity";
            this.charityRB.UseVisualStyleBackColor = true;
            // 
            // supplierRB
            // 
            this.supplierRB.AutoSize = true;
            this.supplierRB.Location = new System.Drawing.Point(286, 446);
            this.supplierRB.Name = "supplierRB";
            this.supplierRB.Size = new System.Drawing.Size(63, 17);
            this.supplierRB.TabIndex = 30;
            this.supplierRB.TabStop = true;
            this.supplierRB.Text = "Supplier";
            this.supplierRB.UseVisualStyleBackColor = true;
            // 
            // sneakrRB
            // 
            this.sneakrRB.AutoSize = true;
            this.sneakrRB.Checked = true;
            this.sneakrRB.Location = new System.Drawing.Point(215, 446);
            this.sneakrRB.Name = "sneakrRB";
            this.sneakrRB.Size = new System.Drawing.Size(65, 17);
            this.sneakrRB.TabIndex = 29;
            this.sneakrRB.TabStop = true;
            this.sneakrRB.Text = "Sneaker";
            this.sneakrRB.UseVisualStyleBackColor = true;
            // 
            // SearchBT
            // 
            this.SearchBT.Location = new System.Drawing.Point(14, 441);
            this.SearchBT.Name = "SearchBT";
            this.SearchBT.Size = new System.Drawing.Size(85, 23);
            this.SearchBT.TabIndex = 28;
            this.SearchBT.Text = "SEARCH";
            this.SearchBT.UseVisualStyleBackColor = true;
            this.SearchBT.Click += new System.EventHandler(this.SearchBT_Click);
            // 
            // StopBT
            // 
            this.StopBT.Location = new System.Drawing.Point(568, 442);
            this.StopBT.Name = "StopBT";
            this.StopBT.Size = new System.Drawing.Size(85, 23);
            this.StopBT.TabIndex = 35;
            this.StopBT.Text = "Stop All Tasks";
            this.StopBT.UseVisualStyleBackColor = true;
            // 
            // ScanBT
            // 
            this.ScanBT.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ScanBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanBT.ForeColor = System.Drawing.Color.Transparent;
            this.ScanBT.Location = new System.Drawing.Point(492, 441);
            this.ScanBT.Name = "ScanBT";
            this.ScanBT.Size = new System.Drawing.Size(70, 24);
            this.ScanBT.TabIndex = 34;
            this.ScanBT.Text = "SCAN";
            this.ScanBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ScanBT.UseVisualStyleBackColor = false;
            // 
            // twitterBT
            // 
            this.twitterBT.Location = new System.Drawing.Point(415, 442);
            this.twitterBT.Name = "twitterBT";
            this.twitterBT.Size = new System.Drawing.Size(71, 23);
            this.twitterBT.TabIndex = 33;
            this.twitterBT.Text = "Twitter list";
            this.twitterBT.UseVisualStyleBackColor = true;
            // 
            // CloseBT
            // 
            this.CloseBT.Location = new System.Drawing.Point(655, 443);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Size = new System.Drawing.Size(65, 23);
            this.CloseBT.TabIndex = 36;
            this.CloseBT.Text = "Close";
            this.CloseBT.UseVisualStyleBackColor = true;
            this.CloseBT.Click += new System.EventHandler(this.CloseBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 485);
            this.Controls.Add(this.CloseBT);
            this.Controls.Add(this.StopBT);
            this.Controls.Add(this.ScanBT);
            this.Controls.Add(this.twitterBT);
            this.Controls.Add(this.searchTB);
            this.Controls.Add(this.charityRB);
            this.Controls.Add(this.supplierRB);
            this.Controls.Add(this.sneakrRB);
            this.Controls.Add(this.SearchBT);
            this.Controls.Add(this.ManageTab);
            this.Controls.Add(this.RefreshBT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SneakerBot for Goods";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ManageTab.ResumeLayout(false);
            this.ReleasingTab.ResumeLayout(false);
            this.ReleasingTab.PerformLayout();
            this.IncomingTab.ResumeLayout(false);
            this.IncomingTab.PerformLayout();
            this.ResellingTab.ResumeLayout(false);
            this.ResellingTab.PerformLayout();
            this.CharityTab.ResumeLayout(false);
            this.CharityTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listsRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paypalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestAccountSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIOBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sneakerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersBillRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charityAcitityRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBillingInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportACSVFileToolStripMenuItem;
        private System.Windows.Forms.Button RefreshBT;
        private System.Windows.Forms.TabControl ManageTab;
        private System.Windows.Forms.TabPage ReleasingTab;
        private System.Windows.Forms.Button ManualPurchaseBT;
        private System.Windows.Forms.Button AddReleaseBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView newSnkrLV;
        private System.Windows.Forms.TabPage IncomingTab;
        private System.Windows.Forms.Button Confirm_arrivalBT;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView IncomingSnkrLV;
        private System.Windows.Forms.TabPage ResellingTab;
        private System.Windows.Forms.Button SoldBT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SoldSnkrBT;
        private System.Windows.Forms.ListView SellingSnkrLV;
        private System.Windows.Forms.TabPage CharityTab;
        private System.Windows.Forms.Button ManageCharityBT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView CharityActLV;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.RadioButton charityRB;
        private System.Windows.Forms.RadioButton supplierRB;
        private System.Windows.Forms.RadioButton sneakrRB;
        private System.Windows.Forms.Button SearchBT;
        private System.Windows.Forms.Button StopBT;
        private System.Windows.Forms.Button ScanBT;
        private System.Windows.Forms.Button twitterBT;
        private System.Windows.Forms.Button CloseBT;
        private System.Windows.Forms.Label noteLB;
        private System.Windows.Forms.TextBox NoteMS;
        private System.Windows.Forms.Button ScanSitesbt;
    }
}

