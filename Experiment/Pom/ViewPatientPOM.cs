using AngleSharp.Dom;
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
    internal class ViewPatientPOM
    {
        public static void ClickAddProvidersButton(IWebDriver driver)
        {
            
            //string NavigationXpath = "//descendant::side-navigation-card/descendant::div[text()='Providers']";
            string Xpath = "//descendant::div[@id = 'PRInfo']/descendant::add-more-icon";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();

            Thread.Sleep(1000);
        }
        public static string HeadlineOfPatientdetail_POPUp(IWebDriver driver)
        {
            string Xpath = "//*[contains(.,'View Patient ')]/child::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
           return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void ClosePatientDetailsPOPUp(IWebDriver driver)
        {
            string Xpath = "//descendant::div[@id='mat-dialog-title-0']/button[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectProviderType_AddProviderPOPUP(IWebDriver driver,string ProviderType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//*[@id='Locality1']"),""));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//select[@name='addProvidercheck']")));
            driver.FindElement(By.XPath("//select[@name='addProvidercheck']")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SelectElement Provider = new SelectElement(driver.FindElement(By.XPath("//select[@name='addProvidercheck']")));
            Provider.SelectByText(ProviderType);
        }//*[@id="searchGrid"]
        public static void ClickOnSearchButton_AddProviderPOPUP(IWebDriver driver)
        {
            string Xpath = "//*[@id='searchGrid']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }//descendant::add-providers/descendant::tr[2]/descendant::input[1]
        public static void ClickOnSaveButton_AddProviderPOPUP(IWebDriver driver)
        {
            string Xpath = "//descendant::add-providers/descendant::button[contains(text(),'SAVE')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }//descendant::mat-dialog-content/descendant::label[contains(text(),'Provider')]/following::span[contains(text(),'Send Referral')]
        public static void ClickOnSendReferralButton_ViewPatient(IWebDriver driver)
        {
            string Xpath = "//descendant::label[contains(text(),'Provider')]/following::span[contains(text(),'Send Referral')][1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectProviderFromTable_AddProviderPOPUP(IWebDriver driver)
        {
            string Xpath = "//descendant::add-providers/descendant::tr[2]/descendant::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
       

        public static void WaitForProviderSectionToBeClickable(IWebDriver driver)
        {
            WebDriverWait waitShort = new WebDriverWait(driver, TimeSpan.FromMilliseconds(200));
            WebDriverWait waitLong = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                waitShort.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//view-patient/descendant::i[contains(@class , 'fa-spinner')]")));
                waitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//view-patient/descendant::i[contains(@class , 'fa-spinner')]")));

            }
            catch 
            {
                waitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//view-patient/descendant::i[contains(@class , 'fa-spinner')]")));
            }
        }

    }
}
