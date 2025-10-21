using OpenQA.Selenium;
using AutoProject.Pages;

namespace AutoProject.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {

        [Test]
        public void Login_WithValidCredentials_ShouldAccessHomePage()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.NavigateToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");

            var homePage = new HomePage(Driver);
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "Home page was not displayed after login.");
        }

        [Test]
        public void Login_WithInvalidCredentials_ShouldDisplayErrorMessage()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.NavigateToLoginPage();
            loginPage.Login("invalid_user", "invalid_password");

            Assert.That(loginPage.IsErrorMessageDisplayed(), Is.True, "Error message not displayed for invalid login.");
        }

        [Test]
        public void Login_WithValidCredentials_ShouldAccessInventoryPage()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.NavigateToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.AddProductToCart();
            inventoryPage.NavigateToCartPage();

            Assert.That(inventoryPage.IsInventoryPageDisplayed(), Is.True, "Cart page was not displayed after adding product to cart.");
        }
    }
}