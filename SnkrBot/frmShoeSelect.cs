using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SneakerBot.WebScraping.Model;
using SneakerBot.WebScraping.Service;
using SneakerBot.WebScraping.Presentation;

namespace SnkrBot
{
    public partial class frmShoeSelect : Form,IWebScraperView
    {
        private const int PAGESIZE = 4;
        private WebScraperPresenter _presenter;
        private WebScraperService _service;

        private Color SelectedColour = Color.MistyRose;
        private Color DefaultColour = Color.Transparent;
        public frmShoeSelect()
        {
            InitializeComponent();
            frmShoeSelection_Load();
        }
        private void frmShoeSelection_Load()
        {
            _service = new WebScraperService();
            _presenter = new WebScraperPresenter(this, _service);
            _presenter.DisplayWebsites();
            _presenter.PageSize = PAGESIZE;

            staMessage.Text = "Ready";

            _service.SelectionCommittedEvent += TestEBaySubSystemHandler;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void DisplayWebsites(string[] websites)
        {
            lstWebsites.DataSource = websites;
            lstWebsites.SelectedIndex = -1;
        }

        #region INTERFACE IMPLEMENTATION
        public string Message
        {
            set
            {
                staMessage.Text = value;
            }
        }
        public void ClearFilteredDisplay()
        {
            picFilteredShoe1.Image = null;
            picFilteredShoe2.Image = null;
            picFilteredShoe3.Image = null;
            picFilteredShoe4.Image = null;
            txtFilteredWebsite1.Text = txtFilteredWebsite2.Text
                = txtFilteredShoeName1.Text = txtFilteredShoeName2.Text
                = txtFilteredDescription1.Text = txtFilteredDescription2.Text
                = "";
            txtFilteredWebsite3.Text = txtFilteredWebsite4.Text
                = txtFilteredShoeName3.Text = txtFilteredShoeName4.Text
                = txtFilteredDescription3.Text = txtFilteredDescription4.Text
                = "";
            chkFilteredSelected1.Checked = chkFilteredSelected2.Checked = false;
            chkFilteredSelected3.Checked = chkFilteredSelected4.Checked = false;

            staMessage.Text = "Ready";
        }
        public void DisplayFilteredPageCount(int count)
        {
            scrFilteredPage.Value = 0;
            scrFilteredPage.Maximum = count > 0 ? count - 1 : count;
            btnLoad.Enabled = true;
        }
        public void DisplayFilteredPage(ShoeModel[] shoes)
        {
            ShoeModel tmpShoe;

            tmpShoe = shoes[0];
            if (tmpShoe.GetType().Equals(typeof(NullShoeModel)))
            {
                grpFilteredShoe1.Visible = false;
            }
            else
            {
                grpFilteredShoe1.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picFilteredShoe1.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picFilteredShoe1.Image = null;
                //}
                picFilteredShoe1.Image = tmpShoe.ImageBinary;
                txtFilteredWebsite1.Text = tmpShoe.WebsiteName;
                txtFilteredShoeName1.Text = tmpShoe.ModelName;
                txtFilteredDescription1.Text = tmpShoe.Description;
                chkFilteredSelected1.Checked = tmpShoe.Selected;

                //MessageBox.Show(tmpShoe.ModelName, "", MessageBoxButtons.YesNoCancel);
            }

            tmpShoe = shoes[1];
            if (tmpShoe.GetType().Equals(typeof(NullShoeModel)))
            {
                grpFilteredShoe2.Visible = false;
            }
            else
            {
                grpFilteredShoe2.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picFilteredShoe2.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picFilteredShoe2.Image = null;
                //}
                picFilteredShoe2.Image = tmpShoe.ImageBinary;
                txtFilteredWebsite2.Text = tmpShoe.WebsiteName;
                txtFilteredShoeName2.Text = tmpShoe.ModelName;
                txtFilteredDescription2.Text = tmpShoe.Description;
                chkFilteredSelected2.Checked = tmpShoe.Selected;
            }

            if ((shoes.Length<3)||(shoes[2].GetType().Equals(typeof(NullShoeModel))))
            {
                grpFilteredShoe3.Visible = false;
            }
            else
            {
                tmpShoe = shoes[2];
                grpFilteredShoe3.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picFilteredShoe3.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picFilteredShoe3.Image = null;
                //}
                picFilteredShoe3.Image = tmpShoe.ImageBinary;
                txtFilteredWebsite3.Text = tmpShoe.WebsiteName;
                txtFilteredShoeName3.Text = tmpShoe.ModelName;
                txtFilteredDescription3.Text = tmpShoe.Description;
                chkFilteredSelected3.Checked = tmpShoe.Selected;
            }
            
            if ((shoes.Length<4)||(shoes[3].GetType().Equals(typeof(NullShoeModel))))
            {
                grpFilteredShoe4.Visible = false;
            }
            else
            {
                tmpShoe = shoes[3];
                grpFilteredShoe4.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picFilteredShoe3.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picFilteredShoe3.Image = null;
                //}
                picFilteredShoe4.Image = tmpShoe.ImageBinary;
                txtFilteredWebsite4.Text = tmpShoe.WebsiteName;
                txtFilteredShoeName4.Text = tmpShoe.ModelName;
                txtFilteredDescription4.Text = tmpShoe.Description;
                chkFilteredSelected4.Checked = tmpShoe.Selected;
            }

        }
        public void ClearSelectedDisplay()
        {
            picSelectedShoe1.Image = null;
            picSelectedShoe2.Image = null;
            picSelectedShoe3.Image = null;
            picSelectedShoe4.Image = null;
            txtSelectedWebsite1.Text = txtSelectedWebsite2.Text
                = txtSelectedShoeName1.Text = txtSelectedShoeName2.Text
                = txtSelectedDescription1.Text = txtSelectedDescription2.Text
                = "";
            txtSelectedWebsite3.Text = txtSelectedWebsite4.Text
                = txtSelectedShoeName3.Text = txtSelectedShoeName4.Text
                = txtSelectedDescription3.Text = txtSelectedDescription4.Text
                = "";
            chkSelectedSelected1.Checked = chkSelectedSelected2.Checked = false;
            chkSelectedSelected3.Checked = chkSelectedSelected4.Checked = false;
            staMessage.Text = "Ready";
        }
        public void DisplaySelectedPageCount(int count)
        {
            scrSelectedPage.Maximum = (count/2) > 0 ? ((count%2)>0?count/2:count/2-1) : 0;
            scrSelectedPage.Value = scrSelectedPage.Value > scrSelectedPage.Maximum ? scrSelectedPage.Maximum : scrSelectedPage.Value;
        }
        public void DisplaySelectedShoes(ShoeModel[] shoes)
        {
            ShoeModel tmpShoe;

            tmpShoe = shoes[0];
            if (tmpShoe.GetType().Equals(typeof(NullShoeModel)))
            {
                grpSelectedShoe1.Visible = false;
            }
            else
            {
                grpSelectedShoe1.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picSelectedShoe1.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picSelectedShoe1.Image = null;
                //}
                picSelectedShoe1.Image = tmpShoe.ImageBinary;
                txtSelectedWebsite1.Text = tmpShoe.WebsiteName;
                txtSelectedShoeName1.Text = tmpShoe.ModelName;
                txtSelectedDescription1.Text = tmpShoe.Description;
                chkSelectedSelected1.Checked = tmpShoe.Selected;
            }

            tmpShoe = shoes[1];
            if (tmpShoe.GetType().Equals(typeof(NullShoeModel)))
            {
                grpSelectedShoe2.Visible = false;
            }
            else
            {
                grpSelectedShoe2.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picSelectedShoe2.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picSelectedShoe2.Image = null;
                //}
                picSelectedShoe2.Image = tmpShoe.ImageBinary;
                txtSelectedWebsite2.Text = tmpShoe.WebsiteName;
                txtSelectedShoeName2.Text = tmpShoe.ModelName;
                txtSelectedDescription2.Text = tmpShoe.Description;
                chkSelectedSelected2.Checked = tmpShoe.Selected;
            }
            
            if ((shoes.Length < 3)||(shoes[2].GetType().Equals(typeof(NullShoeModel))))
            {
                grpSelectedShoe3.Visible = false;
            }
            else
            {
                tmpShoe = shoes[2];
                grpSelectedShoe3.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picSelectedShoe3.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picSelectedShoe3.Image = null;
                //}
                picSelectedShoe3.Image = tmpShoe.ImageBinary;
                txtSelectedWebsite3.Text = tmpShoe.WebsiteName;
                txtSelectedShoeName3.Text = tmpShoe.ModelName;
                txtSelectedDescription3.Text = tmpShoe.Description;
                chkSelectedSelected3.Checked = tmpShoe.Selected;
            }
            
            if ((shoes.Length<4)||(tmpShoe.GetType().Equals(typeof(NullShoeModel))))
            {
                grpSelectedShoe4.Visible = false;
            }
            else
            {
                tmpShoe = shoes[3];
                grpSelectedShoe4.Visible = true;

                //if (tmpShoe.ImageURI != "")
                //{
                //    picSelectedShoe4.Load(tmpShoe.ImageURI);
                //}
                //else
                //{
                //    picSelectedShoe4.Image = null;
                //}
                picSelectedShoe4.Image = tmpShoe.ImageBinary;
                txtSelectedWebsite4.Text = tmpShoe.WebsiteName;
                txtSelectedShoeName4.Text = tmpShoe.ModelName;
                txtSelectedDescription4.Text = tmpShoe.Description;
                chkSelectedSelected4.Checked = tmpShoe.Selected;
            }
        }
        #endregion

        #region COMMAND BUTTONS
        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            _presenter.LoadData(this);
        }
        private void btnReviewSelection_Click(object sender, EventArgs e)
        {
            tabSearchAndSelect.SelectedIndex = 1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabSearchAndSelect.SelectedIndex = 0;
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            _presenter.ClearSelection();
        }

        private void btnFilterByKeyword_Click(object sender, EventArgs e)
        {
            _presenter.FilterDisplay(txtKeywordsString.Text, chkAndSearch.Checked);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtKeywordsString.Text = "";
            _presenter.FilterDisplay("");
        }

        private void btnCommitSelected_Click(object sender, EventArgs e)
        {
            btnCommitSelected.Enabled = false;
            _presenter.CommitSelections();
            btnCommitSelected.Enabled = true;
        }
        #endregion

        #region GUI Events

        private void scrFilteredPage_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.DisplayFilteredPage(scrFilteredPage.Value);
        }
        private void chkFilteredSelected1_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateFilteredShoe(0, chkFilteredSelected1.Checked);

            if (chkFilteredSelected1.Checked)
            {
                grpFilteredShoe1.BackColor = SelectedColour;
            }
            else
            {
                grpFilteredShoe1.BackColor = DefaultColour;
            }
        }
        private void chkFilteredSelected2_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateFilteredShoe(1, chkFilteredSelected2.Checked);

            if (chkFilteredSelected2.Checked)
            {
                grpFilteredShoe2.BackColor = SelectedColour;
            }
            else
            {
                grpFilteredShoe2.BackColor = DefaultColour;
            }
        }
        private void tabSearchAndSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSearchAndSelect.SelectedIndex == 1)
            {
                _presenter.UpdateSelection(scrSelectedPage.Value);
            }
        }
        private void scrSelectedPage_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.DisplaySelectedPage(scrSelectedPage.Value);
        }
        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            _presenter.ClearSelection();
        }
        private void chkSelectedSelected1_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateSelectedShoe(scrSelectedPage.Value, 0, chkSelectedSelected1.Checked);

            //if (chkSelectedSelected1.Checked)
            //{
            //    grpSelectedShoe1.BackColor = SelectedColour;
            //}
            //else
            //{
            //    grpSelectedShoe1.BackColor = DefaultColour;
            //}
        }
        private void chkSelectedSelected2_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateSelectedShoe(scrSelectedPage.Value, 1, chkSelectedSelected2.Checked);

            //if (chkSelectedSelected2.Checked)
            //{
            //    grpSelectedShoe2.BackColor = SelectedColour;
            //}
            //else
            //{
            //    grpSelectedShoe2.BackColor = DefaultColour;
            //}
        }
        #endregion

        private void TestEBaySubSystemHandler(object sender, CommittedSelectionEventArgs e)
        {
            ShoeModel[] selectedShoes = e.SelectedShoes;

            string tmp = "EBay Subsystem handles SelectionCommittedEvent:\n\n";

            foreach (ShoeModel shoe in selectedShoes)
            {
                tmp += shoe + new string('-', 15) + "\n";
            }

            MessageBox.Show(tmp, "EBay Subsystem Example");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void grpFilteredShoe2_Enter(object sender, EventArgs e)
        {

        }

        private void txtFilteredDescription2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilteredShoeName2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilteredWebsite2_TextChanged(object sender, EventArgs e)
        {

        }

        private void picFilteredShoe2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkAndSearch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtKeywordsString_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void grpFilteredShoe1_Enter(object sender, EventArgs e)
        {

        }

        private void txtFilteredDescription1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilteredShoeName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilteredWebsite1_TextChanged(object sender, EventArgs e)
        {

        }

        private void picFilteredShoe1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lstWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void grpSelectedShoe2_Enter(object sender, EventArgs e)
        {

        }

        private void txtSelectedDescription2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSelectedShoeName2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSelectedWebsite2_TextChanged(object sender, EventArgs e)
        {

        }

        private void picSelectedShoe2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void grpSelectedShoe1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSelectedDescription1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSelectedShoeName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSelectedWebsite1_TextChanged(object sender, EventArgs e)
        {

        }

        private void picSelectedShoe1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void staMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilterByKeyword_Click_1(object sender, EventArgs e)
        {
            _presenter.FilterDisplay(txtKeywordsString.Text, chkAndSearch.Checked);
        }

        private void btnClearFilter_Click_1(object sender, EventArgs e)
        {
            txtKeywordsString.Text = "";
            _presenter.FilterDisplay("");
        }

        private void btnClearSelection_Click_1(object sender, EventArgs e)
        {
            _presenter.ClearSelection();
        }

        private void btnReviewSelection_Click_1(object sender, EventArgs e)
        {
            tabSearchAndSelect.SelectedIndex = 1;
        }

        private void scrFilteredPage_Scroll_1(object sender, ScrollEventArgs e)
        {
            _presenter.DisplayFilteredPage(scrFilteredPage.Value);
        }
        
        private void chkFilteredSelected3_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateFilteredShoe(2, chkFilteredSelected3.Checked);

            if (chkFilteredSelected3.Checked)
            {
                grpFilteredShoe3.BackColor = SelectedColour;
            }
            else
            {
                grpFilteredShoe3.BackColor = DefaultColour;
            }
        }

        private void chkFilteredSelected4_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateFilteredShoe(3, chkFilteredSelected4.Checked);

            if (chkFilteredSelected4.Checked)
            {
                grpFilteredShoe4.BackColor = SelectedColour;
            }
            else
            {
                grpFilteredShoe4.BackColor = DefaultColour;
            }
        }

        private void chkSelectedSelected3_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateSelectedShoe(scrSelectedPage.Value, 2, chkSelectedSelected3.Checked);

        }

        private void chkSelectedSelected4_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.UpdateSelectedShoe(scrSelectedPage.Value, 3, chkSelectedSelected4.Checked);

        }
        
    }
}