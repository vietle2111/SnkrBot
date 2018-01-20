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
    public partial class Billing_Shipping : Form
    {
        bool CB = true;
        public Billing_Shipping()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LoadData();
            
        }
        public void LoadData() {
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
                        
                        FirstNameBtb.Text = column[1];
                        LastNameBtb.Text = column[2];
                        StreetBtb.Text = column[3];
                        CityBtb.Text = column[4];
                        StateBtb.Text = column[5];
                        ZipcodeBtb.Text = column[6];
                        CountryBtb.Text = column[7];
                        PhoneBrb.Text = column[8];
                        EmailBtb.Text = column[9];
                    }
                    if (column[0].Equals("Shipping"))
                    {
                        FirstNameStb.Text = column[1];
                        LastNameStb.Text = column[2];
                        StreetStb.Text = column[3];
                        CityStb.Text = column[4];
                        StateStb.Text = column[5];
                        ZipcodeStb.Text = column[6];
                        CountryStb.Text = column[7];
                        PhoneStb.Text = column[8];
                        EmailStb.Text = column[9];
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            PathTB.Text = @"C:\SnkrBot\Shipping_Billing_Info.csv";
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Billing_Shipping_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BillforShipcb_CheckStateChanged(object sender, EventArgs e)
        {/*
            if (CB == false)
            {

                this.StartPosition = FormStartPosition.CenterScreen;
               //this.CenterToScreen();
                this.Size = new Size(300, 450);
                Closebt.Location = new Point(230, 376);
                SaveBillbt.Location = new Point(122, 376);
                
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
                this.Size = new Size(600, 450);
                this.Show();
                Closebt.Location = new Point(519, 376);
                SaveBillbt.Location = new Point(185, 376);
            }
            CB = !CB;*/
        }

        

        private void StreetBtb_Click(object sender, EventArgs e)
        {
            if (StreetBtb.Text.Equals("number and street name"))
                StreetBtb.Text="";
        }

        private void StreetStb_Click(object sender, EventArgs e)
        {
            if (StreetStb.Text.Equals("number and street name"))  StreetStb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FirstNameBtb.Text = "";
            LastNameBtb.Text = "";
            StreetBtb.Text = "number and treet name";
            CityBtb.Text = "";
            StateBtb.Text = "";
            ZipcodeBtb.Text = "";
            CountryBtb.Text = "";
            PhoneBrb.Text = "";
            EmailBtb.Text = "";

            FirstNameStb.Text = "";
            LastNameStb.Text = "";
            StreetStb.Text = "number and treet name";
            CityStb.Text = "";
            StateStb.Text = "";
            ZipcodeStb.Text = "";
            CountryStb.Text = "";
            PhoneStb.Text = "";
            EmailStb.Text = "";
        }

        private void ShipAdcb_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void SaveBillbt_Click(object sender, EventArgs e)
        {
            
            if (PathTB.Text.Equals(""))
            {
                MessageBox.Show("Choose a destination path before saving information.");
            }
            else
            {
                
                //before your loop
                var csv = new StringBuilder();

                //in your loop
                string first = "Billing", second = FirstNameBtb.Text, third = LastNameBtb.Text, forth = StreetBtb.Text, 
                    fifth = CityBtb.Text.ToString(), sixth = StateBtb.Text, seventh = ZipcodeBtb.Text, 
                    eighth = CountryBtb.Text, nineth = PhoneBrb.Text, tenth = EmailBtb.Text, eleventh = Environment.NewLine;
                try
                {
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", first, second, third, forth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh);
                    csv.Append(newLine);
                    MessageBox.Show("Save Billing Information Successful!");
                }
                catch (FormatException fe)
                {

                    MessageBox.Show("Error! Save Billing Information Unsuccessful!");
                }
                if (ShipAdcb.Checked == false)
                {
                    first = "Shipping";
                }
                else
                {
                    first = "Shipping"; second = FirstNameStb.Text; third = LastNameStb.Text; forth = StreetStb.Text;
                    fifth = CityStb.Text.ToString(); sixth = StateStb.Text; seventh = ZipcodeStb.Text;
                    eighth = CountryStb.Text; nineth = PhoneStb.Text; tenth = EmailStb.Text; eleventh = Environment.NewLine;
                }
                try
                { 
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", first, second, third, forth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh);
                    csv.Append(newLine);
                        MessageBox.Show("Save Shipping Information Successful!");
                }
                catch (FormatException fe)
                {

                    MessageBox.Show("Error! Save Shipping Information Unsuccessful!");
                }
                //after your loop
                //File.WriteAllText(PathTB.Text, csv.ToString());
                File.AppendAllText(PathTB.Text, csv.ToString());
                this.Close();
            }
        }

        
        private void WriteDataCSV(string path)
        {

        }

        private void PathBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg;

            fdlg = new OpenFileDialog();
            fdlg.Title = "Import a CSV file";
            fdlg.InitialDirectory = @"c:\SnkrBot\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                PathTB.Text = fdlg.FileName;
            }
        }
    }
}
