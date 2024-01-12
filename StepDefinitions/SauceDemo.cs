using NUnit.Framework;
using SpecFlowBDD.Core;
using SpecFlowBDD.Drivers;
using SpecFlowBDD.Pages;

namespace SpecFlowBDD.StepDefinitions
{
    [Binding]
    internal class SauceDemo : DriveBase
    {
        private readonly SauceLoginPage sauceLoginPage;
        private readonly SauceHomePage sauceHomePage;
        private readonly ScenarioContext scenarioContext;
        private readonly CartPage cartPage;
        private readonly InformationPage informationPage;

        public SauceDemo(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            Driver = GetWebDriver("chrome");
            sauceLoginPage = new(Driver);
            sauceHomePage = new(Driver);
            cartPage = new(Driver);
            informationPage = new(Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

        [BeforeScenario]
        public void NavigateToApplication()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Driver.Manage().Window.Maximize();
            Driver.WaitForPageToLoad();
        }

        [Given(@"The user ""([^""]*)"" login using the password ""([^""]*)""")]
        public void GivenTheUserLoginUsingThePassword(string userName, string password)
        {
            sauceLoginPage.Login(userName, password);
        }

        [Given(@"the user selects an item ""([^""]*)""")]
        public void GivenTheUserSelectsAnItem(string itemName)
        {
            scenarioContext.Add("priceInHomePage", sauceHomePage.GetTheCostOfASpecificItem(itemName));
            sauceHomePage.SelectAnItem(itemName);
        }

        [Given(@"the goto the cart")]
        public void GivenTheGotoTheCart()
        {
            sauceHomePage.ClickOnCartIcon();
        }

        [Then(@"price in home is equal to price in cart")]
        public void ThenPriceInHomeIsEqualToPriceInCart()
        {
            Assert.That(scenarioContext.Get<string>("priceInHomePage").Equals(cartPage.GetPriceListedInCart()));
        }

        [Given(@"the user checkout the selected product")]
        public void GivenTheUserCheckoutTheSelectedProduct()
        {
            cartPage.ClickOnCheckOut();
        }

        [Given(@"the user enter required details ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" and continue")]
        public void GivenTheUserEnterRequiredDetailsAndContinue(string firstName, string lastName, string zipCode)
        {
            informationPage.EnterUserInformationInCart(firstName, lastName, zipCode);
        }

        [Then(@"price in final checkout page is the initial price and Item name is ""([^""]*)""")]
        public void ThenPriceInFinalCheckoutPageIsTheInitialPriceAndItemNameIs(string expectedItemName)
        {
            var a = cartPage.GetItemName();
            Assert.That(a.Equals(expectedItemName), Is.True);
        }

        [Given(@"user finish shopping")]
        public void GivenUserFinishShopping()
        {
            cartPage.ClickOnFinishButton();
        }

        [Then(@"thank you message for order should be displayed")]
        public void ThenThankYouMessageForOrderShouldBeDisplayed()
        {
            Assert.That("Thank you for your order!".Equals(cartPage.GetFinalSuccessMessageHeading()));
            Assert.That("Your order has been dispatched, and will arrive just as fast as the pony can get there!".Equals(cartPage.GetFinalSuccessMessage()));
        }
    }
}