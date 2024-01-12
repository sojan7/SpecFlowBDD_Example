using OpenQA.Selenium;
using SpecFlowBDD.Core;

namespace SpecFlowBDD.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements

        private By FinishButton { get; } = By.XPath("//button[@id='finish']");
        private By PriceListedInCart { get; } = By.XPath("//div[@class='inventory_item_price']");
        private By InventoryItemName { get; } = By.XPath("//div[@class='inventory_item_name']");
        private By CheckOutButton { get; } = By.XPath("//button[@id='checkout']");
        private By SuccessMessageCompleteHeader { get; } = By.XPath("//h2[@class='complete-header']");
        private By SuccessMessage { get; } = By.XPath("//div[@class='complete-text']");

        #endregion Elements

        #region Actions

        public void ClickOnFinishButton()
        {
            driver.WaitForElementVisible(FinishButton).Click();
        }

        public string GetPriceListedInCart()
        {
            return driver.WaitForElementVisible(PriceListedInCart).Text;
        }

        public string GetItemName()
        {
            return driver.WaitForElementVisible(InventoryItemName).Text;
        }

        public void ClickOnCheckOut()
        {
            driver.WaitForElementVisible(CheckOutButton).Click();
        }

        public string GetFinalSuccessMessageHeading()
        {
            return driver.WaitForElementVisible(SuccessMessageCompleteHeader).Text;
        }

        public string GetFinalSuccessMessage()
        {
            return driver.WaitForElementVisible(SuccessMessage).Text;
        }

        #endregion Actions
    }
}