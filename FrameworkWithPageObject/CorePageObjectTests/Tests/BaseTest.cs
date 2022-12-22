using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using CorePageObjectTests.Driver;

namespace CorePageObjectTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup() => driver = DriverSingleton.GetInstance();

        [TearDown]
        public void TearDown() => DriverSingleton.CloseBrowser();
    }
}
