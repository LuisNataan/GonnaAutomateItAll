using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _searchBar = By.Id("twotabsearchtextbox");
        private readonly By _userGreeting = By.Id("nav-link-accountList-nav-line-1");
        private readonly By _cartIcon = By.Id("nav-cart");

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public bool IsHomePageDisplayed()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(_searchBar)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string IsUserGreetingDisplayed()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_userGreeting)).Text;
        }

        public void SearchProduct(string product)
        {
            var searchField = _wait.Until(ExpectedConditions.ElementIsVisible(_searchBar));
            searchField.Clear();
            searchField.SendKeys(product);
            searchField.SendKeys(Keys.Enter);
        }

        public void ClickCartIcon()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_cartIcon)).Click();
        }
    }
}