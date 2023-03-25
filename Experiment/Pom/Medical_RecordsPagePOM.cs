using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    public class Medical_RecordsPagePOM
    {
        public static void NavigateToMedicalRecordsPage(IWebDriver Driver)
        {
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElement(By.XPath("//a[contains(@title,'Patient List')]")));
                Actions action = new Actions(Driver);
                action.MoveToElement(Driver.FindElement(By.XPath("//a[contains(@title,'Patient List')]")))
                .Perform();

                //Thread.Sleep(2000);
                //WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
                //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//a[contains(@title,'Patient List')]")));
                //Boolean b=Driver.FindElement(By.XPath("//a[contains(@title,'Patient List')]")).Enabled;
                WebDriverWait Wait1 = new(Driver, TimeSpan.FromSeconds(10));
                Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::app-menu/descendant::a[contains(@title,'Medical Records')]")));
                Driver.FindElement(By.XPath("//descendant::app-menu/descendant::a[contains(@title,'Medical Records')]")).Click();





            }
        }
    }
}
