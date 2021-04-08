using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GenericProject.Steps.BaseSteps
{
    public class FrontEndBaseStep
    {
        protected IWebDriver _webDriver;

        [BeforeScenario]
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
