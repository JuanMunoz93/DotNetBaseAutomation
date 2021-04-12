using GenericProject.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Pages.Mattmahoney
{
    public class MattmahoneyHomePage
    {
        private IWebDriver _webDriver;
        private IWebElement _testImage => _webDriver.FindElement(By.CssSelector("p img[src='stock_gs200.jpg']"));

        public MattmahoneyHomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void CenterTestImage()
        {
            _testImage.CenterElement("tesseract test image");
        }
    }
}
