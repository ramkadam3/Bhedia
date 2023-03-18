using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Experiment.Config
{
    public class ExtentReportGeneration
    {
        public static DateTime Time = DateTime.Now;
        public static String Filename = "Screenshot_" + Time.ToString("h_mm_ss") + ".png";
        public IWebDriver Driver;

        protected ExtentReports extent;
        protected ExtentTest Test;

       // [OneTimeSetUp]
        [SetUp]
        public void BeforeSuite()
        {
            string reportPath = @"C:\Users\User\source\repos\DemoProject\Experiment\Reports\ExtentReport.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }//C:\Users\User\source\repos\DemoProject\Experiment\Reports\

        // [SetUp]
        // public void BeforeTest()
        //{
        //    Test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        //}

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logStatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    Test.Log(logStatus, "Test case failed with error message: " + errorMessage);
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    Test.Log(logStatus, "Test case is inconclusive");
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    Test.Log(logStatus, "Test case is skipped");
                    break;
                default:
                    logStatus = Status.Pass;
                    Test.Log(logStatus, "Test case is passed");
                    break;
            }

            extent.Flush();
        }

        [OneTimeTearDown]
        public void AfterSuite()
        {
            extent.Flush();
        }








       
    }



}
