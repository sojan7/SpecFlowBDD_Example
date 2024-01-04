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

        public void Login(string userName, string password)
        {
            driver.WaitForElementVisible(By.XPath("//input[@id='user-name']")).SendKeys(userName);
            driver.WaitForElementVisible(By.XPath("//input[@id='password']")).SendKeys(password);
            driver.WaitForElementVisible(By.XPath("//input[@id='login-button']")).Click();
        }
    }
}