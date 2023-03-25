using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using RovicareTestProject.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Xml;
using OpenQA.Selenium.DevTools;
using AventStack.ExtentReports;

namespace RovicareTestProject.PageObjects
{

    public class OutgoingPOM : BaseClass
    {

        public static void NavigateToOutgoingPage(IWebDriver Driver)
        {
            string Xpath = "//app-root/div[1]/div[1]/app-menu/descendant::a[@title='Outgoing']";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

            Driver.FindElement(By.XPath(Xpath)).Click();

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//descendant::tr[1]")));
        }
        public static void ExpandMoreActions(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")));
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")))
            .Perform();
        }
        public static void DropDown_MoreAction_referralList(IWebDriver Driver, int IndexNumber)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//tbody/tr[2]/td/descendant::li[{IndexNumber}]")));
            Driver.FindElement(By.XPath($"//tbody/tr[2]/td/descendant::li[{IndexNumber}]")).Click();

        }
        //*******************************************Referral_Report_Mothods***Start***********************************************************
        public static void DropDown_MoreAction_referralList(IWebDriver Driver, string ElementName)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//tbody/tr[2]/td/descendant::li[contains(.,'{ElementName}')]")));
            Driver.FindElement(By.XPath($"//tbody/tr[2]/td/descendant::li[contains(.,'{ElementName}')]")).Click();

        }
        public static IWebElement CheckReferralReportPopUpHeadline(IWebDriver Driver)
        {
            string xpath = "//descendant::patient-care-report-dialog/descendant::h4[1]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
            return Driver.FindElement(By.XPath(xpath));

        }
        public static Tuple<string, string, Boolean, string, string> ValidateHeadlineElement_ReferralReportPOPUP(IWebDriver Driver)
        {
            string X_ProviderName = "//descendant::referral-report/descendant::label[contains(text(),'Selected Provider Name')]/following-sibling::span[1]";
            string X_ProviderType = "//descendant::referral-report/descendant::label[contains(text(),'Provider Type')]/following::span[1]";
            string X_Status = "//descendant::referral-report/descendant::label[contains(text(),'Status :')]/following::span[1]";
            string X_ServiceNeeded = "//descendant::referral-report/descendant::label[contains(text(),'Services Needed')]/following::span[1]";
            string X_SpecialPrograms = "//descendant::referral-report/descendant::label[contains(text(),'Special Program')]/following::span[1]";



            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(X_SpecialPrograms)));

            string Providername = Driver.FindElement(By.XPath(X_ProviderName)).Text;
            string ProviderType = Driver.FindElement(By.XPath(X_ProviderType)).Text;
            string Status = Driver.FindElement(By.XPath(X_Status)).Text.ToLower();
            string OurstatusList = "Response Received|confirmed".ToLower().Trim();
            Boolean statusResult = OurstatusList.Contains(Status) ? true : false;
            string ServiceNeeded = Driver.FindElement(By.XPath(X_ServiceNeeded)).Text;
            string SpecialPrograms = Driver.FindElement(By.XPath(X_SpecialPrograms)).Text;




            return Tuple.Create(Providername, ProviderType, statusResult, ServiceNeeded, SpecialPrograms);





        }
        public static void ClickOnProviderNameInReferralSentSection(IWebDriver Driver, string ProviderName)
        {
            string X_providerNameButton = $"//descendant::a[contains(text(),'Referral Sent')]/following::a[contains(text(),'{ProviderName}')]/preceding-sibling::a";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(X_providerNameButton)));
            Driver.FindElement(By.XPath(X_providerNameButton)).Click();

        }
        public static Tuple<string, string, string> ValidateReferralSentTableElements_ReferralReportPOPUP(IWebDriver Driver, string mode)
        {
            string X_receiverName = $"//*[contains(@id,'innerTable')]/descendant::span[contains(text(),'{mode}')]/preceding::span[contains(text(),'Receiver Name')][1]/following-sibling::span";
            string X_mode = $"//*[contains(@id,'innerTable')]/descendant::span[contains(text(),'{mode}')]";
            string X_status = $"//*[contains(@id,'innerTable')]/descendant::span[contains(text(),'{mode}')]/following::span[contains(text(),'Status')][1]/following-sibling::span";
            string X_action = $"//*[contains(@id,'innerTable')]/descendant::span[contains(text(),'{mode}')]/following::button[1]";





            //string X_receiverName = "//*[contains(@id,'innerTable')]/descendant::tr[2]/descendant::span[contains(text(),'Receiver Name')]/following-sibling::span";
            //string X_mode = "//*[contains(@id,'innerTable')]/descendant::tr[2]/descendant::span[contains(text(),'Mode')]/following-sibling::span";
            //string X_status = "//*[contains(@id,'innerTable')]/descendant::tr[2]/descendant::span[contains(text(),'Status')]/following-sibling::span";
            //string X_action = "//*[contains(@id,'innerTable')]/descendant::tr[2]/descendant::span[contains(text(),'Status')]/following::span[2]//button";

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(X_receiverName)));
            Actions Act = new Actions(Driver);
            Act.MoveToElement(Driver.FindElement(By.XPath(X_receiverName))).Build().Perform();

            string RreceiverName = Driver.FindElement(By.XPath(X_receiverName)).Text;
            string Mode = Driver.FindElement(By.XPath(X_mode)).Text;
            string Status = Driver.FindElement(By.XPath(X_status)).Text;
            // IWebElement Action = Driver.FindElement(By.XPath(X_action));






            return Tuple.Create(RreceiverName, Mode, Status);





        }
        public static Tuple<Boolean, string, string, Boolean, Boolean, Boolean, Boolean> ValidateResponseReceivedTableElements_ReferralReportPOPUP(IWebDriver Driver, string ProviderName)
        {
            string X_responserName = $"//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'{ProviderName}')][1]";

            string X_sentDate = $"//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'{ProviderName}')]/following::app-date-time[1]/span";
            string X_respondDate = $"//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'{ProviderName}')]/following::app-date-time[2]/span";
            string X_confirmed = "//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'Confirmed')]  ";
            string X_transportScheduled = "//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'Transport Scheduled')]";
            string X_discharged = "//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'Discharged')]";
            string X_transportCompleted = "//descendant::a[contains(text(),'Response Received')]/following::a[contains(text(),'Transport Completed')]";



            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(X_responserName)));
            Actions Act = new Actions(Driver);
            Act.MoveToElement(Driver.FindElement(By.XPath(X_transportCompleted))).Build().Perform();

            Boolean ProviderNameButton = Driver.FindElement(By.XPath(X_responserName)).Displayed;
            string SentDate = Driver.FindElement(By.XPath(X_sentDate)).Text;
            string RespondDate = Driver.FindElement(By.XPath(X_respondDate)).Text;
            Boolean Confirmed = Driver.FindElement(By.XPath(X_confirmed)).Displayed;
            Boolean TransportScheduled = Driver.FindElement(By.XPath(X_transportScheduled)).Displayed;
            Boolean Discharged = Driver.FindElement(By.XPath(X_discharged)).Displayed;
            Boolean TransportCompleted = Driver.FindElement(By.XPath(X_transportCompleted)).Displayed;





            return Tuple.Create(ProviderNameButton, SentDate, RespondDate, Confirmed, TransportScheduled, Discharged, TransportCompleted);





        }

        //*******************************************Referral_Report_Mothods***End***********************************************************
        public static Boolean StatusValidationofReferrals(IWebDriver Driver, String Status)
        {
            string Xpath = $"//descendant::*[@id='ReferralsInnerTable']/descendant::span[contains(text(),'{Status}')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            string temp = Driver.FindElement(By.XPath(Xpath)).Text;
            temp = temp.Trim();
            if (temp == Status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean CheckTransportCompletedSuccessfully(IWebDriver Driver)
        {
            string Xpath = "//descendant::*[@id='ReferralsInnerTable']/descendant::span[contains(text(),'Completed')]";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
            return true;

        }
        public static IWebElement CheckRespondedDateOfTransport(IWebDriver Driver, int rowNumber, string Date)
        {
            string Xpath = $"(//descendant::*[@id='ReferralsInnerTable']/descendant::tr[{rowNumber + 1}]/descendant::span[contains(text(),'{Date}')])[1]";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath));

        }
        public static IWebElement ClickOnCompleteTransport_UpdateTransportPopUp(IWebDriver Driver)
        {
            string Xpath = $"//*[@id='arrangeTransportForm']/descendant::label[contains(.,'Complete Transport')]/input";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath));

        }
        public static string CheckStatusofreferral(IWebDriver Driver, int rowNumber)
        {
            string Xpath = $"//*[@id='Referralstable-container']/descendant::tr[{rowNumber+1}]/descendant::status-labels//span";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            string status = Driver.FindElement(By.XPath(Xpath)).Text;
            return status;
        }
        public static void ClickOnSendList_ReferralTable(IWebDriver Driver, int rowNumber)
        {//Portal,Send List
            string Xpath = $"//descendant::*[@id='Referrals']/descendant::tr[{rowNumber+1}]/descendant::button[contains(@title,'Send List')]/i";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();

        }
        public static void ClickOnViewPatientPortal_ReferralTable(IWebDriver Driver, int rowNumber)
        {//Portal,Send List
            string Xpath = $"//descendant::*[@id='Referrals']/descendant::tr[{rowNumber + 1}]/descendant::button[contains(@title,'Portal')]/i";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();

        }
        //Provider selection cancel methods are below
        public static void ProvideCancelationReason(IWebDriver Driver,int i)
        {
            string Xpath = "//*[@id='cancellationReasonSearch']";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id,'mat-dialog-title')]")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            
            Driver.FindElement(By.XPath(Xpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='cancellationReasonSearch']/following::span[{i}]")));
            IWebElement element = Driver.FindElement(By.XPath($"//*[@id='cancellationReasonSearch']/following::span[{i}]"));
            

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
           

            element.Click();


            // return Tuple.Create(Driver.FindElement(By.XPath(Xpath)), Xpath);
        }
        public static void EnterNotes_CancelReferralPopUp(IWebDriver Driver, String Notes)
        {
            string Xpath = "//descendant::label[contains(text(),'Notes')]/following-sibling::textarea";
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                Driver.FindElement(By.XPath(Xpath)).Clear();
                Driver.FindElement(By.XPath(Xpath)).SendKeys(Notes);
            }
            catch
            {

            }

        }
        public static IWebElement ClickSubmitOnCancelationPopUp(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-actions/descendant::button[text()='SUBMIT']")));
            return Driver.FindElement(By.XPath("//descendant::mat-dialog-actions/descendant::button[text()='SUBMIT']"));
            
        }
        public static Boolean CheckSendPreferredListPopUpOpened(IWebDriver Driver)
        {
            string Xpath = "//form[@id='sendPacfForm']/descendant::input";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//form[@id='sendPacfForm']")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void EnterPatientEmail_OnPopUp(IWebDriver Driver,string PatientEmail)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//*[@id='Email_0']"), ""));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::div[contains(@id,'mat-dialog-title')]/following::*[@id='EmailID']")));
            Thread.Sleep(1000);
            if (!Driver.FindElement(By.XPath($"//descendant::div[contains(@id,'mat-dialog-title')]/following::*[@id='EmailID']")).Selected)
            {
                Driver.FindElement(By.XPath("//descendant::div[contains(@id,'mat-dialog-title')]/following::*[@id='EmailID']")).Click();
                Thread.Sleep(3000);
                Driver.FindElement(By.XPath("//*[@id='Email_0']")).SendKeys(PatientEmail);
                //devesh.sahu@interbizconsulting.com
            }

        }
        public static void ClickOnSendButtonOnPopup_SendListTopatient(IWebDriver Driver)
        {
            

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::div[contains(@id,'mat-dialog-title')]/following::button[@name='create']")));
                Driver.FindElement(By.XPath("//descendant::div[contains(@id,'mat-dialog-title')]/following::button[@name='create']")).Click();
           

        }
       
        public static void ClickOnCancelReferralButton(IWebDriver Driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='providerListTableData']/descendant::tr[{rowNumber + 1}]/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")));
            Driver.FindElement(By.XPath($"//*[@id='providerListTableData']/descendant::tr[{rowNumber + 1}]/descendant::i[@class = 'fa fa-ellipsis-v more-action-icon-position']")).Click();
           
        }
        public static void ClickOnCancelReferral_CrossButton(IWebDriver Driver, int rowNumber)
        {
            string Xpath = $"//*[@id='providerListTableData']/descendant::tr[{rowNumber + 1}]/descendant::i[@class = 'fa fa-times']";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();

        }
        
        public static void ClosePopup_ViewPatientPortal(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='mat-dialog-title-1']/button/div")));
            Driver.FindElement(By.XPath("//*[@id='mat-dialog-title-1']/button/div")).Click();

        }

        

        public static void ClickOnPatientPreferenceList(IWebDriver Driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='providerListTableData']/descendant::tr[5]/descendant::i[@class = 'fa fa-list-ol patient-preference-list']")));
            Driver.FindElement(By.XPath($"//*[@id='providerListTableData']/descendant::tr[5]/descendant::i[@class = 'fa fa-list-ol patient-preference-list']")).Click();

        }
        public static void ClickOnGeneratedListForPatientButton(IWebDriver Driver, int rowNumber,string IfAction)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='providerListTableData']/descendant::tr[{rowNumber + 1}]/descendant::i[@class = 'fa fa-list-ol']")));
            Driver.FindElement(By.XPath($"//*[@id='providerListTableData']/descendant::tr[{rowNumber + 1}]/descendant::i[@class = 'fa fa-list-ol']")).Click();
            //descendant::shortlist-providers//span[3]/descendant::i    listbutton
            //*[@id="facility_3d1f7ef4-3249-4b6f-a11e-789a4fc1b0a5"]//div[2]/descendant::h3   providername
            //descendant::shortlist-providers//div[3]/descendant::button[text()='Go']            Go
        }
        // This link available in pop up that open after click on View patient's portal button under action section of provider selection
        public static IWebElement ClickOnPatientPortalLinkPopUp(IWebDriver Driver)
        {
            string Xpath = "//descendant::div[@id='link']/descendant::button[@class='view-portal-link']";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath));
            
        }
        //Below button is available on patient's portal page
        public static void ClickOnSendPreferenceButton(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='id_0']/descendant::button[@title='Send Preference']")));
            Driver.FindElement(By.XPath("//*[@id='id_0']/descendant::button[@title='Send Preference']")).Click();
            
        }
        //Below button is available on patient's portal page
        public static void ClickOnSavePreferenceButton(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@title='Print List']/preceding::button[@title='Save Preference']")));
            Driver.FindElement(By.XPath("//a[@title='Print List']/preceding::button[@title='Save Preference']")).Click();

        }

        public static void ClickOnSendMoreReferral (IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tr[2]/td/descendant::action/descendant::button[contains(@title,'Send More Referrals')]")));
            Driver.FindElement(By.XPath("//tr[2]/td/descendant::action/descendant::button[contains(@title,'Send More Referrals')]"))
            .Click();

        }
        public static void ClickOn_NotesAction(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//tr[2]/descendant::td/div[1]/div[8]/action/div/span[3]/a/descendant::button[@class='btn-annotation-clr' and @type= 'submit' and @title='Notes']")));
            driver.FindElement(By.XPath($"//tr[2]/descendant::td/div[1]/div[8]/action/div/span[3]/a/descendant::button[@class='btn-annotation-clr' and @type= 'submit' and @title='Notes']")).Click();
        }

        public static void ExpandInnerTable(IWebDriver Driver, int RowNumber)
        { string Xpath = $"//referral-table/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][{RowNumber + 1}]/descendant::i[1]";
                    WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                if (!Driver.FindElement(By.XPath(Xpath)).GetAttribute("class").Contains("down"));
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                    Driver.FindElement(By.XPath(Xpath))
                    .Click();
                    Thread.Sleep(3000);
                }
            }
            catch(Exception)
            {

            }
            
            
        }


        public static int CountNumberOfReferralSentInnerTable(IWebDriver Driver, int RowNumberOfOuterTable)
        {
            
            int rows = Driver.FindElements(By.XPath($"//referral-table/descendant::tr[{RowNumberOfOuterTable + 1}]/descendant::table[contains(@id, 'ReferralsInnerTable')]/descendant::tr")).Count();
            return rows-1;
        }


        // this refers to the doctor icon accept-referral-icon
        public static void ClickOnAcceptReferralIcon(IWebDriver Driver, String RowNumberOfOuterTable, String RowNumberOfInnerTable)
        {
            Driver.FindElement(By.XPath($"//referral-table/descendant::tr[2]/descendant::table[contains(@id, 'ReferralsInnerTable')]/descendant::tr[2]/descendant::action/descendant::accept-referral-icon"))
            .Click();
        }

        public static void ClickOnConfirmReferralIconInInnerTable(IWebDriver Driver, int RowNumberOfOuterTable, int RowNumberOfInnerTable)
        {
            Driver.FindElement(By.XPath($"//referral-table/descendant::tr[{RowNumberOfOuterTable + 1}]/descendant::table[contains(@id, 'ReferralsInnerTable')]/descendant::tr[{RowNumberOfInnerTable + 1}]/descendant::action/descendant::button[@title = 'Confirm Referral']"))
            .Click();
        }

        public static void ClickOnRespondToReferralbutton_UnderInnerTable (IWebDriver Driver, int RowNumberOfInnerTable)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='ReferralsInnerTable']/descendant::tr[{RowNumberOfInnerTable+1}]/td/descendant::accept-referral-icon")));
            Driver.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/descendant::tr[{RowNumberOfInnerTable + 1}]/td/descendant::accept-referral-icon")).Click();
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//*[name()='svg'])[{RowNumberOfInnerTable}]")));
            //Driver.FindElement(By.XPath($"(//*[name()='svg'])[{RowNumberOfInnerTable}]")).Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//h4[@id='login_title']")));
            
        }

        public static void ClickSubmitFormButton_ConfirmReferralPopup(IWebDriver Driver)
        {
            
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("app-decision-dialog")));
            Driver.FindElement(By.XPath("//app-decision-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'create']"))
            .Click();
        }

        public static void ClickCancelButtonConfirmReferralPopup(IWebDriver Driver, String RowNumberOfOuterTable, String RowNumberOfInnerTable)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("app-decision-dialog")));
            Driver.FindElement(By.XPath("//app-decision-dialog/descendant::mat-dialog-actions/descendant::button[@name = 'cancel']"))
            .Click();
        }

        public static void ClickOn_YES_ConfirmPatientDischargePopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//h4[normalize-space()='Confirm Patient Discharge'])[1]")));
            Driver.FindElement(By.XPath("(//button[normalize-space()='YES'])[1]"))
            .Click();
        }

        public static void ClickOn_NO_ConfirmPatientDischargePopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//h4[normalize-space()='Confirm Patient Discharge'])[1]")));
            Driver.FindElement(By.XPath("//button[normalize-space()='NO']"))
            .Click();
        }

        public static IWebElement ClickOnTransportAction(IWebDriver Driver, int RowNumber)
        {
            string Xpath = $"//referral-table/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][{RowNumber + 1}]/descendant::action/descendant::button[contains(@title,'Transport')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]
            
        }
        public static IWebElement CheckArrangeTransportPOPup(IWebDriver Driver)
        {
            string Xpath = "//descendant::*[contains(@id,'mat-dialog-title-')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]

        }
        public static IWebElement CheckUpdateTransportPOPup(IWebDriver Driver)
        {
            string Xpath = "//descendant::*[contains(@id,'mat-dialog-title-')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]

        }
        public static void EnterAppointmentDate_ArrangeTransportPopUp(IWebDriver Driver, string Date) // the format will be dd-mm--yyyy hh:
        {DateTime date=DateTime.Now;
            int day=date.Day;   
            try
            {
                string Xpath1 = "//descendant::input[@id='newPickupDate']";
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath1)));
              
                
                //Driver.FindElement(By.XPath("//descendant::input[@id='newPickupDate']")).SendKeys("12-30-2022 6:00 PM");
               // Thread.Sleep(200);
               if(Date=="Today")
                {
                Driver.FindElement(By.XPath(Xpath1)).Click();
                    string Xpath = $"//descendant::input[@id='newPickupDate']/following::div[contains(@style,'block')]/descendant::td[contains(@class,'current')][@data-date='{day}']/div";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                   Driver.FindElement(By.XPath(Xpath)).Click();
                }
               else if(Date=="Today+1")
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath(Xpath1), ""));
                    Driver.FindElement(By.XPath(Xpath1)).Click();
                    string Xpath = $"//descendant::input[@id='newPickupDate']/following::div[contains(@style,'block')]/descendant::td[contains(@class,'current')][@data-date='{day}']/following-sibling::td[1]";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                    Driver.FindElement(By.XPath(Xpath)).Click();
                    Thread.Sleep(1000);
                }
               else if(Date=="Today+2")
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath(Xpath1), ""));
                    Driver.FindElement(By.XPath(Xpath1)).Click();
                    string Xpath = $"//descendant::input[@id='newPickupDate']/following::div[contains(@style,'block')]/descendant::td[contains(@class,'current')][@data-date='{day}']/following-sibling::td[2]";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                    Driver.FindElement(By.XPath(Xpath)).Click();
                    Thread.Sleep(1000);
                }

                Thread.Sleep(500);


                Driver.FindElement(By.XPath("//descendant::input[@id='newPickupDate']")).SendKeys(Keys.Enter);
                // Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space()='6:00 PM']")));
                // Driver.FindElement(By.XPath("//div[normalize-space()='6:00 PM']")).Click();
                //Thread.Sleep(200);
                //Driver.FindElement(By.XPath("//input[@id='newPickupDate']")).SendKeys(Keys.Enter);
                //Thread.Sleep(200);
            }
            catch
            {

            }

        }


        public static void ClickOn_TransportCompeleteButton(IWebDriver Driver, int rowNum)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//button[@title='Transport Complete'])[{rowNum}]")));
                Driver.FindElement(By.XPath($"(//button[@title='Transport Complete'])[{rowNum}]")).Click();
                Thread.Sleep(200);

            }
            catch
            {

            }

        }
        public static IWebElement CheckTransportScheduledStatus(IWebDriver Driver)
        {
            string Xpath = "//descendant::*[@id='Referralstable-container']/descendant::tr[2]/descendant::span[contains(text(),'Transport Scheduled')][1]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]

        }
        public static void EnterPatientNameInSearchField(IWebDriver Driver, String PatientName)
        {
            Driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).Clear();
            Driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).SendKeys(PatientName);
        }

        public static void ClickOn_EditTransportButton(IWebDriver Driver)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[@title='Transport Complete']")));
                Driver.FindElement(By.XPath("//i[@class='fa fa-ambulance edit-transport-icon']")).Click();
            }
            catch
            {

            }

        }
        public static void ClickOn_SubmitButton_UpdateTransportPopUp(IWebDriver Driver)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='arrangeTransportForm']/mat-dialog-actions/div/div[1]/button")));
                Driver.FindElement(By.XPath("//*[@id='arrangeTransportForm']/mat-dialog-actions/div/div[1]/button")).Click();
            }
            catch
            {

            }

        }

        public static void ClickOn_CancelButton_UpdateTransportPopUp(IWebDriver Driver)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='arrangeTransportForm']/mat-dialog-actions/div/div[2]/button")));
                Driver.FindElement(By.XPath("//*[@id='arrangeTransportForm']/mat-dialog-actions/div/div[2]/button")).Click();
            }
            catch
            {

            }

        }
        public static IWebElement CheckDateofTransport_RequestTimeColumn(IWebDriver Driver,string Date)
        {
           
            
                string Xpath = $"//descendant::*[@id='ReferralsInnerTable']/descendant::span[contains(normalize-space(),'{Date}')]";
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                return Driver.FindElement(By.XPath(Xpath));
            

        }
        public static void ClickOnSubmitButton_ArrangeTransportPopUp(IWebDriver Driver) 
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//descendant::mat-dialog-actions/descendant::button[normalize-space()='SUBMIT']")));
                Driver.FindElement(By.XPath("//descendant::mat-dialog-actions/descendant::button[normalize-space()='SUBMIT']")).Click();
                Thread.Sleep(200);
                
            }
            catch
            {

            }

        }

        public static void EnterNotes_ArrangeTransportPopUp(IWebDriver Driver, String Notes)
        {//descendant::label[contains(text(),'Notes')]/following-sibling::textarea
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//textarea[@id='newNote']")));
                Driver.FindElement(By.XPath("//textarea[@id='newNote']")).Clear();
                Driver.FindElement(By.XPath("//textarea[@id='newNote']")).SendKeys(Notes);
            }
            catch
            {

            }

        }

        public static Boolean CheckForThePresenceOfTransportCompleteAction(IWebDriver Driver, int RowNumber)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//referral-table/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][{RowNumber + 1}]/descendant::action/descendant::button[@title = 'Transport Complete']")));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void WaitForReferralTableToBeClickable(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//referral-table/descendant::tr[2]")));
            Driver.FindElement(By.XPath("//referral-table/descendant::tr[2]"))
            .Click();
        }
        
        public static void ClickOnResendReferralButton (IWebDriver Driver, int Rownumber)
        {
            Driver.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[{Rownumber+1}]/td/div[1]/div[7]/action/div/span[2]/a/button/i")).Click();
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='center-footer']//div[1]")));
        }

        public static void SelectReceiveingContact (IWebDriver Driver, int ChooseOption)
        {
            Thread.Sleep(2000);
            SelectElement oSelect = new SelectElement(Driver.FindElement(By.XPath("//*[@id='contactFacility']")));
            oSelect.SelectByIndex(ChooseOption);
            Thread.Sleep(1000);
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::mat-dialog-content/descendant::label/following::input")));
            
            
            Driver.FindElement(By.Id("editLocationemail")).Clear();
            Driver.FindElement(By.Id("editLocationemail")).SendKeys("test@interbizconsulting.com");
            //Driver.FindElement(By.Id("editLocationFax")).Clear();
            //Driver.FindElement(By.Id("editLocationFax")).SendKeys("(111) 111-1111");
            //Driver.FindElement(By.Id("editLocationMobileNumber")).Clear();
            //Driver.FindElement(By.Id("editLocationMobileNumber")).SendKeys("(111) 111-1111");

        }

        public static void ClickOnSendButton_UnderResendReferralPopUp (IWebDriver Driver)
        {
            Driver.FindElement(By.XPath($"//div[@class='center-footer']//div[1]")).Click();
        }



        //table[@id = 'Referrals']/descendant::tr[2]/descendant::status-labels/descendant::span
       
        public static String GetPatientNameFromProviderSelection(IWebDriver Driver,int rowNumber)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='providerListTableData']/tbody/tr[{rowNumber+1}]/td/div[1]/div[1]/div[2]/a")));
            Thread.Sleep(3000);
            String temp = Driver.FindElement(By.XPath($"//*[@id='providerListTableData']/tbody/tr[{rowNumber+1}]/td/div[1]/div[1]/div[2]/a")).Text;
            return temp;
        }
        public static void ClickOnConfirmReferralIconInInnerTable(IWebDriver Driver)
        {
            Thread.Sleep(1000);
            string Xpath = "//descendant::*[@id='ReferralsInnerTable']/descendant::button[@title='Confirm Referral']";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();
        } 
        
        public static void ClickToConfirmAppointmentDateRadio(IWebDriver Driver, String ConfirmAppointmentDate, Boolean? Submit = null)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(BaseClass.InterpolateIntoString((String)GetLocatorFromJson()["ConfirmReferralResponse"]["DateSelectionRadio"], new String[] { ConfirmAppointmentDate }))));
            Driver.FindElement(By.XPath(BaseClass.InterpolateIntoString((String)GetLocatorFromJson()["ConfirmReferralResponse"]["DateSelectionRadio"], new String[] { ConfirmAppointmentDate }))).Click();

            if (Submit != null)
            {
                ClickSendButtonInConfirmAppointmentDateDialog(Driver);
                Thread.Sleep(1000);
            }
           
        }

        public static void ClickSendButtonInConfirmAppointmentDateDialog(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["ConfirmReferralResponse"]["SendButton"]))
                .Click();
        }

        public static JObject GetLocatorFromJson()
        {
            return GetDataParser().GetJSonObjectFromFile(@"\Locators\ConfirmAppointmentPopup.json");
        }
        //public static void ClickOnOutgoing(IWebDriver Driver)
        //{
        //   WebDriverWait  Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        //    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("(//a[@class='menuWidth'])[@title='Outgoing']")));
  
        //    Driver.FindElement(By.XPath("(//a[@class='menuWidth'])[@title='Outgoing']")).Click();
           
        //}
        public static void ClickOnChatBox(IWebDriver Driver)
        {
            WebDriverWait Wait = new (Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("(//button[@type='submit'])[@title='Chat'][1]")));
            Driver.FindElement(By.XPath("(//button[@type='submit'])[@title='Chat'][1]")).Click();

        }
        public static string GetPatientNameFromList(IWebDriver Driver)
        {
           
                 WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("(//a[@class='cursor-pointer'])[1]")));
           string patient =Driver.FindElement(By.XPath("(//a[@class='cursor-pointer'])[1]")).Text;

            return patient.ToLower();
            
        }
    }

}
