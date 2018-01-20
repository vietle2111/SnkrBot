/*
COMPONENT:  ScraperService
PURPOSE:    Scrape shoe data from websites.
AUTHOR:     Meng
CREATED:    06/12/2017
MODIFIED:   10/12/2017
VERSION:    0.3.0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Drawing;
using System.Net;
using System.Collections;

using SneakerBot.WebScraping.Model;
using System.IO;

namespace SneakerBot.WebScraping.Service
{
    public class WebScraperService
    {
        private string[,] _websites;
        private ArrayList _scrapedShoes;
        private ArrayList _filteredShoes;
        private ArrayList _selectedShoes;
        private int _pageSize = 0;
        private int _filteredCount = 0;
        private int _filteredPageCount = 0;
        private int _selectedCount = 0;
        private int _selectedPageCount = 0;
        private ShoeModel[] _currentFilteredPage;
        private ShoeModel[] _currentSelectedPage;

        public WebScraperService()
        {
            _websites = WebScraperFactory.Websites;
            _scrapedShoes = new ArrayList();
            _filteredShoes = new ArrayList();
            _selectedShoes = new ArrayList();

            //populateTestData();
        }

        #region EVENT SUPPORT

        public event EventHandler<ScrapeResponseEventArgs> ScrapeCompletedEvent;
        public event EventHandler<CommittedSelectionEventArgs> SelectionCommittedEvent;

        public void CommitSelections()
        {
            //ShoeModel[] selectedShoes = _selectedShoes.Cast<ShoeModel>().ToArray<ShoeModel>();

            //for(int i = 0; i < selectedShoes.Count(); ++i)
            //{
            //    selectedShoes[i].ImageBinary = null;
            //}

            if (SelectionCommittedEvent != null)
                SelectionCommittedEvent(this, new CommittedSelectionEventArgs(_selectedShoes.Cast<ShoeModel>().ToArray<ShoeModel>()));
        }

        #endregion

        #region SCRAPING FUNCTIONS
        public void Scrape()
        {
            _scrapedShoes.Clear();

            ScrapeResponse serviceResponse = new ScrapeResponse();

            try
            {
                string[,] websites = WebScraperFactory.Websites;
                WebScraper scraper;
                ScrapePageResponse websiteResponse = new ScrapePageResponse();
                string[] website;

                for (int i = 0; i < WebScraperFactory.WebsiteCount; ++i)
                {
                    scraper = WebScraperFactory.CreateWebScraper(websites[i, 0]);
                    website = new string[] { websites[i, 0], websites[i, 1] };

                    ScrapePageRequest request = new ScrapePageRequest
                    {
                        Website = website,
                        ShoeList = _scrapedShoes
                    };

                    websiteResponse = scraper.ScrapeWebpage(request);

                    if (!websiteResponse.Success)
                    {
                        break;
                    }
                }

                serviceResponse.Success = websiteResponse.Success;
                serviceResponse.Message = websiteResponse.Message;
                serviceResponse.ScrapeCount = _scrapedShoes.Count;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                serviceResponse.ScrapeCount = 0;
                _scrapedShoes.Clear();
            }
            finally
            {
                FilterShoes("");

                if (ScrapeCompletedEvent != null)
                    ScrapeCompletedEvent(this, new ScrapeResponseEventArgs(serviceResponse));
            }
        }
        #endregion

        #region SHOE LIST FILTERING
        public string[] keywordParser(string keywordsString)
        {
            return keywordsString.Split();
        }
        public void FilterShoes(string keywordsString, bool ANDOp = false)
        {
            _filteredShoes.Clear();

            if(ANDOp)
            {
                foreach(ShoeModel shoe in _scrapedShoes)
                {
                    if(shoe.ContainsKeyword(keywordsString))
                    {
                        _filteredShoes.Add(shoe);
                    }
                }
            }
            else
            {
                string[] keywords = keywordParser(keywordsString);

                foreach(string keyword in keywords)
                {
                    foreach (ShoeModel shoe in _scrapedShoes)
                    {
                        if (shoe.ContainsKeyword(keyword))
                        {
                            if (!_filteredShoes.Contains(shoe))
                                _filteredShoes.Add(shoe);
                        }
                    }
                }
            }
            
            _filteredCount = _filteredShoes.Count;
        }
        public void SelectShoes()
        {
            _selectedShoes.Clear();

            foreach (ShoeModel shoe in _scrapedShoes)
            {
                if(shoe.Selected)
                {
                    _selectedShoes.Add(shoe);
                }
            }

            _selectedCount = _selectedShoes.Count;
        }
        public void ClearSelection()
        {
            foreach(ShoeModel shoe in _scrapedShoes)
            {
                shoe.Selected = false;
            }

            for(int i = 0; i < _pageSize; ++i)
            {
                _currentSelectedPage[i] = new NullShoeModel();
            }

            _selectedShoes.Clear();
            _selectedCount = _selectedShoes.Count;
        }
        #endregion

        #region SHOE LIST PROPERTIES
        public virtual int ShoeCount
        {
            get
            {
                return _filteredCount;
            }
        }
        public virtual int SelectedCount
        {
            get
            {
                return _selectedCount;
            }
        }
        #endregion

        #region PAGING SUPPORT
        public virtual int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if(value >= 0)
                {
                    _pageSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Attempting to set negative PageSize");
                }
            }
        }
        public virtual int FilteredPageCount
        {
            get
            {
                if(_pageSize == 0)
                {
                    return 0;
                }
                else
                {
                    _filteredPageCount = _filteredCount / _pageSize;

                    if ((_filteredCount % _pageSize) != 0)
                        ++_filteredPageCount;

                    return _filteredPageCount;
                }
            }
        }
        /// <summary>
        /// Returns PageSize number of shoes from the current filtered list.
        /// N.B. Page numbering is 0-based.
        /// </summary>
        /// <param name="pageNo">[0, Number of pages)</param>
        /// <returns></returns>
        public virtual ShoeModel[] GetFilteredPage(int pageNo)
        {
            int firstIndex = pageNo * _pageSize;
            int lastIndex = firstIndex + _pageSize - 1;

            _currentFilteredPage = new ShoeModel[_pageSize];
            ShoeModel tmpShoe;

            for(int i = firstIndex, j = 0; i <= lastIndex; ++i, ++j)
            {
                if(i < _filteredCount)
                {
                    tmpShoe = (ShoeModel)_filteredShoes[i];
                }
                else
                {
                    tmpShoe = new NullShoeModel();
                }

                _currentFilteredPage[j] = tmpShoe;
            }

            return _currentFilteredPage;
        }
        public virtual ShoeModel[] CurrentFilteredPage
        {
            get
            {
                if (_currentFilteredPage == null)
                    _currentFilteredPage = new ShoeModel[_pageSize];

                for(int i = 0; i < _pageSize; ++i)
                {

                    if (_currentFilteredPage[i] == null)
                        _currentFilteredPage[i] = new NullShoeModel();
                }

                return _currentFilteredPage;
            }
        }
        public virtual int SelectedPageCount
        {
            get
            {
                if (_pageSize == 0)
                {
                    return 0;
                }
                else
                {
                    _selectedPageCount = _selectedCount / _pageSize;

                    if ((_selectedCount % _pageSize) != 0)
                        ++_selectedPageCount;

                    return _selectedPageCount;
                }
            }
        }
        public virtual ShoeModel[] GetSelectedPage(int pageNo)
        {
            int firstIndex = pageNo * _pageSize;
            firstIndex = firstIndex >= 0 ? firstIndex : 0;
            int lastIndex = firstIndex + _pageSize - 1;

            _currentSelectedPage = new ShoeModel[_pageSize];
            ShoeModel tmpShoe;

            for (int i = firstIndex, j = 0; i <= lastIndex; ++i, ++j)
            {
                if (i < _selectedCount)
                {
                    tmpShoe = (ShoeModel)_selectedShoes[i];
                }
                else
                {
                    tmpShoe = new NullShoeModel();
                }

                _currentSelectedPage[j] = tmpShoe;
            }

            return _currentSelectedPage;
        }
        public virtual ShoeModel[] CurrentSelectedPage
        {
            get
            {
                return _currentSelectedPage;
            }
        }
        #endregion

        #region WEBSITE PROPERTIES
        public virtual string[,] Websites
        {
            get
            {
                return WebScraperFactory.Websites;
            }
        }
        public virtual string[] WebsiteNames
        {
            get
            {
                return WebScraperFactory.WebsiteNames;
            }
        }
        public virtual string[] WebsiteURLs
        {
            get
            {
                return WebScraperFactory.WebsiteURLs;
            }
        }
        #endregion
        
    }
}
