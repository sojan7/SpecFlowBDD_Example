using OpenQA.Selenium;
using SpecFlowBDD.Core;

namespace SpecFlowBDD.Pages
{
    internal class InformationPage
    {
        private IWebDriver driver;

        public InformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUserInformationInCart(string firstName, string lastName, string zipCode)
        {
            driver.WaitForElementVisible(By.XPath("//input[@id='first-name']")).SendKeys(firstName);
            driver.WaitForElementVisible(By.XPath("//input[@id='last-name']")).SendKeys(lastName);
            driver.WaitForElementVisible(By.XPath("//input[@id='postal-code']")).SendKeys(zipCode);
            driver.WaitForElementVisible(By.XPath("//input[@id='continue']")).Click();
        }
    }
}