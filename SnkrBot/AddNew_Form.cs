using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SnkrBot
{
    public partial class AddNew_Form : Form
    {
        DBConnection SQLConnect = new DBConnection();
        string supplierID="";
        public AddNew_Form(ref string id, int number)
        {
            InitializeComponent();
            supplierID = id;
            //number==1 => edit
            if (number== 1)
            {
                Load_Data();
                OKbt.Text = "Update";
            }
            //bumber == 2 => add new
            else if (number == 2)
            {
                supplierIDlb.Text = "be created randomly";
                OKbt.Text = "Add new";
            }
            // number == 3 => Show infor
            else if (number == 3)
            {
                Load_Data();
                OKbt.Text = "Update";
                if (SQLConnect.Count("Select count(*) from Supplier where SupplierID = '" + supplierID + "';") > 0)
                    supplierIDlb.Text = "Supplier ID " + supplierID + " is found!!!";

            }

        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {

        }
        public void Load_Data()
        {
            
            DataTable data = (SQLConnect.Selects("Select * from Supplier where (SupplierID = '" + supplierID + "');", 9));
                foreach (DataRow row in data.Rows)
                {
                    supplierIDlb.Text = row[0].ToString();
                    nameTB.Text = row[1].ToString();
                    websiteTB.Text = row[2].ToString();
                    twitterTB.Text = row[3].ToString();
                    emailTB.Text = row[4].ToString();
                    phoneTB.Text = row[5].ToString();
                    if (row[6].Equals("1")) availableRB.Checked = true;
                    else notAvailableRB.Checked = true;
                    accountTB.Text = row[7].ToString();
                    passwordTB.Text = row[8].ToString();
                    break;
                }
            
        }
        public void Save_data()
        {
            int isGuest = 0;
            if (availableRB.Checked == true) isGuest = 1;

            if (supplierID.Equals(""))
            {
                if (nameTB.Text.Equals(""))
                    MessageBox.Show("Please enter Supplier Name");
                else
                {
                    SQLConnect.Insert("Insert into Supplier values('" + GetCode() + "','" + nameTB.Text + "','" + websiteTB.Text + "','" + twitterTB.Text + "','" + emailTB.Text + "','" + phoneTB.Text + "'," + isGuest + ",'" + accountTB.Text + "','" + passwordTB.Text + "')");
                    MessageBox.Show("A new supplier was created successful!");
                }
            }
            else
            {
                SQLConnect.Update("Update Supplier set SupplierName='" + nameTB.Text + "', websiteAddress= '" + websiteTB.Text + "',twitteraccount='" + twitterTB.Text + "',email='" + emailTB.Text + "',phone='" + phoneTB.Text + "',isguestlogin=" + isGuest + ",loginaccount='" + accountTB.Text + "',loginpassword='" + passwordTB.Text + "' where supplierID='"+supplierID+"';");
                MessageBox.Show("The supplier's information was updated successful!");
                
            }
            this.Close();
        }
        private void resetBT_Click(object sender, EventArgs e)
        {
            supplierIDlb.Text = "be created randomly";
            nameTB.Text="";
            websiteTB.Text = "";
            twitterTB.Text = "";
            emailTB.Text = "";
            phoneTB.Text = "";
            notAvailableRB.Checked = true;
            accountTB.Text = "";
            passwordTB.Text = "";
        }

        private void OKbt_Click(object sender, EventArgs e)
        {
            Save_data();
        }
        public string GetCode()
        {
            //Random rand = new Random(Guid.NewGuid().GetHashCode());
            int rand = new Random(DateTime.Now.Millisecond).Next();
            Thread.Sleep(1);
            return rand.ToString();
        }

        private void cancelBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
