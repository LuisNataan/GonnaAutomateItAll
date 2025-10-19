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
        private readonly By _errorMEssage = By.Id("[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));
        }

        public void EnterUsername(string username)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField)).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField)).SendKeys(password);
        }

        public void ClickLogin()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton)).Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(_errorMEssage)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
