using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly WebDriverWait _wait;

        public InventoryPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        private static By AddJacketToCart => By.CssSelector("[data-test='add-to-cart-sauce-labs-fleece-jacket']");
        private static By RemoveJacketFromCart => By.CssSelector("[data-test='remove-sauce-labs-fleece-jacket']");
        private static By CartIcon => By.CssSelector("[data-test='shopping-cart-link']");
        private static By InventoryContainer => By.CssSelector("[data-test='inventory-item']");

        public void AddProductToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(AddJacketToCart)).Click();
        }

        public void NavigateToCartPage()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(CartIcon)).Click();
        }

        public bool IsInventoryPageDisplayed()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(InventoryContainer)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public int GetNumberOfProducts()
        {
            return _driver.FindElements(InventoryContainer).Count;
        }

        public void ClickCartIcon()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartIcon)).Click();
        }

        public void RemoveProductFromCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(RemoveJacketFromCart)).Click();
        }
    }
}