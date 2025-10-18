using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomation.Drivers
{
    public class WebDriverSetup
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }
    }
}
