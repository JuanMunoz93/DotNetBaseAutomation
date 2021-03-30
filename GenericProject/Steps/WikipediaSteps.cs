using System;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public class WikipediaSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public WikipediaSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the browser is in the wikipedia home page")]
        public void TheBrowserIsInTheWikipediaHomePage()
        {
            _scenarioContext.Pending();
        }

        [When(@"(.*) is searched")]
        public void IsSearched(string searchTerm)
        {
            _scenarioContext.Pending();
        }

        [Then(@"a (.*) result page is opened")]
        public void AResultPageIsOpened()
        {
            _scenarioContext.Pending();
        }
    }
}
