using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using eBay.Service.EPS;

namespace SnkrBot
{
    public partial class ConfirmArrival : Form
    {
        private static ApiContext apiContext = null;
        DBConnection SQLConnect = new DBConnection();
        string ID = "";
        public ConfirmArrival(string ShoeID)
        {
            InitializeComponent();
            ID = ShoeID;
            LoadData();
        }
        private void LoadData() {

            sneakerIDtb.Text = ID;
            SneakernameTB.Text = SQLConnect.Select("Select ShoeName from Shoe where ShoeID='" + ID + "';");
            DataTable data = SQLConnect.Selects("Select StaffID, FirstName, LastName from STAFF", 2);
            // Create a List to store our KeyValuePairs
            List<KeyValuePair<string, string>> dataComboBox = new List<KeyValuePair<string, string>>();
            //add the first data to the list
            dataComboBox.Add(new KeyValuePair<string, string>("0", "Select a staff"));

            //Add first item
            int index = 1;
            foreach (DataRow row in data.Rows)
            {
                // Add data to the List
                dataComboBox.Add(new KeyValuePair<string, string>(row[0].ToString(), row[1].ToString()+" "+row[2].ToString()));
                index++;
            }
            StaffIDcb.DataSource = new BindingSource(dataComboBox,null);
            StaffIDcb.DisplayMember = "Value";
            StaffIDcb.ValueMember = "Key";
        }
        private void ConfirmBT_Click(object sender, EventArgs e)
        {
            float price = -1;
            try {
                price = float.Parse(ResellPricetb.Text);
            }
            catch (Exception ex) { }
            // Get the selected item in the combobox
            KeyValuePair<string, string> selectedPair = (KeyValuePair<string, string>)StaffIDcb.SelectedItem;
            if (selectedPair.Key.ToString().Equals("0")) { MessageBox.Show("Please select a staff"); }
            else if (ResellPricetb.Text.Equals(""))
                MessageBox.Show("Please enter Resell Price!");
            else if ( price < 0)
            {
                    MessageBox.Show("Please check Resell Price!");
            }
            
            else 
            {
                try
                {
                    // Get the selected item in the combobox
                    SQLConnect.Update("Update Incoming_Shoe SET StaffID = '" + selectedPair.Key + "', Position = '" + ResellPricetb.Text + "', isReady = " + (YesRB.Checked == true ? "1" : "0") + " where ShoeID = '" + ID + "';");
                 //   SQLConnect.Update("Update Shoe SET Price = '" + ResellPricetb.Text + "' where ShoeID = '" + ID + "';");
                    MessageBox.Show("The sneaker " + ID + " is arrived and waiting for reselling on Ebay!");
                    this.Close();
                }
                catch (DBConcurrencyException Db)
                {
                    MessageBox.Show("There is error during updating data!");
                }
            }
            
            
            if (YesRB.Checked == true)
            {
                new Ebay().AddItemEbay(ID);
                //SQLConnect.Update("Update Shoe SET Status = 'ReSelling' where ShoeID = '" + ID + "';");
            }
            else SQLConnect.Update("Update Shoe SET Status = 'Arrived' where ShoeID = '" + ID + "';");
            SQLConnect.Update("Update Incoming_shoe SET ArrivalDate = '" + ArrivalDTP.Value.ToString("yyyy-MM-dd") + "' WHERE ShoeID='" + ID + "';");
        }

        private void CancelBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StaffIDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
#region Ebay
        //Update an item on Ebay
        private void AddItemEbay(string sneakerID)
        {
            try
            {
                MessageBox.Show("Prepare to list the item " + SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '" + sneakerID + "';") + " on Ebay");
                //[Step 1] Initialize eBay ApiContext object
                ApiContext apiContext = GetApiContext();

                //[Step 2] Create a new ItemType object
                ItemType item = BuildItem(sneakerID);


                //[Step 3] Create Call object and execute the Call
                AddItemCall apiCall = new AddItemCall(apiContext);
                //Note_MS("Begin to call eBay API, please wait ...");
                FeeTypeCollection fees = apiCall.AddItem(item);
                //Note_MS("End to call eBay API, show call result ...");

                //[Step 4] Handle the result returned
                MessageBox.Show("The item " + SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '" + sneakerID + "';") + " was listed successfully!");
                double listingFee = 0.0;
                foreach (FeeType fee in fees)
                {
                    if (fee.Name == "ListingFee")
                    {
                        listingFee = fee.Fee.Value;
                    }
                }
                //MessageBox.Show(String.Format("Listing fee is: {0}", listingFee));
                //MessageBox.Show(String.Format("Listed Item ID: {0}", item.ItemID));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to list the item : " + ex.Message);
            }
        }
        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext object</returns>
        private ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();
                apiContext.Version = "673";
                //set Api Server Url
                apiContext.SoapApiServerUrl =
                    ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken =
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to AU
                apiContext.Site = SiteCodeType.Australia;

                //set Api logging
                apiContext.ApiLogManager = new ApiLogManager();
                apiContext.ApiLogManager.ApiLoggerList.Add(new FileLogger("listing_log.txt", true, true, true));

                apiContext.ApiLogManager.EnableLogging = true;


                return apiContext;
            }
        }

        /// <summary>
        /// Build a sample item
        /// </summary>
        /// <returns>ItemType object</returns>
        private ItemType BuildItem(string sneakerID)
        {
            ItemType item = new ItemType();

            // item title
            item.Title = SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '" + sneakerID + "';");
            // item description
            item.Description = "";
            // upload description + photos 
            try
            {
                string[] imgFile = new string[10];
                eBayPictureService pictureService = new eBayPictureService(new ApiContext());
                // pictureService.ApiContext.EPSServerUrl = @"https://api.sandbox.ebay.com/ws/api.dll";
                string[] picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, imgFile);

            }
            catch (Exception e)
            {
                //MessageBox.Show("Reading file Unsuccessful");
            }



            // listing duration
            item.ListingDuration = "Days_7";


            // listing category, 
            CategoryType category = new CategoryType();
            category.CategoryID = "153008"; //CategoryID = 11104 (CookBooks) , Parent CategoryID=267(Books), 153008 (shoe)
            item.PrimaryCategory = category;

            // item quality
            item.Quantity = 1;

            // item condition, New
            item.ConditionID = 1000;

            // item specifics
            item.ItemSpecifics = buildItemSpecifics(sneakerID);
            // listing type
            item.ListingType = ListingTypeCodeType.Chinese;



            // item location and country
            item.Location = "Melbourne";
            item.Country = CountryCodeType.AU;
            item.Currency = CurrencyCodeType.AUD;
            // listing price
            //item Start Price
            AmountType amount = new AmountType();
            amount.Value = 20;
            amount.currencyID = CurrencyCodeType.AUD;
            item.StartPrice = amount;

            //Console.WriteLine("Do you want to use Business policy profiles to list this item? y/n");
            String input = "n";//Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                item.SellerProfiles = BuildSellerProfiles();
            }
            else
            {
                // payment methods
                item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
                item.PaymentMethods.AddRange(
                    new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal }
                    );
                // email is required if paypal is used as payment method
                item.PayPalEmailAddress = "theroyals@gmail.com";
                item.PostalCode = "3000";
                // handling time is required
                item.DispatchTimeMax = 1;
                // shipping details
                //item.ShippingDetails = BuildShippingDetails();
                item.ShippingDetails = new ShippingDetailsType();
                item.ShippingDetails.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection();

                // return policy
                item.ReturnPolicy = new ReturnPolicyType();
                item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";
                ShippingServiceOptionsType shipservice1 = new ShippingServiceOptionsType();
                shipservice1.ShippingService = "AU_Regular";
                shipservice1.ShippingServicePriority = 1;
                shipservice1.ShippingServiceCost = new AmountType();
                shipservice1.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
                shipservice1.ShippingServiceCost.Value = 1.0;

                shipservice1.ShippingServiceAdditionalCost = new AmountType();
                shipservice1.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
                shipservice1.ShippingServiceAdditionalCost.Value = 1.0;

                item.ShippingDetails.ShippingServiceOptions.Add(shipservice1);

                ShippingServiceOptionsType shipservice2 = new ShippingServiceOptionsType();
                shipservice2.ShippingService = "AU_Express";
                shipservice2.ShippingServicePriority = 2;
                shipservice2.ShippingServiceCost = new AmountType();
                shipservice2.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
                shipservice2.ShippingServiceCost.Value = 4.0;

                shipservice2.ShippingServiceAdditionalCost = new AmountType();
                shipservice2.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
                shipservice2.ShippingServiceAdditionalCost.Value = 1.0;

                item.ShippingDetails.ShippingServiceOptions.Add(shipservice2);
            }



            return item;
        }

        /// <summary>
        /// Build sample SellerProfile details
        /// </summary>
        /// <returns></returns>
        private SellerProfilesType BuildSellerProfiles()
        {
            /*
             * Beginning with release 763, some of the item fields from
             * the AddItem/ReviseItem/VerifyItem family of calls have been
             * moved to the Business Policies API. 
             * See http://developer.ebay.com/Devzone/business-policies/Concepts/BusinessPoliciesAPIGuide.html for more
             * 
             * This example uses profiles that were previously created using this api.
             */

            SellerProfilesType sellerProfile = new SellerProfilesType();

          //  Note_MS("Return policy profile Id:");
            sellerProfile.SellerReturnProfile = new SellerReturnProfileType();
            sellerProfile.SellerReturnProfile.ReturnProfileID = 123456;//Int64.Parse(Console.ReadLine());

            //Note_MS("Shipping profile Id:");
            sellerProfile.SellerShippingProfile = new SellerShippingProfileType();
            sellerProfile.SellerShippingProfile.ShippingProfileID = 123456;// Int64.Parse(Console.ReadLine());

            //Note_MS("Payment profile Id:");
            sellerProfile.SellerPaymentProfile = new SellerPaymentProfileType();
            sellerProfile.SellerPaymentProfile.PaymentProfileID = 123456;// Int64.Parse(Console.ReadLine());

            return sellerProfile;
        }

        /// <summary>
        /// Build sample shipping details
        /// </summary>
        /// <returns>ShippingDetailsType object</returns>
        private ShippingDetailsType BuildShippingDetails()
        {

            // Shipping details
            ShippingDetailsType sd = new ShippingDetailsType();

            sd.ApplyShippingDiscount = true;
            AmountType amount = new AmountType();
            amount.Value = 20;
            amount.currencyID = CurrencyCodeType.AUD;
            sd.PaymentInstructions = "Please do the payment via Paypal.";

            // Shipping type and shipping service options
            sd.ShippingType = ShippingTypeCodeType.Flat;
            ShippingServiceOptionsType shippingOptions = new ShippingServiceOptionsType();
            shippingOptions.ShippingService =
            ShippingServiceCodeType.ShippingMethodStandard.ToString();

            amount = new AmountType();
            amount.Value = 2.0;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingServiceAdditionalCost = amount;
            amount = new AmountType();
            amount.Value = 10;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingServiceCost = amount;
            shippingOptions.ShippingServicePriority = 1;
            amount = new AmountType();
            amount.Value = 1.0;
            amount.currencyID = CurrencyCodeType.AUD;
            shippingOptions.ShippingInsuranceCost = amount;

            sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(
                new ShippingServiceOptionsType[] { shippingOptions }
                );

            return sd;

        }

        /// <summary>
        /// Build sample item specifics
        /// </summary>
        /// <returns>ItemSpecifics object</returns>
        private NameValueListTypeCollection buildItemSpecifics(string sneakerID)
        {
            //create the content of item specifics
            NameValueListTypeCollection nvCollection = new NameValueListTypeCollection();
            NameValueListType nv0 = new NameValueListType();
            nv0.Name = "Code";
            StringCollection nv0Col = new StringCollection();
            String[] strArr0 = new string[] { sneakerID };
            nv0Col.AddRange(strArr0);
            nv0.Value = nv0Col;
            NameValueListType nv1 = new NameValueListType();
            nv1.Name = "Name";
            StringCollection nv1Col = new StringCollection();
            String[] strArr1 = new string[] { SQLConnect.Select("Select ShoeName from Shoe where ShoeID = '" + sneakerID + "';") };
            nv1Col.AddRange(strArr1);
            nv1.Value = nv1Col;
            NameValueListType nv2 = new NameValueListType();
            nv2.Name = "Size";
            StringCollection nv2Col = new StringCollection();
            String[] strArr2 = new string[] { SQLConnect.Select("Select Size from Shoe where ShoeID = '" + sneakerID + "';") };
            nv2Col.AddRange(strArr2);
            nv2.Value = nv2Col;
            NameValueListType nv3 = new NameValueListType();
            nv3.Name = "Color";
            StringCollection nv3Col = new StringCollection();
            String[] strArr3 = new string[] { SQLConnect.Select("Select Color from Shoe where ShoeID = '" + sneakerID + "';") };
            nv3Col.AddRange(strArr3);
            nv3.Value = nv3Col;
            nvCollection.Add(nv0);
            nvCollection.Add(nv1);
            nvCollection.Add(nv1);
            nvCollection.Add(nv3);
            return nvCollection;
        }
        #endregion
    }
}
