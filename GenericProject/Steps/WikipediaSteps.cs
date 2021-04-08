using GenericProject.Definitions;
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
        private WikipediaDefinitions _wikipediaDefinitions;
        
        [BeforeScenario(Order = 1)]
        public void  Before()
        {
            _wikipediaDefinitions = new WikipediaDefinitions(_webDriver);
        }

        [Given(@"the browser is in the wikipedia home page")]
        public void TheBrowserIsInTheWikipediaHomePage()
        {
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
        }
    }
}
