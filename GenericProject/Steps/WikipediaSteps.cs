using GenericProject.Definitions;
using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public sealed class WikipediaSteps: BaseSteps
    {
        private WikipediaDefinitions _wikipediaDefinitions;

        [Given(@"the browser is in the wikipedia home page")]
        public void TheBrowserIsInTheWikipediaHomePage()
        {
            SetUp();
            _wikipediaDefinitions = new WikipediaDefinitions(_webDriver);
            _wikipediaDefinitions.OpenWikipediaHomePage();
        }

        [When(@"(.*) is searched")]
        public void IsSearched(string searchTerm)
        {
            _wikipediaDefinitions.SearchInWikipedia(searchTerm);

        }

        [Then(@"a (.*) result page is opened")]
        public void AResultPageIsOpened(string pageTitle)
        {
            _wikipediaDefinitions.VerifyWikipediaResultTitle(pageTitle);
            TearDown();
        }
    }
}
