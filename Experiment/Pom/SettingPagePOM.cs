using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V105.Input;
using AngleSharp;

namespace RovicareTestProject.PageObjects
{
    public class SettingPagePOM
    {
        public static void NavigateToSettingsPage(IWebDriver driver)
        {

            string Xpath = $"//descendant::a[@title='Settings']/i";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


            //descendant::mat-tab-header/descendant::div[contains(text(),'Configure Referrals')]
        }
        public static void NavigateToConfigurationHeaderSection_Configuration(IWebDriver driver,string HeaderSection)
        {
            //HeaderSection= Patient Settings|Destination Service|Cofigure Referrals|Tags
            string Xpath = $"//descendant::mat-tab-header/descendant::div[contains(text(),'{HeaderSection}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Thread.Sleep(300);
            driver.FindElement(By.XPath(Xpath)).Click();


          
        }
        public static void NavigateToDashBoardHeaderSection_SettingsPage(IWebDriver driver, string HeaderSection)
        {
            //HeaderSection= Notification|Configuration|Assign Role




            string Xpath = $"//descendant::h3[contains(text(),'{HeaderSection}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static (IWebElement CheckSelected,IWebElement Clickable) CheckFeature_EnableORdisable(IWebDriver driver, string ElemenetName , string Input)
        {
            
            string Xpath;
            if ("Yes|Enable|Medical|All".Contains(Input))
            {
                Xpath = $"//descendant::div[contains(text(),'{ElemenetName}')]/following::input[1]";

            }
            else if ("No|Disable".Contains(Input))
            {
                Xpath = $"//descendant::div[contains(text(),'{ElemenetName}')]/following::input[2]";
            }
            else
            {
                Xpath = $"//descendant::div[contains(text(),'{ElemenetName}')]/following::input[3]";
            }
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath($"{Xpath}/preceding-sibling::div/child::div[2]")));
            
               // IWebElement CheckSelected =driver.FindElement(By.XPath(Xpath));
               // IWebElement Clickable=driver.FindElement(By.XPath($"{Xpath}/ancestor::mat-radio-button"));
            return (driver.FindElement(By.XPath(Xpath)), driver.FindElement(By.XPath($"{Xpath}/preceding-sibling::div/child::div[2]")));



        }
        public static Boolean CheckRatingFeature(IWebDriver driver, string RatingFeatureName,int StarNumber)
        {
            //HeaderSection= Notification|Configuration|Assign Role

            string Xpath = $"//descendant::div[contains(text(),'{RatingFeatureName}')]/following::a[contains(@class,'deactivateRate')]";
            


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath($"{ Xpath}[{1}]")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"{Xpath}[{1}]")));
            return StarNumber == 5-driver.FindElements(By.XPath(Xpath)).Count();




        }
        public static void SelectShareReferrerDetails(IWebDriver driver, string Options)
        {
            //HeaderSection= Notification|Configuration|Assign Role

            string Xpath = $"//div[contains(text(),'Share Referrer Details')]/following::input[1]";


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Thread.Sleep(4000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Xpath))).Click();
            foreach(string option in Options.Split('|'))
            {
            string XpathOption = $"//div[contains(text(),'Share Referrer Details')]/following::input[1]/following::span[contains(text(),'{option}')]/preceding-sibling::input";
                try
                {
                driver.FindElement(By.XPath(XpathOption)).Click();

                }
                catch { }
            }




        }
        public static void ClickOnSubmit_SettingPage(IWebDriver driver)
        {
            

            string Xpath = $"//descendant::button[text()='SUBMIT']";



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();




        }
        public static void EnableDestinationService_OnDestinationSettingPOPUp(IWebDriver Driver, string Service)
        {

            string Xpath = $"//descendant::div[contains(text(),'{Service}')]/following::input[1]";
            string ClickXpath=$"//descendant::div[contains(text(),'{Service}')]/following::mat-slide-toggle[1]";



            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(ClickXpath)));
            Driver.FindElement(By.XPath(ClickXpath)).Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath(Xpath)));



        }
        public static void ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(IWebDriver Driver, string ElementName)
        {

            string Xpath = $"//descendant::div[contains(text(),'Destination Service')]/following::label[contains(text(),'{ElementName}')]/following-sibling::button['Save']";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", Driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Click();




        }
        public static void ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(IWebDriver Driver, string ElementName)
        {

            string Xpath = $"//descendant::div[contains(text(),'Destination Service')]/following::label[contains(text(),'{ElementName}')]/following::span[1]";




            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));


            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            if (!Driver.FindElement(By.XPath(Xpath)).GetAttribute("Style").Contains("180"))
                Driver.FindElement(By.XPath(Xpath)).Click();




        }

        
    }
    //descendant::div[contains(text(),'Destination Service')]/following::label[contains(text(),'Provider Type')]/following::span[1]--Excepansion
}
