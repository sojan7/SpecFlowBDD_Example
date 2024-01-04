using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowBDD.Core
{
    public static class DriverExtensions
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static IWebElement WaitForElementVisible(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}