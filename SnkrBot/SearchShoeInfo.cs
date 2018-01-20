using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace SnkrBot
{
    class SearchShoeInfo
    {
        //API Key
        private static string API_KEY = "AIzaSyDDHzDHu5RVYiWJp1leKdnH1cukRcOwKaE";
        //The custom search engine identifier
        private static string cx = "016116530617786704090:sm0v3hpgqgk";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApplicationName = "SnkrBot",
                ApiKey = API_KEY,
            });


        public string GetShoeDescription(string SiteName, string ShoeID, string Style_Number)
        {
            string query = ShoeID + " " + Style_Number + " " + SiteName + " description";
            string first_result = "";
            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;
            listRequest.Num = 2;
            listRequest.Start = 1;
            IList<Result> results = new List<Result>();
            results = listRequest.Execute().Items;
            if (results != null)
            {
                foreach (var result in results)
                {
                    first_result = first_result + "\n" + result.Snippet;
                }

            }
            else first_result = "There is no information about " + ShoeID;
            return first_result;
        }
        public string GetShoeImage(string SiteName, string ShoeID, string Style_Number, int NumOfImage)
        {
            string query = ShoeID + " " + Style_Number + " " + SiteName + " image";
            string first_result = "";
            //CseResource.ListRequest listRequest = Service.Cse.List(query);
            var listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;
            listRequest.Num = NumOfImage;
            listRequest.Start = 1;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            IList<Result> results = new List<Result>();
            results = listRequest.Execute().Items;
            if (results != null)
            {
                foreach (var result in results)
                {
                    first_result = first_result + "\n" + result.Link;
                }
            }
            else first_result = "There is no information about " + ShoeID;
            return first_result;
        }
    }
}
