using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SneakerBot.WebScraping.Model;

namespace SneakerBot.WebScraping.Presentation
{
    public interface IWebScraperView
    {
        void DisplayWebsites(string[] websites);
        void ClearFilteredDisplay();
        void DisplayFilteredPageCount(int count);
        void DisplayFilteredPage(ShoeModel[] shoes);
        void ClearSelectedDisplay();
        void DisplaySelectedPageCount(int count);
        void DisplaySelectedShoes(ShoeModel[] shoes);
        string Message { set; }
    }
}
