

////discharge-patient/descendant::button[@name = 'create']
///

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    internal class ConfirmPatientDischargePopupPOM
    {
        public static void ClickYesInConfirmPatientDischargeP(IWebDriver Driver) 
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//discharge-patient/descendant::button[@name = 'create']")));
            Driver.FindElement(By.XPath("//discharge-patient/descendant::button[@name = 'create']")).Click();


        }
        public static void ExpandMoreActions(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")));
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")))
            .Perform();
        }
        public static void CollapseMoreActions(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")));
            Driver.FindElement(By.XPath("//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")).Click();

        }
        public static Boolean CheckAbsenceOfCancelReferralIcon(IWebDriver Driver)
        {
            ExpandMoreActions(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::div[contains(@class , 'more-action-box')]/descendant::i[@class = 'fa fa-times']")));
            WebDriverWait wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
            try
            {
                wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//app-custom-table-component/descendant::tr[4]/descendant::action/descendant::div[contains(@class , 'more-action-box')]/descendant::i[@class = 'fa fa-times']")));
                CollapseMoreActions(Driver);
                return false;

            }
            catch (Exception e)
            {
                CollapseMoreActions(Driver);
                Console.WriteLine(e);
                return true;
            }
        }

    }
}
