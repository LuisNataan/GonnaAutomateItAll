using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoProject.Pages;
using NUnit.Framework;

namespace AutoProject.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.amazon.com.br");
            _driver.Manage().Window.Maximize();

            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
        }

        [Test]
        public void Login_WithValidCredentials_ShouldAccessAccount()
        {
            _loginPage.NavigateToLoginPage();
            _loginPage.EnterEmail("9Xu0d@example.com");
            _loginPage.ClickContinue();
            _loginPage.EnterPassword("123456789");
            _loginPage.ClickSignIn();

            Assert.IsTrue(_homePage.IsHomePageDisplayed(), "Home page was not displayed after login.");
            Assert.IsTrue(_homePage.IsUserGreetingDisplayed().Contains("Olá"), "User greeting not found - login may have failed.");
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}