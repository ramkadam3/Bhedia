using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    public class AppointmentPagePOM
    {//****************************************SearchField_POM**************************************

        public static void NaviagateToAppointmentPage(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@title='Appointments']/descendant::i[@class='fas fa-calendar-check']")));
           

            Driver.FindElement(By.XPath("//*[@title='Appointments']/descendant::i[@class='fas fa-calendar-check']")).Click();
        }
        public static void NavigateToAppointment_Appointment(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//i[@class='fas fa-calendar-check']")));
            driver.FindElement(By.XPath($"//i[@class='fas fa-calendar-check']")).Click();
        }
        public static void ClickOnNotesAction_Appointment(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//tbody/tr[{rowNumber + 1}]/td/div[1]/div[7]/action/div/span[2]/a/button[@class='btn-annotation-clr']")));
            driver.FindElement(By.XPath($"//tbody/tr[{rowNumber + 1}]/td/div[1]/div[7]/action/div/span[2]/a/button[@class='btn-annotation-clr']")).Click();
        }
        public static void ClickOnMedicalRecord_Appointment(IWebDriver driver, int rowNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//tbody/tr[{rowNumber + 1}]/td/div[1]/div[7]/action/div/span[3]/a/button[@class='btn-LTClist-clr']")));
            driver.FindElement(By.XPath($"//tbody/tr[{rowNumber + 1}]/td/div[1]/div[7]/action/div/span[3]/a/button[@class='btn-LTClist-clr']")).Click();
        }
        public static void WaitForAppointmentPage_loading(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr[1]/td/div/div[7]")));


            //h2[@class='filter-Title-report  search-Title']
        }
        public static Boolean CheckSearchField(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//h2[@class='filter-Title-report  search-Title']")));

            return Driver.FindElement(By.XPath("//h2[@class='filter-Title-report  search-Title']")).Displayed;
            
        }
        public static IWebElement ClickonByPatientName(IWebDriver Driver)   
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//input-search/descendant::input[contains(@type,'text')]")));
            //i[@class='fas fa-calendar-check']

            return Driver.FindElement(By.XPath("//input-search/descendant::input[contains(@type,'text')]"));
        }
        public static IWebElement ClickOnFrom_ToTab(IWebDriver Driver,string From_To)   //use From or To as argument
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//label[contains(text(),'From')]/following::input[@placeholder='Select A Date'][1]")));

            //*[@id="hsgdsahasj"]/appointment-dashboard/div/h3/span
            return Driver.FindElement(By.XPath($"//label[contains(text(),'{From_To}')]/following::input[@placeholder='Select A Date'][1]"));
        }
       
        public static Tuple<IWebElement,string> ClickOnFollowUpStatus(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//descendant::select[@name='select-input'][2]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            IWebElement webElement= Driver.FindElement(By.XPath(Xpath));
            return Tuple.Create( webElement,Xpath);
        }
        public static Tuple<IWebElement,string> ClickOnAppointmentStatus(IWebDriver Driver)
        {
            WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            string Xpath = "//input-select/descendant::label[contains(text(),'Appointment Status:')]/following::select[@style='text-indent: 138px;']";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            IWebElement webElement = Driver.FindElement(By.XPath(Xpath));

            return Tuple.Create( webElement,Xpath);
        }
       
       
        public static IWebElement SelectDateForFrom_OR_To(IWebDriver Driver,string From_OR_To,string Date)//Use From OR To as per requirement
        {
         
                WebDriverWait Wait = new(Driver, TimeSpan.FromSeconds(10));
            if (From_OR_To== "From")
            {
                string Xpath = $"//tbody/descendant::td[contains(@data-date,'{Date}')]/descendant::div[text()='{Date}']";
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                return Driver.FindElement(By.XPath(Xpath));
            }
            else
            {
                string Xpath = $"//tbody/descendant::td[contains(@data-date,'{Date}')]/following::div[text()='{Date}']";
            
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                return Driver.FindElement(By.XPath(Xpath));
            }
            
            
            }
        public static Boolean CheckStatusOfAllRows(IWebDriver driver, String Status)
        {
            Boolean AreAllStatusSame = true;
            IList<IWebElement> statusList = driver.FindElements(By.XPath("//tbody//td/div[1]/div[4]/div[2]/status-labels/div"));
            foreach (WebElement status in statusList)
            {
               string text=status.Text;
                if (!Status.Contains(text))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }
        public static Boolean CheckFollowUpOfAllRows(IWebDriver driver, String[] FollowUp)
        {
            Boolean AreAllFollowUpSame = true;
            IList<IWebElement> statusList = driver.FindElements(By.XPath("//tbody//td/div[1]/div[5]/div[2]/status-labels/div/span"));
            foreach (WebElement followUp in statusList)
            {
                if (!FollowUp[0].Contains(followUp.Text))
                    AreAllFollowUpSame = false;
            }

            return AreAllFollowUpSame;
        }
        public static Boolean CheckDateOfAllRows(IWebDriver driver, String From_Date, String To_Date)
        {
            Boolean AreAllStatusSame = true;
            IList<IWebElement> DateList = driver.FindElements(By.XPath("//tr/descendant::app-date-time/span"));
            foreach (WebElement Dates in DateList)
            {
                DateTime fromDate = DateTime.Parse(From_Date);
                DateTime elementDate = DateTime.Parse(Dates.Text);
                DateTime toDate = DateTime.Parse(To_Date);
                if (!(elementDate >= fromDate && elementDate <= toDate))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }

    }
}
