using Experiment.Config;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experiment.Pom;
using AventStack.ExtentReports;

namespace Experiment.BasePackage
{
    public class BaseClass:ExtentReportGeneration
    {







        public IWebDriver Browser(IWebDriver Driver, String Email, String Password, string Browser = "Chrome")
        {
            if (Browser == "Firefox")
            {

                Driver = new FirefoxDriver();
            }
            else if (Browser.Contains("Edge"))
            {
                Driver = new EdgeDriver();
            }
            else
            {
                Driver = new ChromeDriver();

            }
            Driver.Navigate().GoToUrl("https://test.rovicare.com");
            Driver.Manage().Window.Maximize();
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(35));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));
            
            Login.EnterUsername(Driver, Email);
            Login.EnterPassword(Driver, Password);


            Login.ClickOnSignInButton(Driver);
            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand desktopLogo']//img[@alt='RoviCare']")));
            return Driver;
        }
        public static MediaEntityModelProvider CaptureScreenShot(IWebDriver Driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)Driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }
        public static JSonReader GetDataParser()
        {
            return new JSonReader();
        }

    }
}
