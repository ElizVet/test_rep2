using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Diagnostics;

namespace CorePageObjectTests.Driver
{
    public class DriverSingleton
    {
        private static readonly string BROWSER = "firefox";
        private static IWebDriver _driver;
        public static IWebDriver GetInstance()
        {
            if (_driver == null)
            {
                switch (BROWSER)
                {
                    case "firefox":
                        {
                            _driver = new FirefoxDriver();
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArgument("no-sandbox");
                            break;
                        }
                    case "chrome":
                        {
                            _driver = new ChromeDriver();
                            ChromeOptions options = new ChromeOptions();
                            options.AddArgument("no-sandbox");
                            break;
                        }
                    case "edge":
                        {
                            _driver = new EdgeDriver();
                            EdgeOptions options = new EdgeOptions();
                            options.AddArgument("no-sandbox");
                            break;
                        }
                }
            }
            _driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            _driver.Manage().Window.Maximize();

            return _driver;
        }

        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
