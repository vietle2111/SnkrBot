using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using SneakerBot.WebScraping.Service;
using SneakerBot.WebScraping.Model;
using SneakerBot.WebScraping.Presentation;

namespace SneakerBot.WebScraping.Presentation
{
    public class WebScraperPresenter
    {
        private IWebScraperView _view;
        private WebScraperService _service;
        private System.Windows.Forms.Form _guiDispatcher;

        private bool _isRefreshingDisplay = false;
        
        public WebScraperPresenter(IWebScraperView webscraperView, WebScraperService webscraperService)
        {
            _view = webscraperView;
            _service = webscraperService;
            _service.ScrapeCompletedEvent += DataLoadedHandler;
        }
        public int PageSize
        {
            get
            {
                return _service.PageSize;
            }
            set
            {
                _service.PageSize = value;
            }
        }
        public void DisplayWebsites()
        {
            _view.DisplayWebsites(_service.WebsiteNames);
        }
        public void LoadData(System.Windows.Forms.Form guiDispatcher = null)
        {
            _isRefreshingDisplay = true;

            _guiDispatcher = guiDispatcher;

            Task.Run(() => _service.Scrape());
            _view.Message = "Scraping websites...";

            _isRefreshingDisplay = false;
        }
        public void DataLoadedHandler(object sender, ScrapeResponseEventArgs e)
        {
            if (_guiDispatcher != null)
            {
                Action action = () => updateOnDataLoaded(e.response);
                _guiDispatcher.BeginInvoke(action);
            }
        }
        private void updateOnDataLoaded(ScrapeResponse response)
        {
            _isRefreshingDisplay = true;

            _view.ClearFilteredDisplay();

            if (response.Success)
            {
                _view.DisplayFilteredPageCount(_service.FilteredPageCount);
                _view.ClearFilteredDisplay();
                _view.DisplayFilteredPage(_service.GetFilteredPage(0));
            }
            else
            {
                _view.DisplayFilteredPageCount(0);
                _view.Message = response.Message;
            }

            _isRefreshingDisplay = false;
        }
        public void ClearFilteredDisplay()
        {
            _isRefreshingDisplay = true;

            _view.ClearFilteredDisplay();

            _isRefreshingDisplay = false;
        }
        public void DisplayFilteredPage(int pageNo)
        {
            if(!_isRefreshingDisplay)
            {
                _isRefreshingDisplay = true;
                _view.DisplayFilteredPage(_service.GetFilteredPage(pageNo));
                _isRefreshingDisplay = false;
            }
        }
        public void FilterDisplay(string keywordsString, bool ANDOp = false)
        {
            _isRefreshingDisplay = true;

            _service.FilterShoes(keywordsString, ANDOp);
            _view.DisplayFilteredPageCount(_service.FilteredPageCount);
            _view.DisplayFilteredPage(_service.GetFilteredPage(0));

            _isRefreshingDisplay = false;
        }
        public void UpdateFilteredShoe(int shoeIndex, bool selected)
        {
            if (!_isRefreshingDisplay)
            {
                _service.CurrentFilteredPage[shoeIndex].Selected = selected;
            }
        }
        public void UpdateSelectedShoe(int currentPageNo, int shoeIndex, bool selected)
        {
            if (!_isRefreshingDisplay)
            {
                _isRefreshingDisplay = true;

                _service.CurrentSelectedPage[shoeIndex].Selected = selected;

                _service.SelectShoes();
                _view.DisplaySelectedPageCount(_service.SelectedPageCount);

                if(currentPageNo > (_service.SelectedPageCount - 1))
                {
                    currentPageNo = _service.SelectedPageCount - 1;
                }

                _view.DisplaySelectedShoes(_service.GetSelectedPage(currentPageNo));
                _view.DisplayFilteredPage(_service.CurrentFilteredPage);

                _isRefreshingDisplay = false;
            }
        }
        public void ClearSelection()
        {
            _isRefreshingDisplay = true;

            _service.ClearSelection();
            _view.DisplayFilteredPage(_service.CurrentFilteredPage);
            _view.DisplaySelectedPageCount(_service.SelectedPageCount);
            _view.DisplaySelectedShoes(_service.GetSelectedPage(0));

            _isRefreshingDisplay = false;
        }
        public void ClearSelectedDisplay()
        {
            _isRefreshingDisplay = true;

            _view.ClearSelectedDisplay();

            _isRefreshingDisplay = false;
        }
        public void DisplaySelectedPage(int pageNo)
        {
            if (!_isRefreshingDisplay)
            {
                _isRefreshingDisplay = true;
                _view.DisplaySelectedShoes(_service.GetSelectedPage(pageNo));
                _isRefreshingDisplay = false;
            }
        }
        public void UpdateSelection(int currentPage)
        {
            _isRefreshingDisplay = true;

            _service.SelectShoes();
            _view.DisplaySelectedPageCount(_service.SelectedPageCount);
            if(currentPage > (_service.SelectedPageCount - 1))
            {
                currentPage = _service.SelectedPageCount - 1;
            }
            _view.DisplaySelectedShoes(_service.GetSelectedPage(currentPage));

            _isRefreshingDisplay = false;
        }
        public void CommitSelections()
        {
            _service.CommitSelections();
            ClearSelection();
        }
    }
}
