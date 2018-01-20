using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Windows.Forms;
using eBay.Service.Util;
using eBay.Service.EPS;
using System.Net;

namespace SnkrBot
{
    class Ebay
    {
        private static ApiContext apiContext = null;
        DBConnection SQLConnect = new DBConnection();
        //Update an item on Ebay
        public void AddItemEbay(string sneakerID)
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
                FeeTypeCollection fees = new FeeTypeCollection();
                   // fees = apiCall.AddItem(item);

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
                
                //throw ex;
                MessageBox.Show("Fail to list the item : " + ex.StackTrace);
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
            item.ItemID = sneakerID;
            string Website = SQLConnect.Select("Select SupplierName from Supplier, Shoe where (Supplier.SupplierID = Shoe.SupplierID) AND (Shoe.ShoeID = '" + sneakerID+"');");
            string Description = new SearchShoeInfo().GetShoeDescription(Website,item.Title, sneakerID);
            // item description
            item.Description = Description;

            string ShoeImage = new SearchShoeInfo().GetShoeImage(Website,item.Title,sneakerID, 5);
            string[] imgURL = ShoeImage.Split('\n');
            // upload photos 

            
                eBayPictureService pictureService = new eBayPictureService(apiContext);
                pictureService.ApiContext = apiContext;
                //pictureService.
                //pictureService.ApiContext.EPSServerUrl = @"https://api.sandbox.ebay.com/wsapi";
                //pictureService.ApiContext.EPSServerUrl = @"https://api.sandbox.ebay.com/ws/api.dll";
                pictureService.ApiContext.EPSServerUrl = @"https://api.ebay.com/ws/wsapi";
                /*UploadSiteHostedPicturesRequestType request = new UploadSiteHostedPicturesRequestType();
                request.WarningLevel = WarningLevelCodeType.High;
                request.ExternalPictureURL = new StringCollection();
                request.ExternalPictureURL.Add(@"https://images-eu.ssl-images-amazon.com/images/I/41qPjKzQcyL._SL75_.jpg");
                request.PictureName = "Deva_testimage_URL";
                request.PictureSet = PictureSetCodeType.Supersize;
                request.PictureSetSpecified = true;
                */
                string[] pictureList = { @"C:\\Users\\Viet\\Pictures\\img.jpg", @"C:\\Users\\Viet\\Pictures\\img.jpg" };
                string[] picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, pictureList);
                 

            try { 
                    item.PictureDetails = new PictureDetailsType();
                    //item.PictureDetails.GalleryType = GalleryTypeCodeType.None;
                    item.PictureDetails.PictureURL = new StringCollection();
                    item.PictureDetails.PictureSource = PictureSourceCodeType.EPS;
                    //item.PictureDetails.PhotoDisplay = PhotoDisplayCodeType.SuperSize;
                    //item.PictureDetails.PhotoDisplaySpecified = true;
                    foreach (string pic in picURLs)
                    {
                        //item.PictureDetails.PictureURL.Add(pic);
                    }
            }
                catch (ApiException e)
                {
                    MessageBox.Show(e.Message);
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
            // listing type: Auction
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
                item.PayPalEmailAddress = "vietle211@gmail.com";
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
        #region Add pictures
        private UploadSiteHostedPicturesRequestType BuildUploadPictures()
        {
            UploadSiteHostedPicturesRequestType uploadsitehostedpicturesrequesttype = new UploadSiteHostedPicturesRequestType();
            uploadsitehostedpicturesrequesttype.PictureData = new Base64BinaryType();
            uploadsitehostedpicturesrequesttype.PictureSet = new PictureSetCodeType();
            uploadsitehostedpicturesrequesttype.PictureSystemVersion = 2;
            return uploadsitehostedpicturesrequesttype;
        }
        private void AddPictures(string url)
        { 
            string token = ConfigurationManager.AppSettings["UserAccount.ApiToken"];

            string SandboxURL = "https://api.sandbox.ebay.com/ws/api.dll";

            string PictureURL = url;

            string DevID = "94beb406-3ec1-4cac-ac4d-f374ce59170a";

            string AppID = "VietLe-SnkrBot-SBX-d5d74fc8f-a3a74c51";

            string CertID = "SBX-5d74fc8f8ede-5440-43af-b1e1-4fd2";
            

            string payload = "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +

            "<UploadSiteHostedPicturesRequest xmlns=\"urn:ebay:apis:eBLBaseComponents\">" +

            "<ExternalPictureURL>" + PictureURL + "</ExternalPictureURL>" +

            "<RequesterCredentials><eBayAuthToken>" + token + "</eBayAuthToken></RequesterCredentials>" +

            "</UploadSiteHostedPicturesRequest>";
           
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(SandboxURL);

            HttpWebResponse resp = null;

            //Add the request headers

            req.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "803");

            req.Headers.Add("X-EBAY-API-SITEID", "0");

            req.Headers.Add("X-EBAY-API-CALL-NAME", "UploadSiteHostedPictures");

            req.Headers.Add("X-EBAY-API-DEV-NAME", DevID);

            req.Headers.Add("X-EBAY-API-APP-NAME", AppID);

            req.Headers.Add("X-EBAY-API-CERT-NAME", CertID);

            //set the method to POST

            req.Method = "POST";

            //Convert the string to a byte array

            byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(payload);

            int len = postDataBytes.Length;

            req.ContentLength = len;

            //Post the request to eBay

            System.IO.Stream requestStream = req.GetRequestStream();

            requestStream.Write(postDataBytes, 0, len);

            requestStream.Close();

            try

            {

                // get response and write to console

                resp = (HttpWebResponse)req.GetResponse();

                StreamReader responseReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);

                string output = responseReader.ReadToEnd();

                resp.Close();

                XmlDocument xmlResponse = new XmlDocument();

                xmlResponse.LoadXml(output);
                

                //string response = xmlResponse.ToString();

                //process response

                //show them how to get the full url and specify that in the AddItem request

            }

            catch (Exception ex)

            {

                //handle exception

            }
        }
#endregion
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
    }
}
