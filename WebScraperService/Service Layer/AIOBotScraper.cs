﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using HtmlAgilityPack;

using SneakerBot.WebScraping.Model;

namespace SneakerBot.WebScraping.Service
{
    public class AIOBotScraper : WebScraper
    {
        private HtmlWeb _webscraper;

        public AIOBotScraper()
        {
            _webscraper = new HtmlWeb();
        }

        public override ScrapePageResponse ScrapeWebpage(ScrapePageRequest request)
        {
            ShoeModel tmpShoe;
            ShoeModel[] tmpArray = null;

            ScrapePageResponse response = new ScrapePageResponse { Success = true, Message = "" };

            try
            {
                HtmlDocument webpage = _webscraper.Load(request.Website[1]);
                HtmlNodeCollection nodes = webpage.DocumentNode.SelectNodes("//div[contains(@class, 'rt-holder')]");
                _shoeCount = nodes.Count;
                response.ScrapeCount = _shoeCount;

                if (_shoeCount != 0)
                {
                    tmpArray = new ShoeModel[_shoeCount];

                    for (int i = 0; i < _shoeCount; ++i)
                    {
                        tmpShoe = new ShoeModel();
                        tmpShoe.ID = 0;
                        tmpShoe.WebsiteName = request.Website[0];
                        tmpShoe.WebsiteURL = request.Website[1];
                        tmpShoe.ModelName = WebScraper.CleanHTMLString(nodes[i].SelectNodes("//h3 [contains(@class, 'entry-title')]")[i].InnerText);
                        tmpShoe.Description = WebScraper.CleanHTMLString(nodes[i].SelectNodes("//h3 [contains(@class, 'entry-title')]")[i].InnerText);
                        //tmpShoe.Description = WebScraper.CleanHTMLString(nodes[i].SelectNodes("//div[contains(@class, 'post-meta-user')]//i")[i].InnerText);                        
                        tmpShoe.ImageURI = nodes[i].SelectNodes("//div[contains(@class, 'rt-holder')]//img")[i].GetAttributeValue("src", "");
                        tmpShoe.ImageBinary = WebScraper.LoadImageBinary(tmpShoe.ImageURI);
                        tmpArray[i] = tmpShoe;
                    }
                    request.ShoeList.AddRange(tmpArray);
                }
            }
            catch (Exception ex)
            {
                _shoeCount = 0;

                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}
