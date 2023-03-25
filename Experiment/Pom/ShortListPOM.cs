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
using ExcelDataReader.Log;
using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.IO;
using AngleSharp.Dom;
using AventStack.ExtentReports;

namespace RovicareTestProject.PageObjects
{
    public class ShortListPOM : BaseClass
    {
        public static void WaitForShortlistTableToBeClickable(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='AddHospitalTblid']/descendant::tr[2]/td[1]")));
            Thread.Sleep(4000);
        }

        public static void ClickGoButtonInFilter(IWebDriver driver)
        {
            string Xpath = "//descendant::button[@title='Filter' and text()='GO']|//descendant::configurable-form/following::button[text()='APPLY'][1]";
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            
        }
       

        public static void SelectMilesInFilter(IWebDriver driver, int Mile)
        {
            
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("zip")));

            SelectElement MileSelection = new SelectElement(driver.FindElement(By.XPath("//div[@id='MainWrapper']//div[2]//div[1]//input-select[1]//select[1]")));
            MileSelection.SelectByText(Mile.ToString());
        }

        public static void EnterZipCodeInFilter(IWebDriver driver, String Zipcode)
        {
            string Xpath = "//descendant::a [contains(text(),'Zipcode')]/following::input[1]|//descendant::label[ contains( text(),'Zipcode')]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Clear();
            driver.FindElement(By.XPath(Xpath)).SendKeys(Zipcode);
        }

        public static void SelectOptionInSearchFacilitiesInFilter(IWebDriver driver, String SearchFacility)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::a[contains(.,'Search Facilities')]|//descendant::label[contains(.,'Search Facilities')]")));

            if (SearchFacility.ToLower() == "all")
                driver.FindElement(By.XPath("//descendant::a[contains(.,'Search Facilities')]/following::label[contains(.,'All')]/input|//descendant::label[contains(.,'Search Facilities')]/following::label[contains(.,'All')]/input")).Click();

            if (SearchFacility.ToLower() == "only preferred providers")
                driver.FindElement(By.XPath("//descendant::label[contains(.,'Search Facilities')]/following::label[contains(.,'Only Preferred Providers')]/input|//descendant::a[contains(.,'Search Facilities')]/following::label[contains(.,'Only Preferred Providers')]/input/preceding-sibling::div/div[2]")).Click();
        }

        public static void SelectOptionInFacilityTypeInFilter(IWebDriver driver, String FacilityType)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::label[contains(.,'Facility Type')]|//descendant::a[contains(.,'Facility Type')]")));

            if (FacilityType.ToLower() == "medical")
                driver.FindElement(By.XPath("//descendant::a[contains(.,'Facility Type')]/following::div[contains(.,'Medical') and contains(@class,'mat-radio')]/preceding-sibling::div/div[2]|//descendant::label[contains(.,'Facility Type')]/following::label[contains(.,'Medical')]/input[@type='radio']")).Click();

            if (FacilityType.ToLower() == "behavioral")
                driver.FindElement(By.XPath("//descendant::a[contains(.,'Facility Type')]/following::div[contains(.,'Behavioral') and contains(@class,'mat-radio')]/preceding-sibling::div/div[2]|//descendant::label[contains(.,'Facility Type')]/following::label[contains(.,'Behavioral')]/input[@type='radio']")).Click();
        }


        public static Boolean SelectProviderTypesInFilter(IWebDriver driver, String ProviderType)
        {
            string Xpath = $"//descendant::a[contains(.,'Provider Type')]/following::label[contains(.,'{ProviderType}')]/input|//descendant::label[contains(.,'Provider Type')]/following::label[contains(.,'{ProviderType}')]/input";
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)))
            .Click();
            return driver.FindElement(By.XPath(Xpath)).Selected;

        }
        public static IWebElement CheckFiltersValueAvailableInFilter(IWebDriver driver, String FilterName,string FilterValue)
        {
            string Xpath = $"//descendant::a[contains(.,'{FilterName}')]/following::label[contains(.,'{FilterValue}')]/input|//descendant::label[contains(.,'{FilterName}')]/following::label[contains(.,'{FilterValue}')]/input";
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));

        }
        public static void SelectSpecialProgramsInFilter(IWebDriver driver, String[] SpecialPrograms)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::label[contains(.,'Special Program')]|//descendant::a[contains(.,'Special Program')]")));

            foreach (String SpecialProgram in SpecialPrograms)
            {
                driver.FindElement(By.XPath($"//descendant::label[contains(.,'Special Program')]/following::label[contains(.,'{SpecialProgram}')]/child::input|//descendant::a[contains(.,'Special Program')]/following::span[contains(.,'{SpecialProgram}')]/preceding-sibling::input"))
                .Click();
            }
        }

        public static void SelectGenderInFilter(IWebDriver driver, String[] Genders)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            foreach (String Gender in Genders)
            {
                string Xpath = $"//descendant::label[contains(.,'{Gender}')]/child::input|//descendant::span[contains(.,'{Gender}')]/preceding-sibling::input";
                //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//descendant::label[contains(.,'{Gender}')]/child::input")));
                // Actions Act = new Actions(driver);
                //Act.MoveToElement(driver.FindElement(By.XPath($"//descendant::label[contains(.,'{Gender}')]/child::input"))).Click().Build().Perform();

                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();

            }
        }

        public static void SelectAgeGroupsInFilters(IWebDriver driver, String[] AgeGroups)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            foreach (String AgeGroup in AgeGroups)
            { string Xpath = $"//descendant::label[contains(.,'{AgeGroup}')]/child::input|//descendant::span[text()='{AgeGroup}']/preceding-sibling::input";
                // Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"//descendant::label[contains(.,'{AgeGroup}')]/child::input")));
                // Actions Act = new Actions(driver);
                //Act.MoveToElement( driver.FindElement(By.XPath($"//descendant::label[contains(.,'{AgeGroup}')]/child::input"))).Click().Build().Perform();
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();

            }
        }

        public static Boolean SelectServicesNeededInFilter(IWebDriver driver, String[] ServicesNeeded)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::a[contains(.,'Services Needed')]|//descendant::label[contains(.,'Services Needed')]")));

            foreach (String ServiceNeeded in ServicesNeeded)
            {
            string Xpath = $"//descendant::label[contains(.,'Services Needed')]/following::label[contains(.,'{ServiceNeeded}')]/child::input|//descendant::a[contains(.,'Services Needed')]/following::label[contains(.,'{ServiceNeeded}')]/child::input";
                if (driver.FindElement(By.XPath(Xpath)).Enabled)
                {
                    driver.FindElement(By.XPath(Xpath)).Click();
                }
            }
            Boolean CorrectlyWorking = true;
            foreach (String ServiceNeeded in ServicesNeeded)
            {
                //String temp = driver.FindElement(By.XPath($"//form[@id = 'LTCListForm']/descendant::div[@id = 'Filterid2']/descendant::label/span[text() = '{ServiceNeeded}']/preceding-sibling::input[@type = 'checkbox']")).GetAttribute("checked");
                if (!(driver.FindElement(By.XPath($"//descendant::a[contains(.,'Services Needed')]/following::label[contains(.,'{ServiceNeeded}')]/child::input|//descendant::label[contains(.,'Services Needed')]/following::label[contains(.,'{ServiceNeeded}')]/child::input"))).Selected)
                {
                    CorrectlyWorking = false;
                }
            }
            return CorrectlyWorking;
        }

        public static Boolean SelectInsuranceInFilter(IWebDriver driver, String[] Insurances)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::label[text()='Insurance']|//descendant::a[contains(.,'Insurance')]")));

            foreach (String Insurance in Insurances)
            {
                try
                {
                    string Xpath = $"//descendant::a[contains(.,'Insurance')]/following::label[contains(.,'{Insurance}')]/child::input|//descendant::label[contains(.,'Insurance')]/following::label[contains(.,'{Insurance}')]/child::input";
                    if (driver.FindElement(By.XPath(Xpath)).Enabled)
                    {
                        driver.FindElement(By.XPath(Xpath))
                        .Click();
                    }
                }
                catch { }
            }

            Boolean CorrectlyWorking = true;
            foreach (String Insurance in Insurances)
            {
                try
                {
                    if (!(driver.FindElement(By.XPath($"//descendant::a[contains(.,'Insurance')]/following::label[contains(.,'{Insurance}')]/child::input|//descendant::label[contains(.,'Insurance')]/following::label[contains(.,'{Insurance}')]/child::input")).Selected))
                    {
                        CorrectlyWorking = false;
                    }
                }
                catch { }
            }
            return CorrectlyWorking;
        }


        public static void SearchProviderByName(IWebDriver driver, String ProviderName)
        { string Xpath = "//descendant::label[contains(text(),'Sort By')]/preceding::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(ProviderName);
        }
        public static void SelectAllProvider(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-all")));
            driver.FindElement(By.Id("select-all")).Click();
            Thread.Sleep(1000);
        }

        public static Boolean CheckProviderNameOfAllRows(IWebDriver driver, String SearchByProviderName)
        {
            Thread.Sleep(5000);
            Boolean AreAllProviderNameSame = true;
            int totalRows = driver.FindElements(By.CssSelector("table#AddHospitalTblid tr")).Count;//table[@id = 'AddHospitalTblid']/descendant::td[10]/descendant::div[@class = 'row_detail'][1]
            for (int i = 1; i <= totalRows - 1; i++)
            {
                if (!driver.FindElement(By.XPath($"//table[@id = 'AddHospitalTblid']/descendant::td[{i + 1}]/descendant::div[@class = 'row_detail'][1]")).Text.Contains(SearchByProviderName))
                {
                    AreAllProviderNameSame = false;
                }

            }

            return AreAllProviderNameSame;
        }

        public static void ClickTopSaveButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Save']")));
            driver.FindElement(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Save']")).Click();
        }

        public static void ClickTopSendToPatientButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Send To Patient']")));
            driver.FindElement(By.XPath("//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Send To Patient']")).Click();
        }
        public static void ClickSendOnSendPreferencePopup(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//button[@type='submit'])[text()='SEND'][2]")));
            driver.FindElement(By.XPath("(//button[@type='submit'])[text()='SEND'][2]")).Click();
        }
       
        

        public static void ClickTopSendReferralButton(IWebDriver driver)
        {
            string Xpath = "//div[contains(@class, 'common-header-buttons')]/descendant::button[@title = 'Send Referral']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h4[@class='color-header-dark margin-record ng-star-inserted']")));
        }


        public static void ClickSendReferralAction(IWebDriver driver, int RowNumber)
        {
            string Xpath = $"//descendant::td[{RowNumber+1}]/descendant::action/descendant::button[@title = 'Send Referral']";
            Thread.Sleep(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();

        }

        public static void ClickSortByProviderName(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'header_container')]/div[contains(@class, 'header_title')]/span/i[contains(@class, 'fa-arrow')]")));
            driver.FindElement(By.XPath("//div[contains(@class, 'header_container')]/div[contains(@class, 'header_title')]/span/i[contains(@class, 'fa-arrow')]")).Click();
        }

        public static void ClickSortByProviderType(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/descendant::div[contains(@class, 'header_container')]/div[contains(@class, 'header_title')][3]/span/i[contains(@class, 'fa-arrow')]")));
            driver.FindElement(By.XPath("/descendant::div[contains(@class, 'header_container')]/div[contains(@class, 'header_title')][3]/span/i[contains(@class, 'fa-arrow')]")).Click();
        }

        public static void ClickProviderDetailsAction(IWebDriver driver, int RowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::td[{RowNumber + 1}]/descendant::div[@class = 'row_detail']/a[@class = 'cursor-pointer']")));
            driver.FindElement(By.XPath($"/descendant::td[{RowNumber + 1}]/descendant::div[@class = 'row_detail']/a[@class = 'cursor-pointer']")).Click();
        }

        public static void ClickClearFiltersButton(IWebDriver driver)
        {
            string Xpath = "//button[text()='CLEAR']|//button[text()='Clear']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }

        public static void SelectSortByInFilter(IWebDriver driver, String TypeOfSort)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("sortRating")));

            SelectElement SortBySelection = new SelectElement(driver.FindElement(By.Id("sortRating")));
            int index = 0;
            TypeOfSort = TypeOfSort.ToLower();
            if (TypeOfSort.Contains("rating"))
            {
                if (TypeOfSort.Contains("high to low"))
                    index = 1;
            }

            if (TypeOfSort.Contains("distance"))
            {
                if (TypeOfSort.Contains("near to far"))
                    index = 2;
                if (TypeOfSort.Contains("far to near"))
                    index = 3;
            }

            SortBySelection.SelectByIndex(index);
        }

        public static void ClickShowOnlySelectedButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[contains(@class, 'selected-provider-list-icon')]")));
            driver.FindElement(By.XPath("//i[contains(@class, 'selected-provider-list-icon')]")).Click();
        }

        public static void SelectProvidersByCheckboxes(IWebDriver driver, String RowNumbers)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/descendant::td[2]/descendant::input[@type = 'checkbox']")));

            foreach (String RowNumber in RowNumbers.Split("|"))
            {
                try
                {

                driver.FindElement(By.XPath($"/descendant::td[{int.Parse(RowNumber) + 1}]/descendant::input[@type = 'checkbox']")).Click();
                }
                catch { }
                
            }
            Thread.Sleep(1000);
        }


        // for cards, when we land this page via blue funnel
        public static void SelectProvidersByCheckboxesInCards(IWebDriver driver, String RowNumbers)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::label[text()='Select All Providers']/following::input[@type='checkbox'][1]|//descendant::provider-details-card/descendant::input[@type='checkbox'][2]")));

            foreach (var RowNumber in RowNumbers.Split("|"))
            {
                string Xpath = $"//descendant::provider-details-card/descendant::input[@type='checkbox'][{int.Parse(RowNumber)}]|//descendant::label[text()='Select All Providers']/following::input[@type='checkbox'][{int.Parse(RowNumber)}]";
                driver.FindElement(By.XPath(Xpath))
                .Click();
            }
        }


        public static void ClickSendReferralButtonInCard(IWebDriver driver, int RowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/descendant::div[contains(@class, 'PACF-list-view')][1]/descendant::button[contains(@class, 'btn-request-appointment') and @title = 'Send Referral']")));
            driver.FindElement(By.XPath($"/descendant::div[contains(@class, 'PACF-list-view')][{RowNumber}]/descendant::button[contains(@class, 'btn-request-appointment') and @title = 'Send Referral']"))
            .Click();
        }

        /********************************************** Send Referral Dialog *************************************************/
        public static void ClickCancelFormButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@class, 'global-cancel-button') and @name = 'cancel']")));
            driver.FindElement(By.XPath("//button[contains(@class, 'global-cancel-button') and @name = 'cancel']")).Click();
        }

        public static void ClickSendButton(IWebDriver driver)
        {
       
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-actions/descendant::button[@id='restart']")));
            driver.FindElement(By.XPath("//descendant::mat-dialog-actions/descendant::button[@id='restart']")).Click();
        }
        public static void Clickoncancel(IWebDriver driver)
        {
            string Xpath = "//descendant::mat-dialog-actions/descendant::button[text()='Cancel']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ClickOnContinueWithoutSharing(IWebDriver driver)
        {
            string Xpath = "//descendant::mat-dialog-actions/descendant::button[text()='CONTINUE WITHOUT SHARING']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void SelectProviderForReferralByName(IWebDriver driver,string ProviderName,string? ShortlistProviderPageType="RowListType")
        {//ShortlistProviderPageType=RowListType /ImageType

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='By Name']")));
            driver.FindElement(By.XPath("//input[@placeholder='By Name']")).Clear();

            driver.FindElement(By.XPath("//input[@placeholder='By Name']")).SendKeys(ProviderName);
            BaseClass.WaitForSpinnerToDisappear(driver);
            if(!ShortlistProviderPageType.ToLower().Contains("ImageType".ToLower()))
            {
                string Xpath = $"//descendant::a[contains(text(),'{ProviderName.ToUpper()}') or contains(text(),'{ProviderName}')]/preceding::input[contains(@class,'checkbox-size single-checkbox-margin')][1]";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();

            }else
            {
                string Xpath = $"//descendant::h3[contains(text(),'{ProviderName.ToUpper()}') or contains(text(),'{ProviderName}')]/preceding::input[contains(@type,'checkbox')][1]|descendant::a[contains(text(),'{ProviderName.ToUpper()}') or contains(text(),'{ProviderName}')]/preceding::input[1]";
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();
            }
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//input[@placeholder='By Name']")).Clear();
            //driver.FindElement(By.XPath("//input[@placeholder='By Name']")).SendKeys("Jh Hospitals");

            //WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Jh Hospitals')]/preceding::input[contains(@class,'checkbox-size single-checkbox-margin')][1]")));
            //driver.FindElement(By.XPath("//a[contains(text(),'Jh Hospitals')]/preceding::input[contains(@class,'checkbox-size single-checkbox-margin')][1]")).Click();

            //Thread.Sleep(2000);
        }
        public static void ClickOnSendReferral(IWebDriver Driver)
        {
            WebDriverWait wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Send Referral']")));
            Driver.FindElement(By.XPath("//button[text()='Send Referral']")).Click();



        }


        public static void SelectReferralType(IWebDriver driver, String ReferralType)
        {
            Thread.Sleep(1000);
            // /descendant::input[@name = 'referralTypeRadio'][3]
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::label[contains(text(),'Referral Type')]/following::input[1]")));

            if (ReferralType.ToLower().Contains("inpatient"))
                driver.FindElement(By.XPath("//descendant::label[contains(text(),'Referral Type')]/following::input[1]")).Click();
            else
                driver.FindElement(By.XPath("//descendant::label[contains(text(),'Referral Type')]/following::input[2]")).Click();
        }

        public static void SelectRequestDate(IWebDriver driver, String RequestDate)
        {
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//send-referral-dialog/descendant::select[1]")));

            SelectElement SortBySelection = new SelectElement(driver.FindElement(By.XPath("//send-referral-dialog/descendant::select[1]")));
            int index = 7;
            RequestDate = RequestDate.ToLower();

            if (RequestDate.Contains("asap"))
                index = 0;
            if (RequestDate.Contains("1 day"))
                index = 1;
            if (RequestDate.Contains("3 day"))
                index = 2;
            if (RequestDate.Contains("5 day"))
                index = 3;
            if (RequestDate.Contains("7 day"))
                index = 4;
            if (RequestDate.Contains("7 day"))
                index = 5;
            if (RequestDate.Contains("30 day"))
                index = 6;

            SortBySelection.SelectByIndex(index);

            if (index == 7)
            {
                String[] DateArr = RequestDate.Split("-");
                String RequestDateDate = DateArr[0];
                String RequestDateMonth = DateArr[1];
                String RequestDateYear = DateArr[2].Substring(0, 4);

                // open date-time picker 
                driver.FindElement(By.XPath("//send-referral-dialog/descendant::input[@id ='appointmentDateSendReferral']"))
                .Click();

                // open year dropdown and click 
                driver.FindElement(By.XPath("/descendant::div[contains(@class, 'xdsoft_datetimepicker')][2]/descendant::div[@class = 'xdsoft_select xdsoft_yearselect xdsoft_scroller_box']"))
                .Click();
                driver.FindElement(By.XPath($"/ descendant::div[contains(@class, 'xdsoft_yearselect')] / descendant::div[@data-value = '{RequestDateYear}']"))
                .Click();

                // open month dropdown and click 
                driver.FindElement(By.XPath("/descendant::div[contains(@class, 'xdsoft_datetimepicker')][2]/descendant::div[@class = 'xdsoft_select xdsoft_monthselect xdsoft_scroller_box']"))
                .Click();
                driver.FindElement(By.XPath($"/descendant::div[contains(@class, 'xdsoft_monthselect')]/descendant::div[@data-value = '{int.Parse(RequestDateMonth.Trim()) - 1}']"))
                .Click();

                // click desired Date 
                driver.FindElement(By.XPath($"//div[@class = 'xdsoft_calendar']/descendant::td[@data-year = '{RequestDateYear}' and @data-month='{int.Parse(RequestDateMonth.Trim()) - 1}' and @data-date='{RequestDateDate}']"))
                .Click();
            }

        }

        public static void ChoosePreAuthorizationRequired (IWebDriver driver, Boolean PreAuthorizationRequired)
        {
            if (driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input")).Selected && PreAuthorizationRequired == true)
            { }
            else if (driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input")).Selected && PreAuthorizationRequired == false)
            {
                driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input"))
                     .Click();
            }
            else if (!(driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input")).Selected) && PreAuthorizationRequired == false)
            { }
            else if (!(driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input")).Selected) && PreAuthorizationRequired == true)
            {
                driver.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input"))
                     .Click();
            }
        }

        public static void ChooseAutoConfirm(IWebDriver driver, Boolean AutoConfirm = true)
        {
            if (driver.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input")).Selected)
            {
                if (!AutoConfirm)
                    driver.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input"))
                    .Click();
            }

            else
            {
                if (AutoConfirm)
                    driver.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input"))
                    .Click();
            }

        }

        public static Boolean GetAutoConfirmValue(IWebDriver driver, Boolean AutoConfirm = true)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//send-referral-dialog/descendant::label[contains(text(), 'Auto Confirm')]/parent::div//following-sibling::div/input[@type = 'checkbox']")));
            return driver.FindElement(By.XPath("//send-referral-dialog/descendant::label[contains(text(), 'Auto Confirm')]/parent::div//following-sibling::div/input[@type = 'checkbox']"))
                .GetAttribute("checked") == "true" ? true : false;
        }

        public static void SelectProviderTypeSendReferralDialog(IWebDriver driver, String ProviderType)
        {
            string Xpath = "//descendant::send-referral-dialog/descendant::select[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            String temp = driver.FindElement(By.XPath(Xpath)).Text;
            if (temp != ProviderType)
            {
                SelectElement ProviderSelection = new SelectElement(driver.FindElement(By.XPath(Xpath)));
                ProviderSelection.SelectByText(ProviderType);
            }
        }

        public static void SelectServicesNeededSendReferralDialog(IWebDriver driver, String[] ServicesNeeded)
        {
           // Test.Value = ExtentTestManager.CreateTest("Select ServiceNeeded");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-content/descendant::label[contains(text(),'Services Needed')]"))).Click();
            foreach (String serviceId in ServicesNeeded)
            {  try
                {

                string Xpath = $"//mat-dialog-content/descendant::label[contains(text(),'Services Needed')]/following::label[contains(.,'{serviceId}')][1]/child::input";
               // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                  //  driver.FindElement(By.XPath(Xpath)).Click();
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                    if(!driver.FindElement(By.XPath(Xpath)).Selected)
                driver.FindElement(By.XPath(Xpath)).Click();
                    Test.Value.Log(Status.Pass, $"ServiceNeeded '{serviceId}' is selected ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, $"ServiceNeeded '{serviceId}' is not available "+e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }


            }
        }

        

        public static void SelectSpecialProgramsSendReferralDialog(IWebDriver driver, String[] SpecialPrograms)
        {
            //Test.Value = ExtentTestManager.CreateTest("Select Special Program");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            foreach (String specialProgramsId in SpecialPrograms)
            {
                
                string Xpath = $"//label[contains(text(),'Special Programs')]/following::label[contains(.,'{specialProgramsId}')]/input[1]";
                try
                {
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

                    executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                    driver.FindElement(By.XPath(Xpath)).Click();
                    Test.Value.Log(Status.Pass, $"Special program '{specialProgramsId}' is selected ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e) 
                {
                    Test.Value.Log(Status.Fail, $"Special program '{specialProgramsId}' is not available "+e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }
        }
        public static void SelectProviderShortlisted(IWebDriver driver,int rowNumber)
        {
            string Xpath = $"//descendant::input[@id='selectAllProviderCards']/following::input[{rowNumber}]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectPatientAttributes (IWebDriver driver, String Attributes)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='selectAllSettings']")).Click();
            
            foreach(String Attribute in Attributes.Split("|"))
            {
                if(Attribute == "Care Coordination")
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='careCoordinationCheck']")).Click();
                }
                else if(Attribute == "Emergency Contact")
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='emergencyContactCheck']")).Click();
                }
                else if (Attribute == "Medical Record")
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='medicalRecordCheck']")).Click();
                }
                else if (Attribute == "Progress Note")
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='progressNoteCheck']")).Click();
                }
                else if (Attribute == "Facesheet")
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='facesheet-check']")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='{Attribute.ToLower()}Check']")).Click();
                }
            }
        }

        public static string GetXPathForAttribute(int Index)
        {
            return $"//send-referral-dialog/descendant::div[@id = 'QuickNavigation'][{Index}]/descendant::input[@type = 'checkbox']";
        }


        //********************************************** Waits *****************************************//


        public static IWebElement WaitForSendReferralDialogToOpen(IWebDriver driver)
        {
            string xpath = "//div[@class='col-sm-2']//button[@id='restart']|//div[contains(@class,'center-footer padding-horizontal')]//button[@id='restart']";
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));

            return driver.FindElement(By.XPath(xpath));

        }

        public static void WaitForSortListResultToLoad(IWebDriver driver)
        {
            WebDriverWait Wait3 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[2]/td[1]/descendant::a[1]")));
        }


        public static void WaitForSortListResultforMoreReferral(IWebDriver driver)
        {
            WebDriverWait Wait3 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='AddHospitalTblid']/tbody/tr[2]/td")));
            Wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='AddHospitalTblid']/tbody/tr[2]/td")));
        }
        //********************************************** Waits End *****************************************//

        public static Boolean EnterNoteSendReferralDialog(IWebDriver driver, String Note)
        {
            driver.FindElement(By.XPath("//label[contains(text(),'Notes')]/following::textarea[@type='text']"))
            .SendKeys(Note);
            var temp = driver.FindElement(By.XPath("//label[contains(text(),'Notes')]/following::textarea[@type='text']")).Text;
            if (temp == Note)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ChooseProviderTypeDropDown(IWebDriver driver, String SendReferralProviderType)
        { 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//send-referral-dialog/descendant::select[2]")));

            SelectElement selection = new SelectElement(driver.FindElement(By.XPath("//send-referral-dialog/descendant::select[2]")));
            IList<IWebElement> OptionsInProviderType = selection.Options;
        
            foreach (IWebElement OptionElement in OptionsInProviderType)
            {
                if (SendReferralProviderType.ToLower().Trim() == OptionElement.Text.ToLower().Trim())
                {
                    selection.SelectByText(OptionElement.Text);
                }
            }
        }
    }
}
