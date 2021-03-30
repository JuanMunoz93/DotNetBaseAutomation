Feature: Wikipedia Features

Scenario: Search in wikipedia
	Given the browser is in the wikipedia home page
	When dotnet is searched
	Then a dotnet result page is opened