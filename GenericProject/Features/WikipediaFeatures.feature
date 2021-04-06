Feature: Wikipedia Features

Scenario: Search in wikipedia
	Given the browser is in the wikipedia home page
	When .net is searched
	Then a .net result page is opened