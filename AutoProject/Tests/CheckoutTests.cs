using AutoProject.Pages;

namespace AutoProject.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        [Test]
        public void Checkout_WithValidInformation_ShouldDisplaySuccessMessage()
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);
            var cartPage = new CartPage(Driver);
            var checkoutPage = new CheckoutPage(Driver);
            var checkoutOverviewPage = new CheckoutOverviewPage(Driver);
            var checkoutCompletePage = new CheckoutCompletePage(Driver);

            loginPage.NavigateToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            Assert.That(inventoryPage.IsInventoryPageDisplayed(), Is.True, "Inventory page was not displayed after login.");
            
            inventoryPage.AddProductToCart();
            inventoryPage.NavigateToCartPage();
            Assert.That(cartPage.IsCartPageDisplayed(), Is.True, "Cart page was not displayed after adding product to cart.");

            cartPage.ClickCheckoutButton();
            checkoutPage.FillCheckoutForm("Natan", "Luis", "123 Main Street");
            checkoutPage.ClickContinue();
            Assert.That(checkoutOverviewPage.IsOverviewPageDisplayed(), "Checkout overview page was not displayed.");

            checkoutOverviewPage.ClickFinishButton();
            Assert.That(checkoutCompletePage.IsCheckoutComplete(), "Checkout complete page was not displayed.");
        }
    }
}