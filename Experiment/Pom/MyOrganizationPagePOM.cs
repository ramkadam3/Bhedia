using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    public class MyOrganizationPagePOM
    {
        public static void NavigateToMyOrganizationPage(IWebDriver driver)
        {

            string Xpath = $"//descendant::a[@title='My Organization']/i";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();


            
        }
        public static IList<IWebElement> CheckProviderType_MyOrganizationPage(IWebDriver driver)
        {

            string Xpath = $"//descendant::label[contains(text(),'Provider Type:')]/following::label[contains(@class,'label-header')]/child::span";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement>Types=driver.FindElements(By.XPath(Xpath));
            return Types;


        }//descendant::label[contains(text(),'Description')]/following::label[contains(text(),'Add_Organization')]

        public static Boolean CheckCompanyBacicDetails_MyOrganizationPage(IWebDriver driver,string ElementName,string VerifyingText)
        {//ElementName=Category|AHCCCS ID|
         //VerifyingText=Entereddata

            string Xpath = $"//descendant::label[contains(text(),'{ElementName}')]/following::label[contains(text(),'{VerifyingText}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;



        }
        public static void ClickOnUploadImage_MyOrganizationPage(IWebDriver driver)
        {

            string Xpath = $"//section[@id='nav']/descendant::i['upload']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        //**************************************************************UploadImagePOP_UP_ start********************************************************
        public static void ClickOnUpload_UploadImagePOP_up(IWebDriver driver)
        {

            string Xpath = $"//descendant::label[contains(text(),'Choose images to upload')]/following::span[text()='Upload'][1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }
        public static IWebElement ClickOnOk_pop_up_UploadImagePOP_up(IWebDriver driver)
        {

            string Xpath = $"//button[text()='Ok']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));



        }
        public static void Close_UploadImagePOP_up(IWebDriver driver)
        {

            string Xpath = $"//button[@class='close'][1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();



        }










        //**************************************************************UploadImagePOP_UP_ End********************************************************
        public static Boolean CheckLocationDetails_OrganizationPage(IWebDriver driver, string AddressText)
        {

            string Xpath = $"//descendant::li[contains(text(),'{AddressText}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;



        }
         public static Boolean CheckOrganizationName_OrganizationPage(IWebDriver driver, string OrgName)
        {

            string Xpath = $"//descendant::label[contains(text(),'{OrgName}')]";
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;



        }
        public static Boolean CheckFeature_MyOrganizationPage(IWebDriver driver, string ElementName, string service)
        {//ElementName = Service Offered|Insurance Accepted|Age Group|Gender
         //service = Service|insurance|Age|Gender

            string Xpath = $"//descendant::li[contains(text(),'{ElementName}')]/following::li[contains(text(),'{service}')][1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;



        }
        
        
        








        public static Boolean CheckMemberAdded_OrganizationPage(IWebDriver driver, string MembtName)
        {
         

            string Xpath = $"//descendant::a[contains(text(),'{MembtName}')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;



        }

       
        




























    }
}
