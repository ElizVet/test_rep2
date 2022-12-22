using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class BasePageObject
    {
        protected static IWebDriver driver;

        public BasePageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}
