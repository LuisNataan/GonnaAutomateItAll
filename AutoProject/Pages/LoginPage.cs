using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class LoginPage : BasePage
    {
        private readonly WebDriverWait _wait;

        // Seletores para os elementos de login da SauceDemo
        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.Id("[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));
        }

        public void Login(string username, string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField)).SendKeys(username);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_loginButton).Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                var errorElement = _wait.Until(ExpectedConditions.ElementIsVisible(_errorMessage));
                return errorElement.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
