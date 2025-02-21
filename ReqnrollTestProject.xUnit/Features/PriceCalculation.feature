Feature: Price calculation

This feature is about calculating the basket price.

We work with fixed item prices for now:
* Electric guitar: $180
* Guitar pick: $1.5

Scenario: Client has a simple basket
  Given the client started shopping
  And the client added 1 pcs of "Electric guitar" to the basket
  When the basket is prepared
  Then the basket price should be $180
