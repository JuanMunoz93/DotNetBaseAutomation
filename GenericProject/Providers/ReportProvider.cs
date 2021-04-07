using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using GenericProject.Utils;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Providers
{
    public class ReportProvider
    {
        private readonly NLog.Logger _logger = NLog.LogManager.GetLogger("customLogger");
        private ExtentReports _extentReports;
        private ExtentTest _test { get; set; }

        public void InitReporter()
        {
            string projectdirectory = GenericUtils.GetProjectDirectory();
            GenericUtils.CreateDirectory($"{projectdirectory}/Reports");
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter($"{projectdirectory}/Reports/Report.html");

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(extentHtmlReporter);
            _extentReports.AddSystemInfo("Machine User Name", Environment.UserName);
        }

        public void GenerateHtmlReport(string status, string message)
        {
            Status logStatus
            switch (status)
            {
                case "Pass":
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

        public void CreateTest(string testName)
        {
            _test = _extentReports.CreateTest(testName);
        }

        public void LogInfoInAllReporters(Status status,string message)
        {
            _test.Log(status, message);      //log in the html report
            _logger.Info(message);           //log in the log file
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogInHtmlReport(Status status, string message)
        {
            _test.Log(status, message);
        }

        public void LogNewExecutionStarted()
        {
            string line = "*****************";
            _logger.Info(line);
            _logger.Info("New Tests Execution");
            _logger.Info(line);
        }

        public void LogTestStarted(string testName)
        {
            _logger.Info($"---------------------Test Name: {testName}---------------------");
        }

        public void LogTestFinished()
        {
            _logger.Info("---------------------Test finished---------------------\n");
        }
    }
}
