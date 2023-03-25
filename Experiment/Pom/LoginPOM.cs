using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using RovicareTestProject.Utilities;
using OpenQA.Selenium.Support.UI;

namespace RovicareTestProject.PageObjects
{

    public class LoginPOM : BaseClass
    { 

        
        public static void EnterUsername(IWebDriver Driver, String username)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));
            Driver.FindElement(By.Id("email")).SendKeys(username);
            
        }

        public static void EnterPassword(IWebDriver Driver, String password)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password")));
            Driver.FindElement(By.Id("password")).SendKeys(password);

        }

        public static void ClickOnSignInButton(IWebDriver Driver,Boolean? MobileLogin=false)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));
            Driver.FindElement(By.Id("next")).Click();
            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            if(MobileLogin== true)
            {
                Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand mobileLogo']//img[@alt='RoviCare']")));
            }
            else
            {
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand desktopLogo']//img[@alt='RoviCare']")));

            }
        }
        public static void SwitchAccount(IWebDriver Driver, string UserType)
        {
            BaseClass.LogOutAccount(Driver);
            BaseClass.WaitForSpinnerToDisappear(Driver);
            
            if (UserType == "Origin")
            {
                LoginPOM.EnterUsername(Driver, Origin_Email);
                LoginPOM.EnterPassword(Driver, Origin_Password);
            }
            else
            {
                LoginPOM.EnterUsername(Driver, Destination_Email);
                LoginPOM.EnterPassword(Driver, Destination_Password);
            }
            LoginPOM.ClickOnSignInButton(Driver);
            Thread.Sleep(2000);
            BaseClass.WaitForSpinnerToDisappear(Driver);
        }
       
        public static LoginPOM ReturnTheDriverObject()
        {
            return new LoginPOM();
        }

    }
       
}
