using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace SnkrBot
{
    public partial class SneakerInfo : Form
    {
        DBConnection SQLConnect = new DBConnection();
        string sneakerID = "";
        public SneakerInfo(string id)
        {
            InitializeComponent();
            sneakerID = id;
            ExportBt.Visible = SQLConnect.Select("Select Status from Shoe where ShoeID = '" + id + "';").Equals("Releasing")?true:false;
            load_Data();
        }
        public void load_Data() {

            DataTable data = SQLConnect.Selects("Select * from SHOE where ShoeID = '"+sneakerID+"';", 10);
            //Add first item
            
            foreach (DataRow row in data.Rows)
            {
                sneakerIDtb.Text = row[0].ToString();
                sneakerNametb.Text = row[1].ToString();
                SupplierNametb.Text = SQLConnect.Select("Select SupplierName from Supplier where SupplierID = '"+ row[2].ToString()+"';");
                genderTB.Text = row[3].ToString();
                sizeTb.Text = row[4].ToString();
                colorTb.Text = row[5].ToString();
                //descriptTB.Text = row[6].ToString();
                descriptTB.Text = GetShoeDescription(SupplierNametb.Text, sneakerNametb.Text,sneakerIDtb.Text);
                BuyPriceTb.Text = row[7].ToString();
                SellPriceTB.Text = row[8].ToString();
                StatusTB.Text = row[9].ToString();
                string[] imgLink = GetShoeImage(SupplierNametb.Text, sneakerNametb.Text, sneakerIDtb.Text).Split('\n');
                if (imgLink.Length > 1)
                {
                    pb1.ImageLocation = imgLink[1];
                    pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (imgLink.Length > 2)
                {
                    pb2.ImageLocation = imgLink[2];
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            //ReadFile();
        }


        private void Closebt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = "";
            link = SQLConnect.Select("Select Linktobuy from releasing_shoe, shoe where (releasing_shoe.shoeid = shoe.shoeid) AND (shoe.shoeid ='" + sneakerID + "');");
            System.Diagnostics.Process.Start(link);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SneakerID = "";
            try
                {
                    SneakerID = sneakerIDtb.Text;
                    // Displays a SaveFileDialog so the user can save the Image  
                    // assigned to Button2.  
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"c:\SnkrBot\";
                    saveFileDialog1.Filter = "CSV file|*.csv";
                    saveFileDialog1.Title = "Save an CSV File";
                    saveFileDialog1.FileName =sneakerIDtb.Text;
                    
                    // If the file name is not an empty string open it for saving.
                    if (saveFileDialog1.FileName != "")
                    {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder csvContent = new StringBuilder();

                        csvContent.AppendLine("Site,Email,Password,Size,NotificationEmail,NotificationText,PostiveKW,NegativeKW,StyleNumber,EarlyLinkMonitorKeywords,NewPageMonitorKeywords," +
                            "FirstNameBilling,LastNameBilling,address1Billing,address2Billing,cityBilling,stateBilling,zipCodeBilling,countryBilling,phoneBilling,houseNbBilling," +
                            "FirstNameShipping,LastNameShipping,address1Shipping,address2Shipping,cityShipping,stateShipping,zipCodeShipping,countryShipping,phoneShipping,houseNbShipping," +
                            "friendlyName,NameOnCard,DOB,cardType,CardNumber,CardExpirationMonth,CardExpirationYear,CardSecurityCode,billingEmail,paypalEmail,paypalPassword," +
                            "CheckoutDelaySeconds,CheckoutOncePerWebsite");

                        //data is create in the order
                        string dataLine = "";
                        try
                        {
                            string SupplierID = SQLConnect.Select("Select SupplierID from SHOE where ShoeID = '" + SneakerID + "';");
                            string Site = SQLConnect.Select("Select SupplierName from Supplier where SupplierID = '" + SupplierID + "';");
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
                            string billingEmail = "", paypalEmail, paypalPassword;
                            paypalEmail = SQLConnect.Select("Select PaypalID from PAYPAL LIMIT 1;");
                            paypalPassword = SQLConnect.Select("Select PaypalPassword from PAYPAL LIMIT 1;");

                            string FirstNameBilling = "", LastNameBilling = "", address1Billing = "", address2Billing = "", cityBilling = "", stateBilling = "", zipCodeBilling = "", countryBilling = "", phoneBilling = "", houseNbBilling = "";
                            string FirstNameShipping = "", LastNameShipping = "", address1Shipping = "", address2Shipping = "", cityShipping = "", stateShipping = "", zipCodeShipping = "", countryShipping = "", phoneShipping = "", houseNbShipping = "";

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
                                        phoneBilling = "\"" + column[8] + "\"";
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
                                        phoneShipping = "\"" + column[8] + "\"";
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
                            string cardType = SQLConnect.Select("Select CardType from CreditCard LIMIT 1;").Equals("V") ? "Visa" : "Master";
                            string CardNumber = "\"" + SQLConnect.Select("Select CardNumber from CreditCard LIMIT 1;") + "\"";
                            string CardExpirationMonth = DateTime.Parse(SQLConnect.Select("Select ExpiredDate from CreditCard LIMIT 1;")).ToString("dd-MM-yyyy").Substring(3, 2);
                            string CardExpirationYear = DateTime.Parse(SQLConnect.Select("Select ExpiredDate from CreditCard LIMIT 1;")).ToString("dd-MM-yyyy").Substring(6, 4);
                            string CardSecurityCode = SQLConnect.Select("Select SecurityCode from CreditCard LIMIT 1;");
                            string CheckoutDelaySeconds = "", CheckoutOncePerWebsite = "";

                            //write data in csv file
                            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43}", Site, Email, Password, Size, NotificationEmail, NotificationText, PostiveKW, NegativeKW, StyleNumber, EarlyLinkMonitorKeywords, NewPageMonitorKeywords, FirstNameBilling, LastNameBilling, address1Billing, address2Billing, cityBilling, stateBilling, zipCodeBilling, countryBilling, phoneBilling, houseNbBilling, FirstNameShipping, LastNameShipping, address1Shipping, address2Shipping, cityShipping, stateShipping, zipCodeShipping, countryShipping, phoneShipping, houseNbShipping, friendlyName, NameOnCard, DOB, cardType, CardNumber, CardExpirationMonth, CardExpirationYear, CardSecurityCode, billingEmail, paypalEmail, paypalPassword, CheckoutDelaySeconds, CheckoutOncePerWebsite);
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
                    }
                    else MessageBox.Show("Please Enter file name.");
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Can not export a CSV file.");
                }
            }
        public void ReadFile()
        {
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
                        descriptTB.Text = streamReader.ReadToEnd();
                    }
                }
                // Only get files end .jpeg
                string[] imgFile = Directory.GetFiles(folder, "*.jpeg");
                //MessageBox.Show("The number of files .jpeg is" + imgFile.Length + ".");
                foreach (string dir in imgFile)
                {

                }
                pb1.ImageLocation = imgFile[0];
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                pb2.ImageLocation = imgFile[1];
                pb2.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch (Exception e)
            {
                //MessageBox.Show("Reading file Unsuccessful");
            }
        }
        //API Key
        private static string API_KEY = "AIzaSyDDHzDHu5RVYiWJp1leKdnH1cukRcOwKaE";

        //The custom search engine identifier
        private static string cx = "016116530617786704090:sm0v3hpgqgk";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApplicationName = "SnkrBot",
                ApiKey = API_KEY,
            });


        public string GetShoeDescription(string SiteName, string ShoeID, string Style_Number)
        {
            string query = ShoeID + " " + Style_Number + " " + SiteName + " description";
            string first_result = "";
            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;
            listRequest.Num = 2;
            listRequest.Start = 1;
            IList<Result> results = new List<Result>();
            results = listRequest.Execute().Items;
            if (results != null)
            {
                foreach (var result in results)
                {
                    first_result = first_result + "\n" + result.Snippet;
                }

            }
            else first_result = "There is no information about " + ShoeID;
            return first_result;
        }
        public string GetShoeImage(string SiteName, string ShoeID, string Style_Number)
        {
            string query = ShoeID + " " + Style_Number + " " + SiteName + " image";
            string first_result = "";
            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;
            listRequest.Num = 5;
            listRequest.Start = 1;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.ImgSize = CseResource.ListRequest.ImgSizeEnum.Medium;
            IList<Result> results = new List<Result>();
            results = listRequest.Execute().Items;
            if (results != null)
            {
                foreach (var result in results)
                {
                    string[] SubRS = result.Link.Split('/');
                    string[] Sub1RS = first_result.Split('/');
                    if (!SubRS[SubRS.Length-1].Equals(Sub1RS[Sub1RS.Length-1]))
                        first_result = first_result + "\n" + result.Link;
                }
            }
            else first_result = "There is no information about " + ShoeID;
            return first_result;
        }
        /*
        //image -> image binary
        public static Image LoadImageBinary(string url)
        {
            try
            {
                WebClient webClient = new WebClient { Proxy = null };
                byte[] imageFile = webClient.DownloadData(url);
                MemoryStream stream = new MemoryStream(imageFile);
                Image img = Image.FromStream(stream);

                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading image.");
            }
        }
        public Image ImageBinary = Form1.LoadImageBinary("uri");
        */

    }
}
