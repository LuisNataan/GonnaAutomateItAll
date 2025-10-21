using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutoProject.Utils
{
    public class WaitHelper
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public bool WaitForElementInvisible(By locator)
        {
            return _wait.Until(d => d.FindElements(locator).Count == 0);
        }
        
        public static IWebDriver Wait(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            return driver;
        }
    }
}