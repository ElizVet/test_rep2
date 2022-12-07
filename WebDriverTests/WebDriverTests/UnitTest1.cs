using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverTests
{
    public class Tests
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://pastebin.com");
        }

        [Test]
        public void ICanWin()
        {
            _chromeDriver.FindElement(By.XPath("//textarea[@id='postform-text']")).
                SendKeys("Hello from WebDriver");

            _chromeDriver.FindElement(By.XPath("//span[@id='select2-postform-expiration-container']")).Click();
            _chromeDriver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            _chromeDriver.FindElement(By.XPath("//input[@name='PostForm[name]']")).
                SendKeys("helloweb");

            _chromeDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();

            Assert.AreEqual(_chromeDriver.FindElement(By.XPath("//div[@class='de1']")).Text, "Hello from WebDriver");
        }

        [Test]
        public void BringItOn()
        {
            string code = "git config --global user.name  \"New Sheriff in Town\"" +
                "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\")" +
                "\ngit push origin master --force";
            _chromeDriver.FindElement(By.XPath("//textarea[@id='postform-text']")).
                SendKeys(code);
            
            _chromeDriver.FindElement(By.XPath("//span[@id='select2-postform-format-container']")).Click();
            _chromeDriver.FindElement(By.XPath("//li[text()='Bash']")).Click();

            _chromeDriver.FindElement(By.XPath("//span[@id='select2-postform-expiration-container']")).Click();
            _chromeDriver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            _chromeDriver.FindElement(By.XPath("//input[@name='PostForm[name]']")).
                SendKeys("how to gain dominance among developers");

            _chromeDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();

            StringAssert.Contains("how to gain dominance among developers", _chromeDriver.Title);
            Assert.IsTrue(_chromeDriver.FindElement(By.XPath("//a[@class='btn -small h_800']")).Text == "Bash");

            string expectedStr = "";
            foreach(var item in _chromeDriver.FindElements(By.XPath("//li[@class='li1']")))
            {
                expectedStr += item.Text + "\n";
            }
            StringAssert.Contains(expectedStr, code + "\n");
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}