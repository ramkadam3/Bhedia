using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Experiment.Config;
using System;
using Experiment.BaseClass;
using Experiment.Pom;

namespace Experiment.Test

{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestLogin : BaseClass
    {


        [SetUp]
        public void SetUp()
        {
             Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://test.rovicare.com");
            Driver.Manage().Window.Maximize();
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));


        }


        [Test, Order(1)]
        [TestCaseSource("AddLoginInfo_Valid")]
        [TestCaseSource("AddLoginInfo_Invalid1")]
        [TestCaseSource("AddLoginInfo_Invalid2")]
        [TestCaseSource("AddLoginInfo_Invalid3")]
        [TestCaseSource("AddLoginInfo_Invalid4")]
        public void loginMethod(string username, string password)
        {
            //try
            //{

            //Test.Value = ExtentTestManager.CreateParentTest("Login test", "Testing the login functionality with multiple valid and invalid credentials");
            Test = extent.CreateTest("Login test", "Testing the login functionality with following credentials= " + username + "   Password =" + password);
            //Test.Value = Extent.Value.CreateTest("Test_Login Username = " + username + "   Password =" + password);
            
            Login.EnterUsername(Driver, username);
            Login.EnterPassword(Driver, password);
            Test.Log(Status.Info, "Credential Entered");
            Login.ClickOnSignInButton(Driver);
            Thread.Sleep(1500);
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addPatientDetail")));
                string ActualResult = Driver.FindElement(By.Id("addPatientDetail")).GetAttribute("Id");
                string ExpectedResult = "addPatientDetail";
                Test.Log(Status.Info, "Correct Credential, User Logged in successfully");
                Test.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                Assert.AreEqual(ActualResult, ExpectedResult);
            }
            catch (WebDriverTimeoutException)
            {
                try
                {
                    WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@aria-hidden='false']")));
                    try
                    {
                        string ActualResult = Driver.FindElement(By.XPath("//div[@aria-hidden='false']")).Text;
                        string ExpectedResult = "Your password is incorrect, please try again or use forgot password link to reset it.";
                        string ExpectedResult2 = "We can't seem to find your account.";
                        string ExpectedResult3 = "Please enter a valid email address.";
                        if (ActualResult == ExpectedResult)
                        {
                            Assert.AreEqual(ActualResult, ExpectedResult);
                            Test.Log(Status.Info, "Incorrect Password, LogIn Denied");
                            Test.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                        }
                        else if (ActualResult == ExpectedResult2)
                        {
                            Assert.AreEqual(ActualResult, ExpectedResult2);
                            Test.Log(Status.Info, "User Not Found, LogIn Denied");
                            Test.Log(Status.Pass, CaptureScreenShot(Driver, Filename));

                        }
                        else if (ActualResult == ExpectedResult3)
                        {
                            Assert.AreEqual(ActualResult, ExpectedResult3);
                            Test.Log(Status.Info, "Invlid username format, LogIn Denied");
                            Test.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                        }
                    }
                    catch (WebDriverTimeoutException) { }
                }
                catch (Exception) { }
            }
            //}
            //catch (Exception) {  }
        }


        //*********************************************** Test Data *********************************************************
        static string Path = "\\Experiment\\TestData\\AddLoginInfo.json";
        public static IEnumerable<TestCaseData> AddLoginInfo_Valid()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_valid", TestLogin.Path), GetDataParser().TestData("password_valid", TestLogin.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid1()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid1", TestLogin.Path), GetDataParser().TestData("password_invalid1", TestLogin.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid2()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid2", TestLogin.Path), GetDataParser().TestData("password_invalid2", TestLogin.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid3()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid3", TestLogin.Path), GetDataParser().TestData("password_invalid3", TestLogin.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid4()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid4", TestLogin.Path), GetDataParser().TestData("password_invalid4", TestLogin.Path));
        }






    }
}
