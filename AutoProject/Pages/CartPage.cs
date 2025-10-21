using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _checkoutButton = By.Id("checkout");
        private readonly By _cartTitle = By.ClassName("title");
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public bool IsCartPageDisplayed()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_cartTitle)).Displayed;
        }

        public void ClickCheckoutButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_checkoutButton)).Click();
        }
    }
}