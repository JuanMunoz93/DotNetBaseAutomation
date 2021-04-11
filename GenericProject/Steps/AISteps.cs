using GenericProject.Steps.BaseSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public sealed class AISteps : FrontEndBaseStep
    {

        [Given(@"the browser is in an OCR Test Images Page")]
        public void GivenTheBrowserIsInAnOCRTestImagesPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the page is analized with tesseract")]
        public void WhenThePageIsAnalizedWithTesseract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the text ""(.*)"" is found")]
        public void ThenTheTextIsFound(string expectedTest)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
