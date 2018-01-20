using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace SneakerBot.WebScraping.Model
{
    public class ShoeModel
    {
        public int ID { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteURL { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public Image ImageBinary { get; set; }
        public bool Selected { get; set; }
        public bool ContainsKeyword(string keyword)
        {
            keyword = keyword.ToUpper();
            string modelname = ModelName.ToUpper();
            string description = Description.ToUpper();

            if(modelname.Contains(keyword))
            {
                return true;
            }
            if(description.Contains(keyword))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string tmp = "";

            tmp += ID + "\n" + WebsiteName + "\n" + WebsiteURL + "\n"
                + ModelName + "\n" + Description + "\n"
                + ImageURI + "\n"
                + Selected + "\n";

            return tmp;
        }
    }
}
