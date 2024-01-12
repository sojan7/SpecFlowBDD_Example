using OpenQA.Selenium;
using SpecFlowBDD.Core;
using SpecFlowBDD.Drivers;

namespace SpecFlowBDD.Pages
{
    public class SauceHomePage : DriveBase
    {
        private readonly IWebDriver driver;

        public SauceHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements

        private By AddToCartButton { get; } = By.XPath("//a[@class='shopping_cart_link']");

        #endregion Elements

        #region Actions

        public void ClickOnCartIcon()
        {
            driver.WaitForElementVisible(AddToCartButton).Click();
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

        #endregion Actions
    }
}