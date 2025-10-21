using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Seletores para os elementos de login da SauceDemo
        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.Id("[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));
        }

        public void Login(string username, string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name"))).SendKeys(username);
            _driver.FindElement(By.Id("password")).SendKeys(password);
            _driver.FindElement(By.Id("login-button")).Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                var errorElement = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='error']")));
                return errorElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
