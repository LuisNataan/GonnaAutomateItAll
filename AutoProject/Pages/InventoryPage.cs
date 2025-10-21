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
        private By AddToCarton => By.CssSelector("[data-test='add-to-cart-sauce-labs-fleece-jacket']");
        private By CartIcon => By.CssSelector("[data-test='shopping_cart_link']");
        private By _inventoryContainer => By.CssSelector("[data-test='inventory_container']");
        private By _inventoryItem => By.CssSelector("[data-test='inventory_item']");

        public void AddProductToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(AddToCarton)).Click();
        }

        public void NavigateToCartPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartIcon)).Click();
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
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartIcon)).Click();
        }
    }
}