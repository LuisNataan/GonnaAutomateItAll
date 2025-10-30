using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class HomePage : BasePage
    {
        private readonly WebDriverWait _wait;
        private readonly By _inventoryContainer = By.Id("inventory_container");
        private readonly By _menuButton = By.Id("react-burger-menu-btn");

        public HomePage(IWebDriver driver) : base(driver)
        {
            this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public bool IsHomePageDisplayed()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(_inventoryContainer)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void OpenMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_menuButton)).Click();
        }
    }
}