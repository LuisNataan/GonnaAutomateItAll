using AutoProject.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private readonly WebDriverWait _wait;
        private readonly By _finishButton = By.Id("finish");
        private readonly By _summaryTitle = By.ClassName("title");

        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public bool IsOverviewPageDisplayed()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_summaryTitle)).Displayed;
        }

        public void ClickFinishButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_finishButton)).Click();
        }
    }
}