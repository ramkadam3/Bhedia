using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RovicareTestProject.PageObjects
{
    public class ShortlistFacilityPOM
    {
        //mat-radio-button[@id = 'mat-radio-2']/descendant::div[@class = 'mat-radio-container']
        public static void WaitForShortlistFilterPageToLoadUp(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='list-info crs-list-info'])[1]")));
        }
        public static void SelectOptionInFacilityTypeInFilter(IWebDriver driver, String FacilityType)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//mat-radio-button[@id = 'mat-radio-1']/descendant::div[@class = 'mat-radio-container']/child::div[2]")));

            if (FacilityType.ToLower().Trim() == "medical")
                driver.FindElement(By.XPath("//mat-radio-button[@id = 'mat-radio-1']/descendant::div[@class = 'mat-radio-container']/child::div[2]")).Click();

            if (FacilityType.ToLower().Trim() == "behavioral")
                driver.FindElement(By.XPath("//mat-radio-button[@id = 'mat-radio-2']/descendant::div[@class = 'mat-radio-container']/child::div[2]")).Click();
        }

        public static void EnterZipCodeInFilter(IWebDriver driver, String Zipcode)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='Locality']")));

            driver.FindElement(By.XPath("//input[@name='Locality']")).Clear();
            driver.FindElement(By.XPath("//input[@name='Locality']")).SendKeys(Zipcode);
        }

        public static void SelectMilesInFilter(IWebDriver driver, int Mile)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//select[@name='zip']")));

            SelectElement MileSelection = new SelectElement(driver.FindElement(By.XPath("//select[@name='zip']")));
            MileSelection.SelectByText(Mile.ToString());
        }


        public static IWebElement SelectProviderTypesInFilter(IWebDriver driver, String FacilityType)
        {
            string Xpath = $"//div[@id = 'ProviderTypeid1']/descendant::label/span[text() = '{FacilityType}']/preceding-sibling::input";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }

        public static void SelectServicesNeededInFilter(IWebDriver driver, String[] ServicesNeeded)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("CareRequirementid1")));

            foreach (String ServiceNeeded in ServicesNeeded)
            {
                try
                {

                driver.FindElement(By.XPath($"//label[contains(text(),'Services Needed')]/following::input[2]"))
                .Click();
                }
                catch { }
            }
        }
        

        public static void SelectSpecialProgramsInFilter(IWebDriver driver, String[] SpecialPrograms)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("specialProgram1")));

            foreach (String SpecialProgram in SpecialPrograms)
            {
                try
                {
                    driver.FindElement(By.XPath($"//div[@id = 'specialProgram1']/descendant::label/span[text() = '{SpecialProgram}']/preceding-sibling::input[@type = 'checkbox']"))
                    .Click();
                }
                catch { }
            }
        }

        public static void SelectGenderInFilter(IWebDriver driver, String[] Genders)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='display-flex margin-top-10 gender-flex-wrap']")));

            foreach (String Gender in Genders)
            {
                try
                {
                    driver.FindElement(By.XPath($"//div[@class = 'display-flex margin-top-10 gender-flex-wrap']/descendant::label/span[text() = '{Gender}']/preceding-sibling::input[@type = 'checkbox']"))
                    .Click();
                }
                catch { }
            }
        }

        public static void SelectInsurancesInFilter(IWebDriver driver, String[] Insurances)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Insuranceid1")));

            foreach (String Insurance in Insurances)
            {
                try
                {
                    driver.FindElement(By.XPath($"//div[@id = 'Insuranceid1']/descendant::label/span[text() = '{Insurance}']/preceding-sibling::input[@type = 'checkbox']"))
                    .Click();
                }
                catch { }
            }
        }
        
        public static void ClickClearButton(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@type = 'submit' and text() = 'Go']")));


            driver.FindElement(By.XPath("//button[normalize-space()='Clear']"))
            .Click();
        }

        public static void ClickSaveButton(IWebDriver driver)
        {
            string Xpath = "//button[normalize-space()='Save']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));


            driver.FindElement(By.XPath(Xpath))
            .Click();
        }

        public static void EnterSaveSearchNameInFilter(IWebDriver driver, String SaveSearchName)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Save Search']")));

            driver.FindElement(By.XPath("//input[@placeholder='Save Search']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Save Search']")).SendKeys(SaveSearchName);
        }
        public static void ClickSavedSearchDeleteButton(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//i[@title='Delete']")));


            driver.FindElement(By.XPath("//i[@title='Delete']"))
            .Click();
        }
        public static void ClickOnDeleteButtonInDeleteSearchPopUp(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='col-md-12']//div[@class='col-md-12']")));


            driver.FindElement(By.XPath("//button[normalize-space()='DELETE']"))
            .Click();
        }

        public static void SearchWithSavedSearch(IWebDriver driver, String SaveSearchName)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//div[@title='{SaveSearchName}']")));
            driver.FindElement(By.XPath($"//div[@title='{SaveSearchName}']")).Click();
            WebDriverWait Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@title='Search']")));
            driver.FindElement(By.XPath("//button[@title='Search']")).Click();
        }

        public static void ClickGoButton(IWebDriver driver)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath("//button[@type = 'submit' and text() = 'Go']")));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@type = 'submit' and text() = 'Go']")));


            driver.FindElement(By.XPath("//button[@type = 'submit' and text() = 'Go']"))
            .Click();
        }
        //id : ageGroup1
        public static void SelectAgeGroupsInFilters(IWebDriver driver, String[] AgeGroups)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ageGroup1")));

            foreach (String AgeGroup in AgeGroups)
            {
                driver.FindElement(By.XPath($"//div[@id = 'ageGroup1']/descendant::label/span[text() = '{AgeGroup}']/preceding-sibling::input[@type = 'checkbox']"))
                .Click();
            }
        }
        public static IWebElement CheckFilterValueAvailibilityInFilters(IWebDriver driver, String FileterName,string FilterValue)
        {
            string Xpath = $"//label[text()='{FileterName}']/following::label/span[text() = '{FilterValue}'][1]/preceding-sibling::input[@type = 'checkbox']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            
            
               return driver.FindElement(By.XPath(Xpath));
            
        }

        public static void ClickOnCheckBox(IWebDriver driver, int rowNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"// descendant::tr[{rowNumber + 1}] / descendant::span[@class = 'row_detail'] / input[@type = 'checkbox']")));
                driver.FindElement(By.XPath($"// descendant::tr[{rowNumber + 1}] / descendant::span[@class = 'row_detail'] / input[@type = 'checkbox']")).Click();
            }
            catch (Exception ex)
            { }
        }

        public static IWebElement ClickOnOk_confirmationPopup(IWebDriver driver)
        {
            string Xpath = "//descendant::button[text()='Ok']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            
            
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
               return driver.FindElement(By.XPath(Xpath));
           
           
            
        }



    }
}
