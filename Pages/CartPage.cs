using OpenQA.Selenium;
using SpecFlowBDD.Core;

namespace SpecFlowBDD.Pages
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnFinishButton()
        {
            driver.WaitForElementVisible(By.XPath("//button[@id='finish']")).Click();
        }

        public string GetPriceListedInCart()
        {
            return driver.WaitForElementVisible(By.XPath("//div[@class='inventory_item_price']")).Text;
        }

        public string GetItemName()
        {
            return driver.WaitForElementVisible(By.XPath("//div[@class='inventory_item_name']")).Text;
        }

        public void ClickOnCheckOut()
        {
            driver.WaitForElementVisible(By.XPath("//button[@id='checkout']")).Click();
        }

        public string GetFinalSuccessMessageHeading()
        {
            return driver.WaitForElementVisible(By.XPath("//h2[@class='complete-header']")).Text;
        }

        public string GetFinalSuccessMessage()
        {
            return driver.WaitForElementVisible(By.XPath("//div[@class='complete-text']")).Text;
        }
    }
}