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
    public partial class AddStaff : Form
    {
        DBConnection SQLConnect = new DBConnection();
        String StaffID = "";
        public AddStaff(string ID)
        {
            InitializeComponent();
            if (!ID.Equals("")) {
                StaffID = ID;
                staffIDlb.Text = "Staff: " + StaffID;
                FnameTB.Text = SQLConnect.Select("Select FirstName from Staff where StaffID = '"+StaffID+"';");
                LnameTB.Text = SQLConnect.Select("Select LastName from Staff where StaffID = '" + StaffID + "';");
                emailTB.Text = SQLConnect.Select("Select Email from Staff where StaffID = '" + StaffID + "';");
                phoneTB.Text = SQLConnect.Select("Select Phone from Staff where StaffID = '" + StaffID + "';");
                RoleTB.Text = SQLConnect.Select("Select Role from Staff where StaffID = '" + StaffID + "';");
                AddessTB.Text = SQLConnect.Select("Select Address from Staff where StaffID = '" + StaffID + "';");
                passwordTB.Text = SQLConnect.Select("Select Password from Staff where StaffID = '" + StaffID + "';");
                MaleRB.Checked = (SQLConnect.Select("Select Gender from Staff where StaffID = '" + StaffID + "';").Equals("M"))? true:false;
                dobDTP.Value = DateTime.Parse(SQLConnect.Select("Select DOB from Staff where StaffID = '" + StaffID + "';"));
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void resetBT_Click(object sender, EventArgs e)
        {
            FnameTB.Text = "";
            LnameTB.Text = "";
            emailTB.Text = "";
            phoneTB.Text = "";
            RoleTB.Text = "";
            AddessTB.Text = "";
            passwordTB.Text = "";
        }

        private void OKbt_Click(object sender, EventArgs e)
        {
            
                try
                {
                if (StaffID.Equals(""))
                {
                    string ID = GetCode();
                    SQLConnect.Insert("Insert into STAFF values('" + ID + "','" + FnameTB.Text + "','" + LnameTB.Text + "','" + (MaleRB.Checked == true ? "M" : "F") + "','" + dobDTP.Value.ToString("yyyy-MM-dd") + "','" + AddessTB.Text + "','" + emailTB.Text + "','" + phoneTB.Text + "','" + RoleTB.Text + "','" + ID + "','" + passwordTB.Text + "')");
                    MessageBox.Show("Add a new staff successful!");
                }
                else
                {
                    SQLConnect.Insert("Update STAFF SET FirstName='" + FnameTB.Text + "', LastName='" + LnameTB.Text + "',Gender = '" + (MaleRB.Checked == true ? "M" : "F") + "',DOB = '" + dobDTP.Value.ToString("yyyy-MM-dd") + "',Address = '" + AddessTB.Text + "',Email = '" + emailTB.Text + "', Phone='" + phoneTB.Text + "',Role = '" + RoleTB.Text + "',UserName = '" + StaffID + "',Password = '" + passwordTB.Text + "' where StaffID = '"+ StaffID+"';");
                    MessageBox.Show("Update staff's information successful!");
                }
                    this.Close();
                }
                catch (DBConcurrencyException db)
                {
                    MessageBox.Show("Unsuccessful!");
                }

        }

        private void cancelBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string GetCode()
        {
            //Random rand = new Random(Guid.NewGuid().GetHashCode());
            int rand = new Random(DateTime.Now.Millisecond).Next();
            Thread.Sleep(1);
            return rand.ToString();
        }
    }
}
