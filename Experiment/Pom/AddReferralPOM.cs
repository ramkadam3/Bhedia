using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.Intrinsics.X86;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using AventStack.ExtentReports;
using OpenQA.Selenium.DevTools;


namespace RovicareTestProject.PageObjects
{
    public class AddReferralPOM
    {
        //***********************************AddReferral_IncomingPage**************************************************
        public static void ClickOnReferralButton_IncomingPage(IWebDriver Driver)
        {
            string Xpath = "//button[@id='addPatientDetail']";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }

        public static IWebElement EnterDataInTab(IWebDriver Driver, string ElementName)
        {   //ElementName=
            //First Name,Last Name, Middle Name,Date of Birth,SSN / PID (Last 4 characters),Email ID, Mobile Number,Home Number,
            //Organization Name,Received Date, Contact Person Name, Services Needed,Special Program
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//label[contains(text(),'{ElementName}')]/following::input[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement SelectContactPersonName(IWebDriver Driver)
        {   
            
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//label[contains(text(),'Contact Person Name')]/following::input[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
             Driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.XPath("//search-select-dropdown/descendant::li[1]")).Click();
            Thread.Sleep(500);

            return Driver.FindElement(By.XPath(Xpath));

        }
        //label[contains(text(),'Mobile Number')]/following::div[@class='error']
        public static Boolean CheckErrorMessage(IWebDriver Driver, string ElementName)
        {   //ElementName=
            //First Name,Last Name, Middle Name,Date of Birth,SSN / PID (Last 4 characters),Email ID, Mobile Number,Home Number,
            //Organization Name,Received Date, Contact Person Name, Services Needed,Special Program
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(1));
            string Xpath = $"//label[contains(text(),'{ElementName}')]/following-sibling::div[contains(@class,'error')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void SelectDateofReceive(IWebDriver Driver, int DateOfTheDay, int? Time=0)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath= $"//descendant::td[@data-date='{DateOfTheDay}'][contains(@class,'today')]/div";
            //string Xpath = $"/html/body/div[5]/div[1]/div[2]/table/tbody/descendant::td[@data-date='{DateOfTheDay}']/div";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectServiceNeeded(IWebDriver Driver, int ServiceIndex)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//div//descendant::span[@class='chk-name-search'][{ServiceIndex}]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectSpecialProgramme(IWebDriver Driver, string ProgrammeName)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//descendant::label//descendant::span[@class='chk-name-search'][contains(text(),'{ProgrammeName}')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            //descendant::label//descendant::span[@class='chk-name-search'][contains(text(),'Gambling disorder')]
            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnAttachDocuments(IWebDriver Driver)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//a[contains(@class,'rhf-accept btn upload-medical')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnCloseReferralReferralPopUp(IWebDriver Driver)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            //string Xpath = "//descendant::app-medical-record//div[contains(text(),'×')]";
            string Xpath = "/html/body/div[2]/app-root/div[1]/div[1]/div/add-patient/div[3]/div/div/div[1]/button";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnCloseMedicalRecordPopUp(IWebDriver Driver)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//descendant::app-medical-record//div[contains(text(),'×')]";
            //string Xpath = "/html/body/div[2]/app-root/div[1]/div[1]/div/add-patient/div[3]/div/div/div[1]/button";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
        }
        public static Tuple< IWebElement,string> SelectMode_ProviderType(IWebDriver Driver, string ElementName)
        {
            //Provider Type,Mode
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//label[contains(text(),'{ElementName}')]/following::select[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Tuple.Create( Driver.FindElement(By.XPath(Xpath)),Xpath);
        }
        public static Tuple<IWebElement, string> SelectElement_AddreferralPOP_Up(IWebDriver Driver, string ElementName)
        {
            //Provider Type,Mode
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//form[@id='addReferralForm']/descendant::label[contains(text(),'{ElementName}')]/following::select[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Tuple.Create(Driver.FindElement(By.XPath(Xpath)), Xpath);
        }
        public static IWebElement SelectGender_AddReferral(IWebDriver Driver, string Gender)
        {//Male,Female,Other
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//label[contains(text(),'{Gender}')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement EnterTextForNote(IWebDriver Driver, string? Message="")
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//label[contains(text(),'Referral Note')]/following::textarea";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).SendKeys(Message);
            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement ClickOnInsuranceDetails(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//descendant::i[@class='fa fa-chevron-down']";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static Tuple<IWebElement, string> ClickOnInsuranceName(IWebDriver Driver, int? SelectIndex = 0)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//descendant::label[text()='Insurance Name']/following::select[@id='Provider_{SelectIndex}']";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Tuple.Create(Driver.FindElement(By.XPath(Xpath)), Xpath);
        }
        public static void ClickOncheckBoxForShareInsuranceRecords(IWebDriver Driver, string ElementName)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(5));
            string Xpath = $"//label[contains(text(),'{ElementName}')]/preceding-sibling::input";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

         
            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Tuple<string, IWebElement> CheckGroupNumber(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//descendant::label[text()='Group Number']/following::input[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            string Number=Driver.FindElement(By.XPath(Xpath)).Text;
            return Tuple.Create(Number, Driver.FindElement(By.XPath(Xpath)));
        }
        public static IWebElement ClickOnSave_Cancel(IWebDriver Driver, string ElementName)
        {//CANCEL,SAVE
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = $"//button[contains(text(),'{ElementName}')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

           
           return Driver.FindElement(By.XPath(Xpath));
        }
        public static void SelectOrganizationName(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//label[text()='Organization Name']/following::li[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnMoreInsurance(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//add-more-icon/descendant::i";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            //*[@id="INSInfo"]/descendant::span[2]
            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnCancelInsurance_CrossButton(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//*[@id='INSInfo']/descendant::span[4]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            
            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ClickOnfinalPOp_AfterSAVE(IWebDriver Driver)
        {
            
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "/html/body/div[3]/div[3]/div/mat-dialog-container/app-more-patient-detail-dialog/mat-dialog-actions/div/div[2]/button";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnCheckbox_PolicyHolderIsDifferent_InsuranceSection(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//input[@id='policyholder']";

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            IWebElement element = Driver.FindElement(By.XPath(Xpath));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement EnterFirst_Lastname_MobileNumber_policyHolder(IWebDriver Driver,string ElementName)
        {//Firstname,lastname,patientcellnumber use these text as ElementName
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(3));
            string Xpath = $"//input[@id='policyholder']/following::input[@id='{ElementName}']";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement Select_Relationship_policyHolder(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//input[@id='policyholder']/following::select[1]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


           return Driver.FindElement(By.XPath(Xpath));
        }//notifier-notification

        public static Boolean MessageNotifier(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//notifier-notification";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static IWebElement EnterHomeNumber_policyHolder(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//input[@id='policyholder']/following::label[text()='Home Number']/following-sibling::input";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        

    }
}
