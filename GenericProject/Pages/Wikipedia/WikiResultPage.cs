using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Pages.Wikipedia
{
    public class WikiResultPage
    {
        private IWebDriver _webDriver;
        private IWebElement _titleLabel => _webDriver.FindElement(By.Id("firstHeading"));

        public WikiResultPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetPageTitle()
        {
            return _titleLabel.Text;
        }
    }
}
