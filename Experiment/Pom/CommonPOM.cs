using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using RovicareTestProject.Utilities;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium.DevTools;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Tests.Incoming;


namespace RovicareTestProject.PageObjects
{
    public class CommonPOM : BaseClass
    { static string label= "HoursNeeded|OriginName";

        //****************************************** Mostly used method Start ******************************************************//

        //**************************************************trial_Start*****************************************************

        public static void CheckEmptyMandatoryField(IWebDriver Driver)
        {
            IWebElement Elo;
            Boolean Result=true;
            string Xpath = $"//descendant::span[text()='*']/following::input[1]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> Element = Driver.FindElements(By.XPath(Xpath));
            foreach(IWebElement Ele in Element)
            {
                if(Ele.Text.Contains(""))
                {
                   string text= Ele.FindElement(By.XPath("//preceding::label[1]")).Text;
                    Ele.SendKeys(DataFixtureData(Driver,text));
                    //Result = false;
                    Elo= Ele;
                }
                

            }
            //return Result;
        }



        public static Boolean CheckErrorMessageFollowing(IWebDriver Driver)
        {   
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(5));
            string Xpath = $"//descendant::div[contains(@class,'error')]/div";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static string DataFixtureData(IWebDriver Driver,string label)
        {
            string Data="";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            if (label == "Hours Needed")
            {
                Data = "12";
            }
            else if(label== "Origin Name")
            {
                Data = "Arizona state hospital";
            }
            
            
            return Data;
        }
        public static void DefaultDataFixture(IWebDriver Driver)
        {
            string Xpath = "//descendant::div[contains(@class,'error')]/div/preceding::label[1]";
            string InputXpath = "//descendant::div[contains(@class,'error')]/div/preceding::label[1]/following::input[1]";
            string ErrorXpath = "//descendant::div[contains(@class,'error')]/div";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement>ErrorElement=   Driver.FindElements(By.XPath(Xpath));

           
            
            
            foreach (IWebElement errorEle in ErrorElement)
            {
                try
                {

                    string Label = errorEle.FindElement(By.XPath("//preceding::label[1]")).Text;
                    if (label.ToLower().Contains(Label.ToLower()))
                    {
                        string xpath = $"//descendant::label[contains(text(),'{Label}')]/following::input[1]";
                        Driver.FindElement(By.XPath(xpath)).SendKeys(DataFixtureData(Driver, Label));
                    }
                }
                catch
                { }
            
            
            }



           

            
        }
//*********************************************************trial_End*****************************************************

        public static string GetPatientNameFromList(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")));
            string patient = Driver.FindElement(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")).Text;
            
            return patient;
        }
        public static Boolean CheckNoRecordsFound(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='No Record Found']")));
            return Driver.FindElement(By.XPath("//strong[text()='No Record Found']")).Displayed;
        }
        public static void  CheckInvisibilityNoRecordsFound(IWebDriver Driver)
        {
            WebDriverWait Waitt = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            Waitt.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//strong[text()='No Record Found']")));
            
            
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//strong[text()='No Record Found']")));
            
        }
        public static IWebElement ClickOnPatientNameInList(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")));
           return Driver.FindElement(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]"));

            
        }
        public static Boolean CheckErrorMessage(IWebDriver Driver, string ElementName)
        {   //ElementName=
            //First Name,Last Name, Middle Name,Date of Birth,SSN / PID (Last 4 characters),Email ID, Mobile Number,Home Number,
            //Organization Name,Received Date, Contact Person Name, Services Needed,Special Program
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(1));
            string Xpath = $"//label[contains(text(),'{ElementName}')]/following-sibling::div[contains(@class,'error')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void MouseActionForDropDownHandle(IWebDriver Driver, string xpath_DropDown,string? Arrow="Down", int? Index = 1)
        {//use this method to handle drop-down that could not be handled by select class method
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = xpath_DropDown;
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

            IWebElement element = Driver.FindElement(By.XPath(Xpath));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
            for (int i = 1; i <= Index; i++)
            {
                if (Arrow == "Up")
                { element.SendKeys(Keys.ArrowUp); }
                else { element.SendKeys(Keys.ArrowDown); }
               
            }
            element.Click();
            //executor.ExecuteScript("window.scrollBy(0,-700)");





        }
        //****************************************** Mostly used method END ******************************************************//
        //*******************************************Start Dummy patient************************************************************************//

        public static void CreateDummyReferralSend(IWebDriver driver,string DestinationName,string? SearchFacility= "only preferred providers", string? ReferralType= "Outpatient")
        {
            string ServicesNeeded = "Counseling Services";
            string SpecialPrograms = "Geriatric Psych|Adult Women";
            //string ReferralType = "Outpatient";
            string PreAuthorization = "true";
            string ProviderType = "Skilled Nursing(SNF)";
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Create Dummy-Patient With Referral ");
                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, "Navigate To Patient List Page");
                PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                PatientListPOM.WaitForDummyPatientConfirmation(Driver.Value);
                BaseClass.InvisibleSuccess_Notification(Driver.Value);
                Thread.Sleep(3000);

                Test.Value.Log(Status.Pass, "DummyPatient Created Successfully");
                PatientListPOM.ClickSendReferral(Driver.Value, 1);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                if(SearchFacility== "All")
                {
                                       
                    ShortListPOM.SelectOptionInSearchFacilitiesInFilter(Driver.Value,"All");
                    
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Search facility set to All");
                }
                    Thread.Sleep(2000);
                
                
                    ShortListPOM.EnterZipCodeInFilter(Driver.Value,"85017");
                    ShortListPOM.ClickGoButtonInFilter(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                foreach (string item in DestinationName.Split("|"))
                {
                    //ShortListPOM.ClickClearFiltersButton(Driver.Value);
                    ShortListPOM.SelectProviderForReferralByName(Driver.Value, item);
                }
                ShortListPOM.ClickOnSendReferral(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Thread.Sleep(3000);
                
                ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);
                ShortListPOM.SelectReferralType(Driver.Value, ReferralType);
                Thread.Sleep(1000);
                if (ReferralType == "Outpatient")
                {
                    ShortListPOM.ChooseAutoConfirm(Driver.Value);
                }
                ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, bool.Parse(PreAuthorization));
                try
                {

                ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split("|"));
                }
                catch { }
                Thread.Sleep(1000);

                try
                {

                ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                }
                catch { }
                Thread.Sleep(1000);
                // ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split);
                // ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                ShortListPOM.ClickSendButton(Driver.Value);
                Thread.Sleep(2000);
                try
                {

                    ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                }
                catch(Exception e) {
                    Test.Value.Log(Status.Fail, "Unable to click on continue without sharing Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                Thread.Sleep(2000);

                Test.Value.Log(Status.Pass, "DummyPatient with Referral created Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to create Dummy Patient Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
        }
        public static void WaitForTableToGetLoaded(IWebDriver Driver)
        {
            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            try
            {
                Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[contains(@class, 'fa-spinner')]")));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//i[contains(@class, 'fa-spinner')]")));
            }
            catch 
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//i[contains(@class, 'fa-spinner')]")));
            }
            
        }
        //*****************************************************************************End Dummy Patient************************************************************************//
        //**************************************************************************Tags_filter_TestMethods*********************************
    
    
    
    }
}