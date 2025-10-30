using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private readonly WebDriverWait _wait;
        private readonly By _completeHeader = By.ClassName("complete-header");
        public CheckoutCompletePage(IWebDriver _driver) : base(_driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public bool IsCheckoutComplete()
        {
            var header = _wait.Until(ExpectedConditions.ElementIsVisible(_completeHeader));
            return header.Text.Contains("Thank you for your order!");
        }
    }
}