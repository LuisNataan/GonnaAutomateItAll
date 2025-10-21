using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoProject.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public virtual void SetUp()
        {
            var opt = new ChromeOptions();
            
            //Arguments
            opt.AddArgument("--start-maximized");
            opt.AddArgument("--disable-notifications");
            opt.AddArgument("--incognito");
            opt.AddArgument("--no-default-browser-check");
            opt.AddArgument("--no-first-run");
            opt.AddArgument("--diasble-blink-fetrures=AutomationControlled");
            

            
            opt.AddUserProfilePreference("credential_enable_service", false);
            opt.AddUserProfilePreference("profile.password_manager_enabled", false);
            opt.AddUserProfilePreference("credentials_enable_service", false);
            opt.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            opt.AddExcludedArgument("enable-automation");

            Driver = new ChromeDriver(opt);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
