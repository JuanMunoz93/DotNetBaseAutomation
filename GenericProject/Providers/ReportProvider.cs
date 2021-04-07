using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using GenericProject.Utils;
using NLog;
using System;

namespace GenericProject.Providers
{
    public static class ReportProvider
    {
        private static readonly Logger _logger = LogManager.GetLogger("customLogger");
        private static ExtentReports _extentReports;
        private static bool isInit = false;
        private static ExtentTest _test { get; set; }

        public static void InitReporter()
        {
            if (isInit) return;

            
            string projectdirectory = GenericUtils.GetProjectDirectory();
            GenericUtils.CreateDirectory($"{projectdirectory}/Reports");
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter($"{projectdirectory}/Reports/Report.html");

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(extentHtmlReporter);
            _extentReports.AddSystemInfo("Machine User Name", Environment.UserName);
            isInit = true;
        }

        public static void GenerateHtmlReport(string status, string message)
        {
            Status logStatus;
            switch (status)
            {
                case "Passed":
                    logStatus = Status.Pass;
                    break;
                case "Failed":
                    logStatus = Status.Fail;
                    break;
                case "Skipped":
                    logStatus = Status.Skip;
                    break;
                case "Inconclusive":
                default:
                    logStatus = Status.Warning;
                    break;
            }

            LogInfoInAllReporters(logStatus, $"Execution status: {status}");
            _extentReports.Flush();
        }

        public static void CreateTest(string testName)
        {
            _test = _extentReports.CreateTest(testName);
            LogTestStarted(testName);
        }

        public static void LogInfoInAllReporters(Status status,string message)
        {
            _test.Log(status, message);      //log in the html report
            _logger.Info(message);           //log in the log file
        }

        public static void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public static void LogInHtmlReport(Status status, string message)
        {
            _test.Log(status, message);
        }

        public static void LogNewExecutionStarted()
        {
            string line = "*****************";
            _logger.Info(line);
            _logger.Info("New Tests Execution");
            _logger.Info(line);
        }

        public static void LogTestStarted(string testName)
        {
            _logger.Info($"---------------------Test Name: {testName}---------------------");
        }

        public static void LogTestFinished()
        {
            _logger.Info("---------------------Test finished---------------------");
        }
    }
}
