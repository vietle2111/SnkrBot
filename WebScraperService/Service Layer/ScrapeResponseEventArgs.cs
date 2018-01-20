using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SneakerBot.WebScraping.Model;

namespace SneakerBot.WebScraping.Service
{
    public delegate void ScrapeCompletedHandler(object sender, ScrapeResponseEventArgs e);
    public class ScrapeResponseEventArgs : System.EventArgs
    {
        public readonly ScrapeResponse response;

        public ScrapeResponseEventArgs(ScrapeResponse response)
        {
            this.response = response;
        }
    }
}
