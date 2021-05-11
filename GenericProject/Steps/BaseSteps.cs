using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    public abstract class BaseSteps
    {
        protected IWebDriver _webDriver;

        protected void SetUp()
        {
            ReportProvider.InitReporter();
            ReportProvider.CreateTest(TestContext.CurrentContext.Test.Name);
            _webDriver = WebDriverProvider.GenerateWebDriver(WebDriverProvider.Browser.Chrome);
        }

        public static void TearDown()
        {
            string testResultStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            string resultMessage = TestContext.CurrentContext.Result.Message;
            ReportProvider.GenerateHtmlReport(testResultStatus, resultMessage);
            ReportProvider.LogTestFinished();
            WebDriverProvider.QuitWebDriver();
        }
    }
}
