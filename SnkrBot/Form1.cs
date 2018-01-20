using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using eBay.Service.EPS;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
namespace SnkrBot
{
    public partial class Form1 : Form
    {
        private static ApiContext apiContext = null;
        private string ImportFileName = "f";
        DBConnection SQLConnect = new DBConnection();
        public Form1()
        {
            InitializeComponent();
            StopBT.Visible = false;
            ScanBT.Visible = false;
            twitterBT.Visible = false;
            NoteMS.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Releasing_shoe_loadData();
            Incomming_shoe_loadData();
            SellingEbay_shoe_loadData();
            Charity_Activity_loadData();
        }
   
        

        
        private void tSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void twitterBT_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void sneakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void charityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void ManageCharityBT_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void creditCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }

        private void paypalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form7().Show();
        }

        private void guestAccountSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //(new Form()).ShowDialog(this);
            MessageBox.Show("This function is not ready in use", "Guest Accounts",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            if (searchTB.Text.Equals("Enter ID/Code") || searchTB.Text.Equals("")) MessageBox.Show("Please enter ID or Code");
            else
            {
                string searchID = searchTB.Text;
                if (sneakrRB.Checked == true)
                {
                    if (SQLConnect.Count("Select count(*) from Shoe where ShoeID = '" + searchID + "';") == 0)
                        MessageBox.Show("ID/Code "+searchID+" is NOT found. \nPlease enter again!");
                    else new SneakerInfo(searchID).Show();
                }
                else if (supplierRB.Checked == true)
                {
                    if (SQLConnect.Count("Select count(*) from Supplier where SupplierID = '" + searchID + "';") == 0)
                        MessageBox.Show("ID/Code is NOT found. \nPlease enter again!");
                    else new AddNew_Form(ref searchID, 3).Show();
                }
                else
                {
                    if (SQLConnect.Count("Select count(*) from Charity where CharityID = '" + searchID + "';") == 0)
                        MessageBox.Show("ID/Code is NOT found. \nPlease enter again!");
                    else
                    {
                        DataTable data = SQLConnect.Selects("Select * from charity where charityid = "+searchID+";", 8);
                        string st = "";
                        foreach (DataRow row in data.Rows)
                        {
                            st += "Charity ID: " + row[0];
                            st += "\nCharity Name: "+row[1];
                            st += "\nWebsite: " + row[7];
                            st += "\nEmail: " + row[5];
                            st += "\nPhone: " + row[6];
                            break;
                        }
                        MessageBox.Show(st);
                    }
                }    
            }
        }

        private void SoldSnkrBT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not ready in use", "Records of Sold sneakers",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form3("Instore").Show();
        }

        private void aIOBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("AIO Bot.exe");
            }
            catch
            {
                MessageBox.Show("Require installing AIO Bot", "AIOBot",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not ready in use", "About",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not ready in use", "Helps",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void ScanBT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Im not ready to let you SCAN!!!", "SCAN",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void StopBT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have not started yet...", "Stop me...",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void importCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg;
           
                fdlg = new OpenFileDialog();
                fdlg.Title = "Import a CSV file";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    ImportFileName = fdlg.FileName;
                }
            ImportData(ImportFileName);
        }

        private void ImportData(string FilePath)
        {
            try
            {
                StreamReader sr = new StreamReader(FilePath);
                //importingData = new Account();
                string line;
                string[] column = new string[8];
                //inorge the 1st line
                line = sr.ReadLine();
                //read from 2nd line to end
                while ((line = sr.ReadLine()) != null)
                {
                    column = line.Split(',');
                    if (SQLConnect.Count("Select Count(*) FROM SUPPLIER WHERE SupplierName = '" + column[0] + "';") == 0)
                    {
                        SQLConnect.Insert("Insert into SUPPLIER(SupplierID, SupplierName) values('" + GetCode() + "','" + column[0] + "')");
                    }
                    if (SQLConnect.Count("Select Count(*) FROM SHOE WHERE ShoeID = '" + column[3] + "';") == 0)
                    {
                        string supplierID = SQLConnect.Select("Select SupplierID from Supplier where SupplierName ='" +column[0] + "';");
                        SQLConnect.Insert("Insert into SHOE(ShoeID, ShoeName, SupplierID, Size, Status) values('" +column[3] + "','" + column[1] + "','" + supplierID + "'," + column[2] + ",'Releasing');");
                        //MessageBox.Show(GetCode() + "', '" + column[3] + "','" + column[6] + " " + column[7] + "','" + column[6] + "','" + column[4]);
                        SQLConnect.Insert("Insert into RELEASING_SHOE values('"+ GetCode() + "', '" + column[3] + "','" + column[6] + " " + column[7] + "','" + column[6] + "','" + column[4] + "');");
                    }

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Releasing_shoe_loadData();
        }

        public string GetCode()
        {
            //Random rand = new Random(Guid.NewGuid().GetHashCode());
            int rand = new Random(DateTime.Now.Millisecond).Next();
            Thread.Sleep(1);
            return rand.ToString();
        }

        private void Releasing_shoe_loadData()
        {
            newSnkrLV.Clear();
            newSnkrLV.View = View.Details;
            newSnkrLV.GridLines = true;
            newSnkrLV.FullRowSelect = true;
            //Add column header
            newSnkrLV.Columns.Add("ID", 80);
            newSnkrLV.Columns.Add("Name", 205);
            newSnkrLV.Columns.Add("Supplier", 110);
            newSnkrLV.Columns.Add("Date - Time", 100);
            newSnkrLV.Columns.Add("Link", 171);
            DataTable data = SQLConnect.Selects("Select Shoe.ShoeID, Shoe.ShoeName, Supplier.SupplierName,DATE_FORMAT(ReleaseTime,'%d/%m/%y %H:%i ') AS RLDate_Time, LinkTobuy from Releasing_Shoe, Shoe, Supplier where (Releasing_Shoe.ShoeID=Shoe.ShoeID) AND (Shoe.SupplierID=Supplier.SupplierID) AND (Shoe.Status = 'Releasing');", 7);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Releasing = new ListViewItem(row[0].ToString());
                Releasing.SubItems.Add(row[1].ToString());
                Releasing.SubItems.Add(row[2].ToString());
                Releasing.SubItems.Add(row[3].ToString());//+DateTime.Parse(row[3].ToString()).DayOfWeek.ToString()
                Releasing.SubItems.Add(row[4].ToString());
                newSnkrLV.Items.Add(Releasing);
                index++;
            }
            
        }
        private void Incomming_shoe_loadData()
        {
            IncomingSnkrLV.Clear();
            IncomingSnkrLV.View = View.Details;
            IncomingSnkrLV.GridLines = true;
            IncomingSnkrLV.FullRowSelect = true;
            //add column header
            IncomingSnkrLV.Columns.Add("ID", 80);
            IncomingSnkrLV.Columns.Add("Name", 200);
            IncomingSnkrLV.Columns.Add("Supplier", 120);
            IncomingSnkrLV.Columns.Add("Est. Date", 100);
            IncomingSnkrLV.Columns.Add("Status", 85);
            IncomingSnkrLV.Columns.Add("Flag Ebay", 80);

            DataTable data = SQLConnect.Selects("Select Shoe.ShoeID, Shoe.ShoeName, Supplier.SupplierName, Shoe.Status from Shoe, Supplier where  (Supplier.SupplierID=Shoe.SupplierID) AND ((Shoe.status = 'Purchased') OR (Shoe.status = 'Arrived'));", 6);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Incoming = new ListViewItem(row[0].ToString());
                Incoming.SubItems.Add(row[1].ToString());
                Incoming.SubItems.Add(row[2].ToString());
                if (SQLConnect.Count("Select count(*) from Incoming_shoe where shoeId = '" + row[0].ToString() + "';") == 0)
                {
                    Incoming.SubItems.Add("");
                    Incoming.SubItems.Add(row[3].ToString());
                    Incoming.SubItems.Add("");
                }
                else
                {
                    Incoming.SubItems.Add(SQLConnect.Select("Select ArrivalDate from Incoming_Shoe where ShoeID = '" + row[0].ToString() + "';"));
                    Incoming.SubItems.Add(row[3].ToString());
                    Incoming.SubItems.Add(SQLConnect.Select("Select isReady from Incoming_Shoe where ShoeID = '" + row[0].ToString() + "';"));
                }
                IncomingSnkrLV.Items.Add(Incoming);
                index++;
            }
        }
        private void SellingEbay_shoe_loadData()
        {
            SellingSnkrLV.Clear();
            SellingSnkrLV.View = View.Details;
            SellingSnkrLV.GridLines = true;
            SellingSnkrLV.FullRowSelect = true;
            //Add column header
            SellingSnkrLV.Columns.Add("ID", 80);
            SellingSnkrLV.Columns.Add("Name", 200);
            SellingSnkrLV.Columns.Add("Supplier", 120);
            SellingSnkrLV.Columns.Add("Upload Date", 150);
            SellingSnkrLV.Columns.Add("Status", 115);

            //load data from database
            DataTable data = SQLConnect.Selects("Select Shoe.ShoeID, Shoe.ShoeName, Supplier.SupplierName, ArrivalDate As UploadDate, Shoe.Status from Incoming_Shoe, Shoe, Supplier where (Supplier.SupplierID=Shoe.SupplierID) AND (Shoe.status = 'ReSelling') AND (Incoming_Shoe.isReady = 1);", 6);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem ReSelling = new ListViewItem(row[0].ToString());
                ReSelling.SubItems.Add(row[1].ToString());
                ReSelling.SubItems.Add(row[2].ToString());
                ReSelling.SubItems.Add(row[3].ToString());
                ReSelling.SubItems.Add(row[4].ToString());
                SellingSnkrLV.Items.Add(ReSelling);
                index++;
            }
        }
        private void Charity_Activity_loadData()
        {
            CharityActLV.Clear();
            CharityActLV.View = View.Details;
            CharityActLV.GridLines = true;
            CharityActLV.FullRowSelect = true;
            //add column header
            CharityActLV.Columns.Add("No.", 50);
            CharityActLV.Columns.Add("Charity ID", 100);
            CharityActLV.Columns.Add("Charity Name", 200);
            CharityActLV.Columns.Add("Fund Amound", 100);
            CharityActLV.Columns.Add("Date", 115);
            CharityActLV.Columns.Add("Method", 100);
            //load data from database
            DataTable data = SQLConnect.Selects("Select * from FUND_Record;", 5);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem fund = new ListViewItem(index.ToString());
                fund.SubItems.Add(SQLConnect.Select("Select CharityID from Fund_Record where FundCode = '"+row[0].ToString()+"';"));
                fund.SubItems.Add(row[1].ToString());
                fund.SubItems.Add(row[3].ToString());
                fund.SubItems.Add(row[2].ToString());
                if (row[4].ToString().Equals("P")) fund.SubItems.Add("Paypal");
                else if (row[4].ToString().Equals("C")) fund.SubItems.Add("Bank Account");
                else fund.SubItems.Add("");
                CharityActLV.Items.Add(fund);
                index++;
            }

        }

        private void manageBillingInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing_Shipping BS = new Billing_Shipping();
            BS.Size = new Size(600,400);
            BS.Show();
        }

        private void IncomingSnkrLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in newSnkrLV.SelectedItems)
            {
                try
                {
                    //auto purchase and set up appropriate database 
                    SQLConnect.Update("Update Shoe SET Status = 'Purchased' where ShoeID = '" +eachItem.SubItems[0].Text +"';");
                    SQLConnect.Insert("Insert Into Incoming_shoe(ArrivalCode, ShoeID) values('"+GetCode()+"','"+  eachItem.SubItems[0].Text +"');");
                    MessageBox.Show("The sneaker " + eachItem.SubItems[1].Text+ " is purchased successful!");
                    newSnkrLV.Items.Remove(eachItem);
                    Incomming_shoe_loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is problems during purchasing Sneaker ID" + eachItem.SubItems[0].Text+ex);
                }
            }
        }
        */
        private void Confirm_arrivalBT_Click_1(object sender, EventArgs e)
        {
            if (IncomingSnkrLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item in the list.");
            }
            else
            {
                foreach (ListViewItem eachItem in IncomingSnkrLV.SelectedItems)
                {
                    try
                    {
                        if (SQLConnect.Select("Select isReady from Incoming_shoe where ShoeID = '" + eachItem.SubItems[0].Text + "';") == "0")
                        {
                            if (MessageBox.Show("This item is arrived already. Do you want to set Ebay Flag for Sale?", " Confirm for Ebay Reselling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                SQLConnect.Update("Update Incoming_shoe SET isReady = 1 WHERE ShoeID='" + eachItem.SubItems[0].Text + "';");
                                SQLConnect.Update("Update Shoe SET Status = 'ReSelling' WHERE ShoeID='" + eachItem.SubItems[0].Text + "';");
                                AddItemEbay(eachItem.SubItems[0].Text);
                                eachItem.Remove();
                            }
                            else
                            {
                                //this.Close();
                            }
                        }
                        else (new ConfirmArrival(eachItem.SubItems[0].Text)).Show();
                        //auto purchase and set up appropriate database 
                        if (SQLConnect.Select("Select isReady from Incoming_shoe where ShoeID = '" + eachItem.SubItems[0].Text + "';") == "1")
                            newSnkrLV.Items.Remove(eachItem);
                        SellingEbay_shoe_loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is problems during confirming Sneaker ID" + SQLConnect.Select("Select ShoeID from Releasing_Shoe where ReleaseCode='" + eachItem.SubItems[0].Text + "';"));
                    }
                }
            }
            
        }

        private void searchTB_Click(object sender, EventArgs e)
        {
            if (searchTB.Text.Equals("Enter ID/Code")) searchTB.Text = "";
        }

        private void exportACSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3("ExportAIOBotFile").Show();
        }
        
        private void newSnkrLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem eachItem in newSnkrLV.SelectedItems)
                {
                    //for myPC
                    //string checkExpire = SQLConnect.Select("Select DATE_FORMAT(Releasing_Shoe.ReleaseTime,'%d/%m/%y %H:%i:%s') from Releasing_Shoe, Shoe where ((Releasing_Shoe.ShoeID=Shoe.ShoeID) AND (Shoe.ShoeID = '" + eachItem.SubItems[0].Text + "'));");
                    //for RDC
                    string checkExpire = SQLConnect.Select("Select DATE_FORMAT(Releasing_Shoe.ReleaseTime,'%m/%d/%y %H:%i:%s') from Releasing_Shoe, Shoe where ((Releasing_Shoe.ShoeID=Shoe.ShoeID) AND (Shoe.ShoeID = '"+eachItem.SubItems[0].Text+"'));");
                    noteLB.Text = "Notes: The sneaker " + eachItem.SubItems[1].Text + (DateTime.Compare(DateTime.Parse(checkExpire), DateTime.Now) > 0 ? " is releasing soon" : " was released (Expired)");
                }
            }
            catch (FormatException fe)
            {

            }
        }
        private void newSnkrLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem eachItem in newSnkrLV.SelectedItems)
            {
                //MessageBox.Show(new SearchShoeInfo().GetShoeImage(eachItem.SubItems[2].Text,eachItem.SubItems[1].Text,eachItem.SubItems[0].Text,3));
                (new SneakerInfo(eachItem.SubItems[0].Text)).Show();
            }
        }

        private void SellingSnkrLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SellingEbay_shoe_loadData();
        }
        private void IncomingSnkrLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem eachItem in IncomingSnkrLV.SelectedItems)
            {
                if (eachItem.SubItems[4].Text.Equals("Arrived"))
                {
                   if (MessageBox.Show("Do you want to set Ebay Flag for Sale?", " Confirm for Ebay Reselling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SQLConnect.Update("Update Incoming_shoe SET isReady = 1 WHERE ShoeID='" + eachItem.SubItems[0].Text + "';");
                        SQLConnect.Update("Update Shoe SET Status = 'ReSelling' WHERE ShoeID='" + eachItem.SubItems[0].Text + "';");
                        new Ebay().AddItemEbay(eachItem.SubItems[0].Text);
                        eachItem.Remove();
                    }
                    else
                    {
                        //this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("The sneaker ID " + eachItem.SubItems[0].Text + " is still on the way.\n Click OK to confirm \"Arrived\".", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        (new ConfirmArrival(eachItem.SubItems[0].Text)).Show();
                    Incomming_shoe_loadData();
                    SellingEbay_shoe_loadData();
                }
            }
        }

        private void RefreshBT_Click(object sender, EventArgs e)
        {
            Releasing_shoe_loadData();
            Incomming_shoe_loadData();
            SellingEbay_shoe_loadData();
            Charity_Activity_loadData();
        }

        
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CloseBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (newSnkrLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item in the list.");
            }
            else
            {
                foreach (ListViewItem eachItem in newSnkrLV.SelectedItems)
                {
                    try
                    {
                        //auto purchase and set up appropriate database 
                        SQLConnect.Update("Update Shoe SET Status = 'Purchased' where ShoeID = '" + eachItem.SubItems[0].Text + "';");
                        SQLConnect.Insert("Insert Into Incoming_shoe(ArrivalCode, ShoeID) values('" + GetCode() + "','" + eachItem.SubItems[0].Text + "');");
                        MessageBox.Show("The sneaker " + eachItem.SubItems[1].Text + " is marked: \'Purchased\'");
                        //MessageBox.Show(new SearchShoeInfo().GetShoeDescription(eachItem.SubItems[2].Text, eachItem.SubItems[1].Text, eachItem.SubItems[0].Text));
                        newSnkrLV.Items.Remove(eachItem);
                        Incomming_shoe_loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is problems during purchasing Sneaker ID" + eachItem.SubItems[0].Text + ex);
                    }
                }
            }
        }

        private void SoldBT_Click(object sender, EventArgs e)
        {
            if (SellingSnkrLV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item in the list.");
            }
            else
            {
                foreach (ListViewItem eachItem in SellingSnkrLV.SelectedItems)
                {
                    try
                    {
                        //auto purchase and set up appropriate database 
                        SQLConnect.Update("Update Shoe SET Status = 'Sold' where ShoeID = '" + eachItem.SubItems[0].Text + "';");
                        MessageBox.Show("The sneaker " + eachItem.SubItems[1].Text + " is sold successful!");
                        SellingSnkrLV.Items.Remove(eachItem);
                        SellingEbay_shoe_loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is problems during purchasing Sneaker ID" + eachItem.SubItems[0].Text + ex);
                    }
                }
            }
        }

        private void ReleasingTab_Click(object sender, EventArgs e)
        {
            Releasing_shoe_loadData();
        }

        private void IncomingTab_Click(object sender, EventArgs e)
        {
            Incomming_shoe_loadData();
        }

        private void ResellingTab_Click(object sender, EventArgs e)
        {
            SellingEbay_shoe_loadData();
        }

        private void CharityTab_Click(object sender, EventArgs e)
        {
            Charity_Activity_loadData();
        }

        private void IncomingSnkrLV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Incomming_shoe_loadData();
        }

        private void SellingSnkrLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem eachItem in SellingSnkrLV.SelectedItems)
            {
                (new SneakerInfo(eachItem.SubItems[0].Text)).Show();
            }
        }

        private void SellingSnkrLV_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void SoldSnkrBT_Click_1(object sender, EventArgs e)
        {
            new Form3("SoldListing").Show();
        }
        private void Note_MS(string str)
        {
            NoteMS.Text += str + "\r\n";
        }
        private void AIOBotBT_Click(object sender, EventArgs e)
        {
            new New_Release_Form().Show();
            Releasing_shoe_loadData();
        }
#region Ebay
        //Update an item on Ebay
        private void AddItemEbay(string sneakerID) {

            try
            {
                Note_MS("Prepare to list "+SQLConnect.Select("Select ShoeName from Shoe where shoeID = '"+sneakerID+"';")+" on Ebay");
                //[Step 1] Initialize eBay ApiContext object
                ApiContext apiContext = GetApiContext();

                //[Step 2] Create a new ItemType object
                ItemType item = BuildItem(sneakerID);


                //[Step 3] Create Call object and execute the Call
                AddItemCall apiCall = new AddItemCall(apiContext);
                Note_MS("Begin to call eBay API, please wait ...");
                FeeTypeCollection fees = apiCall.AddItem(item);
                Note_MS("End to call eBay API, show call result ...");
                
                //[Step 4] Handle the result returned
                Note_MS("The item was listed successfully!");
                double listingFee = 0.0;
                foreach (FeeType fee in fees)
                {
                    if (fee.Name == "ListingFee")
                    {
                        listingFee = fee.Fee.Value;
                    }
                }
                Note_MS(String.Format("Listing fee is: {0}", listingFee));
                Note_MS(String.Format("Listed Item ID: {0}", item.ItemID));
            }
            catch (Exception ex)
            {
                Note_MS("Fail to list the item : " + ex.Message);
            }
        }
        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext object</returns>
        private ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();
                apiContext.Version = "673";
                //set Api Server Url
                apiContext.SoapApiServerUrl =
                    ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken =
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to AU
                apiContext.Site = SiteCodeType.Australia;

                //set Api logging
                apiContext.ApiLogManager = new ApiLogManager();
                apiContext.ApiLogManager.ApiLoggerList.Add(new FileLogger("listing_log.txt", true, true, true));
                
                apiContext.ApiLogManager.EnableLogging = true;


                return apiContext;
            }
        }

        /// <summary>
        /// Build a sample item
        /// </summary>
        /// <returns>ItemType object</returns>
        private ItemType BuildItem(string sneakerID)
        {
            ItemType item = new ItemType();
            
            // item title
            item.Title = SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '"+sneakerID+"';");
            // item description
            item.Description = "";
            // display description + photos on window form.
            //string rootPath = @"C:\Users\Viet\Documents\Visual Studio 2017\Projects\SnkrBot\target list-desc-images\";
            string rootPath = @"C:\SnkrBot\target list-desc-images";
            //string rootPath = @"C: \Users\Administrator\Desktop\target list-desc-images\";
            // scan sundirectories of rootPath
            string[] subdirectoryEntries = Directory.GetDirectories(rootPath);

            string folder = "";
            // check to find the right directory for the shoe
            foreach (string subdirectory in subdirectoryEntries)
            {
                if (subdirectory.Contains(sneakerID))
                {
                    folder = subdirectory;
                    break;
                }
            }

            try
            {
                // Only get files end .txt
                string[] txtFile = Directory.GetFiles(folder, "*.txt");
                //MessageBox.Show("The number of files .txt is" +txtFile.Length+".");
                foreach (string dir in txtFile)
                {
                    var fileStream = new FileStream(dir, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        item.Description = streamReader.ReadToEnd();
                    }
                }
                // Only get files end .jpeg
                string[] imgFile = Directory.GetFiles(folder, "*.jpeg");
                //MessageBox.Show("The number of files .jpeg is" + imgFile.Length + ".");
                foreach (string dir in imgFile)
                {

                }
                //pb1.ImageLocation = imgFile[0];
                apiContext.EPSServerUrl = @"https://api.sandbox.ebay.com/ws/api.dll";
                eBayPictureService pictureService = new eBayPictureService(new ApiContext());
               // pictureService.ApiContext.EPSServerUrl = @"https://api.sandbox.ebay.com/ws/api.dll";
                string[] picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, imgFile);
                //To specify a Gallery Image 
                item.PictureDetails = new PictureDetailsType();
                //The first picture is used for Gallery URL 
                item.PictureDetails.GalleryType = GalleryTypeCodeType.Gallery;

            }
            catch (Exception e)
            {
                //MessageBox.Show("Reading file Unsuccessful");
            }
            

            
            // listing duration
            item.ListingDuration = "Days_7";


            // listing category, 
            CategoryType category = new CategoryType();
            category.CategoryID = "153008"; //CategoryID = 11104 (CookBooks) , Parent CategoryID=267(Books), 153008 (shoe)
            item.PrimaryCategory = category;

            // item quality
            item.Quantity = 1;

            // item condition, New
            item.ConditionID = 1000;

            // item specifics
            item.ItemSpecifics = buildItemSpecifics(sneakerID);
            // listing type
            item.ListingType = ListingTypeCodeType.Chinese;
            


            // item location and country
            item.Location = "Melbourne";
            item.Country = CountryCodeType.AU;
            item.Currency = CurrencyCodeType.AUD;
            // listing price
            //item Start Price
            AmountType amount = new AmountType();
            amount.Value = 20;
            amount.currencyID = CurrencyCodeType.AUD;
            item.StartPrice = amount;

            //Console.WriteLine("Do you want to use Business policy profiles to list this item? y/n");
            String input = "n";//Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                item.SellerProfiles = BuildSellerProfiles();
            }
            else
            {
                // payment methods
                item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
                item.PaymentMethods.AddRange(
                    new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal }
                    );
                // email is required if paypal is used as payment method
                item.PayPalEmailAddress = "theroyals@gmail.com";
                item.PostalCode = "3000";
                // handling time is required
                item.DispatchTimeMax = 1;
                // shipping details
                //item.ShippingDetails = BuildShippingDetails();
                item.ShippingDetails = new ShippingDetailsType();
                item.ShippingDetails.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection();

                // return policy
                item.ReturnPolicy = new ReturnPolicyType();
                item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";
                ShippingServiceOptionsType shipservice1 = new ShippingServiceOptionsType();
                shipservice1.ShippingService = "AU_Regular";
                shipservice1.ShippingServicePriority = 1;
                shipservice1.ShippingServiceCost = new AmountType();
                shipservice1.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
                shipservice1.ShippingServiceCost.Value = 1.0;

                shipservice1.ShippingServiceAdditionalCost = new AmountType();
                shipservice1.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
                shipservice1.ShippingServiceAdditionalCost.Value = 1.0;

                item.ShippingDetails.ShippingServiceOptions.Add(shipservice1);

                ShippingServiceOptionsType shipservice2 = new ShippingServiceOptionsType();
                shipservice2.ShippingService = "AU_Express";
                shipservice2.ShippingServicePriority = 2;
                shipservice2.ShippingServiceCost = new AmountType();
                shipservice2.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
                shipservice2.ShippingServiceCost.Value = 4.0;

                shipservice2.ShippingServiceAdditionalCost = new AmountType();
                shipservice2.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
                shipservice2.ShippingServiceAdditionalCost.Value = 1.0;

                item.ShippingDetails.ShippingServiceOptions.Add(shipservice2);
            }
            


            return item;
        }

        /// <summary>
        /// Build sample SellerProfile details
        /// </summary>
        /// <returns></returns>
        private SellerProfilesType BuildSellerProfiles()
        {
            /*
             * Beginning with release 763, some of the item fields from
             * the AddItem/ReviseItem/VerifyItem family of calls have been
             * moved to the Business Policies API. 
             * See http://developer.ebay.com/Devzone/business-policies/Concepts/BusinessPoliciesAPIGuide.html for more
             * 
             * This example uses profiles that were previously created using this api.
             */

            SellerProfilesType sellerProfile = new SellerProfilesType();

            Note_MS("Return policy profile Id:");
            sellerProfile.SellerReturnProfile = new SellerReturnProfileType();
            sellerProfile.SellerReturnProfile.ReturnProfileID = 123456;//Int64.Parse(Console.ReadLine());

            Note_MS("Shipping profile Id:");
            sellerProfile.SellerShippingProfile = new SellerShippingProfileType();
            sellerProfile.SellerShippingProfile.ShippingProfileID = 123456;// Int64.Parse(Console.ReadLine());

            Note_MS("Payment profile Id:");
            sellerProfile.SellerPaymentProfile = new SellerPaymentProfileType();
            sellerProfile.SellerPaymentProfile.PaymentProfileID = 123456;// Int64.Parse(Console.ReadLine());

            return sellerProfile;
        }

        /// <summary>
        /// Build sample shipping details
        /// </summary>
        /// <returns>ShippingDetailsType object</returns>
        private ShippingDetailsType BuildShippingDetails()
        {
            
            // Shipping details
            ShippingDetailsType sd = new ShippingDetailsType();
            
            sd.ApplyShippingDiscount = true;
            AmountType amount = new AmountType();
            amount.Value = 20;
            amount.currencyID = CurrencyCodeType.AUD;
            sd.PaymentInstructions = "Please do the payment via Paypal.";

            // Shipping type and shipping service options
            sd.ShippingType = ShippingTypeCodeType.Flat;
            ShippingServiceOptionsType shippingOptions = new ShippingServiceOptionsType();
                shippingOptions.ShippingService =
                ShippingServiceCodeType.ShippingMethodStandard.ToString();
            
            amount = new AmountType();
            amount.Value = 2.0;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingServiceAdditionalCost = amount;
            amount = new AmountType();
            amount.Value = 10;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingServiceCost = amount;
            shippingOptions.ShippingServicePriority = 1;
            amount = new AmountType();
            amount.Value = 1.0;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingInsuranceCost = amount;

            sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(
                new ShippingServiceOptionsType[] { shippingOptions }
                );

            return sd;
            
        }

        /// <summary>
        /// Build sample item specifics
        /// </summary>
        /// <returns>ItemSpecifics object</returns>
        private NameValueListTypeCollection buildItemSpecifics(string sneakerID)
        {
            //create the content of item specifics
            NameValueListTypeCollection nvCollection = new NameValueListTypeCollection();
            NameValueListType nv0 = new NameValueListType();
            nv0.Name = "Code";
            StringCollection nv0Col = new StringCollection();
            String[] strArr0 = new string[] { sneakerID };
            nv0Col.AddRange(strArr0);
            nv0.Value = nv0Col;
            NameValueListType nv1 = new NameValueListType();
            nv1.Name = "Name" ;
            StringCollection nv1Col = new StringCollection();
            String[] strArr1 = new string[] { SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '" + sneakerID + "';") };
            nv1Col.AddRange(strArr1);
            nv1.Value = nv1Col;
            NameValueListType nv2 = new NameValueListType();
            nv2.Name = "Size";
            StringCollection nv2Col = new StringCollection();
            String[] strArr2 = new string[] { SQLConnect.Select("Select Size from Shoe where ShoeID = '" + sneakerID + "';") };
            nv2Col.AddRange(strArr2);
            nv2.Value = nv2Col;
            NameValueListType nv3 = new NameValueListType();
            nv3.Name = "Color";
            StringCollection nv3Col = new StringCollection();
            String[] strArr3 = new string[] { SQLConnect.Select("Select Color from Shoe where ShoeID = '" + sneakerID + "';") };
            nv3Col.AddRange(strArr3);
            nv3.Value = nv3Col;
            nvCollection.Add(nv0);
            nvCollection.Add(nv1);
            nvCollection.Add(nv1);
            nvCollection.Add(nv3);
            return nvCollection;
        }
#endregion
        private void button1_Click(object sender, EventArgs e)
        {
           // AddItemEbay("123");
        }

        private void ScanSitesbt_Click(object sender, EventArgs e)
        {
            new frmShoeSelect().Show();
        }
        
    }
}
