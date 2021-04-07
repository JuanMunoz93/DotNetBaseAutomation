using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GenericProject.Providers
{
    public static class WebDriverProvider
    {
       
        public enum Browser
        {
            Chrome,
            FireFox,
            Edge
        }

        public static IWebDriver GetWebDriver(Browser browser)
        {
            IWebDriver webDriver = GetDriver(browser);
            ReportProvider.LogInfoInAllReporters(Status.Info, $"Browser selected: {browser}");
            return webDriver;
        }

        private static IWebDriver GetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    return new ChromeDriver();
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
