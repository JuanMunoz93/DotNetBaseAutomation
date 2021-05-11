Feature: AIFeatures

Scenario: Tesseract Implementation
	Given the browser is opened in the OCR Test Images Page
	When the page is analized with tesseract
	Then the text "Stocks in bold rose or fell 5% or more" is found

Scenario: Sikuli Implementation
	Given the browser is opened in the Google Home Page
	When "sikuli" is typed in the search bar using sikuli
	Then in the search bar is visible the text "sikuli"
