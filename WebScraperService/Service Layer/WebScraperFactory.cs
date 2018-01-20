using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Configuration;

namespace SneakerBot.WebScraping.Service
{
    public static class WebScraperFactory
    {
        public static WebScraper CreateWebScraper(string type)
        {
            type = type.ToUpper();

            switch(type)
            {
                case "AIOBOT":
                    return new AIOBotScraper();
                case "REBEL":
                    return new RebelScraper();
                case "FOOTLOCKER":
                default:
                    throw new ArgumentException("Unknown WebScraper Subclass");
            }
        }
        public static int WebsiteCount
        {
            get
            {
                return new WebURLs().Properties.Count;
            }
        }
        public static string[,] Websites
        {
            get
            {
                WebURLs settings = new WebURLs();
                int urlCount = settings.Properties.Count;
                string[,] tmp = new string[urlCount, 2];

                int i = 0;
                foreach(SettingsProperty s in settings.Properties)
                {
                    tmp[i, 0] = s.Name;
                    tmp[i++, 1] = (string)s.DefaultValue;
                }

                return tmp;
            }
        }
        public static string[] WebsiteNames
        {
            get
            {
                int websiteCount = Websites.GetLength(0);
                string[] tmp = new string[websiteCount];
                string[,] websites = Websites;

                for (int i = 0; i < websiteCount; ++i)
                {
                    tmp[i] = Websites[i, 0];
                }

                return tmp;
            }
        }
        public static string[] WebsiteURLs
        {
            get
            {
                int websiteCount = Websites.GetLength(0);
                string[] tmp = new string[websiteCount];
                string[,] websites = Websites;

                for (int i = 0; i < websiteCount; ++i)
                {
                    tmp[i] = Websites[i, 1];
                }

                return tmp;
            }
        }
    }
}
