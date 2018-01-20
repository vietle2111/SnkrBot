using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SnkrBot
{
    public partial class Form7 : Form
    {
        DBConnection SQLConnect = new DBConnection();
        int index = 0;
        public Form7()
        {
            InitializeComponent();
            LoadData();
        }

        private void PaypalLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void PaypalLV_Click(object sender, EventArgs e)
        {
            var FirstselectedItem = PaypalLV.SelectedItems[0];
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            if (NameTB.Text == "") MessageBox.Show("Please enter Paypal Name.");
            else if (!AddressTB.Text.Contains("@") || AddressTB.Text.EndsWith("@") || AddressTB.Text.StartsWith("@") || !AddressTB.Text.Contains(".") || AddressTB.Text.EndsWith(".") || AddressTB.Text.StartsWith(".")) MessageBox.Show("Paypal Address is invalid. Please Enter again.");
            else if (PasswordTB.Text.Length <= 6) MessageBox.Show("Password is too short. Please enter again!");
            else
            {
                SQLConnect.Insert("Insert into PAYPAL values('" + AddressTB.Text + "','" + NameTB.Text + "','" + PasswordTB.Text + "')");
                //Add items in the listview
                LoadData();
            }
        }

        private void LoadData()
        {
            PaypalLV.Clear();
            PaypalLV.View = View.Details;
            PaypalLV.GridLines = true;
            PaypalLV.FullRowSelect = true;
            //Add column header
            PaypalLV.Columns.Add("No.", 30);
            PaypalLV.Columns.Add("Paypal Name", 100);
            PaypalLV.Columns.Add("Paypal Address", 150);

            DataTable data = SQLConnect.Selects("Select PaypalName, PaypalID from Paypal", 2);
            //Add first item
            index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Paypal = new ListViewItem(index.ToString());
                Paypal.SubItems.Add(row[0].ToString());
                Paypal.SubItems.Add(row[1].ToString());
                PaypalLV.Items.Add(Paypal);
                index++;
            }
        }

        private void RemoveBT_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem eachItem in PaypalLV.SelectedItems)
            {
                PaypalLV.Items.Remove(eachItem);
                SQLConnect.Delete("Delete from Paypal where PaypalID = '"+eachItem.SubItems[2].Text+"';");
            }
            
        }
    }
}
