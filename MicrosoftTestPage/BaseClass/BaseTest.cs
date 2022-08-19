using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using System.Xml.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MicrosoftTestPage.Utilities;

namespace MicrosoftTestPage.BaseClass
{
    public class BaseTest
    {
        public static int countSignUp = 0;
        public static string[,] elementsFirstPage;

        public static void ClicButtonWindows(IWebDriver Driver)
        {
            IWebElement buttonWindows = Driver.FindElement(By.XPath("(//a[contains(text(),'Windows')])[1]"));
            buttonWindows.Click();
        }

        public static void VerifyUrlOfThePage(String UrlExpected, IWebDriver Driver)
        {
            Assert.That(UrlExpected, Is.EqualTo(Driver.Url.ToString()));
        }

        public static void ClicButtonSearch(String ItemToSearch, IWebDriver Driver)
        {
            IWebElement buttonSearchIcon = Driver.FindElement(By.XPath("//button[@id='search']"));
            buttonSearchIcon.Click();
            IWebElement buttonSearch = Driver.FindElement(By.XPath("//input[@placeholder='Buscar en Microsoft.com']"));
            buttonSearch.SendKeys(ItemToSearch);

        }

        public static void ClicBuyText(IWebDriver Driver)
        {
            WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[starts-with(@title,'Consolas Xbox')]")));
            IWebElement buyText = Driver.FindElement(By.XPath("//li[starts-with(@title,'Consolas Xbox')]"));
            buyText.Click();
        }

        public static void ClicApplicationsText(IWebDriver Driver)
        {
            WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[starts-with(@aria-label,'Aplicaciones')]")));
            IWebElement linkTextApplications = Driver.FindElement(By.XPath("//a[starts-with(@aria-label,'Aplicaciones')]"));
            linkTextApplications.Click();
        }

        public static void ClicGoToAllApplications(IWebDriver Driver)
        {
            WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[contains(text(),'Mostrar todo')])[1]")));
            IWebElement buttonShowAllApplications = Driver.FindElement(By.XPath("(//a[contains(text(),'Mostrar todo')])[1]"));
            buttonShowAllApplications.Click();
        }

        public static void ClicNextPage(IWebDriver Driver)
        {
            IWebElement buttonNextPage = Driver.FindElement(By.XPath("//a[@aria-label='next page']"));
            buttonNextPage.Click();    
        }

        public static int GetCountElementsInPage(IWebDriver Driver)
        {
            WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='m-channel-placement-item']")));
            ReadOnlyCollection<IWebElement> firstGroupElements = Driver.FindElements(By.XPath("//div[@class='m-channel-placement-item']"));
            BaseTest.CloseSignUpAlert(Driver);
            elementsFirstPage = new string[firstGroupElements.Count + 1, 3];
            int count = firstGroupElements.Count();
            for (int i = 1; i <= count; i++)
            {
                elementsFirstPage[i, 0] = i.ToString();
                elementsFirstPage[i, 1] = Driver.FindElement(By.XPath($"(//h3[@class='c-subheading-6'])[\"{i}\"]")).Text;
                elementsFirstPage[i, 2] = Driver.FindElement(By.XPath($"(//span[starts-with(@content,'Free')])[\"{i}\"]")).Text;
            }
            return elementsFirstPage.GetLength(0) - 1;
        }

        public static void CloseSignUpAlert(IWebDriver Driver)
        {
            if (countSignUp == 0)
            {
                WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='sfw-dialog']")));
                IWebElement buttonCloseSignUpAlert = Driver.FindElement(By.XPath("//div[@class='c-glyph glyph-cancel']"));
                buttonCloseSignUpAlert.Click();
                countSignUp--;
            }
           
        }

        public static void PrintCountOfElements(IWebDriver Driver, int elements)
        {
            Console.WriteLine(elements);
            Driver.ExecuteJavaScript($"console.log(\"{elements}\");");
        }

        public static void ClicGoToTheFirstPage(IWebDriver Driver)
        {
            WaitClass.WaitUntilAppearsElement(Driver).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@aria-label='page 1']")));
            IWebElement buttonGoToTheFirstPage = Driver.FindElement(By.XPath("//a[@aria-label='page 1']"));
            buttonGoToTheFirstPage.Click();     
        }

        public static string GetPriceFirstItem(IWebDriver Driver)
        {
            string[,] ElementsToCompare = new string[ 1, 1];
            ElementsToCompare[0, 0] = Driver.FindElement(By.XPath($"(//span[starts-with(@content,'Free')])[1]")).Text;
            return ElementsToCompare[0, 0];
        }

        public static string[,] GetAllItems()
        {
            return elementsFirstPage;
        }
    }       
}
