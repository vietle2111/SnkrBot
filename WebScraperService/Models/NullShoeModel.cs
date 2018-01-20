using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerBot.WebScraping.Model
{
    public class NullShoeModel : ShoeModel
    {
        public NullShoeModel()
        {
            ID = -1;
            WebsiteName = WebsiteURL = Description = ImageURI = "";
            Selected = false;
        }
    }
}
