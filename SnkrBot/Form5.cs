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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Form5_Load();
        }

        private void CharityLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form5_Load()
        {

            CharityLV.View = View.Details;
            CharityLV.GridLines = true;
            CharityLV.FullRowSelect = true;
            //Add column header
            CharityLV.Columns.Add("ID", 50);
            CharityLV.Columns.Add("Name", 100);
            CharityLV.Columns.Add("Website", 100);
            CharityLV.Columns.Add("Email", 100);
            CharityLV.Columns.Add("Phone", 60);
            CharityLV.Columns.Add("Paypal", 75);
            CharityLV.Columns.Add("Account", 65);
        }
    }
}
