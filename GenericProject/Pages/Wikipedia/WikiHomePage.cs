using GenericProject.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Pages.Wikipedia
{

    public class WikiHomePage
    {
        private IWebDriver _webDriver;
        private IWebElement _searchInput => _webDriver.FindElement(By.Id("searchInput"));
        private IWebElement _searchBtn => _webDriver.FindElement(By.CssSelector("i.sprite.svg-search-icon"));

        public WikiHomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void SearchATerm(string term)
        {
            _searchInput.CustomSendKeys(term);
            _searchBtn.CustomClick();
        }
    }
}
