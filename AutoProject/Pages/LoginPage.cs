using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Seletores para os elementos de login da Amazon
        private readonly By _accountList = By.Id("nav-link-accountList");
        private readonly By _emailField = By.Id("ap_email");
        private readonly By _continueButton = By.Id("continue");
        private readonly By _passwordField = By.Id("ap_password");
        private readonly By _signInButton = By.Id("signInSubmit");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.amazon.com.br/ap/signin");
        }

        public void EnterEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_emailField)).SendKeys(email);
        }

        public void ClickContinue()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_continueButton)).Click();
        }

        public void EnterPassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField)).SendKeys(password);
        }

        public void ClickSignIn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_signInButton)).Click();
        }

        public bool IsLoginPageDisplayed()
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(_emailField)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
