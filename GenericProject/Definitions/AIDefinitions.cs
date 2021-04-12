using GenericProject.Pages.Mattmahoney;
using GenericProject.Providers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Definitions
{
    class AIDefinitions
    {
        private IWebDriver _webDriver;

        public AIDefinitions(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenTesseractTestPage()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("http://www.mattmahoney.net/ocr/");
            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        public void GetPageText()
        {
            try
            {
                MattmahoneyHomePage mattmahoneyHomePage = new MattmahoneyHomePage(_webDriver);
                mattmahoneyHomePage.CenterTestImage();
                WebDriverProvider.TakeScreenshot();
                Console.WriteLine("asd");

            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }
    }
}
