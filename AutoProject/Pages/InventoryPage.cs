using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        private By _addToCarton => By.CssSelector("[data-test='add-to-cart-sauce-labs-fleece-jacket']");
        private By _cartIcon => By.CssSelector("[data-test='shopping-cart-link']");
        private By _inventoryContainer => By.CssSelector("[data-test='inventory-item']");
        private By _inventoryItem => By.CssSelector("[data-test='inventory-item-name']");

        public void AddProductToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_addToCarton)).Click();
        }

        public void NavigateToCartPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_cartIcon)).Click();
        }

        public bool IsInventoryPageDisplayed()
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

        public int GetNumberOfProducts()
        {
            return _driver.FindElements(_inventoryContainer).Count;
        }

        public void ClickCartIcon()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_cartIcon)).Click();
        }
    }
}