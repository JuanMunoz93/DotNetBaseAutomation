using GenericProject.Pages.Wikipedia;
using GenericProject.Providers;
using OpenQA.Selenium;
using System;

namespace GenericProject.Definitions
{
    public class WikipediaDefinitions
    {
        private IWebDriver _webDriver;

        public WikipediaDefinitions(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenWikipediaHomePage()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("https://www.wikipedia.org/");
            }
            catch(Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        public void SearchInWikipedia(string searchTerm)
        {
            try
            {
                WikiHomePage wikiHome = new WikiHomePage(_webDriver);
                wikiHome.SearchATerm(searchTerm);
            }
            catch(Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        public void VerifyWikipediaResultTitle(string expectedTitle)
        {
            try
            {
                WikiResultPage wikiResult = new WikiResultPage(_webDriver);
                AssertionProvider.EqualsHardAssert(wikiResult.GetPageTitle(), expectedTitle, "Wikipedia result page title");
            }
            catch(Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }


    }
}
