using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages.Base
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void Click(By locator)
        {
            WaitForElementClickable(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return WaitForElementVisible(locator).Text;
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
