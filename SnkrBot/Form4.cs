using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnkrBot
{
    public partial class Form4 : Form
    {
        DBConnection SQLConnect = new DBConnection();
        public Form4()
        {
            InitializeComponent();
            Form4_Load();
        }

        private void StaffLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void Form4_Load() {
            StaffLV.Clear();
            StaffLV.View = View.Details;
            StaffLV.GridLines = true;
            StaffLV.FullRowSelect = true;
            //Add column header
            StaffLV.Columns.Add("ID", 80);
            StaffLV.Columns.Add("Name", 100);
            StaffLV.Columns.Add("Gender", 65);
            StaffLV.Columns.Add("Role", 70);
            StaffLV.Columns.Add("Email", 100);
            StaffLV.Columns.Add("Phone", 70);
            StaffLV.Columns.Add("Address", 65);
            DataTable data = SQLConnect.Selects("Select * from STAFF;", 7);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Staff = new ListViewItem(row[0].ToString());
                Staff.SubItems.Add(row[1].ToString()+" "+ row[2].ToString());
                if (row[3].ToString().Equals("M")) Staff.SubItems.Add("Male");
                else if (row[3].ToString().Equals("F")) Staff.SubItems.Add("Female");
                else Staff.SubItems.Add("Unkown");
                Staff.SubItems.Add(row[8].ToString());
                Staff.SubItems.Add(row[6].ToString());
                Staff.SubItems.Add(row[7].ToString());
                Staff.SubItems.Add(row[5].ToString());
                StaffLV.Items.Add(Staff);
                index++;
            }
        }

        private void AddBT_Click(object sender, EventArgs e)
        {
            new AddStaff("").Show();
            Form4_Load();

        }

        private void RemoveBT_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in StaffLV.SelectedItems)
            {

                SQLConnect.Delete("Delete from STAFF where StaffID = '" + eachItem.SubItems[0].Text + "';");
                StaffLV.Items.Remove(eachItem);
                MessageBox.Show("The staff ID " + eachItem.SubItems[0].Text + " was removed successful!");
                
            }
            Form4_Load();
        }

        private void EditBT_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in StaffLV.SelectedItems)
            {

                new AddStaff(eachItem.SubItems[0].Text).Show();
                Form4_Load();
            }
        }

        private void RefreshBT_Click(object sender, EventArgs e)
        {
            Form4_Load();
        }
    }
}
