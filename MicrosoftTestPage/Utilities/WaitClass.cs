using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTestPage.Utilities
{
     public class WaitClass
    {
         public static WebDriverWait WaitUntilAppearsElement(IWebDriver Driver)
        {
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(20));
            return wait;
        }
    }
}
