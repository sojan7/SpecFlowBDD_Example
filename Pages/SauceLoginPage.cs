using OpenQA.Selenium;
using SpecFlowBDD.Core;

namespace SpecFlowBDD.Pages
{
    public class SauceLoginPage
    {
        private readonly IWebDriver driver;

        public SauceLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements

        private By UserName { get; } = By.XPath("//input[@id='user-name']");
        private By Password { get; } = By.XPath("//input[@id='password']");
        private By LoginButton { get; } = By.XPath("//input[@id='login-button']");

        #endregion Elements

        #region Actions

        public void Login(string userName, string password)
        {
            driver.WaitForElementVisible(UserName).SendKeys(userName);
            driver.WaitForElementVisible(Password).SendKeys(password);
            driver.WaitForElementVisible(LoginButton).Click();
        }

        #endregion Actions
    }
}