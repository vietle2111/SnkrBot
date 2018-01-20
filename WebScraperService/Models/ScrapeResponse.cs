using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerBot.WebScraping.Model
{
    public class ScrapeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ScrapeCount { get; set; }
    }
}
