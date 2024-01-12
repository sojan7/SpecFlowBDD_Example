using OpenQA.Selenium;
using SpecFlowBDD.Core;

namespace SpecFlowBDD.Pages
{
    internal class InformationPage
    {
        private readonly IWebDriver driver;

        public InformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements

        private By FirstNameField { get; } = By.XPath("//input[@id='first-name']");
        private By LastNameField { get; } = By.XPath("//input[@id='last-name']");
        private By PostalCodeField { get; } = By.XPath("//input[@id='postal-code']");
        private By ContinueButton { get; } = By.XPath("//input[@id='continue']");

        #endregion Elements

        #region Actions

        public void EnterUserInformationInCart(string firstName, string lastName, string zipCode)
        {
            driver.WaitForElementVisible(FirstNameField).SendKeys(firstName);
            driver.WaitForElementVisible(LastNameField).SendKeys(lastName);
            driver.WaitForElementVisible(PostalCodeField).SendKeys(zipCode);
            driver.WaitForElementVisible(ContinueButton).Click();
        }

        #endregion Actions
    }
}