using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    public class ReportsPOM:BaseClass

    {


        public static void NavigateToReportsPage(IWebDriver driver)
        {

            string Xpath = $"//descendant::a[@title='Reports']/i";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static void ClickOnReportCardBox(IWebDriver driver,int IndexOfReport)
        {

            string Xpath = $"//descendant::div[@class='card-box'][{IndexOfReport}]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static IWebElement RestrictToOpenReport_AlerPopUp(IWebDriver driver)
        {

            string Xpath = $"//descendant::div[contains(@class,'alert-dialog')]/button['Ok']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }




    }
}
