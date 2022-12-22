using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePageObjectTests.Util
{
    public class JSUtil
    {
        public static void Scroll(IWebDriver driver, int valueScroll)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript($"window.scrollBy(0,{valueScroll});");
        }
    }
}
