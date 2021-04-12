using GenericProject.Definitions;
using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public sealed class AISteps: BaseSteps 
    {
        private AIDefinitions _AIDefinitions;

        [Given(@"the browser is in an OCR Test Images Page")]
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
            ScenarioContext.Current.Pending();
        }


    }
}
