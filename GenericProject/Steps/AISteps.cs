using GenericProject.Definitions;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public sealed class AISteps: BaseSteps 
    {
        private AIDefinitions _AIDefinitions;

        [Given(@"the browser is opened in the OCR Test Images Page")]
        public void GivenTheBrowserIsInAnOCRTestImagesPage()
        {
            SetUp();
            _AIDefinitions = new AIDefinitions(_webDriver);
            _AIDefinitions.OpenTesseractTestPage();
        }

        [When(@"the page is analized with tesseract")]
        public void WhenThePageIsAnalizedWithTesseract()
        {
            _AIDefinitions.GetPageText();
        }

        [Then(@"the text ""(.*)"" is found")]
        public void ThenTheTextIsFound(string expectedTest)
        {
            _AIDefinitions.VerifyTextInImage(expectedTest);
            TearDown();
        }

        [Given(@"the browser is opened in the Google Home Page")]
        public void GivenTheBrowserIsInTheGoogleHomePage()
        {
            SetUp();
            _AIDefinitions = new AIDefinitions(_webDriver);
            _AIDefinitions.OpenGoogleHomePage();
        }

        [When(@"""(.*)"" is typed in the search bar using sikuli")]
        public void IsTypedInTheSearchBarUsingSikuli(string searchTerm)
        {
            _AIDefinitions.WriteInGoogleSearchBar(searchTerm);
        }

        [Then(@"in the search bar is visible the text ""(.*)""")]
        public void InTheSearchBarIsVisibleTheText(string expectedTest)
        {
            _AIDefinitions.VerifyTextInSearchBar(expectedTest);
            TearDown();
        }
    }
}
