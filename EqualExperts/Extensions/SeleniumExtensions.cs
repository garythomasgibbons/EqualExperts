using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EqualExperts.Extensions
{
    public static class SeleniumExtensions
    {
        public static void FindElement(this IWebElement element, By by, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));

            driver.FindElement(by);
        }

        public static void ClearAndSendKeys(this IWebElement element, string inputText)
        {
            element.Clear();
            element.SendKeys(inputText);
        }
    }
}
