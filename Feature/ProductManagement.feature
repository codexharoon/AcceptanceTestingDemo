Feature: Product management
  In order to manage products
  As a user
  I want to add and remove products from a list

  Scenario: Add a product to the list
    Given the product list is empty
    When I add "Apple"
    Then the product list should contain "Apple"

  Scenario: Remove a product from the list
    Given the product list has "Banana"
    When I remove "Banana"
    Then the product list should not contain "Banana"

  Scenario: Check if a product is in the list
    Given the product list has "Orange"
    When I check for "Orange"
    Then the product list should contain checked "Orange"
