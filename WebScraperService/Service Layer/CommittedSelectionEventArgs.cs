using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SneakerBot.WebScraping.Model;

namespace SneakerBot.WebScraping.Service
{
    public delegate void SelectionCommittedHandler(object sender, ScrapeResponseEventArgs e);

    public class CommittedSelectionEventArgs : System.EventArgs
    {
        public readonly ShoeModel[] SelectedShoes;

        public CommittedSelectionEventArgs(ShoeModel[] selectedShoes)
        {
            this.SelectedShoes = selectedShoes;
        }
    }
}
