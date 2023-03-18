using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Experiment.Pom
{
    public class Login
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

        public static void ClickOnSignInButton(IWebDriver Driver, Boolean? MobileLogin = false)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));
            Driver.FindElement(By.Id("next")).Click();
            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            if (MobileLogin == true)
            {
                Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand mobileLogo']//img[@alt='RoviCare']")));
            }
            else
            {
                Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand desktopLogo']//img[@alt='RoviCare']")));

            }
        }
        


    }
}
