using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;

using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebDriverTests
{
    public class Tests2
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            // ��������� ���-��������.
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://www.boho.life/");
            //_chromeDriver.Navigate().GoToUrl("https://www.boho.life/financing");
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void CheckCampersByLocation()
        {
            // ������� ������ ��� �������� �� �� ��������. �������. ���������.
            _chromeDriver.FindElement(By.LinkText("book a trip")).Click();

            // ���������� ���� �� ��������.
            IJavaScriptExecutor js = _chromeDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            // ��������� ���������. (��������� � iframe)
            _chromeDriver.SwitchTo().Frame(_chromeDriver.FindElement(By.XPath("//*[@id='iFrameResizer0']")));

            // ������� �������. �������.
            _chromeDriver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[2]/div[1]/div[2]/ul/li[3]/label/input")).Click();

            // �������, ����� ��� �������� � ������ ���� � ��������������� TEMPE
            List<IWebElement> list = _chromeDriver.FindElements(By.XPath("//li[@class='ember-view _Text_kux1gm']")).Where(x => x.Text != "TEMPE").ToList();
            Assert.IsFalse(list.Count == 0);
        }

        //[Test]
        //public void CheckFinancingCalculator()
        //{
        //    _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        //    _chromeDriver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("1000");
        //    _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        //    _chromeDriver.FindElement(By.XPath("//*[@id='credit']")).Click();
        //}

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}


// ��������� ����������� ����.
//_chromeDriver.FindElement(By.XPath("//a[@class='sqs-popup-overlay-close']")).Click();



//var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(20));
//wait.Until(driver => driver.FindElement(By.ClassName("language-selection")));
//����� ExpectedConditions ������������ ������� ��������� �������� ��������

//Thread.Sleep(1000);
