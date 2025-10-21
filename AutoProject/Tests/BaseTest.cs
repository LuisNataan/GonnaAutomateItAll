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
            opt.AddArgument("--start-maximized");
            opt.AddArgument("--disable-notifications");

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
