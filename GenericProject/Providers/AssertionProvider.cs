using NUnit.Framework;

namespace GenericProject.Providers
{
    public static class AssertionProvider
    {
        public static void EqualsHardAssert(object expectedValue, object actualValue, string assertionMsg)
        {
            ReportProvider.LogInfoInAllReporters(AventStack.ExtentReports.Status.Info, 
                $"Comparing if two elements are equal. \nExpected value: '{expectedValue}' \nActual value: '{actualValue}'");
            Assert.AreEqual(expectedValue, actualValue, assertionMsg);
        }

        public static void NotEqualsHardAssert(object expectedValue, object actualValue, string assertionMsg)
        {
            ReportProvider.LogInfoInAllReporters(AventStack.ExtentReports.Status.Info, 
                $"Comparing if two elements are not equal: \nExpected value: '{expectedValue}' \nActual value: '{actualValue}'");
            Assert.AreNotEqual(expectedValue, actualValue, assertionMsg);
        }

        public static void IsTrueHardAssert(bool actualValue, string assertionMsg)
        {
            ReportProvider.LogInfoInAllReporters(AventStack.ExtentReports.Status.Info, 
                $"Verifying if the element is true: \nActual value: '{actualValue}'");
            Assert.IsTrue(actualValue, assertionMsg);
        }

        public static void IsFalseHardAssert(bool actualValue, string assertionMsg)
        {
            ReportProvider.LogInfoInAllReporters(AventStack.ExtentReports.Status.Info, 
                $"Verifying if the element is false: \nActual value: '{actualValue}'");
            Assert.IsFalse(actualValue, assertionMsg);
        }

        public static void FailTest(string failMsg)
        {
            ReportProvider.LogInfoInAllReporters(AventStack.ExtentReports.Status.Fail, 
                $"Test failed: \n'{failMsg}'");
            Assert.Fail(failMsg);
        }


    }
}
