using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using RovicareTestProject.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using AngleSharp.Dom;
using SeleniumExtras.WaitHelpers;
using ExcelDataReader.Log;
using System;
using System.IO;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Interfaces;
using System.Xml.Linq;
using ICSharpCode.SharpZipLib.Tar;

namespace RovicareTestProject.PageObjects
{

    public class PatientListPOM : BaseClass
    {
        public static void WaitForPatientPageToLoadUp(IWebDriver driver, String PatientName)
        {
            
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(30));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//a[normalize-space()='{PatientName.TrimEnd()}'])[1]")));
            Thread.Sleep(4000);
            
        }

        public static void WaitForResultToLoadUp(IWebDriver driver)
        {

            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(30));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//i[@aria-hidden='true'])[1]")));
            
           Thread.Sleep(3000);

        }

        public static void WaitForInsurancePopUp(IWebDriver driver)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='patient-details-header']")));

        }

        public static void WaitForChatPopUp(IWebDriver driver)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='popup-title Comment-header']")));

        }
        

        public static void NavigateToPatientListPage(IWebDriver driver)
        {
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(30));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//a[contains(@title,'Patient List')]")));
            driver.FindElement(By.XPath("//a[contains(@title,'Patient List')]")).Click();
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[1]/td/div/div[2]")));
            driver.FindElement(By.XPath("//tr[1]/td/div/div[2]")).Click();
            
                    }

        public static String GetXPathForInnerTableAction(int rowNumber)
        {
            return $"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][{rowNumber + 1}]";
        }

        public static void HoverOverFunnelIconAction(IWebDriver driver)
        {
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.Id("//tbody/tr[2]/td[1]/div[1]/div[7]/action[1]/div[1]/span[1]/a[1]/button[1]/i[1]")));
            new Actions(driver).MoveToElement(element).Perform();

        }

        public static void ClickBackNavigationButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h3[@class = 'header']/child::a[@class = 'show-pointer' and i[@class = 'fa fa-arrow-left backButton']]")));
            driver.FindElement(By.XPath("//h3[@class = 'header']/child::a[@class = 'show-pointer' and i[@class = 'fa fa-arrow-left backButton']]")).Click();
        }

        public static void ClickAddPatientButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addPatientDetail")));
            driver.FindElement(By.Id("addPatientDetail")).Click();
        }

        public static void ClickAddDummyPatientButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addDummyPatientDetail")));
            driver.FindElement(By.Id("addDummyPatientDetail")).Click();
            //Thread.Sleep(20000);
        }

        public static String GetDummyPatientName (IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            string Xpath = "//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
             
        }
        
        public static void ClickImportPatientButton(IWebDriver driver)
        {
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Import Patient' and @class = 'btn top-add-buttons']")));
            driver.FindElement(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Import Patient' and @class = 'btn top-add-buttons']")).Click();
        }
        //********************************************** Import Patient Pop up *********************************************************************//
        public static Boolean Verify_ImportPatientPopUp_Opened(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//h4[@id='login_title']")));
            return driver.FindElement(By.XPath("//h4[@id='login_title']")).Displayed;

        }
        public static IWebElement ClickOn_SelectFileToUpload_ImportPatientPopUp(IWebDriver driver)
        {
            string xpath = "//descendant::input[@id='chooseExcelFile']/following-sibling::button";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return driver.FindElement(By.XPath(xpath));
            
        }
        public static void ClickOn_SelectFileType_ImportPatientPopUp(IWebDriver driver,string Option)
        {
            string Xpath = "//descendant::mat-dialog-content/descendant::label[contains(text(),'File Type')]/following::select";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            //IWebElement browse = driver.FindElement(By.XPath(Xpath));
            //browse.Click();
            SelectElement File = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            File.SelectByText(Option);
        }

        public static Tuple<string,string> Check_HeadlineElement_ImportPatientPopUp(IWebDriver driver)
        {   string importchannel = "//descendant::mat-dialog-content/descendant::h4[1]";
            string importStatus = "//descendant::mat-dialog-content/descendant::status-labels[1]/descendant::span[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(importchannel)));
           string channel = driver.FindElement(By.XPath(importchannel)).Text;
            string Importstatus = driver.FindElement(By.XPath(importStatus)).Text;

            return Tuple.Create(channel, Importstatus); 
        }

        public static Tuple<IList<string>, IList<string>, IList<string>,Boolean,string, IWebElement> Check_InnerTableElement_ImportPatientPopUp(IWebDriver driver)
        {
            string gender = "//descendant::*[@id='AddHospitalTblid']/descendant::tr[2]/descendant::span[contains(text(),'Gender')]/following-sibling::span";
            string Editp = "//descendant::*[@id='AddHospitalTblid']/descendant::tr/descendant::button[@title='Edit Patient']";
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Editp)));
            
            IList<IWebElement> Table = driver.FindElements(By.XPath("//descendant::*[@id='AddHospitalTblid']/descendant::tr"));
            IList<string> name=new List<string>(); 
            IList<string> ExistP=new List<string>();
            IList<string> FailedP = new List<string>();
            for (int i = 2; i <= Table.Count; i++)
            {
            string namestatus = driver.FindElement(By.XPath($"//descendant::*[@id='AddHospitalTblid']/descendant::tr[{i}]/descendant::status-labels/descendant::span")).Text;
                
                    if (namestatus.Contains("Failed"))
                    {
                    FailedP.Add(driver.FindElement(By.XPath($"//descendant::*[@id='AddHospitalTblid']/descendant::tr[{i}]/descendant::span[text()='Patient Name']/following-sibling::span")).Text);
                    }
                    else if (namestatus.Contains("Patient Exists"))
                    {
                        ExistP.Add(driver.FindElement(By.XPath($"//descendant::*[@id='AddHospitalTblid']/descendant::tr[{i}]/descendant::span[text()='Patient Name']/following-sibling::span")).Text);
                    }
                    else

                    { name.Add(driver.FindElement(By.XPath($"//descendant::*[@id='AddHospitalTblid']/descendant::tr[{i}]/descendant::span[text()='Patient Name']/following-sibling::span")).Text); }
                
            }


            // PatientList.Add//Patient Exists

           // IList<IWebElement> statuslist = driver.FindElements(By.XPath(namestatus));
            
            
            IList<IWebElement> Editpatient = driver.FindElements(By.XPath(Editp));
            Boolean AreAllEditEnabled = true;
            foreach (WebElement Edit in Editpatient)
            {
                if (!Edit.Enabled)
                    AreAllEditEnabled = false;
            }

            string Gender =driver.FindElement(By.XPath(gender)).Text;
            IWebElement firstEditPatient = driver.FindElement(By.XPath("//descendant::*[@id='AddHospitalTblid']/descendant::tr[2]/descendant::button[@title='Edit Patient']"));
            return Tuple.Create(name, ExistP, FailedP,AreAllEditEnabled, Gender, firstEditPatient);
        }
        public static Tuple<IWebElement,IWebElement,IWebElement> VerifyEditPatientElement_ImportPatientPopUp(IWebDriver driver)
        {
            string gende = $"//descendant::mat-dialog-content/descendant::input[@id='other']";
            string save = "//descendant::*[@id='editPatientForm']/descendant::button[1]";
            string close = "//descendant::app-edit-patient-dialog/descendant::*[text() = '×']";
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(gende)));

            return Tuple.Create(

                driver.FindElement(By.XPath(gende)),
                driver.FindElement(By.XPath(save)),
                driver.FindElement(By.XPath(close))
                               
                );




        }

        public static IWebElement ClickOn_SampleFile_ImportPatientPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='download-link']")));
            return driver.FindElement(By.XPath("//a[@class='download-link']"));
           


        }

        public static IWebElement Check_ImporsuccessMessage_ImportPatientPopUp(IWebDriver driver)
        {
            string xpath = "//descendant::*[@id='ImportPatientCountContainer']/p";
            string xpath1 = "//descendant::*[@id='ImportPatientCountContainer']/p[contains(text(),'Completed') or contains(text(),'imported')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath1)));
            Thread.Sleep(500);
            return driver.FindElement(By.XPath(xpath1));
        }
        public static IWebElement ClickOn_ImportButton_ImportPatientPopUp(IWebDriver driver)
        {
            string Xpath = "//descendant::mat-dialog-actions/descendant::button[text()='IMPORT']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOn_Done_ImportPatientPopUp(IWebDriver driver,string ButtonName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//descendant::mat-dialog-actions/descendant::button[contains(.,'{ButtonName}')]")));
            driver.FindElement(By.XPath($"//descendant::mat-dialog-actions/descendant::button[contains(.,'{ButtonName}')]")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//descendant::mat-dialog-actions/descendant::button")));
        }

        public static IWebElement ClickOn_CancelButton_ImportPatientPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@name='cancel']")));
            return driver.FindElement(By.XPath("//button[@name='cancel']"));
        }
        

        //*********************************** Search Section **********************************************//

        public static void SelectTrackedByFilter(IWebDriver driver, String TrackedBy)
        {
            string Xpath = "//descendant::label[contains(text(),'Tracked By')]/following-sibling::select";
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            modeSelection.SelectByText(TrackedBy);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);

        }

        public static void SelectModeFilter(IWebDriver driver, string Mode,string element)
        { string Xpath = $"//descendant::label[contains(text(),'{element}')]/following-sibling::select";
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            modeSelection.SelectByText(Mode);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
        }

       
        public static Boolean CheckStatusOfAllRows(IWebDriver driver, String Status)
        {
            Boolean AreAllStatusSame = true;
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(1));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("status-badge-container")));
            IList<IWebElement> statusList = driver.FindElements(By.ClassName("status-badge-container"));
            foreach (WebElement status in statusList)
            {
                if (!Status.ToLower().Contains(status.Text.ToLower()))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }
        //View Insurance Detail
        public static Boolean CheckInsuranceOfAllRows(IWebDriver driver, String insurance)
        {
            Boolean AreAllInsuranceSame = true;
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(1));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//a[@title='View Insurance Detail']")));
            IList<IWebElement> InList = driver.FindElements(By.XPath("//a[@title='View Insurance Detail']"));
            foreach (WebElement Insu in InList)
            {
                if (!insurance.ToLower().Contains(Insu.Text.ToLower()))
                    AreAllInsuranceSame = false;
            }

            return AreAllInsuranceSame;
        }
        public static void SelectSentByFilter(IWebDriver driver, String SentBy)
        {
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input-select[contains(@ng-reflect-label,'Sent By')]//select[contains(@name,'select-input')]")));
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath("//input-select[contains(@ng-reflect-label,'Sent By')]//select[contains(@name,'select-input')]")));
            modeSelection.SelectByText(SentBy);
            driver.FindElement(By.XPath("//input-select[contains(@ng-reflect-label,'Sent By')]//select[contains(@name,'select-input')]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//input-select[contains(@ng-reflect-label,'Sent By')]//select[contains(@name,'select-input')]")).SendKeys(Keys.Enter);
        }

        public static void EnterPatientNameForSearch(IWebDriver driver, String PatientName)
        {
            foreach(String Name in PatientName.Split("|"))
            {
                driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).Clear();
                driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).SendKeys(Name);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//a[normalize-space()='{Name.TrimEnd()}']")));
            }
        }
        public static void ClearEnterPatientNameForSearch(IWebDriver driver)
        {

            string Xpath = "//input[contains(@placeholder,'Patient Name')]";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                String namee=driver.FindElement(By.XPath(Xpath)).GetAttribute("value");
            
            for(int i=namee.Length;i>=1;i--)
            {

            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Backspace);
            }
            driver.FindElement(By.XPath(Xpath)).Click();


        }
        //new method, not sure where it should be placed, edited by Nikhil


        //*********************************** Result Section **********************************************//  


        public static void SelectItemPerPageInPaginationControls(IWebDriver driver, int ItemPerPage)
        {
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath("//app-pagination/descendant::select")));
            modeSelection.SelectByText(ItemPerPage.ToString());
        }

        public static void ClickPreviousPageButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[contains(@class, 'pagination-previous')]")));
            driver.FindElement(By.XPath("//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[contains(@class, 'pagination-previous')]")).Click();
        }

        public static void ClickNextPageButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[contains(@class, 'pagination-next')]")));
            driver.FindElement(By.XPath("//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[contains(@class, 'pagination-next')]")).Click();
        }

        public static void GoToPageNumber(IWebDriver driver, int PageNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[a[span[text() = '{PageNumber}']]]")));
            driver.FindElement(By.XPath($"//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[a[span[text() = '{PageNumber}']]]")).Click();
        }

        public static void SortByPatientName(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='header_container']/descendant::i[1]")));
            driver.FindElement(By.XPath("//div[@class='header_container']/descendant::i[1]")).Click();
        }

        public static void SortByInsuranceName(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='header_container']/descendant::i[2]")));
            driver.FindElement(By.XPath("//div[@class='header_container']/descendant::i[2]")).Click();
        }

        public static void SortByDischargeDate(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='header_container']/descendant::i[3]")));
            driver.FindElement(By.XPath("//div[@class='header_container']/descendant::i[3]")).Click();
        }

        public static void ExpandInnerTable(IWebDriver driver, int rowNumber)
        {
            string Xpath = $"//descendant::tr[{rowNumber+1}]/td[@class='patient-list-td']/descendant::div[contains(@class,'row_detail')]/descendant::a[@title = 'Preferred Facility List']/i";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static string GetPatientNameFromList(IWebDriver Driver,int rowNumber)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")));
            string patient = Driver.FindElement(By.XPath($"//tr[{rowNumber+1}]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")).Text;

            return patient;
        }
        public static Boolean StatusValidationofTransport(IWebDriver Driver, String Status)
        {
            string Xpath = $"//descendant::*[@id='ReferralsInnerTable']/descendant::span[contains(text(),'{Status}')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
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
        internal static void WaitForLoadingSpinnerToDisappear(IWebDriver driver)
        {
            
            WebDriverWait wait_Short = new WebDriverWait(driver, TimeSpan.FromMilliseconds(200));
            WebDriverWait wait_Long = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait_Short.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[contains(@class, 'fa-spinner')]")));
                wait_Long.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//i[contains(@class, 'fa-spinner')]")));

            }
            catch (Exception ex)
            {
                try
                {
                    wait_Long.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//i[contains(@class, 'fa-spinner')]")));
                }
                catch (Exception ex2)
                {
                    throw new TimeoutException();
                }
            }

        }

        public static string GetPatientInfoFromSearchResult (IWebDriver driver, int rowNumber)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tbody/tr[2]/td[1]/div[1]/div[1]/div[2]/a[2]")));

            return driver.FindElement(By.XPath($"//tbody/tr[2]/td[1]/div[1]/div[1]/div[2]/a[2]")).Text;
        
        }

        public static String GetPatientNameVerified_SearchCriteria(IWebDriver driver, int RowNum)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tbody/tr[2]/td[1]/div[1]/div[1]/div[2]/a[2]")));

            return driver.FindElement(By.XPath("//tbody/tr[2]/td[1]/div[1]/div[1]/div[2]/a[2]")).Text;     

        }
        public static String GetPatientNameFromPatientList(IWebDriver driver, int RowNum)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//tbody/tr[{RowNum+1}]/td/div[1]/div[1]/div[2]/span/span[2]/descendant::a")));

            return driver.FindElement(By.XPath($"//tbody/tr[{RowNum+1}]/td/div[1]/div[1]/div[2]/span/span[2]/descendant::a")).Text;

        }

        public static String ExpandInnerTableStatusCapture(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::status-labels/div/descendant::span")));
            String status = driver.FindElement(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::status-labels/div/descendant::span")).Text;
            return status.ToLower().Trim();
        }

        public static Boolean ExpandInnerTableStatusVarification(IWebDriver driver, String StatusToBeVerified)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::status-labels/div/descendant::span")));
            var status = driver.FindElement(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::status-labels/div/descendant::span")).Text;
            return status.ToLower().Trim() == StatusToBeVerified.ToLower().Trim() ? true : false;
        }
        public static void ClickArrangeTransportInInnerTable(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::action/descendant::button[@title='Arrange Transport']")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::action/descendant::button[@title='Arrange Transport']")).Click();
           
        }
        public static void ClickTransportCompleteInInnerTable(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::action/descendant::button[@title='Transport Complete']")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][2]/descendant::action/descendant::button[@title='Transport Complete']")).Click();
        }

        public static void ClickOnConfirmReferralButtonInnerTable(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//i[@class='fa fa-lock']")));
            driver.FindElement(By.XPath($"//i[@class='fa fa-lock']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[@name='create']")));
        }

        public static void ClickOnSubmit_ConfirmReferralPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[@name='create']")));
            driver.FindElement(By.XPath($"//button[@name='create']")).Click();
            
        }

        public static Boolean WaitForSendReferralConfirmation(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")));
            return driver.FindElement(By.XPath("//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")).Displayed;
        }
        public static Boolean WaitForDummyPatientConfirmation (IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")));
            Boolean Temp= driver.FindElement(By.XPath("//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")).Displayed;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")));
            return Temp;    
        }

        public static void ClickOnCancel_ConfirmReferralPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[@name='cancel']")));
            driver.FindElement(By.XPath($"//button[@name='cancel']")).Click();
        }



        public static void ExpandInnerTableofInnerTable(IWebDriver driver, int rowNumber)
        {
            string Xpath = $"//app-custom-table-component/descendant::app-custom-table-component/descendant::td[not(ancestor::table[@id = 'ReferralsInnerTable'])][{rowNumber + 1}]/descendant::a[i[contains(@class, 'fa-chevron')]]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();
            }
            catch
            { }
        }

        public static void ClickOnRespondToReferralIcon(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::table[@id = 'ReferralsInnerTableId'][1]/descendant::table[@id = 'ReferralsInnerTable'][1]/descendant::tr[2]/descendant::action/descendant::accept-referral-icon")));
                driver.FindElement(By.XPath($"//app-custom-table-component/descendant::table[@id = 'ReferralsInnerTableId'][1]/descendant::table[@id = 'ReferralsInnerTable'][1]/descendant::tr[2]/descendant::action/descendant::accept-referral-icon")).Click();
            }
            catch (Exception ex)
            { }
        }

        public static void ClickSendMoreReferralsActionofInnerTable(IWebDriver driver, int rowNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"{GetXPathForInnerTableAction(rowNumber)}/descendant::button[@title = 'Send More Referrals' and @class='btn-list-clr' and i[@class= 'fas fa-plus']]")));
                driver.FindElement(By.XPath($"{GetXPathForInnerTableAction(rowNumber)}/descendant::button[@title = 'Send More Referrals' and @class='btn-list-clr' and i[@class= 'fas fa-plus']]")).Click();
            }
            catch (Exception ex)
            { }
        }

        public static void ClickEditTransportActionofInnerTable(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"{GetXPathForInnerTableAction(rowNumber)}/descendant::button[@class = 'btn-filterList-clr' and @title = 'Edit Transport' and i[@class = 'fa fa-ambulance edit-transport-icon']]")));
                driver.FindElement(By.XPath($"{GetXPathForInnerTableAction(rowNumber)}/descendant::button[@class = 'btn-filterList-clr' and @title = 'Edit Transport' and i[@class = 'fa fa-ambulance edit-transport-icon']]")).Click();
            }
            catch (Exception ex)
            { }
        }
        public static Boolean CheckPlaceholder_Tags(IWebDriver driver, string CheckText)
        {
            string Xpath = "//label[contains(text(),'Tags')]/following::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Contains(CheckText);

        }
        
        
        

        public static Boolean ClickReferralReportActionofInnerTableStatusVarification(IWebDriver driver)
        {
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//referral-report/descendant::div[@class='row'][2]/descendant::status-labels/div/descendant::span")));
               var status =  driver.FindElement(By.XPath($"//referral-report/descendant::div[@class='row'][2]/descendant::status-labels/div/descendant::span")).Text;
               return (status == "Referral Sent")? true : false; 
        }
        public static IWebElement ClickDisableReferralActionofInnerTable(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//tr[{rowNumber+1}]/descendant::table[@id='ReferralsInnerTableId']/descendant::button[contains(@title,'Disable')]")));
                return driver.FindElement(By.XPath($"//tr[{rowNumber+1}]/descendant::table[@id='ReferralsInnerTableId']/descendant::button[contains(@title,'Disable')]"));



        }//descendant::div[contains(@id,'ReferralsInnerTableId')]/descendant::button[@title='Enable Referral'][1]
        public static IWebElement ClickEnableReferral_ReferralHistoryPOPUp(IWebDriver driver)
        {
            string Xpath = "//descendant::div[contains(@id,'ReferralsInnerTableId')]/descendant::button[@title='Enable Referral'][1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IWebElement ClickOnEnablepatient(IWebDriver driver)
        {
            string Xpath = "//descendant::tr[2]/descendant::button[@title='Enable Patient']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }

        public static void ProvideDisableReason(IWebDriver Driver, int i)
        {
            string Xpath = "//*[@id='providerTypeSearch']";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id,'mat-dialog-title')]")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));

            Driver.FindElement(By.XPath(Xpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='providerTypeSearch']/following::span[{i}]")));
            IWebElement element = Driver.FindElement(By.XPath($"//*[@id='providerTypeSearch']/following::span[{i}]"));


            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);


            element.Click();


            // return Tuple.Create(Driver.FindElement(By.XPath(Xpath)), Xpath);
        }
        public static void EnterNotes_DisableReferralPopUp(IWebDriver Driver, String Notes)
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
        public static IWebElement ClickSubmitOnDisableReferralPopUp(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-actions/descendant::button[text()='SUBMIT']")));
            return Driver.FindElement(By.XPath("//descendant::mat-dialog-actions/descendant::button[text()='SUBMIT']"));

        }

        public static void OpenInsuranceDetail(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::a[@class = 'insurancegrid' and @title = 'View Insurance Detail']")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::a[@class = 'insurancegrid' and @title = 'View Insurance Detail']")).Click();
        }

        public static void OpenPatientDetail(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::a[@title = 'Preferred Facility List']/following-sibling::a[@class='cursor-pointer']")));
            }
            catch
            {
                throw new TimeoutException();
            }
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::a[@title = 'Preferred Facility List']/following-sibling::a[@class='cursor-pointer']")).Click();
        }

        public static void ClickShortlistFilter(IWebDriver driver, int rowNumber)
        {
            WebDriverWait Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Shortlist Facility' and @class = 'btn-view-clr' and @type='submit' and i[@class = 'fa fa-filter']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Shortlist Facility' and @class = 'btn-view-clr' and @type='submit' and i[@class = 'fa fa-filter']]")).Click();
        }

        public static void ClickEditPatient(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Edit Patient' and @class = 'btn-view-clr' and @type='submit' and i[@class = 'fa fa-edit']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Edit Patient' and @class = 'btn-view-clr' and @type='submit' and i[@class = 'fa fa-edit']]")).Click();
        }

        public static void ClickSendReferral(IWebDriver driver, int rowNumber)
        {
            string Xpath = $"//descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Send Referral' and @class = 'btn-LTClist-clr' and @type = 'submit' and i[@class = 'fa fa-paper-plane']]";
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(4000);

        }


        //*[contains(@id,'mat-dialog-title')]//div[text()='×']
        public static void CloseChatPopUp(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@aria-hidden='true']")));
            driver.FindElement(By.XPath("//span[@aria-hidden='true']")).Click();
            Thread.Sleep(2000);
        }
        public static void CloseReferralHistoryPopUp(IWebDriver driver)
        {
            string Xpath = "//*[contains(@id,'mat-dialog-title')]//div[text()='×']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(2000);
        }

        public static void CloseInsurancePopUp(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@aria-hidden='true']")));
            driver.FindElement(By.XPath("//span[@aria-hidden='true']")).Click();
            Thread.Sleep(2000);
        }

        public static void EnterChatMessage_ChatPopUp(IWebDriver driver, String ChatMessage)
        {
            foreach (string message in ChatMessage.Split("|"))
            driver.FindElement(By.XPath("//*[@id= 'scriptBox']")).SendKeys(message);
            Thread.Sleep(2000);
        }

        public static void ClickOnPrintButton_ChatPopUp(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[@id='print-chats']")).Click();
            Thread.Sleep(2000);
        }
        public static void ClickOnCopyAllButton_ChatPopUp(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[@id='print-copy']")).Click();
            Thread.Sleep(2000);
        }

        public static void ClickOnSendButton_ChatPopUp(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@class = 'fa fa-paper-plane send-paper-icon ng-star-inserted' and @title='Send Message']")).Click();
            Thread.Sleep(2000);
        }

        public static int CountNumberOfMessages_ChatPopUp(IWebDriver driver)
        {
            return driver.FindElements(By.XPath("//*[@class='speech-bubble-ds round right-top ng-star-inserted']")).Count();
            
        }
        public static String LatestMessageVerification__ChatPopUp(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//span[@class='sticky-date-bg ng-star-inserted']")).Text;
        }
        
        public static void ClickMedicalRecordAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Medical Record' and @class = 'btn-LTClist-clr' and @type = 'submit' and i[@class = 'fas fa-file-upload']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Medical Record' and @class = 'btn-LTClist-clr' and @type = 'submit' and i[@class = 'fas fa-file-upload']]")).Click();
        }

        public static void OpenMoreActions(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            //executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", ActionItems);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//descendant::tr[{rowNumber + 1}]/descendant::a[contains(@title,'More Action')]/i")));
            IWebElement ActionItems = driver.FindElement(By.XPath($"//descendant::tr[{rowNumber+1}]/descendant::a[contains(@title,'More Action')]/i"));
            Actions action = new Actions(Driver.Value);
            action.MoveToElement(ActionItems).Perform();
        }//descendant::tr[2]/descendant::li[contains(.,'Share Medical Records')]

        public static IWebElement MoreAction_DropDown(IWebDriver driver, int rowNumber,string element)
        {
            
            
                string Xpath = $"//descendant::tr[{rowNumber + 1}]/descendant::li[contains(.,'{element}')]";

                WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                return driver.FindElement(By.XPath(Xpath));
            
            
           
        }
        public static void ClickOnYesButton_ConfirmPOpup(IWebDriver Driver)
        {
            string Xpath = "//div[contains(@id,'mat-dialog-title')]/following::button[@name='create']";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
             Driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckNoRecordsFound(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='No Record Found']")));
            return Driver.FindElement(By.XPath("//strong[text()='No Record Found']")).Displayed;
        }
        public static void ClickDischargeAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Discharge' and @class = 'btn-view-clr padding-top-15 more-action-icon' and i[@class = 'discharge-svg-icon']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Discharge' and @class = 'btn-view-clr padding-top-15 more-action-icon' and i[@class = 'discharge-svg-icon']]")).Click();
        }

        public static void ClickAdmitPatientAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Admit Patient' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-procedures']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Admit Patient' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-procedures']]")).Click();
        }

        public static void ClickNotesAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Notes' and @class = 'btn-annotation-clr more-action-icon' and @type = 'submit' and i[@class = 'far fa-file-alt']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Notes' and @class = 'btn-annotation-clr more-action-icon' and @type = 'submit' and i[@class = 'far fa-file-alt']]")).Click();
        }

        public static void ClickReferralHistoryAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Referral History' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-history']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Referral History' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-history']]")).Click();
        }


        public static void ClickAddAppointmentAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Add Appointment' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-plus-square']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Add Appointment' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-plus-square']]")).Click();
        }

        public static String ExpandInnerTableofInnerTable_CaptureAppointmentDetails(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-date-time[@ng-reflect-is-arrow-icon-required='false']//span[@class='ng-star-inserted']")));
            return driver.FindElement(By.XPath($"//app-date-time[@ng-reflect-is-arrow-icon-required='false']//span[@class='ng-star-inserted']")).Text;
        }

        public static void ClickSendMedicalRecordsAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Send Medical Records' and @class = 'btn-annotation-clr padding-top-15 more-action-icon' and @type = 'submit' and i[@class = 'upload-medical-record-icon']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Send Medical Records' and @class = 'btn-annotation-clr padding-top-15 more-action-icon' and @type = 'submit' and i[@class = 'upload-medical-record-icon']]")).Click();
        }
        /***********************************************AddReferral pop-up start**********************************************************/

        public static void SelectAddReferralAs(IWebDriver driver, string ElementName)
        {//ElementName=Incoming,Outgoing
            Thread.Sleep(500);
            string Xpath = $"//descendant::span[contains(text(),'{ElementName}')]/preceding-sibling::input";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }













        /***********************************************AddReferral pop-up End**********************************************************/


        /*********************************************** Medical Records pop up start  ***************************************************/

        public static void ClickOn_AddFileButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//a[contains(text(),'Add File')])[2]")));
            driver.FindElement(By.XPath($"(//a[contains(text(),'Add File')])[2]")).Click();
        }

        public static void ClickOn_EditButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[2]")));
            driver.FindElement(By.XPath($"(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[2]")).Click();
        }

        public static void ClickOn_SaveButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[3]")));
            driver.FindElement(By.XPath($"(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[3]")).Click();
        }

        public static void EnterName_SearchField_MedicalRecordPopUp(IWebDriver driver, string FileName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//input[@placeholder='By Name'])[2]")));
            driver.FindElement(By.XPath($"(//input[@placeholder='By Name'])[2]")).SendKeys(FileName);
        }
        public static void ClearName_SearchField_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//input[@placeholder='By Name'])[2]")));
            driver.FindElement(By.XPath($"(//input[@placeholder='By Name'])[2]")).Clear();
        }

        public static void SelectCategory_SearchField_MedicalRecordPopUp(IWebDriver driver, string category)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='Provider_Filter']")));
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath($"//select[@id='Provider_Filter']")));
            modeSelection.SelectByText(category);
        }

        public static void SelectCategory_CategoryColumn_MedicalRecordPopUp(IWebDriver driver, int rowNum, string category)
        {
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath($"(//select[@id='EditFileType{rowNum - 1}'])[1]")));
            modeSelection.SelectByText(category);
        }

        public static void SelectAccess_AccessColumn_MedicalRecordPopUp(IWebDriver driver, int rowNum, string accessType)
        {
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath($"//select[@id='EditShareType{rowNum - 1}']")));
            modeSelection.SelectByText(accessType);
        }

        public static void ClickOnEditButton_ActionColumn_MedicalRecordPopUp(IWebDriver driver, int rowNum)
        {
            if (rowNum >= 0)
                driver.FindElement(By.XPath($"//button[@name='editFile{rowNum - 1}']")).Click();
        }

        public static void ClickOnCancelButton_AfterEdit_MedicalRecordPopUp(IWebDriver driver)
        {
             driver.FindElement(By.XPath($"//a[@title='Cancel']")).Click();
        }

        public static void ClickOnSaveButton_AfterEdit_MedicalRecordPopUp(IWebDriver driver)
        {
            driver.FindElement(By.XPath($"//a[@title='Save']")).Click();
        }

        public static void ClickOnDeleteButton_ActionColumn_MedicalRecordPopUp(IWebDriver driver, int rowNum)
        {
            if (rowNum >= 0)
            { driver.FindElement(By.XPath($"//button[@name='deleteFile{rowNum - 1}']")).Click(); }
        }

        public static void EnterFileName_FileDetailSection_MedicalRecordPopUp(IWebDriver driver, int rowNum)
        {
            if (rowNum >= 0)
            { driver.FindElement(By.XPath($"//button[@name='deleteFile{rowNum - 1}']")).Click(); }
        }

        public static void EnterCategoryName_FileDetailSection_MedicalRecordPopUp(IWebDriver driver, int rowNum)
        {
            if (rowNum >= 0)
            { driver.FindElement(By.XPath($"//button[@name='deleteFile{rowNum - 1}']")).Click(); }
        }
        public static void EnterDescription_FileDetailSection_MedicalRecordPopUp(IWebDriver driver, int rowNum)
        {
            if (rowNum >= 0)
            { driver.FindElement(By.XPath($"//button[@name='deleteFile{rowNum - 1}']")).Click(); }
        }

        /*********************************************** Medical Records pop up end ***************************************************/


        public static void ClickDisablePatientAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Disable Patient' and @class = 'btn-danger-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-eye-slash']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Disable Patient' and @class = 'btn-danger-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-eye-slash']]")).Click();
        }

        public static void ClickConsolidateReferralAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Consolidate Referral' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-object-group']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Consolidate Referral' and @class = 'btn-LTClist-clr more-action-icon' and @type = 'submit' and i[@class = 'fas fa-object-group']]")).Click();
        }

        public static void ClickViewPatientPortalAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'View Patient Portal' and @class = 'btn-copy-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-link']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'View Patient Portal' and @class = 'btn-copy-clr more-action-icon' and @type = 'submit' and i[@class = 'fa fa-link']]")).Click();
        }

        public static void ClickPatientNotificationAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Patient Notification' and @class = 'btn-insurance-clr padding-top-15 more-action-icon' and @type = 'submit' and i[@class = 'patient-notification-icon']]")));
            driver.FindElement(By.XPath($"/descendant::td[{rowNumber + 1}]/descendant::button[@title = 'Patient Notification' and @class = 'btn-insurance-clr padding-top-15 more-action-icon' and @type = 'submit' and i[@class = 'patient-notification-icon']]")).Click();
        }

        public static void WaitForReferralTableToBeClickable(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//tr[2]//action//button/following::i[2]")));
            Thread.Sleep(3000);
        }

        /********************************************** ReturnTheDriverObject *************************************************/



        public static PatientListPOM ReturnTheDriverObject()
        {
            return new PatientListPOM();
        }

    }

}
