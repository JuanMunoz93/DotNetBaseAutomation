using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GenericProject.Providers
{
    public static class WebDriverProvider
    {
        
        public static IWebDriver WebDriver;

        public enum Browser
        {
            Chrome,
            FireFox,
            Edge
        }

        public static IWebDriver GenerateWebDriver(Browser browser)
        {
            WebDriver = GetDriver(browser);
            ReportProvider.LogInfoInAllReporters(Status.Info, $"Browser selected: {browser}");
            return WebDriver;
        }

        private static IWebDriver GetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--incognito");
                    options.AddArguments("--start-maximized");
                    return new ChromeDriver(options);
                case Browser.FireFox:
                    throw new NotImplementedException("Web browser type not implemented");
                case Browser.Edge:
                    throw new NotImplementedException("Web browser type not implemented");
                default:
                    throw new NotImplementedException("Web browser type not implemented");
            }
        }
    }
}
