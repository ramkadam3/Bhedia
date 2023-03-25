using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    internal class ReferralResponsePopupPOM
    {
        public static Boolean CheckReferralResponsePopupToOpenUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//h4[@id='login_title']")));
           return Driver.FindElement(By.XPath($"//h4[@id='login_title']")).Displayed;
        }
        public static void WaitForReferralResponsePopupToOpenUp(IWebDriver Driver)
        {    
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("referral-response-dialog")));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.TagName("referral-response-dialog")));
        }

        public static void ClickAddMoreAppointmentDatesButton(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("referral-response-dialog")));
        }

        public static void EnterDataForAcceptPatientRadio(IWebDriver Driver, String AcceptReject)
        {
            if(AcceptReject.ToLower().Contains("accept"))
            { 
                Driver.FindElement(By.XPath("//referral-response-dialog/descendant::label[contains(text(),'Accept Patient ?')]/following::input[1]"))
                .Click();
            }
            else
            {
                Driver.FindElement(By.XPath("//referral-response-dialog/descendant::label[contains(text(),'Accept Patient ?')]/following::input[2]"))
                .Click();
            }
        }

        public static void SelectInsuranceAuthorizationStatus(IWebDriver Driver, String InsuranceAuthorizationStatus)
        {
            SelectElement InsuranceAuthorizationStatusDropdown = new SelectElement(Driver.FindElement(By.XPath("//referral-response-dialog/descendant::select[@name = 'updateReferralAdvanceTime']")));
            InsuranceAuthorizationStatusDropdown.SelectByText(InsuranceAuthorizationStatus);
        }

       

        public static void EnterAppointmentDate(IWebDriver Driver, String DateTime) // the format will be dd-mm--yyyy hh:
        {
            try
            {
                Driver.FindElement(By.XPath("//referral-response-dialog/descendant::input[contains(@placeholder,'Appointment')]")).Click();
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//referral-response-dialog/descendant::input[contains(@placeholder,'Appointment')]")).SendKeys(DateTime);
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//div[@class='xdsoft_time '][normalize-space()='12:45 PM']")).Click();
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//input[@placeholder='Appointment']")).SendKeys(Keys.Enter);
                Thread.Sleep(200);
            }
            catch
            {

            }

        }
        public static IWebElement CheckRejectionReasonField(IWebDriver Driver)
        {
            string Xpath = "//descendant::input[@id='providerTypeSearch']";
            
            
                
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
              
                return Driver.FindElement(By.XPath(Xpath));           
               
         

          

        }
        public static void EnterRejectionReason (IWebDriver Driver)
        {
            string Xpath = "//descendant::input[@id='providerTypeSearch']";
            try
            {
                //SelectElement InsuranceAuthorizationStatusDropdown = new SelectElement(Driver.FindElement(By.Id("providerTypeSearch")));
                //InsuranceAuthorizationStatusDropdown.SelectByIndex(2);
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                Thread.Sleep(500);
                Driver.FindElement(By.XPath(Xpath)).Click();
                Thread.Sleep(500);
                Driver.FindElement(By.XPath("//descendant::input[@id='providerTypeSearch']/following::span[1]")).Click();
            }
            catch
            {

            }

        }

        public static void EnterAppointmentDate_ConfirmPopUp(IWebDriver Driver, String DateTime) // the format will be dd-mm--yyyy hh:
        {
            try
            {
                Driver.FindElement(By.XPath("//input[@id='AppointmentDates0']")).Click();
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//input[@id='AppointmentDates0']")).SendKeys(DateTime);
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//div[@class='xdsoft_time '][normalize-space()='12:45 PM']")).Click();
                Thread.Sleep(200);
                Driver.FindElement(By.XPath("//input[@placeholder='Appointment']")).SendKeys(Keys.Enter);
                Thread.Sleep(200);
            }
            catch
            {

            }

        }

        public static void EnterAppointmentDates(IWebDriver Driver, String[] AppointmentDates)
        {
            for(int i = 1; i < AppointmentDates.Length; i++)
            {
                AddMoreAppointmentDates(Driver);
            }

            //RemoveAppointmentDate(Driver, "2");

            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("AppointmentDates0")));

            int Index = 0;
            foreach (String AppointmentDate in AppointmentDates)
            {
                Driver.FindElement(By.Id("AppointmentDates" + Index))
                    .SendKeys(AppointmentDate);

                Thread.Sleep(600);
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::div[@class = 'xdsoft_calendar'][{Index + 1}]/descendant::td[contains(@class, 'xdsoft_current')]")));
                Driver.FindElement(By.XPath($"/descendant::div[@class = 'xdsoft_calendar'][{Index + 1}]/descendant::td[contains(@class, 'xdsoft_current')]"))
                    .Click();
                Thread.Sleep(1000);
                ReferralResponsePopupPOM.ClickBackgroundOfReferralResponseDialog(Driver);
                Index++;
            }
            
        }///descendant::div[@class = 'xdsoft_calendar'][12]/descendant::td[contains(@class, 'xdsoft_current')]

        public static void AddMoreAppointmentDates(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath((string)GetLocatorFromJson()["ReferralResponsePopup"]["AddAppointmentDate"])));
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["ReferralResponsePopup"]["AddAppointmentDate"])).Click();
        }

        public static void RemoveAppointmentDate(IWebDriver Driver, String? Index = null)
        {
            if (Index == null)
                Index = "1";

            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(BaseClass.InterpolateIntoString((string)GetLocatorFromJson()["ReferralResponsePopup"]["RemoveAppointmentDatesIcon"], new string[] { Index }))));
            Driver.FindElement(By.XPath(BaseClass.InterpolateIntoString((string)GetLocatorFromJson()["ReferralResponsePopup"]["RemoveAppointmentDatesIcon"], new string[] { Index })))
                .Click();

        }


        public static void EnterNotes(IWebDriver Driver, String Note)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::referral-response-dialog/descendant::textarea[ @id = 'note' or @id='text']")));
            Driver.FindElement(By.XPath("//descendant::referral-response-dialog/descendant::textarea[ @id = 'note' or @id='text']"))
            .SendKeys(Note);
        }
        // /descendant::div[contains(@class, 'xdsoft_datetimepicker')][3]/descendant::div[@class = 'xdsoft_label xdsoft_year']

        
        public static void ClickBackgroundOfReferralResponseDialog(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//referral-response-dialog/descendant::h4[2]")));
            Driver.FindElement(By.XPath("//referral-response-dialog/descendant::h4[2]"))
            .Click();
        }
        public static void ClickSubmitFormButton(IWebDriver Driver)
        {
            Thread.Sleep(2000);
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//referral-response-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'create']")));
            Driver.FindElement(By.XPath("//referral-response-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'create']")).Click();
        }

        public static void ClickCancelButton(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//referral-response-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'cancel']")));
            Driver.FindElement(By.XPath("//referral-response-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'cancel']"))
            .Click();
        }

        public static JObject GetLocatorFromJson()
        {
            return BaseClass.GetDataParser().GetJSonObjectFromFile(@"\Locators\ReferralResponsePopup.json");
        }

         

    }
}
