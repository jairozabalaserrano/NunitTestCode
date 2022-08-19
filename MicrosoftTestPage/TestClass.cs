using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MicrosoftTestPage.BaseClass;
using MicrosoftTestPage.Utilities;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace MicrosoftTestPage
{
    [TestFixture]
    public class TestClass
    {
        protected IWebDriver driver;

        [Test, Order(0), Category("UAT Testing")]
        [Author("Jairo Zabala", "jairoandreszabala@hotmail.com")]
        [Description("Check prices and items on the microsoft page")]
        [TestCaseSource("DataDrivenTesting")]
        public void TestMethod(JObject DataDriven)
        {
            var Driver = new BrowserUtility().OpenSelectBrowser(driver, (string)DataDriven["browser"]);
            BaseTest.ClicButtonWindows(Driver);
            BaseTest.VerifyUrlOfThePage((string)DataDriven["urlWindows"], Driver);
            BaseTest.ClicButtonSearch((string)DataDriven["itemToSearch"], Driver);
            BaseTest.ClicBuyText(Driver);
            BaseTest.ClicApplicationsText(Driver);
            BaseTest.VerifyUrlOfThePage((string)DataDriven["urlApplications"], Driver);
            BaseTest.ClicGoToAllApplications(Driver);
            int getCountFirstPageBaseTest = BaseTest.GetCountElementsInPage(Driver);
            BaseTest.ClicNextPage(Driver);
            int getCountSecondPageBaseTest = BaseTest.GetCountElementsInPage(Driver);
            BaseTest.ClicNextPage(Driver);
            int getCountThirdPageBaseTest = BaseTest.GetCountElementsInPage(Driver);
            BaseTest.PrintCountOfElements(Driver, (getCountFirstPageBaseTest + getCountSecondPageBaseTest + getCountThirdPageBaseTest));
            BaseTest.ClicGoToTheFirstPage(Driver);
            string firstItemCurrentPage = BaseTest.GetPriceFirstItem(Driver);
            Assert.That(firstItemCurrentPage, Is.EqualTo(BaseTest.GetAllItems()[1, 2]));
            BrowserUtility.CloseBrowser(Driver);
            Assert.Pass();
        }
        
        static IList DataDrivenTesting()
        {
            ArrayList list = new()
            {
                new JsonReader().GetDataFromJson()
            };
            return list;
        }
    }
}