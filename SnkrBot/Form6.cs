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
    public partial class Form6 : Form
    {
        DBConnection SQLConnect = new DBConnection();
        public Form6()
        {
            InitializeComponent();
            
            Form6_Load();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form6_Load()
        {
            CCLV.Clear();
            CCLV.View = View.Details;
            CCLV.GridLines = true;
            CCLV.FullRowSelect = true;
            //Add column header
            CCLV.Columns.Add("No.", 30);
            CCLV.Columns.Add("Name", 100);
            CCLV.Columns.Add("Card Number", 150);
            CCLV.Columns.Add("Type", 50);
            CCLV.Columns.Add("Expired Date", 150);
            DataTable data = SQLConnect.Selects("Select * from CreditCard", 6);
            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                //Add items in the listview
                ListViewItem CreditCard = new ListViewItem(index.ToString());
                CreditCard.SubItems.Add(row[1].ToString()+" "+row[2].ToString());
                CreditCard.SubItems.Add(row[0].ToString());
                CreditCard.SubItems.Add(row[3].ToString());
                CreditCard.SubItems.Add(row[4].ToString().Substring(2,7));
                CCLV.Items.Add(CreditCard);
                index++;
            }

        }

        private void resetBT_Click(object sender, EventArgs e)
        {
            FirstNametb.Text = "";
            LastNametb.Text = "";
            CardNumbertb.Text = "";
            Securitytb.Text = "";
            VisaRb.Checked = true;
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            if (FirstNametb.Text.Equals("")) MessageBox.Show("Enter First Name");
            else if (LastNametb.Text == "") MessageBox.Show("Enter Last Name");
            else if (!isValidCard(CardNumbertb.Text)) MessageBox.Show("Invalid card number. Please check again!");
            else if ((VisaRb.Checked == true) && (!CardNumbertb.Text.StartsWith("4"))) MessageBox.Show("Visa Card starts with digit 4. Please check Card Number again!");
            else if ((MasterRb.Checked == true) && (!CardNumbertb.Text.StartsWith("5"))) MessageBox.Show("Master Card starts with digit 5. Please check Card Number again!");
            else if (!isValidDate(ExMYtb.Text))  MessageBox.Show("Expired Month/Year is invalid.");
            else if (!isSecurityCode(Securitytb.Text)) MessageBox.Show("Security code is invalid.");
            else
            {
                char Type = 'V';
                if (MasterRb.Checked == true) Type = 'M'; 
                SQLConnect.Insert("Insert into CreditCard values('"+CardNumbertb.Text+"','"+FirstNametb.Text+"','"+LastNametb.Text+"','"+Type+"','20"+ExMYtb.Text.Substring(3,2)+"-"+ExMYtb.Text.Substring(0,2)+"-01','"+Securitytb.Text+"');");
                MessageBox.Show("A Credit card was added successful.");
                Form6_Load();
            }
        }
        private bool isValidCard(string card) {
            bool isValid = true;
            if (card.Length != 16) isValid = false;
            for(int i=0; i < 16; i++)
            {
                if ((card[i] < '0')||(card[i] > '9')) isValid = false;
            }
            return isValid;
        }
        private bool isSecurityCode(string code)
        {
            bool isValid = true;
            if (code.Length >5) isValid = false;
            for (int i = 0; i < code.Length; i++)
            {
                if ((code[i] < '0') || (code[i] > '9')) isValid = false;
            }
            return isValid;
        }
        private bool isValidDate(string date)
        {
            bool isValid = true;
            if (date.Length != 5) isValid = false;
            for (int i = 0; i < 5; i++)
            {
                if (i == 2) i++;
                if ((date[i] < '0') || (date[i] > '9')) isValid = false;
            }
            if (!date[2].Equals('/')) isValid = false;
            return isValid;
        }
        private string getMonthYear(string date)
        {
            DateTime dt = DateTime.Parse(date);
            return dt.ToString("dd/mm/yyyy");
        }

        private void RemoveBT_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in CCLV.SelectedItems)
            {
                CCLV.Items.Remove(eachItem);
                SQLConnect.Delete("Delete from CreditCard where CardNumber = '" + eachItem.SubItems[2].Text + "';");
            }
        }

        private void closeBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
