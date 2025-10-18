using OpenQA.Selenium;
using TestAutomation.Drivers;

namespace AutoProject.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(WebDriverSetup driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }
    }
}