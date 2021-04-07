﻿using GenericProject.Pages.Wikipedia;
using GenericProject.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GenericProject.Steps
{
    [Binding]
    public class WikipediaSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _webDriver;

        
        [BeforeScenario]
        public void SetUp()
        {
            ReportProvider.InitReporter();
            ReportProvider.CreateTest(TestContext.CurrentContext.Test.Name);
            _webDriver = WebDriverProvider.GetWebDriver(WebDriverProvider.Browser.Chrome);
            Extensions.WebElementExtensions.SetWebDriver(_webDriver);
        }

        [AfterScenario]
        public void TearDown()
        {
            string testResultStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            string resultMessage = TestContext.CurrentContext.Result.Message;
            ReportProvider.LogTestFinished();
            ReportProvider.GenerateHtmlReport(testResultStatus,resultMessage);
            _webDriver.Quit();
        }

        public WikipediaSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

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
