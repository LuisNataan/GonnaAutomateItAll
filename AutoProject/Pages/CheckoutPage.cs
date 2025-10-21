using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _firstName = By.Id("first-name");
        private readonly By _lastName = By.Id("last-name");
        private readonly By _postalCode = By.Id("postal-code");
        private readonly By _continueButton = By.Id("continue");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void FillCheckoutForm(string firstName, string lastName, string postalCode)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_firstName)).SendKeys(firstName);
            _wait.Until(ExpectedConditions.ElementIsVisible(_lastName)).SendKeys(lastName);
            _wait.Until(ExpectedConditions.ElementIsVisible(_postalCode)).SendKeys(postalCode);
            _wait.Until(ExpectedConditions.ElementIsVisible(_continueButton)).Click();
        }

        public void ClickContinue()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_continueButton)).Click();
        }
    }
}