using GenericProject.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Extensions
{
    public static class WebDriverExtensions
    {
        private static int _ssCounter = 0;
        private static readonly string _ssPath= GenericUtils.GetScreenShotsDirectory();

        public static void TakeScreenshot(this IWebDriver WebDriver)
        {
            Screenshot scrShot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            scrShot.SaveAsFile($"{_ssPath}//ss_{_ssCounter}.bmp");
            _ssCounter++;
        }

        public static void TakeScreenshot(this IWebDriver WebDriver, string scrshotName)
        {
            Screenshot scrShot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            scrShot.SaveAsFile($"{_ssPath}//{scrshotName}.bmp");
            _ssCounter++;
        }

        public static void TakeScreenshot(this IWebDriver WebDriver, IWebElement webElement)
        {
            webElement.CenterElement();
            Screenshot scrShot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            scrShot.SaveAsFile($"{_ssPath}//ss_{_ssCounter}.bmp");
            _ssCounter++;
        }
    }
}
