using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Extensions
{
    public static class WebElementExtensions
    {
        private static IWebDriver _webDriver;
        private static int _waitTime=5;
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
        }

        public static void CustomClick(this IWebElement element)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
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

    }
}
