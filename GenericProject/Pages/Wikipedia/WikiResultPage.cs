using GenericProject.Providers;
using OpenQA.Selenium;

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
            string title = _titleLabel.Text;
            ReportProvider.LogInfo($"Page title= '{title}'");
            return title;
        }
    }
}
