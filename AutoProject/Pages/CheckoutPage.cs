using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly WebDriverWait _wait;
        private readonly By _firstName = By.Id("first-name");
        private readonly By _lastName = By.Id("last-name");
        private readonly By _postalCode = By.Id("postal-code");
        private readonly By _continueButton = By.Id("continue");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void FillCheckoutForm(string firstName, string lastName, string postalCode)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_firstName)).SendKeys(firstName);
            _driver.FindElement(_lastName).SendKeys(lastName);
            _driver.FindElement(_postalCode).Clear();
            _driver.FindElement(_postalCode).SendKeys(postalCode);
        }

        public void ClickContinue()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_continueButton)).Click();
        }
    }
}