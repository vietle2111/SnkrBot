using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SnkrBot
{
    public partial class Form3 : Form
    {
        DBConnection SQLConnect = new DBConnection();
        public Form3()
        {
            InitializeComponent();
            Form3_Load("");
        }
        public Form3(string st)
        {
            InitializeComponent();
            ExportCSVbt.Visible = false;
            RemoveBT.Visible = false;
            Form3_Load(st);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void Form3_Load(string st) {
            SneakerLV.Clear();
            SneakerLV.View = View.Details;
            SneakerLV.GridLines = true;
            SneakerLV.FullRowSelect = true;
            //Add column header
            SneakerLV.Columns.Add("ID", 90);
            SneakerLV.Columns.Add("Name", 130);
            SneakerLV.Columns.Add("Supplier", 100);
            SneakerLV.Columns.Add("Gender", 50);
            SneakerLV.Columns.Add("Size", 40);
            SneakerLV.Columns.Add("Color", 60);
            SneakerLV.Columns.Add("Status", 80);
            DataTable data;
            if (st.Equals("Instore")) data = SQLConnect.Selects("Select Shoeid, shoeName, Supplier.SupplierName, gender, size, color, status from SHOE, Supplier where (shoe.supplierID = supplier.SupplierId) AND ((Shoe.status = 'Arrived') OR (Shoe.status = 'ReSelling'));", 11);
            else if (st.Equals("ExportAIOBotFile")) data = SQLConnect.Selects("Select Shoeid, shoeName, Supplier.SupplierName, gender, size, color, status from SHOE, Supplier where ((shoe.supplierID = supplier.SupplierId) AND (Shoe.status = 'Releasing'));", 11);
            else if (st.Equals("SoldListing")) data = SQLConnect.Selects("Select Shoeid, shoeName, Supplier.SupplierName, gender, size, color, status from SHOE, Supplier where ((shoe.supplierID = supplier.SupplierId) AND (Shoe.status = 'Sold'));", 11);
            else data = SQLConnect.Selects("Select Shoeid, shoeName, Supplier.SupplierName, gender, size, color, status from SHOE, Supplier where shoe.supplierID = supplier.SupplierId;", 11);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Sneaker = new ListViewItem(row[0].ToString());
                Sneaker.SubItems.Add(row[1].ToString());
                Sneaker.SubItems.Add(row[2].ToString());
                Sneaker.SubItems.Add(row[3].ToString());
                Sneaker.SubItems.Add(row[4].ToString());
                Sneaker.SubItems.Add(row[5].ToString());
                Sneaker.SubItems.Add(row[6].ToString());
                SneakerLV.Items.Add(Sneaker);
                index++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SneakerID = "";
            foreach (ListViewItem eachItem in SneakerLV.SelectedItems)
            {
                try
                {
                    SneakerID = eachItem.SubItems[0].Text;
                    // Displays a SaveFileDialog so the user can save the Image  
                    // assigned to Button2.  
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"c:\SnkrBot\";
                    saveFileDialog1.Filter = "CSV file|*.csv";
                    saveFileDialog1.Title = "Save an CSV File";
                    saveFileDialog1.ShowDialog();

                    // If the file name is not an empty string open it for saving.  
                    if (saveFileDialog1.FileName != "")
                    {

                        StringBuilder csvContent = new StringBuilder();
                        
                        csvContent.AppendLine("Site,Email,Password,Size,NotificationEmail,NotificationText,PostiveKW,NegativeKW,StyleNumber,EarlyLinkMonitorKeywords,NewPageMonitorKeywords," +
                            "FirstNameBilling,LastNameBilling,address1Billing,address2Billing,cityBilling,stateBilling,zipCodeBilling,countryBilling,phoneBilling,houseNbBilling," +
                            "FirstNameShipping,LastNameShipping,address1Shipping,address2Shipping,cityShipping,stateShipping,zipCodeShipping,countryShipping,phoneShipping,houseNbShipping," +
                            "friendlyName,NameOnCard,DOB,cardType,CardNumber,CardExpirationMonth,CardExpirationYear,CardSecurityCode,billingEmail,paypalEmail,paypalPassword," +
                            "CheckoutDelaySeconds,CheckoutOncePerWebsite");
                            
                        //data is create in the order
                        string dataLine = "";
                        try {
                            string SupplierID = SQLConnect.Select("Select SupplierID from SHOE where ShoeID = '"+SneakerID+"';");
                            string Site = SQLConnect.Select("Select SupplierName from Supplier where SupplierID = '"+SupplierID+"';");
                            string Email = SQLConnect.Select("Select LoginAccount from Supplier where SupplierID ='" + SupplierID + "';");
                            string Password = SQLConnect.Select("Select LoginPassword from Supplier where SupplierID ='" + SupplierID + "';");
                            string Size = SQLConnect.Select("Select Size from Shoe where ShoeID ='" + SneakerID + "';");
                            string NotificationEmail = "";
                            string NotificationText = "";
                            string PostiveKW = "XXX";
                            string NegativeKW = "";
                            string StyleNumber = SneakerID;
                            string EarlyLinkMonitorKeywords = SQLConnect.Select("Select LinkToBuy from Releasing_Shoe where ShoeID ='" + SneakerID + "';");
                            string NewPageMonitorKeywords = "";
                            string billingEmail="", paypalEmail, paypalPassword;
                            paypalEmail = SQLConnect.Select("Select PaypalID from PAYPAL LIMIT 1;");
                            paypalPassword = SQLConnect.Select("Select PaypalPassword from PAYPAL LIMIT 1;");

                            string FirstNameBilling ="", LastNameBilling="", address1Billing="", address2Billing="", cityBilling="", stateBilling="", zipCodeBilling="", countryBilling="", phoneBilling="", houseNbBilling="";
                            string FirstNameShipping="", LastNameShipping="", address1Shipping="", address2Shipping="", cityShipping="", stateShipping="", zipCodeShipping="", countryShipping="", phoneShipping="", houseNbShipping="";
                            
                            //read Billing + Shipping info
                            try
                            {
                                StreamReader sr = new StreamReader(@"C:\SnkrBot\Shipping_Billing_Info.csv");
                                //importingData = new Account();
                                string line;
                                string[] column = new string[8];
                                //inorge the 1st line
                                line = sr.ReadLine();
                                //read from 2nd line to end
                                while ((line = sr.ReadLine()) != null)
                                {
                                    column = line.Split(',');
                                    if (column[0].Equals("Billing"))
                                    {
                                        FirstNameBilling = column[1];
                                        LastNameBilling = column[2];
                                        address1Billing = column[3];
                                        address2Billing = "";
                                        cityBilling = column[4];
                                        stateBilling = column[5];
                                        zipCodeBilling = column[6];
                                        countryBilling = column[7];
                                        phoneBilling = "\""+column[8]+"\"";
                                        billingEmail = column[9];
                                        houseNbBilling = "";
                                    }
                                    if (column[0].Equals("Shipping"))
                                    {
                                        FirstNameShipping = column[1];
                                        LastNameShipping = column[2];
                                        address1Shipping = column[3];
                                        address2Shipping = "";
                                        cityShipping = column[4];
                                        stateShipping = column[5];
                                        zipCodeShipping = column[6];
                                        countryShipping = column[7];
                                        phoneShipping ="\""+ column[8]+"\"";
                                        houseNbShipping = "";
                                    }
                                }
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }

                            string friendlyName = SQLConnect.Select("Select FirstName from CreditCard LIMIT 1;");
                            string NameOnCard = SQLConnect.Select("Select FirstName from CreditCard LIMIT 1;") + SQLConnect.Select("Select LastName from CreditCard LIMIT 1;");
                            string DOB = "";
                            string cardType = SQLConnect.Select("Select CardType from CreditCard LIMIT 1;").Equals("V")? "Visa" : "Master";
                            string CardNumber ="\""+ SQLConnect.Select("Select CardNumber from CreditCard LIMIT 1;")+"\"";
                            string CardExpirationMonth = DateTime.Parse(SQLConnect.Select("Select ExpiredDate from CreditCard LIMIT 1;")).ToString("dd-MM-yyyy").Substring(3,2);
                            string CardExpirationYear = DateTime.Parse(SQLConnect.Select("Select ExpiredDate from CreditCard LIMIT 1;")).ToString("dd-MM-yyyy").Substring(6,4);
                            string CardSecurityCode = SQLConnect.Select("Select SecurityCode from CreditCard LIMIT 1;");
                            string CheckoutDelaySeconds="", CheckoutOncePerWebsite = "";

                            //write data in csv file
                            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43}", Site,Email,Password,Size,NotificationEmail,NotificationText,PostiveKW,NegativeKW,StyleNumber,EarlyLinkMonitorKeywords,NewPageMonitorKeywords,FirstNameBilling,LastNameBilling,address1Billing,address2Billing,cityBilling,stateBilling,zipCodeBilling,countryBilling,phoneBilling,houseNbBilling,FirstNameShipping,LastNameShipping,address1Shipping,address2Shipping,cityShipping,stateShipping,zipCodeShipping,countryShipping,phoneShipping,houseNbShipping,friendlyName,NameOnCard,DOB,cardType,CardNumber,CardExpirationMonth,CardExpirationYear,CardSecurityCode,billingEmail,paypalEmail,paypalPassword,CheckoutDelaySeconds,CheckoutOncePerWebsite);
                            csvContent.AppendLine(newLine);

                        }
                        catch (DBConcurrencyException db)
                        {
                            MessageBox.Show(db.ToString());
                        }

                        //csvContent.AppendLine();
                        string csvPath = saveFileDialog1.FileName;
                        File.AppendAllText(csvPath, csvContent.ToString());
                        MessageBox.Show("A CSV file " + csvPath + " was created for importing AIOBot successful!");
                    }
                    else MessageBox.Show("Please Enter file name.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not export a CSV file."+ex);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = "";
            search = InfoTB.Text;
            if (search.Equals("")) MessageBox.Show("Please enter Sneaker ID");
            else if (SQLConnect.Count("Select count(*) from Shoe where shoeid = '" + search + "';") == 0)
            {
                MessageBox.Show("The sneaker ID " + search + " is NOT found!");
            }
            else new SneakerInfo(search).Show();
        }

        private void AddBT_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            foreach (ListViewItem eachItem in SneakerLV.SelectedItems)
            {
                selectedID = eachItem.SubItems[0].Text;
            }
            new SneakerInfo(selectedID).Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in SneakerLV.SelectedItems)
            {
                try
                {
                    
                    SQLConnect.Delete("Delete from Shoe where ShoeID = '" + eachItem.SubItems[0].Text + "';");
                    SneakerLV.Items.Remove(eachItem);
                    MessageBox.Show("The Sneaker ID " + eachItem.SubItems[0].Text + " was removed successful!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Can not remove if records which are related to the shoe was not removed before!");
                }
            }
        }
    }
}
