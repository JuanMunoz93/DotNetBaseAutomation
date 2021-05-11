using GenericProject.Providers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Pages.Google
{
    public class GoogleHomePage
    {
        private IWebDriver _webDriver;
        private IWebElement _searchInput => _webDriver.FindElement(By.Name("q"));

        public GoogleHomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetTextInInput()
        {
            string input = _searchInput.GetAttribute("value");
            ReportProvider.LogInfo($"Input text= '{input}'");
            return input;
        }
    }
}
