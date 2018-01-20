using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace SneakerBot.WebScraping.Model
{
    public class ScrapePageRequest
    {
        public string[] Website { get; set; }
        public ArrayList ShoeList { get; set; }
    }
}
