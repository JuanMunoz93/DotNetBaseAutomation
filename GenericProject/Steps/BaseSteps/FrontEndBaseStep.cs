using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GenericProject.Steps.BaseSteps
{
    public class FrontEndBaseStep
    {
        protected IWebDriver _webDriver;

        [BeforeScenario(Order = 0)]
        public void FrontEndBefore()
        {
            ReportProvider.InitReporter();
            ReportProvider.CreateTest(TestContext.CurrentContext.Test.Name);
            _webDriver = WebDriverProvider.GenerateWebDriver(WebDriverProvider.Browser.Chrome);
            Extensions.WebElementExtensions.SetWebDriver(_webDriver);
        }

        [AfterScenario]
        public void TearDown()
        {
            string testResultStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            string resultMessage = TestContext.CurrentContext.Result.Message;
            ReportProvider.GenerateHtmlReport(testResultStatus, resultMessage);
            ReportProvider.LogTestFinished();
            _webDriver.Quit();
        }
    }
}
