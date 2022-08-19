using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTestPage.Utilities
{
    public class BrowserUtility
    {
        public IWebDriver OpenSelectBrowser(IWebDriver Driver, String BrowserType)
        {
            if (BrowserType == "Chrome")
            {
                Driver = new ChromeDriver();   
            }
            else if (BrowserType == "Edge")
            {
                Driver = new EdgeDriver(); 
            }
            Driver.Url = "https://www.microsoft.com/es-mx/";
            Driver.Manage().Window.Maximize();
            return Driver;

        }

        [TearDown]
        public static void CloseBrowser(IWebDriver Driver)
        {
            Driver.Quit();
        }
    }
}
