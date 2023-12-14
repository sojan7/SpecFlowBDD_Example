using OpenQA.Selenium;
using SpecFlowBDD.Core;
using SpecFlowBDD.Drivers;

namespace SpecFlowBDD.Pages
{
    public class SauceHomePage : DriveBase
    {
        private IWebDriver driver;

        public SauceHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnCartIcon()
        {
            driver.WaitForElementVisible(By.XPath("//a[@class='shopping_cart_link']")).Click();
        }

        public void SelectAnItem(string itemName)
        {
            driver.WaitForElementVisible(By.XPath($"//div[text()='{itemName}']/parent::a/parent::div/parent::div//button")).Click();
        }

        public string GetTheCostOfASpecificItem(string itemName)
        {
            return driver
                .WaitForElementVisible(By.XPath(
                    $"//div[text()='{itemName}']/parent::a/parent::div/parent::div//div[@class='pricebar']//div"))
                .Text;
        }
    }
}