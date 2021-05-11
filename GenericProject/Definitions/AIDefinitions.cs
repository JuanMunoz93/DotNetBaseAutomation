using GenericProject.Extensions;
using GenericProject.Pages.Google;
using GenericProject.Pages.Mattmahoney;
using GenericProject.Providers;
using GenericProject.Utils;
using OpenQA.Selenium;
using SikuliSharp;
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
        private string text = "";

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

        public void OpenGoogleHomePage()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("https://www.google.com/");
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
                _webDriver.TakeScreenshot("Tesseract_test");
                text=AIProvider.GetTextFromImage($"{GenericUtils.GetScreenShotsDirectory()}//Tesseract_test.bmp");
                Console.WriteLine("asd");
            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        internal void VerifyTextInSearchBar(string expectedTest)
        {
            try
            {
                GoogleHomePage googleHomePage = new GoogleHomePage(_webDriver);
                string textInSearchBar = googleHomePage.GetTextInInput();
                AssertionProvider.EqualsHardAssert(expectedTest, textInSearchBar, "the text in the search bar is not the expected");
            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        public void WriteInGoogleSearchBar(string searchTerm)
        {
            try
            {
                using (var session = Sikuli.CreateSession())
                {
                    var input = Patterns.FromFile("C:\\Users\\juan_\\Documents\\projects\\dotnetBase\\GenericProject\\GenericProject\\Resources\\SikuliImages\\GoogleSearchInput.png", 0.9f);
                    var logo = Patterns.FromFile("C:\\Users\\juan_\\Documents\\projects\\dotnetBase\\GenericProject\\GenericProject\\Resources\\SikuliImages\\GoogleLogo.png", 0.9f);
                    session.Click(input);
                    session.Type(searchTerm);
                    session.Click(logo);
                }
            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }

        internal void VerifyTextInImage(string expectedTest)
        {
            try
            {
                AssertionProvider.Contains(expectedTest, text,"The expected text was not found in the image");
            }
            catch (Exception ex)
            {
                AssertionProvider.FailTest(ex.Message);
            }
        }
    }
}
