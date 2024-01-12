Feature: SauceDemo Site Testing

The user should be able to order item from the Site

Background:
	Given The user "standard_user" login using the password "secret_sauce"

@VerifyProductPurchase
Scenario: Tests the product purchase
	Given the user selects an item "Sauce Labs Backpack"
	And the goto the cart
	Then price in home is equal to price in cart
	Given the user checkout the selected product
	And the user enter required details "Sojan" "Somarajan" "123456" and continue
	Then price in final checkout page is the initial price and Item name is "Sauce Labs Backpack"
	Given user finish shopping
	Then thank you message for order should be displayed