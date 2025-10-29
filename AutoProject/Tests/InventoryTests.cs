using AutoProject.Pages;

namespace AutoProject.Tests
{
    public class InventoryTests : BaseTest
    {

        [Test]
        public void Inventory_WithValidCredentials_ShouldDisplayInventoryItems()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.NavigateToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            Assert.That(loginPage.IsErrorMessageDisplayed(), Is.False, "Error message displayed for valid login.");

            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.IsInventoryPageDisplayed();
            inventoryPage.GetNumberOfProducts();
            Assert.That(inventoryPage.GetNumberOfProducts(), Is.GreaterThan(0), "No products displayed.");
            Assert.That(inventoryPage.IsInventoryPageDisplayed(), Is.True, "Inventory page was not displayed after login.");
        }

        [Test]
        public void Inventory_WithValidCredentials_ShouldAddProductToCart()
        {
            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.NavigateToCartPage();
            inventoryPage.IsInventoryPageDisplayed();
            inventoryPage.AddProductToCart();
        }
    }
}