using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorePageObjectTests.PageObjects
{
    public class MainPageObject : BasePageObject
    {
        private const string BASE_URL = "https://www.boho.life/";

        public MainPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _popUpWindow => driver
            .FindElement(By.XPath("//a[@class='sqs-popup-overlay-close']"));
        private IWebElement _btnBookATrip => driver.FindElement(By.LinkText("book a trip"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public MainPageObject ClickOnBookATrip()
        {
            _btnBookATrip.Click();
            return this;
        }
        public MainPageObject ClosePopUpWindow()
        {
            _popUpWindow.Click();
            return this;
        }
    }
}
