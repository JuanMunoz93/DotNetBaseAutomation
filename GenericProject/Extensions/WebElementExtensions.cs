using GenericProject.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GenericProject.Extensions
{
    public static class WebElementExtensions
    {
        private static IWebDriver _webDriver;
        private static int _waitTime = 5;
        private static WebDriverWait _wait;

        public static void SetWebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_waitTime));
        }

        public static void SetWaitTime(int timeSec)
        {
            _waitTime = timeSec;
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_waitTime));
            ReportProvider.LogInfo($"New Wait Time configured: {timeSec} seconds");
        }

        public static void CustomClick(this IWebElement element)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void CustomClick(this IWebElement element, string elementName)
        {
            element.CustomClick();
            ReportProvider.LogInfo($"'{elementName}' clicked");
        }

        public static void CustomSendKeys(this IWebElement element, string text)
        {
            _wait.Until<IWebElement>(d =>
            {
                if (element.Displayed)
                    return element;
                return null;
            }).SendKeys(text);
        }

        public static void CustomSendKeys(this IWebElement element, string text, string elementName)
        {
            element.CustomSendKeys(text);

            ReportProvider.LogInfo($"Text '{text}' wrote on '{elementName}'");
        }

        public static void CenterElement(this IWebElement element)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void CenterElement(this IWebElement element, string elementName)
        {
            element.CenterElement();
            ReportProvider.LogInfo($"Element '{elementName}' centered");
        }
    }
}
