using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports.Gherkin.Model;
using AngleSharp.Dom;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.IO;
using AventStack.ExtentReports;
using NUnit.Framework;
using RovicareTestProject.Utilities;
using AventStack.ExtentReports.Model;
using System.Reflection.Emit;
using AngleSharp.Text;

namespace RovicareTestProject.PageObjects
{
    public class AddOrganizationList_AdminPOM:BaseClass
    {
        public static void NavigateToOrganizationListPage(IWebDriver driver)
        {
            string Xpath = "//descendant::a[@title='Organization List']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::button[text()='Organization']")));

        }
        public static void ClickOnAddOrganization(IWebDriver driver)
        {
            string Xpath = "//descendant::button[text()='Organization']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


            //descendant::p[text()='Organization List']
        }

        public static IWebElement ClickOnHeadlineElements(IWebDriver driver, string Element)
        {
            //Contact Information,Basic Details,Location Information,Services,Features & Settings
            string Xpath = $"//li/descendant::h4[text()='{Element}']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }

        public static void EnterInputInTab(IWebDriver driver, string Element, string data)
        {
            //Name,Website,AHCCCS ID,Phone Number,Email Id,Fax Number,Street Address,City,Zipcode,Max Saved Search Allowed,
            //Max Number Of Organization Members,Max Number Of Document Uploaded,Max Size Of Document Uploaded in MB
            //Provider Summary Report Receiver EmailIds(Comma Separated),
            string Xpath = $"//descendant::label[text()='{Element}']/following-sibling::input";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            //if(data.ToLower().Contains(Element.ToLower()))
            // driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(Xpath)).Click();
            driver.FindElement(By.XPath(Xpath)).Clear();
            driver.FindElement(By.XPath(Xpath)).SendKeys(data);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.(driver.FindElement(By.XPath(Xpath))));



        }
        public static void EnableIsSystemUser(IWebDriver driver, string Element)
        {
            //Yes,No
            string Xpath = $"//descendant::label[text()='Is System User']/following-sibling::input[@id='IsSystemUser_{Element}']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static void ClickOnSelect(IWebDriver driver, string Element, string Option)
        {
            //State,Category
            string Xpath = $"//descendant::label[text()='{Element}']/following-sibling::select";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            Thread.Sleep(5000);
            SelectElement Ele = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            Ele.SelectByText(Option);






        }
        public static void ClickOnMedicareRating(IWebDriver driver, string StarNumber)
        {

            string Xpath = $"//descendant::label[contains(text(),'Medicare Rating')]/following::a[{StarNumber}]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        //*****************************************************************UseManagement_Pop_up_Methods**************************************************************************************************
        public static void ClickOnAddMemberButton_UsermanagementPOPup(IWebDriver driver)
        {

            string Xpath = $"//descendant::i[@title='Add Member']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


        }//tr[2]/descendant::button[contains(@title,'Edit Member')]
        public static IWebElement AddMultipleMemberButton_UsermanagementPOPup(IWebDriver driver)
        {

            string Xpath = $"//i[contains(@title,'Add Multiple Member')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IWebElement ClickOnActionItem_UsermanagementPOPup(IWebDriver driver,string ActionName,int Rwonumber)
        {

            string Xpath = $"//tr[{Rwonumber+1}]/descendant::button[contains(@title,'{ActionName}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }//button[@name='create']
        public static int CheckRowsCount_UsermanagementPOPup(IWebDriver driver)
        {

            string Xpath = $"//organization-user-management-dialog/descendant::tr";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElements(By.XPath(Xpath)).Count;



        }
        public static void CheckDesignationOfeachMember_UsermanagementPOPup(IWebDriver driver,string Designation)
        {

            string Xpath = $"//table[@id='CMTblid']/descendant::tr";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
           int RowCount =   driver.FindElements(By.XPath(Xpath)).Count();
            for(int i=1;i<=RowCount;i++)
            {
                Xpath = $"//table[@id='CMTblid']/descendant::tr[{i + 1}]/descendant::a[contains(.,'{Designation}')]";
                if (!driver.FindElement(By.XPath(Xpath)).Displayed)
                    Assert.That(false);



            }




        }
        public static void CheckNameOfeachMember_UsermanagementPOPup(IWebDriver driver, string NameInput)
        {

            string Xpath = $"//table[@id='CMTblid']/descendant::tr";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            int RowCount = driver.FindElements(By.XPath(Xpath)).Count();
            for (int i = 2; i <= RowCount; i++)
            {
                Xpath = $"//table[@id='CMTblid']/descendant::tr[{i}]/descendant::a[contains(.,'{NameInput}')]";
                if (!driver.FindElement(By.XPath(Xpath)).Displayed)
                    Assert.That(false);



            }




        }
        public static void CheckRoleOfAllMember_UsermanagementPOPup(IWebDriver driver, string Role)
        {

            string Xpath = $"//table[@id='CMTblid']/descendant::tr";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            int RowCount = driver.FindElements(By.XPath(Xpath)).Count();
            for (int i = 2; i <= RowCount; i++)
            {
                Xpath = $"//table[@id='CMTblid']/descendant::tr[{i}]/descendant::span[contains(.,'{Role}')]";
                if (!driver.FindElement(By.XPath(Xpath)).Displayed)
                    Assert.That(false);



            }




        }//organization-user-management-dialog/descendant::input[@placeholder='By Name']
        public static void SearchByName_UsermanagementPOPup(IWebDriver driver,string Input)
        {

            string Xpath = $"//organization-user-management-dialog/descendant::input[@placeholder='By Name']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Input);



        }
        public static void ClickOnYes_Enable_DisablePop_up(IWebDriver driver)
        {

            string Xpath = $"//button[@name='create']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static IWebElement ReadRoleOfMember_UsermanagementPOPup(IWebDriver driver, int Rwonumber)
        {

            string Xpath = $"//tr[{Rwonumber + 1}]/descendant::span[contains(text(),'Role')]/following::span[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IWebElement CheckRoleOnAssignRolePopUp_UsermanagementPOPup(IWebDriver driver, string RoleText)
        {

            string Xpath = $"//h4/following::div[contains(text(),'{RoleText}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IWebElement CheckMobileNumbers_UsermanagementPOPup(IWebDriver driver, int Rwonumber)
        {

            string Xpath = $"//tr[{Rwonumber + 1}]/descendant::div[contains(text(),'Mobile')]/following-sibling::div";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static void CloseAssignRolePopUp(IWebDriver driver)
        {

            string Xpath = $"//descendant::button[text()='CANCEL']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static void SelectOptionDropDown_AddMemberPOPup(IWebDriver driver, string ElementName, string SelectByText)
        {

            string Xpath = $"//descendant::form[contains(@id,'addManagerForm')]/descendant::label[contains(text(),'{ElementName}')]/following-sibling::select";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(5000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            SelectElement ELe = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            ELe.SelectByText(SelectByText);


        }
        public static void ClickOnSave_AddMemberPOPup(IWebDriver driver)
        {

            string Xpath = $"//descendant::form[contains(@id,'addManagerForm')]/descendant::button[text()='SAVE']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


        }
        public static void ClickOnOk_Confirmation_AddMemberPOPup(IWebDriver driver,string MessageText)
        {
            //this method will be used for edit member also
            string Xpath = $"//descendant::div[contains(text(),'{MessageText}')]/following::button[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


        }
        public static IWebElement CheckOktext_Confirmation_AddMemberPOPup(IWebDriver driver,string textMessage)
        {

            string Xpath = $"//descendant::button[text()='Ok']/preceding::div[contains(text(),'{textMessage}')][1]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));


        }

        public static void ClickOnClose_UserManagementPOPup(IWebDriver driver)
        {//organization-user-management-dialog//add-edit-member-dialog

            string Xpath = $"//descendant::organization-user-management-dialog/descendant::button[@class='close']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


        }
        public static void EnterDescription(IWebDriver driver, string Note)
        {

            string Xpath = $"//descendant::label[text()='Description']/following::textarea[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Note);



        }
        public static (IWebElement SelectProviderByCheckBox, int CountOfProvider, string SelectProviderByname) SelectProviderType(IWebDriver driver, int ProviderIndex)
        {
            //ProviderIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Provider Type']/following::input[contains(@id,'provider')]";
            string Xpath = $"{XpathCount}[{ProviderIndex}]";

            string XpathText = $"{XpathCount}[{ProviderIndex = ((ProviderIndex <= 1) ? 2 : ProviderIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            //Actions act = new Actions(driver);
            //act.MoveToElement(driver.FindElement(By.XPath(Xpath)));
            IWebElement provider = driver.FindElement(By.XPath(Xpath));
            int count = driver.FindElements(By.XPath(XpathCount)).Count();
            string providerByname = driver.FindElement(By.XPath(XpathText)).Text;



            return (provider, count, providerByname);

        }





        public static Tuple<IWebElement, int, string?> SelectInsuranceAccepted(IWebDriver driver, int? InsuranceIndex = 1)
        {
            //InsuranceIndex:1=search;2=SelectAll;3-15= type
            string xpathCount = "//descendant::label[text()='Insurance Accepted']/following::input[contains(@id,'insurance')]";
            string Xpath = $"{xpathCount}[{InsuranceIndex}]";
            string XTextPath = $"{xpathCount}[{InsuranceIndex = ((InsuranceIndex <= 1) ? 2 : InsuranceIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(xpathCount)).Count, driver.FindElement(By.XPath(XTextPath)).Text);



        }
        public static Tuple<IWebElement, int, string?> SelectServiceOffered(IWebDriver driver, int ServiceIndex)
        {
            //ServiceIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Service Offered']/following::input[contains(@id,'serviceOffered') or contains(@id,'requirement')]";
            string Xpath = $"{XpathCount}[{ServiceIndex}]";
            string Xtext = $"{XpathCount}[{ServiceIndex = ((ServiceIndex <= 1) ? 2 : ServiceIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count(), driver.FindElement(By.XPath(Xtext)).Text);



        }
        public static Tuple<IWebElement, int, string> SelectServiceSetting(IWebDriver driver, int ServiceIndex)
        {
            //ServiceIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Service Setting']/following::input[contains(@id,'service')]";
            string Xpath = $"{XpathCount}[{ServiceIndex}]";
            string Xtext = $"{XpathCount}[{ServiceIndex = ((ServiceIndex <= 1) ? 2 : ServiceIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count, driver.FindElement(By.XPath(Xtext)).Text);



        }
        public static Tuple<IWebElement, int, string> SelectSpecialProgram(IWebDriver driver, int ProgramIndex)
        {
            //ProgramIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Special Program Accepted']/following::input[contains(@id,'specialProgram')]";
            string Xpath = $"{XpathCount}[{ProgramIndex}]";
            string Xtext = $"{XpathCount}[{ProgramIndex = ((ProgramIndex <= 1) ? 2 : ProgramIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count, driver.FindElement(By.XPath(Xtext)).Text);



        }
        public static Tuple<IWebElement, int, string> SelectAgeGroupAccepted(IWebDriver driver, int AgeGroupIndex)
        {
            //AgeGroupIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Age Group Accepted']/following::input[contains(@id,'ageGroup')]";
            string Xpath = $"{XpathCount}[{AgeGroupIndex}]";
            string Xtext = $"{XpathCount}[{AgeGroupIndex = ((AgeGroupIndex <= 1) ? 2 : AgeGroupIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count, driver.FindElement(By.XPath(Xtext)).Text);



        }
        public static Tuple<IWebElement, int, string> SelectGenderAccepted(IWebDriver driver, int GenderIndex)
        {
            //GenderIndex:1=search;2=SelectAll;3-15= type
            string XpathCount = "//descendant::label[text()='Gender Accepted']/following::input[contains(@id,'genderGroup')]";
            string Xpath = $"{XpathCount}[{GenderIndex}]";
            string Xtext = $"{XpathCount}[{GenderIndex = ((GenderIndex <= 1) ? 2 : GenderIndex)}]/following-sibling::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count, driver.FindElement(By.XPath(Xtext)).Text);



        }
        public static Tuple<IWebElement, int> SelectPatientUniqueIdentifier(IWebDriver driver, string ElementName)
        {

            string Xpath = $"//descendant::label[text()='Patient Unique Identifier']/following::span[contains(text(),'{ElementName}')]/preceding-sibling::input";
            string XpathCount = "//descendant::label[text()='Patient Unique Identifier']/following::input[contains(@id,'patientidentifer')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), driver.FindElements(By.XPath(XpathCount)).Count);



        }
        public static IWebElement SelectSendReferralFeatureSettings(IWebDriver driver, int IndesxOfParrentFeature, int IndexOfSubFeature)
        {
            //FeatureIndex:0-48
            string XpathParrentFeature = $"//descendant::label[contains(text(),'Send Referral')][1]/preceding-sibling::input[@id='feature0']";
            string Xpath = $"//descendant::label[contains(text(),'Send Referral')][1]/following::input[@id='feature{IndesxOfParrentFeature}{IndexOfSubFeature}']";
            string Xpath_text = $"{Xpath}/following-sibling::label";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IWebElement SelectFeatureSettings(IWebDriver driver, string Feature, string? ParrentFeature = "")
        {
            //FeatureIndex:0-48
            string Xpath;
            if (ParrentFeature.ToLower().Contains("receive referral"))
            {
                Xpath = $"//descendant::label[contains(text(),'Receive Referral')]/following::label[contains(text(),'{Feature}')][1]/preceding-sibling::input[1]";
            }
            else
            {

                Xpath = $"//descendant::label[contains(text(),'{Feature}')][1]/preceding-sibling::input[1]";
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static void ClickOnSubmitButton(IWebDriver driver)
        {

            string Xpath = $"//descendant::button[@name='create']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath))).Click();




        }
        public static void SelectFromOption(IWebDriver driver, string Element, string SelectByText)
        {
            //Login Mode,EMR Type
            string Xpath = $"//descendant::label[contains(text(),'{Element}')]/following-sibling::select";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(5000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

            SelectElement mode = new SelectElement(driver.FindElement(By.XPath(Xpath)));

            mode.SelectByText(SelectByText);



        }
        public static IWebElement CheckProviderSettings(IWebDriver driver, string Settings)
        {

            string Xpath = $"//descendant::label[contains(text(),'{Settings}')]/following-sibling::input";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static IList<IWebElement> ReadOrganizationRoles(IWebDriver driver)
        {

            string Xpath = $"//descendant::label[text()='Organization Roles']/following::span[contains(@class,'role-list-name')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> Roles = driver.FindElements(By.XPath(Xpath));


            return Roles;




        }
        public static void SearchOrganizationByName(IWebDriver driver, string OrgName)
        {

            string Xpath = $"//input[contains(@placeholder,'By Name')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(OrgName);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//button[contains(text(),'Go')]")));
            driver.FindElement(By.XPath("//button[contains(text(),'Go')]")).Click();



        }
        public static IWebElement ClickOnIAccept_OrganizationHomePage(IWebDriver driver)
        {

            string Xpath = $"//descendant::button[contains(text(),'I Accept')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));


        }
        public static string GetOrganizationNameFromList(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")));
            string Organization = Driver.FindElement(By.XPath("//tr[2]/td[1]//div[contains(text(),'Patient') or contains(text(),'Name')]/following::a[text()][1]")).Text;

            return Organization;
        }
        //******************************************************************ViewOrganization*******************************************************************************************

        public static Boolean CheckMedicareRating_ViewOrganizationPopup(IWebDriver Driver, int starRequired)
        {
            string Xpath = "//descendant::mat-dialog-content/descendant::h4[contains(text(),'Medicare')]/following::a[contains(@class,'deactivateRate')]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            int Star = 5 - Driver.FindElements(By.XPath(Xpath)).Count;

            return starRequired == Star;
        }
        public static Boolean CheckDescription_ViewOrganizationPopup(IWebDriver Driver, string Teext)
        {
            string Xpath = $"//descendant::mat-dialog-content/descendant::h4[contains(text(),'Description')]/following::p[contains(text(),'{Teext}')][1]";

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;


        }
        public static Boolean CheckNumber_ViewOrganizationPopup(IWebDriver Driver, string Element, string Number)
        {//Element=Contact Number|Fax
         //Number=Contact Number|Fax

            string Xpath = $"//descendant::mat-dialog-content/descendant::b[contains(text(),'{Element}')]/following::div[contains(text(),'{Number}')][1]";

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;


        }
        public static Boolean CheckAddressLine_ViewOrganizationPopup(IWebDriver Driver, string Line)
        {


            string Xpath = $"//descendant::mat-dialog-content/descendant::b[contains(text(),'Address')]/following::span[contains(text(),'{Line}')][1]";


            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;


        }
        public static Boolean CheckProviderType_ViewOrganizationPopup(IWebDriver Driver, string Provider)
        {

            string Xpath = $"//descendant::mat-dialog-content/descendant::b[contains(text(),'Provider Type')]/following::li[contains(text(),'{Provider}')][1]";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;


        }
        public static Boolean CheckServices_ViewOrganizationPopup(IWebDriver Driver, string Element, string Facts)
        {   //Element= Services Provided| Service setting| Insurance| Age Group| Special Program|Gender Type
            //Facts=Service|insurance|Age|program|Gender

            string Xpath = $"//descendant::mat-dialog-content/descendant::h4[contains(text(),'{Element}')]/following::li[contains(text(),'{Facts}')][1]";

            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Displayed;


        }//*[contains(@id,'mat-dialog-title')]/descendant::button/div
        public static void ClickClose_ViewOrganizationPopup(IWebDriver Driver)
        {

            string Xpath = $"//*[contains(@id,'mat-dialog-title')]/descendant::button/div";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();


        }

        //*************************************************************OrganizationListPage*****************************************************************
        public static void ClickOnDestinationSetting_OrganizationList(IWebDriver Driver)
        {

            string Xpath = $"//descendant::tr[2]/descendant::button[@title='Destination Setting']";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));


            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();


        }//descendant::div[contains(text(),'Skilled Nursing(SNF)')]/following::mat-slide-toggle[1]
        public static void SearchServiceOnDestinationSettingPopUp_OrganizationList(IWebDriver Driver,string ServiceType,string Service)
        {

            string Xpath = $"//label[text()='{ServiceType}']/following::input[1]";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));


            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Clear();
            Driver.FindElement(By.XPath(Xpath)).SendKeys(Service);


        }
        public static void EnableDestinationService_OnDestinationSettingPOPUp(IWebDriver Driver ,string ElementName, string Service)
        {

            string Xpath = $"//descendant::label[text()='{ElementName}']/following::div[contains(text(),'{Service}')][1]/following::input[1]";

            string XpathToggle = $"//descendant::label[text()='{ElementName}']/following::div[contains(text(),'{Service}')][1]/following::mat-slide-toggle[1]//child::div[contains(@class,'no-side-margin')]";


            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Xpath)));
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(By.XPath(XpathToggle))).Click().Build().Perform();
            //Driver.FindElement(By.XPath(XpathToggle)).Click();
            try
            {

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath(Xpath)));
            }
            catch 
            {
                action.MoveToElement(Driver.FindElement(By.XPath(XpathToggle))).Click().Build().Perform();
               // Driver.FindElement(By.XPath(XpathToggle)).Click();
            }
            



        }
        public static void ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(IWebDriver Driver,string ElementName)
        {

            string Xpath = $"//descendant::app-organization-destination-setting-dialog/descendant::label[contains(text(),'{ElementName}')]/following-sibling::button['Save']";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();




        }
        public static void ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(IWebDriver Driver,string ElementName)
        {

            string Xpath = $"//descendant::app-organization-destination-setting-dialog/descendant::label[contains(text(),'{ElementName}')]/following::span[1]";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            if (!Driver.FindElement(By.XPath(Xpath)).GetAttribute("Style").Contains("180"))
                Driver.FindElement(By.XPath(Xpath)).Click();




        }//descendant::app-organization-destination-setting-dialog/descendant::button['Close'][1]
        public static void ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(IWebDriver Driver,string Enable_Disable)
        {
            string Xpath;
            if(Enable_Disable == "Enabled")
            {

            Xpath = "//descendant::app-organization-destination-setting-change-confirmation-dialog/descendant::mat-radio-button[1]";
            }
            else
            {
                Xpath = "//descendant::app-organization-destination-setting-change-confirmation-dialog/descendant::mat-radio-button[1]";
            }

            string XpathOk = " //descendant::app-organization-destination-setting-change-confirmation-dialog/descendant::button[text()='OK']";



            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Actions act = new Actions(Driver);
           
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Thread.Sleep(1000);
            act.MoveToElement(Driver.FindElement(By.XPath($"{Xpath}//div/child::div[2]"))).Click().Build().Perform();
            
            //Driver.FindElement(By.XPath(Xpath)).Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath($"{Xpath}/label/child::input")));
            act.MoveToElement(Driver.FindElement(By.XPath(XpathOk))).Click().Build().Perform();
            //Driver.FindElement(By.XPath(XpathOk)).Click();




        }
        public static void Close_DestinationSettingPOpUp(IWebDriver Driver)
        {

            string Xpath = $"//descendant::app-organization-destination-setting-dialog/descendant::button['Close'][1]";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

           
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();




        }  

//*********************************************************TestMethods of AddOrganizationTest***************************************************************************************
       
        
        
        
        public static void ValidateChatFeatureAtNewOrganization(IWebDriver driver,int Count,string ChatDisablePlaceholderText)
        {
            try
            {
                
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Chat feature reflects in new organization");

                try
                {
                    OutgoingPOM.NavigateToOutgoingPage(driver);
                    CommonPOM.WaitForTableToGetLoaded(driver);
                    Test.Value.Log(Status.Pass, "Navigated to Outgoing page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    CommonMethodPOM.ClickOnChatBox(driver);
                    Test.Value.Log(Status.Pass, "Clicked on ChatBox");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    try
                    {
                        Assert.That(CommonMethodPOM.ValidateChatFeature(driver).GetAttribute("placeholder").Contains(ChatDisablePlaceholderText));
                        //Fail
                        Test.Value.Log(Status.Fail, "Validation of Chat feature failed");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));

                    }
                    catch
                    {
                        //Pass
                        Test.Value.Log(Status.Pass, "Validated Chat feature in Outgoing page successfully ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));

                    }
                    finally
                    {
                        CommonMethodPOM.CloseChatpopUp(driver);
                        Test.Value.Log(Status.Pass, "Closed chat popup successfully ");
                    }
                }
                catch(Exception e)
                {
                    try 
                    {
                        Assert.That(CommonPOM.CheckNoRecordsFound(Driver.Value));
                        Test.Value.Log(Status.Fail, "No Records Found " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    }
                    catch
                    {
                    Test.Value.Log(Status.Fail, "Outgoing Page is not Available");
                    Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    
                    
                    }

                }
                try
                {

                    PatientListPOM.NavigateToPatientListPage(driver);
                    CommonPOM.WaitForTableToGetLoaded(driver);
                    Test.Value.Log(Status.Pass, "Navigated to patientlist page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    CommonMethodPOM.ClickOnChatBox(driver);
                    Test.Value.Log(Status.Pass, "Clicked on chat feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    try
                    {
                        Assert.That(CommonMethodPOM.ValidateChatFeature(driver).GetAttribute("placeholder").Contains(ChatDisablePlaceholderText));
                        //Fail
                        Test.Value.Log(Status.Fail, "Validation of Chat feature failed");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));

                    }
                    catch
                    {
                        //Pass
                        Test.Value.Log(Status.Pass, "Validated Chat feature in PatientList page successfully ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));

                    }
                    finally
                    {
                        CommonMethodPOM.CloseChatpopUp(driver);
                        Test.Value.Log(Status.Pass, "Closed chat popup successfully ");
                    }

                }
                catch
                {
                    try
                    {
                        Assert.That(CommonPOM.CheckNoRecordsFound(Driver.Value));
                        Test.Value.Log(Status.Fail, "No Records Found " );
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    }
                    catch 
                    {
                    
                    Test.Value.Log(Status.Fail, "PatientList Page is not Available");
                    Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    
                    
                    }
                }


                try
                {

                    IncomingPOM.NavigateToIncomingPage(driver);
                    CommonPOM.WaitForTableToGetLoaded(driver);
                    Test.Value.Log(Status.Pass, "Navigate to incoming page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    CommonMethodPOM.ClickOnChatBox(driver);
                    Test.Value.Log(Status.Pass, "Clicked on chat action button ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
                    try
                    {
                        string actual = CommonMethodPOM.ValidateChatFeature(driver).GetAttribute("placeholder");

                        Assert.That(actual.Contains(ChatDisablePlaceholderText));
                        //Fail
                        Test.Value.Log(Status.Fail, "Validation of Chat feature failed");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));

                    }
                    catch(Exception e)
                    {
                        //Pass
                        Test.Value.Log(Status.Pass, "Validated Chat feature in Incoming page successfully ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));

                    }
                    finally
                    {
                        CommonMethodPOM.CloseChatpopUp(driver);
                        Test.Value.Log(Status.Pass, "Closed chat popup successfully ");
                    }

                }
                catch(Exception e)
                {
                    try
                    {
                        Assert.That(CommonPOM.CheckNoRecordsFound(Driver.Value));
                        Test.Value.Log(Status.Fail, "No Records Found " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    }
                    catch 
                    {
                    Test.Value.Log(Status.Fail, "Incoming Page is not Available "+e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
                    
                    }
                }
                Test.Value.Log(Status.Pass, "Validated Chat feature at all level successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(driver, Filename));
            }
            catch(Exception e) 
            {
                Test.Value.Log(Status.Fail, "Validated Chat feature in Incoming page successfully "+e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(driver, Filename));
            }



            
        }
        public static void ValidateNoteFeatureAtOrganization(IWebDriver Driver, int Count)
        {
            Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Notes feature reflects in new organization");
            try
            {
                try
                {
                    OutgoingPOM.NavigateToOutgoingPage(Driver);
                    CommonPOM.WaitForTableToGetLoaded(Driver);
                    Test.Value.Log(Status.Pass, "Navigated to outgoing page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    OutgoingPOM.ClickOn_NotesAction(Driver);
                    Test.Value.Log(Status.Pass, "Clicked on Notes action button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    try
                    {
                        Assert.That(CommonMethodPOM.CheckNotesSectionDisplay_NotesPopUp(Driver));
                        Test.Value.Log(Status.Pass, "Validated Notes feature at Outgoing page");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                        //pass

                    }
                    catch(Exception e)
                    {
                        //Fail
                        Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at outgoing page  " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));

                    }
                    finally
                    {
                        CommonMethodPOM.CloseNotepopUp(Driver);
                        Test.Value.Log(Status.Pass, "Closed Notes pop-up");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    }
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at outgoing page  " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));
                }
                try
                {

                    PatientListPOM.NavigateToPatientListPage(Driver);
                    CommonPOM.WaitForTableToGetLoaded(Driver);
                    Test.Value.Log(Status.Pass, "Navigated to PatientList Page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    PatientListPOM.OpenMoreActions(Driver, 1);
                    Test.Value.Log(Status.Pass, "Expanded more action");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    PatientListPOM.MoreAction_DropDown(Driver, 1, "Notes").Click();
                    Test.Value.Log(Status.Pass, "Clicked on Notes feature ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));

                    try
                    {
                        Assert.That(CommonMethodPOM.CheckNotesSectionDisplay_NotesPopUp(Driver));
                        //Pass
                        Test.Value.Log(Status.Pass, "Validated Note feature at patientlist page successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    }
                    catch(Exception e)
                    {
                        //Fail
                        Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at patientlist page  " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));

                    }
                    finally
                    {
                        CommonMethodPOM.CloseNotepopUp(Driver);
                        Test.Value.Log(Status.Pass, "Closed Notes pop-up");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    }

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at patientlist page  " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));
                }


                try
                {

                    IncomingPOM.NavigateToIncomingPage(Driver);
                    CommonPOM.WaitForTableToGetLoaded(Driver);
                    Test.Value.Log(Status.Pass, "Navigated to incoming page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    IncomingPOM.ExpandMoreActions(Driver, 1);
                    Test.Value.Log(Status.Pass, "Expanded more action");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    IncomingPOM.MoreAction_DropDown(Driver, 1, "Notes").Click();
                    Test.Value.Log(Status.Pass, "Clicked on Note feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));

                    try
                    {
                        Assert.That(CommonMethodPOM.CheckNotesSectionDisplay_NotesPopUp(Driver));
                        //Pass
                        Test.Value.Log(Status.Pass, "Validate Notes feature at IncomingPage successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));

                    }
                    catch(Exception e)
                    {
                        //Fail
                        Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at incoming page  " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));
                    }
                    finally
                    {
                        CommonMethodPOM.CloseNotepopUp(Driver);
                        Test.Value.Log(Status.Pass, "Closed Notes pop-up");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
                    }

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at incoming page  " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));

                }


                Test.Value.Log(Status.Pass, "Validate Notes feature at all level successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Failed: Validation of Notes feature at all level  "+e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver, Filename));
            }





        }
        //********************************************************************CreateNewOganization_TestMethod**************************************************************************************


        public static void AddNewOrganization(IWebDriver driver,
            string  OrganizationName,
            string? ProviderType= "Skilled Nursing(SNF)|Telemedicine|Substance Use|Home Health",
            string? AHCCCSID = "89657412",
            string? Category= "ABHC",
            string? PhoneNumber = "5698321478",
            string? Street = "P.J.Road",
            string? City = "Chandlia",
            string? Zipcode = "85224"





            )
        {


            Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization - Create new Organizarion");
            try
            {
                Thread.Sleep(5000);

                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                AddOrganizationList_AdminPOM.NavigateToOrganizationListPage(Driver.Value);
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                AddOrganizationList_AdminPOM.ClickOnAddOrganization(Driver.Value);
                Test.Value.Log(Status.Pass, "Test_AddOrganization- Click on add-organization button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);

                Assert.That(AddOrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Basic Details").Displayed);

                Test.Value.Log(Status.Pass, "Test_AddOrganization- Navigated to add organization page successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                //Test_AddOrganization - To verify that the Basic details section element working properly 
                try
                {



                    //OrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Basic Details").Click();





                    try
                    {
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Name", OrganizationName);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The name field accepts text input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The name field is not accepting text input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "AHCCCS ID", AHCCCSID);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The AHCCCS ID field accepts text input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The name field is not accepting text input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    try
                    {

                        AddOrganizationList_AdminPOM.SelectFromOption(Driver.Value, "Subscription Plan", "Basic");
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Select The Subscription plan");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization-Unable toSelect The Subscription plan Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Phone Number", PhoneNumber);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Phone number section accepts phone number type data");

                    }
                    catch (Exception e)
                    {

                        Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide phone number type data Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    try
                    {

                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Street Address", Street);
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "City", City);
                        Thread.Sleep(1000);
                        AddOrganizationList_AdminPOM.ClickOnSelect(Driver.Value, "State", "Arizona");

                        AddOrganizationList_AdminPOM.ClickOnSelect(Driver.Value, "Category", Category);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Street Address,City,State and Category tabs applied input");
                    }
                    catch (Exception e)
                    {

                        Test.Value.Log(Status.Fail, "Test_AddOrganization- Location information section not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                    }
                    try
                    {

                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Zipcode", Zipcode);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Zipcode section accepts phone number type data");


                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide Zipcode type data Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }


                    //Select Provider type

                    try
                    {
                        foreach (string provider in ProviderType.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();
                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.SendKeys(provider);
                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByname.ToLower().Contains(provider.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{provider}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {provider}  Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, index.ToInteger(3)).SelectProviderByCheckBox.Click();
                        }


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();

                    }


                    //Click on submit button
                    try
                    {

                        AddOrganizationList_AdminPOM.ClickOnSubmitButton(Driver.Value);
                        Test.Value.Log(Status.Pass, "Click on submit button");
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        Assert.That(Success_Notification(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Success notification displaying by clicking submit button");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Unable to display success notification Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }










                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to create new organization Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }





























            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to create new organization Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
        }
    }
}