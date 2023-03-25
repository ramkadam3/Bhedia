using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RovicareTestProject.Utilities;

namespace RovicareTestProject.PageObjects
{
    public class CommonMethodPOM :BaseClass
    {

        //****************************************** Notes Start ******************************************************//

        public static string CheckPatientName_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='popup-title']")));


            IWebElement title = Driver.FindElement(By.XPath("//div[@class='popup-title']"));
            string text = title.Text;
            Console.WriteLine(text);
            return text;
        }
        public static Boolean CheckAddIconDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-notes-dialog/mat-dialog-content/div/div/div/div/div/div/div[3]/i[@title='add notes']")));


            Boolean result = Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-notes-dialog/mat-dialog-content/div/div/div/div/div/div/div[3]/i[@title='add notes']")).Displayed;
            return result;
        }

        public static Boolean CheckTextFeildDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='scriptBox']")));


            Boolean result = Driver.FindElement(By.XPath("//*[@id='scriptBox']")).Displayed;
            return result;
        }
        public static Boolean CheckNotesSectionDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='scrollnote']")));


            Boolean result = Driver.FindElement(By.XPath("//*[@id='scrollnote']")).Displayed;
            return result;
        }
        public static string CheckTextFeild_Placeholder_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='scriptBox']")));


            string text = Driver.FindElement(By.XPath("//*[@id='scriptBox']")).GetAttribute("placeholder");
            return text;
        }
        public static string Entertext_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='scriptBox']")));

            string text = "Hi";
            //Driver.FindElement(By.XPath("(//input[@placeholder='Enter Message'])")).SendKeys(text);
            Driver.FindElement(By.XPath("//*[@id='scriptBox']")).SendKeys(text);
            return text;
            Thread.Sleep(2000);
        }
        public static void ClickAddNotesIcon_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-notes-dialog/mat-dialog-content/div/div/div/div/div/div/div[3]/i[@title='add notes']")));


            Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-notes-dialog/mat-dialog-content/div/div/div/div/div/div/div[3]/i[@title='add notes']")).Click();

        }

        public static string NotesSaveSuccessfully_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//p[@class='text-annotation']")));
            string text = Driver.FindElement(By.XPath("//p[@class='text-annotation']")).Text;
            Console.WriteLine(text);
            return text;
        }

        public static Boolean CheckDayDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[@class='sticky-date-bg ng-star-inserted']")));


            Boolean result = Driver.FindElement(By.XPath("//span[@class='sticky-date-bg ng-star-inserted']")).Displayed;
            return result;
        }
        public static Boolean CheckTimeeDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[@class='time-annotation']")));


            Boolean result = Driver.FindElement(By.XPath("//span[@class='time-annotation']")).Displayed;
            return result;
        }


        public static Boolean CheckDateTimeDisplay_NotesPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(" //*[@class='date-time col-md-10 padding-input date-size']")));


            Boolean result = Driver.FindElement(By.XPath(" //*[@class='date-time col-md-10 padding-input date-size']")).Displayed;
            return result;
        }
        public static void ClickDeleteIcon_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='fa fa-trash remove-chat ng-star-inserted']")));
            driver.FindElement(By.XPath("//i[@class='fa fa-trash remove-chat ng-star-inserted']")).Click();
        }
        public static Boolean CheckDeletePopUpDisplay_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='fa fa-trash remove-chat ng-star-inserted']")));
            Boolean delete = driver.FindElement(By.XPath("//i[@class='fa fa-trash remove-chat ng-star-inserted']")).Displayed;
            return delete;
        }

        public static Boolean DisplayCancelButton_DeletePopUp_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='ajs-button ajs-cancel']")));
            Boolean cancel = driver.FindElement(By.XPath("//button[@class='ajs-button ajs-cancel']")).Displayed;
            return cancel;
        }

        public static Boolean DisplayOkButton_DeletePopUp_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='ajs-button ajs-ok']")));
            Boolean Ok = driver.FindElement(By.XPath("//button[@class='ajs-button ajs-ok']")).Displayed;
            return Ok;
        }
        public static void ClickOkButton_DeletePopUp_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='ajs-button ajs-ok']")));
            driver.FindElement(By.XPath("//button[@class='ajs-button ajs-ok']")).Click();

        }
        public static Boolean DisplayCopyIcon_NotesPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='fas fa-copy copy-annotation ng-star-inserted']")));
            Boolean copy = driver.FindElement(By.XPath("//i[@class='fas fa-copy copy-annotation ng-star-inserted']")).Displayed;
            return copy;
        }
        public static void ClickCopyIcon_NotesPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='fas fa-copy copy-annotation ng-star-inserted']")));
            driver.FindElement(By.XPath("//i[@class='fas fa-copy copy-annotation ng-star-inserted']")).Click();
            Thread.Sleep(5000);
        }
        public static void CloseNotepopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/descendant::mat-dialog-container/descendant::button[@class='close']")));
            Driver.FindElement(By.XPath("/descendant::mat-dialog-container/descendant::button[@class='close']")).Click();

            Thread.Sleep(2000);

        }
        //****************************************** Notes End ******************************************************//
        //****************************************** Medical Record Start ******************************************************//

        public static string CheckPatientName_MedicalRecordsPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='popup-title ng-star-inserted']")));

            IWebElement title = Driver.FindElement(By.XPath("//div[@class='popup-title ng-star-inserted']"));
            string text = title.Text;
            Console.WriteLine(text);
            return text;
        }
        public static Boolean AddFileDisplay_MedicalRecordsPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-container[@id='popup-medical-record']/descendant::a[1]")));
            Boolean copy = driver.FindElement(By.XPath("//descendant::mat-dialog-container[@id='popup-medical-record']/descendant::a[1]")).Displayed;
            return copy;
        }
        public static Boolean SaveButtonDisplay_MedicalRecordsPopUp(IWebDriver driver)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[3]")));
            Boolean copy = driver.FindElement(By.XPath("(//a[@class='btn button-search-grid action-medical ng-star-inserted'])[3]")).Displayed;
            return copy;
        }

        public static void ClickOn_AddFileButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//descendant::mat-dialog-container[@id='popup-medical-record']/descendant::a[1]")));
            driver.FindElement(By.XPath($"//descendant::mat-dialog-container[@id='popup-medical-record']/descendant::a[1]")).Click();
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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[1]/div/div/div/div/div[1]/div/input")));
            driver.FindElement(By.XPath($"//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[1]/div/div/div/div/div[1]/div/input")).Click();
            driver.FindElement(By.XPath($"//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[1]/div/div/div/div/div[1]/div/input")).SendKeys(FileName);
        }

        public static void ClearName_SearchField_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[1]/div/div/div/div/div[1]/div/input")));
            driver.FindElement(By.XPath($"//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[1]/div/div/div/div/div[1]/div/input")).Clear();
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

        public static void ClickOnEditButton_ActionColumn_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table//tbody/tr[2]/descendant::td/div[1]/div[5]/descendant::a[1]/button/i")));
            driver.FindElement(By.XPath("//html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table//tbody/tr[2]/descendant::td/div[1]/div[5]/descendant::a[1]/button/i")).Click();
        }
        public static void ClickOnEditButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[3]/div[2]/div/mat-dialog-container/descendant::app-medical-record/mat-dialog-content/div/div[2]//a[2]")));
            driver.FindElement(By.XPath("//html/body/div[3]/div[2]/div/mat-dialog-container/descendant::app-medical-record/mat-dialog-content/div/div[2]//a[2]")).Click();
        }
        public static Boolean ClickOnCategoryInnerTable_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[1]/div[2]/div[2]/select")));
            return driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[1]/div[2]/div[2]/select")).Enabled;
        }
        public static Boolean ClickOnAccessboxInnerTable_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[1]/div[4]/div[2]/div/select")));
            return driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[1]/div[4]/div[2]/div/select")).Enabled;
        }
        public static void ClickOnDiscriptionFeildInnerTable_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[2]/div/div[2]/div/input")));
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/app-medical-record/mat-dialog-content/div/div[3]/table/tbody/tr/td/div[2]/div/div[2]/div/input")).SendKeys("Documents");
        }
        public static void ClickOnSaveButton_MedicalRecordPopUp(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[3]/div[2]/div//mat-dialog-content//div[2]//a[1]")));
            driver.FindElement(By.XPath("//html/body/div[3]/div[2]/div//mat-dialog-content//div[2]//a[1]")).Click();
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
        //****************************************** Medical Record End ******************************************************//
        //****************************************** Chat Start ******************************************************//


        public static void ClickOnChatBox(IWebDriver Driver,int? RowNumber=1)
        {
            string Xpath = $"//tr[{RowNumber+1}]/descendant::action//button/descendant::i[contains(@class,'fa fa-comments chat-icon')]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();

        }
        public static IWebElement ValidateChatFeature(IWebDriver Driver)
        {
            string Xpath = $"//textarea";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(3));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath));

        }
        public static string CheckTitleOfChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::mat-dialog-container/descendant::div[contains(@class, 'popup-title')]")));


            IWebElement title = Driver.FindElement(By.XPath("//descendant::mat-dialog-container/descendant::div[contains(@class, 'popup-title')]"));
            string text = title.Text;
            text = text.ToLower();
            return text;
        }
        public static string CheckTitleReferrerNameOnPopUp(IWebDriver Driver, string Pagename)
        {

            if (Pagename == "IncomingPage")
            {
                WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"/descendant::mat-dialog-content/descendant::div[contains(@class,'chat-heading-label')][1]")));


                return Driver.FindElement(By.XPath($"/descendant::mat-dialog-content/descendant::div[contains(@class,'chat-heading-label')][1]")).Text;
            }
            else
            {
                WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"/descendant::mat-dialog-content/descendant::div[contains(@class,'chat-heading-label')][2]")));


                return Driver.FindElement(By.XPath($"/descendant::mat-dialog-content/descendant::div[contains(@class,'chat-heading-label')][2]")).Text;
            }


        }
        public static Boolean Providerlist_ChatPopup(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(text(),'Providers')]")));


            Boolean result = Driver.FindElement(By.XPath("//div[contains(text(),'Providers')]")).Displayed;
            return result;
        }
        public static Boolean Chatbox_ChatpopUp_OutgoingPage(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class,'chat-message-container ')]")));


            Boolean result = Driver.FindElement(By.XPath("//div[contains(@class,'chat-message-container ')]")).Displayed;
            return result;
        }
        public static Boolean ProviderName_ChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-content/div/div[2]/div[1]/div/div[1]/div/a/span")));


            Boolean result1 = Driver.FindElement(By.XPath("//descendant::mat-dialog-content/descendant::div[contains(text(),'Providers')]/following::span[1]")).Enabled;
            Boolean result2 = Driver.FindElement(By.XPath("//descendant::mat-dialog-content/descendant::div[contains(text(),'Providers')]/following::span[2]")).Enabled;
            Boolean result = result1 && result2;
            return result;
        }
        public static string CheckDayOfCommunication_ChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[text()='Today']")));

            string Day = Driver.FindElement(By.XPath("//span[text()='Today']")).Text;

            return Day;
        }
        public static string PlaceholderInTextBox_ChatpopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-content/descendant::input[contains(@placeholder,'Enter Message')]")));


            string text = Driver.FindElement(By.XPath("//mat-dialog-content/descendant::input[contains(@placeholder,'Enter Message')]")).GetAttribute("placeholder");
            return text;
        }
        public static void SendButton_ChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("(//i[@title='Send Message'])")));

            Driver.FindElement(By.XPath("(//i[@title='Send Message'])")).Click();

        }
        public static void ClickOnproviderNameFirst_tosendMessage(IWebDriver Driver, string ProviderName)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//mat-dialog-content//a/descendant::span[contains(text(),'{ProviderName}')]")));
            Driver.FindElement(By.XPath($"//mat-dialog-content//a/descendant::span[contains(text(),'{ProviderName}')]")).Click();

        }
        public static string EntertextIntextBox_ChatpopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='chat-mat-dialog']/div/div[2]/div/div[2]/div/input")));

            string text = "Hi";

            Driver.FindElement(By.XPath("//*[@id='chat-mat-dialog']/div/div[2]/div/div[2]/div/input")).SendKeys(text);
            return text;
            Thread.Sleep(2000);
        }

        public static string SenderNameShowWithMessage_ChatPopUp(IWebDriver Driver, int MessageIndex)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//mat-dialog-container/descendant::label[@class='chat-member-name'][{MessageIndex}]")));
            return Driver.FindElement(By.XPath($"//mat-dialog-container/descendant::label[@class='chat-member-name'][{MessageIndex}]")).Text;

        }

        public static IWebElement CheckCopyAll_PrintButton_ChatPopUp(IWebDriver Driver, string ButtonName)
        {

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//*[@id='chat-mat-dialog']/descendant::button[1]")));
            if (ButtonName == "CopyAll")
            {
                return Driver.FindElement(By.XPath($"//*[@id='chat-mat-dialog']/descendant::button[1]"));
            }
            else
            { return Driver.FindElement(By.XPath($"//*[@id='chat-mat-dialog']/descendant::button[2]")); }

        }
        public static void ClickcopyTextfunction_ChatpopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='chat-message-scroll-container']/div[3]/descendant::i[contains(@title,'Copy')] ")));
            Driver.FindElement(By.XPath("//*[@id='chat-message-scroll-container']/div[3]/descendant::i[contains(@title,'Copy')] ")).Click();


        }
        public static Boolean CheckCopyAllSuccessfulMessage_ChatPopup(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='MainWrapper']/descendant::notifier-notification/descendant::p[text()='All Text Copied.']")));
            Boolean b = Driver.FindElement(By.XPath("//*[@id='MainWrapper']/descendant::notifier-notification/descendant::p[text()='All Text Copied.']")).Displayed;
            return b;

        }
        public static Boolean CheckCopyTextSuccessfulMessage_ChatPopup(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='MainWrapper']//descendant::p[text()='Text Copied.']")));
            Boolean b = Driver.FindElement(By.XPath("//*[@id='MainWrapper']//descendant::p[text()='Text Copied.']")).Displayed;
            return b;

        }

        public static void CloseChatpopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/descendant::mat-dialog-container/descendant::button[@class='close']")));
            Driver.FindElement(By.XPath("/descendant::mat-dialog-container/descendant::button[@class='close']")).Click();

            Thread.Sleep(2000);

        }

        public static string IncomingMessage_OutgoingChatBox_ChatPopUp(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='scrollcomment']/div/div[30]/div/div/ul/li/div/p")));
            string text = Driver.FindElement(By.XPath("//*[@id='scrollcomment']/div/div[30]/div/div/ul/li/div/p")).Text;
            return text;
        }
        //****************************************** Chat End ******************************************************//

    }
}