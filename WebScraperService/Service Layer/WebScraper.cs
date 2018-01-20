using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Drawing;
using System.Net;
using System.IO;

using SneakerBot.WebScraping.Model;

namespace SneakerBot.WebScraping.Service
{
    public abstract class WebScraper
    {
        protected int _shoeCount;
        protected int _pageSize;
        protected string _webURL;
        public virtual string WebURL
        {
            get
            {
                return _webURL;
            }
        }
        public abstract ScrapePageResponse ScrapeWebpage(ScrapePageRequest request);
        public static string CleanHTMLString(string html)
        {
            string tmp = html.Trim();
            return StripHTMLCharCodes(tmp);
        }
        private static string StripHTMLCharCodes(string html)
        {
            string tmp = html;
            tmp = tmp.Replace("&#8220;", "\"");
            tmp = tmp.Replace("&#8221;", "\"");
            tmp = tmp.Replace("&#038;", "&");
            tmp = tmp.Replace("&#39;", "'");
            return tmp;
        }
        public static Image LoadImageBinary(string url)
        {
            try
            {
                WebClient webClient = new WebClient { Proxy = null };
                byte[] imageFile = webClient.DownloadData(url);
                MemoryStream stream = new MemoryStream(imageFile);
                Image img = Image.FromStream(stream);

                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading image.");
            }
        }
    }
}
