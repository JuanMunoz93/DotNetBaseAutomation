Feature: AIFeatures

Scenario: Tesseract Implementation
	Given the browser is in an OCR Test Images Page
	When the page is analized with tesseract
	Then the text "Stocks in bold rose or fell 5% or more" is found