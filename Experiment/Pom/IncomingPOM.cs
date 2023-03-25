using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using RovicareTestProject.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using RovicareTestProject.Models;
using System.Linq;
using System.IO;

namespace RovicareTestProject.PageObjects
{

    public class IncomingPOM : BaseClass
    {
        public static void WaitForIncomingPageToLoadUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("incoming")));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//app-custom-table-component/descendant::div[contains(@class, 'grid-loading')]/descendant::i[@class = 'fa fa-spin fa-spinner']")));
        }

        public static void WaitForChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@title='Send Message']")));
            
        }
        public static string CheckTitlechatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='popup-title display-flex-and-align-center']")));


             return Driver.FindElement(By.XPath("//div[@class='popup-title display-flex-and-align-center']")).Text;

            //*[@id="chat-mat-dialog"]/descendant::div[@class='chat-heading-label left-margin-15 ng-star-inserted']

        }
       

        public static void NavigateToIncomingPage(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@title='Incoming']")));
            driver.FindElement(By.XPath(".//*[@title='Incoming']")).Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::tr[1]/td/descendant::div[contains(text(),'Status')][1]")));
            
        }
        public static Boolean StatusValidationInDestination(IWebDriver Driver, String Status)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(".//incoming/descendant::tr[2]/descendant::status-labels[1]")));
            String temp = Driver.FindElement(By.XPath(".//incoming/descendant::tr[2]/descendant::status-labels[1]")).Text;
            temp = temp.Trim();
            if (temp == Status.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static void ClickOnRespondToReferralButton(IWebDriver Driver, int rowNum)
        {
            Driver.FindElement(By.XPath($"//*[@id='hsgdsahasj']/descendant::tr[{rowNum+1}]/descendant::accept-referral-icon")).Click();

        }

        //*************************Search Field *************************************//
        public static Boolean CheckSearch(IWebDriver Driver)
        {
            return Driver.FindElement(By.XPath("//app-filter/descendant::h2")).Displayed;
           
        }
        public static Tuple<IWebElement,string >SelectStatus (IWebDriver Driver)
        {
            string Xpath = "//div[contains(@class,'col-sm-12 col-xs-12 search-container-padding col-md-12')]//div[1]//div[1]//input-select[1]//select[1]";
           IWebElement webElement= Driver.FindElement(By.XPath(Xpath));
            return Tuple.Create( Driver.FindElement(By.XPath(Xpath)),Xpath);
            
        }


        public static Tuple<IWebElement,string> EnterMode(IWebDriver Driver)
        {
            string Xpath = "//div[@id='MainWrapper']//div[2]//div[1]//input-select[1]//select[1]";
           return Tuple.Create( Driver.FindElement(By.XPath(Xpath)),Xpath);
            
        }

        public static void EnterPatientNameInSearchField(IWebDriver Driver, String PatientName)
        {
            Driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).Clear();
            Driver.FindElement(By.XPath("//input[contains(@placeholder,'Patient Name')]")).SendKeys(PatientName);
        }

        




        /********************************************** Action Items ************************************************/


        // Nikhil
        public static void ClickEditPatientAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-view-clr' and @title = 'Edit Patient' and i[@class = 'fa fa-edit']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-view-clr' and @title = 'Edit Patient' and i[@class = 'fa fa-edit']]")).Click();
        }

        public static void ClickOriginMedicalRecordAction(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-LTClist-clr' and @title = 'Origin Medical Record' and i[@class = 'fa fa-file-download']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-LTClist-clr' and @title = 'Origin Medical Record' and i[@class = 'fa fa-file-download']]")).Click();
        }

        public static void ClickChatAction(IWebDriver driver, int rowNumber)
        {
            string Xpath = $"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-comment-clr' and @title = 'Chat' and i[@class = 'fa fa-comments chat-icon']]";
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(5000);
        }

        public static void ClickOn_SendMedicalRecords_ActionItems(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-annotation-clr padding-top-15' and @title = 'Send Medical Records' and i[@class = 'upload-medical-record-icon']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-annotation-clr padding-top-15' and @title = 'Send Medical Records' and i[@class = 'upload-medical-record-icon']]")).Click();
        }

        public static IWebElement ClickOn_Transport_ActionItem(IWebDriver driver, int rowNumber)
        {
            string Xpath = $"//descendant::*[@id='undefinedtable-container']/descendant::tr[{rowNumber+1}]/descendant::button[contains(@title,'Transport')]/i";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckUpdateTransportPOPup(IWebDriver Driver)
        {
            string Xpath = "//descendant::*[contains(@id,'mat-dialog-title')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]

        }
        public static void EnterNotes_ArrangeTransportPopUp(IWebDriver Driver, String Notes)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//textarea[@id='newNote']")));
                Driver.FindElement(By.XPath("//textarea[@id='newNote']")).Clear();
                Driver.FindElement(By.XPath("//textarea[@id='newNote']")).SendKeys(Notes);
                Driver.FindElement(By.XPath("//textarea[@id='newNote']")).SendKeys(Keys.Enter);

            }
            catch
            {

            }

        }
        public static IWebElement CheckApprovedDateofTransportPOPup(IWebDriver Driver,string Date)
        {
            string Xpath = $"//descendant::app-date-time/*[contains(text(),'{Date.ToLower()}')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)); // try- (//i[@class='fa fa-ambulance'])[1]

        }
        public static void SelectPickupDate_EditTransportPopUp(IWebDriver driver, string Date)
        {
            DateTime date=DateTime.Now;
            int day=date.Day;
            try
            {
                string Xpath = "//descendant::input[@id='newPickupDate']";
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

                if (Date == "Today")
                {
                driver.FindElement(By.XPath(Xpath)).Click();
                
                    string Xpath1 = $"//div[@class='xdsoft_calendar']/descendant::td[contains(@class,'today')][@data-date='{day}']";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath1)));
                    driver.FindElement(By.XPath(Xpath1)).Click();
                    
                }
                else if (Date == "Today+1")
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath(Xpath),""));
                    driver.FindElement(By.XPath(Xpath)).Click();
                    string xpath1 = $"//descendant::div[contains(@style,'fixed')]/descendant::td[contains(@class,'today')][@data-date='{day}']/following::td[1]";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath1)));
                    driver.FindElement(By.XPath(xpath1)).Click();
                    Thread.Sleep(1000);
                }
                else if (Date == "Today+2")
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath(Xpath), ""));
                    driver.FindElement(By.XPath(Xpath)).Click();
                    string xpath1 = $"//descendant::div[contains(@style,'fixed')]/descendant::td[contains(@class,'today')][@data-date='{day}']/following::td[2]";
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath1)));
                    driver.FindElement(By.XPath(xpath1)).Click();
                    Thread.Sleep(1000);
                }
                Thread.Sleep(500);
                driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                
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
        public static IWebElement CheckDateofTransport_RequestTime(IWebDriver Driver, string Date)
        {

            
            string Xpath = $"//span[contains(normalize-space(),'{Date}')]";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath));


        }
        
        public static void ExpandMoreActions(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//descendant::tr[{rowNumber + 1}]/descendant::a[contains(@title,'More Action')]/i")));
            IWebElement ActionItems = driver.FindElement(By.XPath($"//descendant::tr[{rowNumber + 1}]/descendant::a[contains(@title,'More Action')]/i"));
            Actions action = new Actions(Driver.Value);
            action.MoveToElement(ActionItems).Perform();
        }
        
        public static IWebElement MoreAction_DropDown(IWebDriver driver, int rowNumber, string element)
        {//select element by element name


            string Xpath = $"//descendant::tr[{rowNumber + 1}]/descendant::li[contains(.,'{element}')]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }

        public static void ClickBackLinkButton(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//a[i[@class = 'fa fa-arrow-left backButton']]")));
            driver.FindElement(By.XPath($"//a[i[@class = 'fa fa-arrow-left backButton']]")).Click();
        }

        public static void SelectItemPerPageInPaginationControls(IWebDriver driver, int ItemPerPage)
        {
            SelectElement modeSelection = new SelectElement(driver.FindElement(By.XPath("//app-pagination/descendant::select")));
            modeSelection.SelectByText(ItemPerPage.ToString());
        }

        public static void ClickPreviousPageButtonInPagination(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//pagination-controls/descendant::li[@class = 'pagination-previous']")));
            driver.FindElement(By.XPath($"//pagination-controls/descendant::li[@class = 'pagination-previous']")).Click();
        }

        public static void ClickNextPageButtonInPagination(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//pagination-controls/descendant::li[@class = 'pagination-next']")));
            driver.FindElement(By.XPath($"//pagination-controls/descendant::li[@class = 'pagination-next']")).Click();
        }

        public static void GoToPageNumber(IWebDriver driver, int PageNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                if (PageNumber > 5)
                {
                    throw new Exception("Choose a number less than 5");
                }
                wait.Until(driver => driver.FindElement(By.XPath($"//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[a[span[text() = '{PageNumber}']]]")));
                driver.FindElement(By.XPath($"//ul[@class = 'ng2-pagination' and @role = 'navigation']/child::li[a[span[text() = '{PageNumber}']]]")).Click();
            }

            catch (Exception e)
            { Console.WriteLine(e); }
        }

        public static void SelectStatusFilter(IWebDriver driver, String Status)
        {
            SelectElement StatusDropdown = new SelectElement(driver.FindElement(By.XPath("//label[@class = 'label-display' and text() = 'Status:']/following-sibling::select[@name = 'select-input']")));
            StatusDropdown.SelectByText(Status);
        }

        // /descendant::div[@class = 'row_container']/descendant::div[@class = 'status-badge-container']



        // Shubham
        public static void ClickReferralTimeLineIcon(IWebDriver driver, int rowNumber)
        {
            ExpandMoreActions(driver, rowNumber);
            Thread.Sleep(100);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-LTClist-clr padding-top-15 more-action-icon' and @title = 'Referral Timeline' and i[@class = 'referral-timeline-icon']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-LTClist-clr padding-top-15 more-action-icon' and @title = 'Referral Timeline' and i[@class = 'referral-timeline-icon']]")).Click();
        }

        public static void ClickAssignMemberIcon(IWebDriver driver, int rowNumber)
        {
            ExpandMoreActions(driver, rowNumber);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-filterList-clr more-action-icon' and @title = 'Assign Member' and i[@class = 'fas fa-user-check']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-filterList-clr more-action-icon' and @title = 'Assign Member' and i[@class = 'fas fa-user-check']]")).Click();
        }

        public static void ClickNotesIcon(IWebDriver driver, int rowNumber)
        {
            ExpandMoreActions(driver, rowNumber);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-annotation-clr more-action-icon' and @title = 'Notes' and i[@class = 'far fa-file-alt']]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::action/descendant::button[@type = 'submit' and @class = 'btn-annotation-clr more-action-icon' and @title = 'Notes' and i[@class = 'far fa-file-alt']]")).Click();
        }

        public static void ClickPatientDetailsAction(IWebDriver driver, int RowNumber)
        {
            Thread.Sleep(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));    
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//app-custom-table-component/descendant::tr[{RowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::a[contains(@class, 'cursor-pointer')]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{RowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::a[contains(@class, 'cursor-pointer')]")).Click();
        }

        public static void ClickViewReferralDetailsAction(IWebDriver driver, int RowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{RowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::a[contains(@class, 'received-from-hospital-name')]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{RowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::a[contains(@class, 'received-from-hospital-name')]")).Click();
        }

        public static void ClickStatusSelectionDropdown(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::status-labels/descendant::span[i[contains(@class, 'fa-chevron-down')]]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::status-labels/descendant::span[i[contains(@class, 'fa-chevron-down')]]")).Click();
        }

        public static void SelectStatusinStatusSelectionDropdown(IWebDriver driver, int rowNumber, String Status)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::div[@id = 'statusSelection']/descendant::div[@class = 'select-status-options' and contains(text(), '{Status}' )]")));
            driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::div[@class = 'row_container']/descendant::div[@id = 'statusSelection']/descendant::div[@class = 'select-status-options' and contains(text(), '{Status}' )]")).Click();
        }

        public static void ExandReferrerDetails(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::a[contains(@class, 'received-from-hospital-name')]")));
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath($"//app-custom-table-component/descendant::tr[{rowNumber + 1}]/descendant::a[contains(@class, 'received-from-hospital-name')]")))
            .Perform();
        }
        public static void Selectstatus1(IWebDriver driver, string[] name)
        {
            driver.FindElement(By.XPath($"//app-filter/descendant::select/descendant::option[text() = '{name[0]}']")).Click(); 
        }
        
        public static Boolean CheckStatusOfAllRows(IWebDriver driver, String Status)
        {
            Boolean AreAllStatusSame = true;
            IList<IWebElement> statusList = driver.FindElements(By.ClassName("status-badge-container"));
            foreach (WebElement status in statusList)
            {
                if (!Status.Contains(status.Text))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }
        public static Boolean CheckModeOfAllRows(IWebDriver driver, string mode)
        {
            Boolean AreAllModeSame = true;
            if (mode == "Portal")
            {
                IList<IWebElement> ModeList = driver.FindElements(By.XPath("//img[@title='Portal']"));
                foreach (WebElement Modes in ModeList)
                {      
                    if (!mode.Contains(Modes.GetAttribute("title")))
                        AreAllModeSame = false;
                }

                return AreAllModeSame;
            }
            else
            {
                IList<IWebElement> ModeList = driver.FindElements(By.XPath("//tr/td/div[1]/div[4]/descendant::span[@class='ng-star-inserted' ]"));
                foreach (WebElement Modes in ModeList)
                {
                    if (!mode.Contains(Modes.Text))
                        AreAllModeSame = false;
                }

                return AreAllModeSame;
                
            }
        }
        public static Boolean CheckNoRecordsFound(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='No Record Found']")));
            return Driver.FindElement(By.XPath("//strong[text()='No Record Found']")).Displayed;
        }


        // ************************************ Row Actions ******************************************************************/


        public static IList<IWebElement> CountAllRows(IWebDriver Driver)
        {
            IList<IWebElement> rows = Driver.FindElements(By.ClassName("row_container"));
            return rows;

        }

        public List<string> GetRowsData(IWebDriver Driver)
        {
            List<string> allRowsData = new List<string>();
            foreach (var data in CountAllRows(Driver))
            {
                allRowsData.Add(data.Text);
            }
            return allRowsData;
        }

        public static Boolean ValidatePatientStatusGotUpdated(IWebDriver Driver, String PatientName)
        {
         
            IncomingPOM.EnterPatientNameInSearchField(Driver, PatientName);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//app-custom-table-component/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][2]/descendant::div[@class = 'status-badge-container']")));
            var status = Driver.FindElement(By.XPath("//app-custom-table-component/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][2]/descendant::div[@class = 'status-badge-container']")).Text.ToLower();
            String OurStatusSet = "referral received|in review|confirmed|Rejected".ToLower().Trim();
            return ((OurStatusSet.Contains(status)) ? true : false);
            
        }

        public static void ClickReferralResponseIconInDestination(IWebDriver Driver, String ProviderType, String ReferralType1, String ServicesNeeded, String SpecialPrograms, string ? notes = null)
        {
            
            
        }

        public static Boolean ValidatePatientNameInDestination(IWebDriver Driver, String PatientName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//app-custom-table-component/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][2]/descendant::div[@class='row_detail']/descendant::a[@class='cursor-pointer']")));
            String patientNameValidation = Driver.FindElement(By.XPath("//app-custom-table-component/descendant::td[not(ancestor::table[@id ='ReferralsInnerTable'])][2]/descendant::div[@class='row_detail']/descendant::a[@class='cursor-pointer']")).Text;

            String[] nameAttributes = PatientName.Split(' ');
            Boolean correct = true;
            foreach (String attr in nameAttributes)
            {
                if (!patientNameValidation.Contains(attr))
                    correct = false;
            }

            return correct;
        }

        public static Boolean ViewPatientDataValidation(IWebDriver Driver, String[] Attributes)
        {
            //ViewPatientPOM.WaitForProviderSectionToBeClickable(Driver);
            //String patientNameValidation = Driver.FindElement(By.XPath("descendant::div[@id='INSInfo']")).Text;

            String[] allNameAttributes = { "INSInfo", "AIInfo", "DIGInfo", "EMGInfo", "IMNInfo", "MDInfo", "MedInfo", "PNInfo"};
            //IList<String> existingCards = new List<String>();
            String existingCardsString = "";
            String AttributesString = "";
            Boolean correct;
            foreach (String check in allNameAttributes)
            {
                try
                {
                    Driver.FindElement(By.XPath($"descendant::div[@id='{check}']"));
                    existingCardsString += check;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            foreach (String Attribute in Attributes)
            {
                switch (Attribute.ToLower())
                {
                    case "insurance":
                        AttributesString += "INSInfo";
                        break;

                    case "care coordination":
                        AttributesString += "CRTInfo";
                        break;

                    case "allergy":
                        AttributesString += "AIInfo";
                        break;

                    case "diagnosis":
                        AttributesString += "DIGInfo";
                        break;

                    case "emergencysecondarycontact":
                        AttributesString += "EMGInfo";
                        break;

                    case "immunization":
                        AttributesString += "IMNInfo";
                        break;

                    case "medical record":
                        AttributesString += "MDInfo";
                        break;

                    case "medication":
                        AttributesString += "MedInfo";
                        break;

                    case "progress note":
                        AttributesString += "PNInfo";
                        break;
                }
            }

            if(existingCardsString == AttributesString)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }

            return correct;

        }

        public static Boolean ValidateNavigationCardInDestination(IWebDriver Driver, String[] Attributes)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//side-navigation-card")));
            Boolean Check = true;


            foreach (String Attribute in Attributes)
            {
                try
                {
                    String text = Driver.FindElement(By.XPath($"//side-navigation-card/descendant::div/descendant::div[@class='nav-list-text' and text() = '{NavigationCardIds.GetNavigationListText(Attribute)}']")).Text;
                    if (NavigationCardIds.GetNavigationListText(Attribute) != text)
                    {
                        Check = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Check = false;
                }

            }

            return Check;
        }

        /********************************************** New Methods ************************************/
        public static String GetFormattedTime(int Value)
        {
            return Value > 10 ? Value.ToString() : ("0" + Value.ToString());
        }
        public static void EnterChatTextArea(IWebDriver driver, String Chat)
        {
            //IncomingPage.ClickNotesIcon(driver, 3);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(driver => driver.FindElement(By.XPath("//textarea[@id = 'scriptBox' and @name = 'commentpacf' and @placeholder = 'Please put the message here']")));
            driver.FindElement(By.XPath("//textarea[@id = 'scriptBox' and @name = 'commentpacf' and @placeholder = 'Please put the message here']"))
              .SendKeys(Chat);
        }
        public static void ClickSendChatButton(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(driver => driver.FindElement(By.XPath("//i[@class= 'fa fa-paper-plane send-paper-icon ng-star-inserted' and @title = 'Send Message']")));
            driver.FindElement(By.XPath("//i[@class= 'fa fa-paper-plane send-paper-icon ng-star-inserted' and @title = 'Send Message']"))
              .Click();
        }

        public static void ClickCloseIconInChat(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//chat/descendant::button[@class='close']")));
            Driver.FindElement(By.XPath("//chat/descendant::button[@class='close']"))
                .Click();
        }
        public static void WaitForLoadingSpinnerToDisappear(IWebDriver Driver)
        {
            Thread.Sleep(3000);
            WebDriverWait wait_Short = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(400));
            WebDriverWait wait_Long = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            try
            {
                wait_Short.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//view-patient/descendant::i[contains(@class, 'fa-spinner')]")));
                wait_Long.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//view-patient/descendant::i[contains(@class, 'fa-spinner')]")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                wait_Long.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//view-patient/descendant::i[contains(@class, 'fa-spinner')]")));
            }


        }

        public static void ClickClosePatientDetailsIcon(IWebDriver Driver)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//view-patient/descendant::button[contains(@class, 'close')]")));
            Driver.FindElement(By.XPath("//view-patient/descendant::button[contains(@class, 'close')]"))
                .Click();
        }
        public static string IncomingMessageInChatBox(IWebDriver Driver,int MessageIndex)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//mat-dialog-content/div/div[2]/div/div[1]/div[{MessageIndex+2}]/div/div/descendant::label")));
            string text = Driver.FindElement(By.XPath($"//mat-dialog-content/div/div[2]/div/div[1]/div[{MessageIndex+2}]/div/div/descendant::label")).Text;
            return text;

        }
        public static string ReferralAcceptedMessage(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//p[text()='Referral Accepted Note: request has been accepted']")));
            string text = Driver.FindElement(By.XPath("//p[text()='Referral Accepted Note: request has been accepted']")).Text;
            return text;

        }
        /**********************************************Method of Chat Function*******************************/
        //*[@id="chat-mat-dialog"]/descendant::button[]
        public static string GetReferrerNameFromIncomingList(IWebDriver Driver,int rowNumber)
        {
            string Xpath = $"//app-custom-table-component/descendant::tr[{rowNumber+1}]//descendant::a[@class='cursor-pointer font-weight-bold']"; 
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Text;


        }
       
        public static void CheckCopyText_Function(IWebDriver Driver)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='chat-message-scroll-container']/div[3]/descendant::i[@title='Copy']")));
           
            
                 Driver.FindElement(By.XPath("//*[@id='chat-message-scroll-container']/div[3]/descendant::i[@title='Copy']")).Click();
          
            
        }
        
       
       

        /********************************************** New Methods END ************************************/

        /********************************************** ReturnTheDriverObject *************************************************/


        public static IncomingPOM ReturnTheDriverObject()
        {
            return new IncomingPOM();
        }

    }

}
