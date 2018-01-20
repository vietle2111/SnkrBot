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
    public partial class New_Release_Form : Form
    {
        DBConnection SQLConnect = new DBConnection();
        public New_Release_Form()
        {
            InitializeComponent();
            LoadData();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            //SiteName combobox
            DataTable SiteName_data = SQLConnect.Selects("Select SupplierID, SupplierName from SUPPLIER", 2);
            // Create a List to store our KeyValuePairs
            List<KeyValuePair<string, string>> dataComboBox1 = new List<KeyValuePair<string, string>>();
            //add the first data to the list
            dataComboBox1.Add(new KeyValuePair<string, string>("0", "Select a site name"));

            //Add first item
            int index = 1;
            foreach (DataRow row in SiteName_data.Rows)
            {
                // Add data to the List
                dataComboBox1.Add(new KeyValuePair<string, string>(row[0].ToString(), row[1].ToString()));
                index++;
            }
            SiteNamecb.DataSource = new BindingSource(dataComboBox1, null);
            SiteNamecb.DisplayMember = "Value";
            SiteNamecb.ValueMember = "Key";

            //Size shoe combobox
            DataTable Size_data = new DataTable();
            Size_data.Columns.Add("Number");
            Size_data.Columns.Add("Size");
            DataRow workRow;
            for (int i = 7; i <= 12; i++)
            {
                workRow = Size_data.NewRow();
                workRow[0] = i;
                workRow[1] = i.ToString();
                Size_data.Rows.Add(workRow);
            }
            // Create a List to store our KeyValuePairs
            List<KeyValuePair<string, string>> dataComboBox2 = new List<KeyValuePair<string, string>>();
            //add the first data to the list
            dataComboBox2.Add(new KeyValuePair<string, string>("0", "Select a shoe size"));

            //Add first item
            index = 1;
            foreach (DataRow row in Size_data.Rows)
            {
                // Add data to the List
                dataComboBox2.Add(new KeyValuePair<string, string>(row[0].ToString(), row[1].ToString()));
                index++;
            }
            Sizecb.DataSource = new BindingSource(dataComboBox2, null);
            Sizecb.DisplayMember = "Value";
            Sizecb.ValueMember = "Key";

           
        }

        private void Cancelbt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKbt_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, string> selectedPair_SiteName = (KeyValuePair<string, string>)SiteNamecb.SelectedItem;
            KeyValuePair<string, string> selectedPair_ShoeSize = (KeyValuePair<string, string>)Sizecb.SelectedItem;
            if (selectedPair_SiteName.Key.ToString().Equals("0")) { MessageBox.Show("Please select a site name"); }
            else if (ShoeNametb.Text.Equals("")) MessageBox.Show("Please enter shoe name");
            else if (selectedPair_ShoeSize.Key.ToString().Equals("0")) { MessageBox.Show("Please select a shoe size"); }
            else if (StyleNumbertb.Text.Equals("")) { MessageBox.Show("Please enter style number"); }
            else if (Linktb.Text.Equals("")) { MessageBox.Show("Please enter an early link monitor"); }
            else {
                if (SQLConnect.Count("Select Count(*) FROM SHOE WHERE ShoeID = '" + StyleNumbertb + "';") == 0)
                {
                    SQLConnect.Insert("Insert into SHOE(ShoeID, ShoeName, SupplierID, Size, Status) values('" + StyleNumbertb.Text + "','" + ShoeNametb.Text + "','" + selectedPair_SiteName.Key + "'," + selectedPair_ShoeSize.Value + ",'Releasing');");
                    //MessageBox.Show(GetCode() + "', '" + column[3] + "','" + column[6] + " " + column[7] + "','" + column[6] + "','" + column[4]);
                    SQLConnect.Insert("Insert into RELEASING_SHOE values('" + GetCode() + "', '" + StyleNumbertb.Text + "','" + ReleaseDTP.Value.ToString("yyyy-MM-dd") + " " + hour.Text + ":" + minute.Text + ":" + second.Text + "','" + ReleaseDTP.Value.ToString("yyyy-MM-dd") + "','" + Linktb.Text + "');");
                    MessageBox.Show("Add a new release successful!!!");
                    this.Close();

                }
                else MessageBox.Show("The shoe style number is stored in database. Please chack style number again.");
                
            }
            
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
