using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    internal class PreferredProviderPOM
    {


        public static void SelectProviderType(IWebDriver driver, String ProviderType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("addProvidercheck")));

            SelectElement ProviderSelection = new SelectElement(driver.FindElement(By.Name("addProvidercheck")));
            IList<IWebElement> AllProviderTypes = ProviderSelection.Options;

            foreach (IWebElement ProviderTypeOption in AllProviderTypes)
            {
                var temp = ProviderTypeOption.Text.ToLower().Trim();
                if (ProviderTypeOption.Text.ToLower().Trim() == ProviderType.ToLower().Trim())
                    ProviderSelection.SelectByText(ProviderType);
            }

        }
        public static void ClickSearchButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.Id("searchGrid")));
            driver.FindElement(By.Id("searchGrid")).Click();
        }


        public static void SelectProviderCheckboxes(IWebDriver driver, String[] RowNumbers)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath("//table[@id = 'ShowProvidertblblid']/descendant::td[2]/descendant::input[@type = 'checkbox']")));
            foreach (String RowNumber in RowNumbers)
            {
                driver.FindElement(By.XPath($"//table[@id = 'ShowProvidertblblid']/descendant::td[{int.Parse(RowNumber) + 1}]/descendant::input[@type = 'checkbox']"))
                .Click();
            }
        }

        public static void ClickSaveButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath("//mat-dialog-actions/descendant::button[@name = 'create']")));
            driver.FindElement(By.XPath("//mat-dialog-actions/descendant::button[@name = 'create']")).Click();
        }
        // table[@id = 'ShowProvidertblblid']/descendant::td[{RowNumber + 1}]/descendant::div[@class = 'row_detail'][3]/child::span

        public static Boolean CheckIfAllProvidersTypesAreSame(IWebDriver driver, String ProviderType)
        {
            Boolean Answer = true;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.Id("ShowProvidertblblid")));
            String TotalRowsInStringForm = driver.FindElement(By.XPath("//add-providers/descendant::select[@name = 'selectNumber']")).GetAttribute("value");
            int TotalRows = int.Parse(TotalRowsInStringForm.Split(":")[1].Trim());
            for (int Row = 1; Row <= TotalRows; Row++)
            {
                if (driver.FindElement(By.XPath($"//table[@id = 'ShowProvidertblblid']/descendant::td[{Row + 1}]/descendant::div[@class = 'row_detail'][3]/child::span")).Text
                    !=
                    ProviderType)
                    Answer = false;
            }

            return Answer;
        }
        //************************************SearchfieldPOM_PreferredProviderPage**************************************************

        public static void NavigateToPreferredProviderList_Page(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string xpath = " //app-menu/descendant::li[5]//following::i[@class='fa fa-building']";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));


            Driver.FindElement(By.XPath(xpath)).Click();
        }
        public static Boolean ChecksearchField_ProviderSelectionPage(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string xpath = "//app-filter/section";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));


            return Driver.FindElement(By.XPath(xpath)).Displayed;
        }

        public static IWebElement ClickOnProviderTypeFilter(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//app-multi-select/div/div/input[@style='text-indent: 0px;' and @name='multi-select' and (@placeholder='Provider Type' or @placeholder='Selected (1)' or @placeholder='Selected (2)' or @placeholder='Selected (3)' or @placeholder='Selected (4)')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement ClickOnLocationTypeTabFilter(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//app-multi-select/div/div/input[@style='text-indent: 0px;' and @name='multi-select' and (@placeholder='Location Type' or @placeholder='Selected (1)' or @placeholder='Selected (2)' or @placeholder='Selected (3)' or @placeholder='Selected (4)' or @placeholder='Selected (5)' or @placeholder='Selected (6)')]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            return Driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement SelectOptionforProviderType(IWebDriver Driver, int Index)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string XPath = $"//*[@id='Filterid']/descendant::div[contains(@class,'border-div')][{Index}]/descendant::label/span";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XPath)));

            return Driver.FindElement(By.XPath(XPath));
        }
        public static Boolean CheckProviderTypeOfAllRows(IWebDriver driver, String ProviderType_Required)
        {
            Boolean AreAllProviderTypesSame = true;
            IList<IWebElement> ProviderTypeList = driver.FindElements(By.XPath("//tbody/descendant::tr/following::span[3]"));
            foreach (WebElement ProviderColumnText in ProviderTypeList)
            {
                string Typetext = ProviderColumnText.Text;
                if (!Typetext.Contains(ProviderType_Required))
                    AreAllProviderTypesSame = false;
            }

            return AreAllProviderTypesSame;
        }
        public static Boolean CheckLocationTypeOfAllRows(IWebDriver driver, String LocationType_Required)
        {
            Boolean AreAllLocationTypesSame = true;
            IList<IWebElement> LocationTypeList = driver.FindElements(By.XPath("//tbody/descendant::tr/following::span[3]"));
            foreach (WebElement LocationColumnText in LocationTypeList)
            {
                if (!LocationType_Required.Contains(LocationColumnText.Text))
                    AreAllLocationTypesSame = false;
            }

            return AreAllLocationTypesSame;
        }
        public static Boolean CheckZipCodeOfAllRows(IWebDriver driver, String Zipcode)
        {
            Boolean AreAllZipcodeSame = true;
            IList<IWebElement> ZipcodeList = driver.FindElements(By.XPath("//tr/td/div[1]/div[3]/span[3]"));
            foreach (WebElement ZipcodeColumnText in ZipcodeList)
            {
                if (!ZipcodeColumnText.Text.Contains(Zipcode))
                    AreAllZipcodeSame = false;
            }

            return AreAllZipcodeSame;
        }
        public static IWebElement SelectOptionforLocationType(IWebDriver Driver, int Index)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(20));
            string XPath = $"//*[@id='Filterid']/descendant::div[contains(@class,'border-div')][{Index}]/descendant::label/span";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XPath)));

            return Driver.FindElement(By.XPath(XPath));
        }
        public static IWebElement ClickOnZipcodeTab(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//label[contains(text(),'Zipcode')]/following::input[contains(@name,'text-input')]")));


            return Driver.FindElement(By.XPath("//label[contains(text(),'Zipcode')]/following::input[contains(@name,'text-input')]"));
        }
        public static IWebElement ClickOnMileTab(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//select[@name='select-input']")));
            return Driver.FindElement(By.XPath("//select[@name='select-input']"));
        }

        public static void ClickOnMoreFilter_Clear_Search_LessFilters_Button(IWebDriver Driver, string ButtonName_text)
        {// Buttonname= More Filters/Search/Clear/Less Filters
            string Xpath = $"//app-filter/descendant::input-button/button[text()='{ButtonName_text}']";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();
        }
        //*********************************************MoreFilter_InnerTableOf_SearchField***************************************
        /// <summary>
        /// ElementName = Use 'Service Offered','Insurance','Company'
        ///  WantCount_YesORNo= Use 'Yes' if you want else No
        ///  Count is Number displayed next to ElementName in More Filter table(It is a count of Totale checkBox selected among the list)
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="ElementName"> Em,Hdjsdskj</param>
        /// <param name="WantCount_YesORNo"></param>
        /// <returns></returns>
        public static Tuple<Boolean, string> CheckServiceOffered_ORInsurance_ORCompany_Count(IWebDriver Driver, string ElementName, string WantCount_YesORNo)
        {                               //ElementName = Use 'Service Offered','Insurance','Company'
            ///WantCount_YesORNo= Use 'Yes' if you want else No
            ///Count is Number displayed next to ElementName in More Filter table(It is a count of Totale checkBox selected among the list)
            string Count = "0";
            string ElementName_Xpath = $"//search-and-select/label[contains(text(),'{ElementName}')]";
            string ElementCount_Xpath = $"//search-and-select/label[contains(text(),'{ElementName}')]/descendant::span[1]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(ElementName_Xpath)));
            Boolean Displayed = Driver.FindElement(By.XPath(ElementName_Xpath)).Displayed;
            if (WantCount_YesORNo == "Yes")
            {
                Count = Driver.FindElement(By.XPath(ElementCount_Xpath)).Text;
            }

            return Tuple.Create(Displayed, Count);
        }
        //*********************************************SearchField_END******************************************************************
        //************************************************Action_Item*******************************************************************

        public static void ClickOnButton_ActionItem(IWebDriver Driver, string ButtonName)
        {// Buttonname= Send Multiple Referral,Add Referral,Update Contract,Delete Contract
            string Xpath = $"//descendant::tr[2]/descendant::button[@title='{ButtonName}']/i";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();
        }//descendant::*[@id='PatientList']/descendant::i[contains(@class,'add-referral')][1]
        public static void ClickOnAddReferralIcon_SelectPatientPOPup(IWebDriver Driver)
        {
            string Xpath = $"//descendant::*[@id='PatientList']/descendant::i[contains(@class,'add-referral')][1]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();
        }//*[@id='patientListCard0']/descendant::label[contains(text(),'Name')]/following::span[1]
        public static string GetpatientName_SelectPatientPOPup(IWebDriver Driver,int? PatientCardNumber=1)
        {
            string Xpath = $"//*[@id='patientListCard{PatientCardNumber-1}']/descendant::label[contains(text(),'Name')]/following::span[1]";
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Driver.FindElement(By.XPath(Xpath)).Text;
        }
        //************************************************Action_Item_END*******************************************************************
    }
}
