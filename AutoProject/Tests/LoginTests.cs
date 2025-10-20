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
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            _driver.Manage().Window.Maximize();

            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
        }

        [Test]
        public void Login_WithValidCredentials_ShouldAccessHomePage()
        {
            _loginPage.NavigateToLoginPage();
            _loginPage.EnterUsername("standard_user");
            _loginPage.EnterPassword("secret_sauce");
            _loginPage.ClickLogin();

            Assert.That(_homePage.IsHomePageDisplayed(), Is.True, "Home page was not displayed after login.");
        }

        [Test]
        public void Login_WithInvalidCredentials_ShouldDisplayErrorMessage()
        {
            _loginPage.NavigateToLoginPage();
            _loginPage.EnterUsername("invalid_user");
            _loginPage.EnterPassword("wrong_password");
            _loginPage.ClickLogin();

            Assert.That(_loginPage.IsErrorMessageDisplayed(), Is.True, "Error message not displayed for invalid login.");
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