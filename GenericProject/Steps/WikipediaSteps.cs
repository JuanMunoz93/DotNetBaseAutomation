using GenericProject.Pages.Wikipedia;
using GenericProject.Providers;
using GenericProject.Steps.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public class WikipediaSteps: FrontEndBaseStep
    {

        [Given(@"the browser is in the wikipedia home page")]
        public void TheBrowserIsInTheWikipediaHomePage()
        {
            _webDriver.Navigate().GoToUrl("https://www.wikipedia.org/");
        }

        [When(@"(.*) is searched")]
        public void IsSearched(string searchTerm)
        {
            WikiHomePage wikiHome = new WikiHomePage(_webDriver);
            wikiHome.SearchATerm(searchTerm);
        }

        [Then(@"a (.*) result page is opened")]
        public void AResultPageIsOpened(string pageTitle)
        {
            WikiResultPage wikiResult = new WikiResultPage(_webDriver);
            Assert.AreEqual(wikiResult.GetPageTitle(), pageTitle);
        }
    }
}
