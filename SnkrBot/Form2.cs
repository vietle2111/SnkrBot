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
    public partial class Form2 : Form
    {
        DBConnection SQLConnect = new DBConnection();
        public Form2()
        {
            InitializeComponent();
            Form2_Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id="";
            (new AddNew_Form(ref id,2)).Show();
            Form2_Load();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Load() {
            SupplierLV.Clear();
            SupplierLV.View = View.Details;
            SupplierLV.GridLines = true;
            SupplierLV.FullRowSelect = true;
            //Add column header
            SupplierLV.Columns.Add("ID", 50);
            SupplierLV.Columns.Add("Name", 70);
            SupplierLV.Columns.Add("Website", 140);
            SupplierLV.Columns.Add("Twitter", 70);
            SupplierLV.Columns.Add("Email", 120);
            SupplierLV.Columns.Add("Phone", 100);
            //load date from Database

            DataTable data = SQLConnect.Selects("Select SupplierID, SupplierName, WebsiteAddress, TwitterAccount, Email, Phone from SUPPLIER;", 6);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem Supplier = new ListViewItem(row[0].ToString());
                Supplier.SubItems.Add(row[1].ToString());
                Supplier.SubItems.Add(row[2].ToString());
                Supplier.SubItems.Add(row[3].ToString());
                Supplier.SubItems.Add(row[4].ToString());
                Supplier.SubItems.Add(row[5].ToString());
                SupplierLV.Items.Add(Supplier);
                index++;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InfoTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchID = InfoTB.Text;
            if (SQLConnect.Count("Select count(*) from Supplier where SupplierID = '" + searchID + "';") <= 0)
            {
                MessageBox.Show("Supplier " + searchID + " is NOT found! ");
            }
            else (new AddNew_Form(ref searchID, 3)).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            foreach (ListViewItem eachItem in SupplierLV.SelectedItems)
            {
                selectedID = eachItem.SubItems[0].Text;
                
            }
            AddNew_Form Edit_Form = new AddNew_Form(ref selectedID, 1);
                Edit_Form.Text = "Edit";
                Edit_Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in SupplierLV.SelectedItems)
            {
                SQLConnect.Delete("Delete from Supplier where SupplierID = '" + eachItem.SubItems[0].Text + "';");
                SupplierLV.Items.Remove(eachItem);
                MessageBox.Show("The supplier ID "+eachItem.SubItems[0].Text+" was removed successful!");
            }
        }

        private void refreshBT_Click(object sender, EventArgs e)
        {
            SupplierLV.Clear();
            Form2_Load();
        }
    }
}
