# Overview
This Specflow + NUnit project contains all the necessary elements, configurations, and examples to build 
a complete and professional test automation project. This proposal wants to keep the main elements decoupled so that, if necessary, they can be changed without having cascading effects.

The objective of this project is to save time on a new automation project, do not hesitate to copy, download and modify it and please feel free to contact me for any question, suggestion o comment.

# VisualStudio Extensions
+ Specflow

# Nugget PackagesS
## WebBrowser Automation
+ Selenium.WebDriver
+ Selenium.WebDriver.Chrome
+ DotNetSeleniumExtras.WaitHelpers

## Reports
+ NLog
+ ExtentReports

## AI
+ Tesseract
+ SikuliSharp

# Notes
The next files needs the "Copy if newer" or the "Copy always" value in the "Copy to Output Directory" property:
+ NLog.config
+ testdata/eng.traineddata

Sikulix is not recommended to use with dotnet, currently to use it is needed to install Java and an obsolete sikuli desktop version (1.1.3 available on https://launchpad.net/sikuli/+download). You should add the SIKULI_HOME environment variable with the sikuli installation path as value. In this project you can find an example of the use of sikuli in the testing context, but if you need to use this tool Java has and api and its use with this language is easier.


# Contact
+ mail: juan_munozbe@outlook.com
+ linkedin: https://www.linkedin.com/in/juan-munoz-bedoya/