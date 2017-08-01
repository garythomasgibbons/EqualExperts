using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace EqualExperts.Pages
{
    [Binding]
    public class BasePage
    {
        public static ChromeDriver driver;

        [BeforeFeature]
        public static void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterFeature]
        public static void AfterScenario()
        {
            driver.Quit();
        }

    }
}
