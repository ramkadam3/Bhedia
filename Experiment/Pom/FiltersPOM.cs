using AventStack.ExtentReports;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    public class FiltersPOM:BaseClass
    {
        public static void EnterPatientNameInSearchField(IWebDriver Driver, String PatientName)
        {
            
            string Xpath = "//input[contains(@placeholder,'Patient Name')]";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            Driver.FindElement(By.XPath(Xpath)).Clear();
            Driver.FindElement(By.XPath(Xpath)).SendKeys(PatientName);
        }
        public static void ClearEnterPatientNameForSearch(IWebDriver driver)
        {
            string Xpath = "//input[contains(@placeholder,'Patient Name')]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            String namee = driver.FindElement(By.XPath(Xpath)).GetAttribute("value");

            driver.FindElement(By.XPath(Xpath)).Click();
            for (int i = namee.Length; i >= 1; i--)
            {

                driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Backspace);
            }
        }
        public static Tuple<IWebElement, string> ClickOnFilter(IWebDriver driver, string element)
        {
            string Xpath = $"//descendant::label[contains(text(),'{element}')]/following-sibling::select";
            WebDriverWait Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Tuple.Create(driver.FindElement(By.XPath(Xpath)), Xpath);


        }
        public static IWebElement ClickOnInputTypeFilter(IWebDriver driver, string element)
        {
            string Xpath = $"//descendant::label[contains(text(),'{element}')]/following::input[1]";
            WebDriverWait Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));


        }
        public static IWebElement SelectInputFromInputTypeFilter(IWebDriver driver, string element,string Input)
        {
            string Xpath = $"//descendant::label[contains(text(),'{element}')]/following::input[1]/following::span[text()='{Input}']/preceding-sibling::input";
            WebDriverWait Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));


        }


        //Status
        public static Boolean CheckStatusOfAllRows_IncomingPage(IWebDriver driver, String Status)
        {
            string Xpath = "//div[5]/descendant::div[text()='ShowBelowStatusKeyStatus']/following-sibling::div/descendant::div[@class='status-badge-container']";
            Boolean AreAllStatusSame = true;
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(1));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> statusList = driver.FindElements(By.XPath(Xpath));
            foreach (WebElement status in statusList)
            {
                if (!Status.ToLower().Contains(status.Text.ToLower()))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }
        public static Boolean CheckStatusOfAllRows(IWebDriver driver, String Status)
        {
            string Xpath = "status-badge-container";
            Boolean AreAllStatusSame = true;
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(1));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName(Xpath)));
            IList<IWebElement> statusList = driver.FindElements(By.ClassName(Xpath));
            foreach (WebElement status in statusList)
            {
                if (!Status.ToLower().Contains(status.Text.ToLower()))
                    AreAllStatusSame = false;
            }

            return AreAllStatusSame;
        }
        //track
        public static void SelectTrackedByFilter(IWebDriver driver, String TrackedBy)
        {
            string Xpath = "//descendant::label[contains(text(),'Tracked By')]/following-sibling::select";
            WebDriverWait Wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            SelectElement modelSelection = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            modelSelection.SelectByText(TrackedBy);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(Xpath)).SendKeys(Keys.Enter);

        }


        //Tags

        public static void SelectTaginFilter(IWebDriver driver, string Tag)
        {
            string Xpath = "//label[contains(text(),'Tags')]/following::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();
                foreach (string tag in Tag.Split("|"))
                {
                    string Xpath1 = $"//label[contains(text(),'Tags')]/following::span[contains(text(),'{tag}')]/preceding-sibling::input";
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath1)));


                    driver.FindElement(By.XPath(Xpath1)).Click();


                }



            }
            catch (Exception ex)
            {

            }
        }
        public static void SelectStatusinFilter(IWebDriver driver, string Statuses)
        {
            string Xpath = "//label[contains(text(),'Status')]/following::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                driver.FindElement(By.XPath(Xpath)).Click();
                foreach (string status in Statuses.Split("|"))
                {
                    string Xpath1 = $"//label[contains(text(),'Status')]/following::span[text()='{status}']/preceding-sibling::input";
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath1)));


                    driver.FindElement(By.XPath(Xpath1)).Click();


                }



            }
            catch (Exception ex)
            {

            }
        }
        public static Boolean CheckAllTagsSelected(IWebDriver driver,string? tag=null)
        {
            if(tag==null)
            {

            Boolean AllCheckSelected = true;
            string Xpath = "//label[contains(text(),'Tags')]/following::span[contains(text(),'')]/preceding-sibling::input";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            IList<IWebElement> Cheklist = driver.FindElements(By.XPath(Xpath));
            foreach (IWebElement chek in Cheklist)
            {
                AllCheckSelected = chek.Selected;

            }
            return AllCheckSelected;
            }
            else
            {
                Boolean AllCheckSelected = true;
                string Xpath = $"//label[contains(text(),'Tags')]/following::span[contains(text(),'{tag}')]/preceding-sibling::input";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                IList<IWebElement> Cheklist = driver.FindElements(By.XPath(Xpath));
                foreach (IWebElement chek in Cheklist)
                {
                    AllCheckSelected = chek.Selected;

                }
                return AllCheckSelected;
            }
        }
        public static Boolean CheckAllStatusesSelected(IWebDriver driver,string? Status=null)
        {
            if(Status==null)
            {

            Boolean AllCheckSelected = true;
            string Xpath = "//label[contains(text(),'Status')]/following::span[contains(text(),'')]/preceding-sibling::input";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            IList<IWebElement> Cheklist = driver.FindElements(By.XPath(Xpath));
            foreach (IWebElement chek in Cheklist)
            {
                AllCheckSelected = chek.Selected;

            }
            return AllCheckSelected;
            }
            else {


                Boolean AllCheckSelected = true;
                string Xpath = $"//label[contains(text(),'Status')]/following::span[contains(text(),'{Status}')]/preceding-sibling::input";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                IList<IWebElement> Cheklist = driver.FindElements(By.XPath(Xpath));
                foreach (IWebElement chek in Cheklist)
                {
                    AllCheckSelected = chek.Selected;

                }
                return AllCheckSelected;

            }
        }
        public static Boolean CheckPlaceholder_Tags(IWebDriver driver, string CheckText)
        {
            string Xpath = "//label[contains(text(),'Tags')]/following::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Contains(CheckText);

        }
        public static Boolean CheckPlaceholder_Status_IncomingPage(IWebDriver driver, string CheckText)
        {
            string Xpath = "//label[contains(text(),'Status')]/following::input[1]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).GetAttribute("placeholder").Contains(CheckText);

        }
        public static Boolean CheckTagOfAllRows(IWebDriver driver, String Tag)
        {
            Boolean AreAllRowSameTag = false;
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(1));

            int RowList = driver.FindElements(By.XPath("//tr")).Count;
            for (int i = 2; i < RowList; i++)
            {
                string Xpath = $"//descendant::tr[{i}]/descendant::div[contains(@class,'position-relative d-inline-block')]/descendant::span";
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
                IList<IWebElement> TagList = driver.FindElements(By.XPath(Xpath));
                foreach (IWebElement tag in TagList)
                {
                    //string t = Tag;
                    string text = tag.Text.Trim();
                    //Console.WriteLine( t);

                    if (Tag.ToLower().Trim().Contains(tag.Text.Trim().ToLower()))
                        AreAllRowSameTag = true;
                }
            }
            return AreAllRowSameTag;
        }
        
        public static void ClearFilter_OutgoingPage(IWebDriver driver)
        {

            try
            {
            FiltersPOM.ClickOnInputTypeFilter(driver, "Provider Type").Click();
                if(FiltersPOM.SelectInputFromInputTypeFilter(driver, "Provider Type", "All").Selected)
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Provider Type", "All").Click();
                }
                else
                {
            FiltersPOM.SelectInputFromInputTypeFilter(driver, "Provider Type", "All").Click();
            FiltersPOM.SelectInputFromInputTypeFilter(driver, "Provider Type", "All").Click();

                }

            }
            catch { }
            try
            {
            FiltersPOM.ClickOnInputTypeFilter(driver, "Status").Click();
                if(FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Selected)
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();
                }
                else
                {
            FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();
            FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();

                }

            }
            catch { }
            try
            {
            SelectElement Tracke = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item1);
            Tracke.SelectByText("Me");
            CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item2);

            }catch { }
            try
            { 
            
            FiltersPOM.ClearEnterPatientNameForSearch(driver);
            }
            catch { }

            
            
            
            
            

        }
             public static void ClearFilter_PatientList(IWebDriver driver)
             {
            try
            {
            SelectElement Sta = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Status:").Item1);
            Sta.SelectByText("Admitted");
            CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Status:").Item2, "Up");

            }
            catch { }

            try
            {
                FiltersPOM.ClickOnInputTypeFilter(driver, "Tags").Click();
                if (FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Selected)
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();
                }
                else
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();

                }

            }
            catch { }
            try {
            
            SelectElement Tracke = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item1);
            Tracke.SelectByText("Me");
            CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item2);
            
            
            } catch { }
            try
            {
            SelectElement Insu = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Insurance:").Item1);
            Insu.SelectByText("Arizona Complete Health");
            CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Insurance").Item2, "Up", 50);
            
            
            }catch { }
            try
            { 
            SelectElement Modee = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Mode:").Item1);
            Modee.SelectByText("Recent Patients");
            CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Mode").Item2);
            
            
            }
            catch { }
            try 
            {
            PatientListPOM.ClearEnterPatientNameForSearch(driver);
            
            
            } catch { }



        }
        public static void ClearFilter_IncomingPage(IWebDriver driver)
        {

            try
            {
                SelectElement Tracke = new SelectElement(FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item1);
                Tracke.SelectByText("Me");
                CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Tracked By:").Item2,"Up");

            }
            catch { }
            try
            {
                FiltersPOM.ClickOnInputTypeFilter(driver, "Status").Click();
                if(FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Selected)
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();
                }
                else
                {
                FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();
                FiltersPOM.SelectInputFromInputTypeFilter(driver, "Status", "All").Click();

                }

            }
            catch { }
           
            
            try
            {
                FiltersPOM.ClickOnInputTypeFilter(driver, "Tags").Click();
                if (FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Selected)
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();
                }
                else
                {
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();
                    FiltersPOM.SelectInputFromInputTypeFilter(driver, "Tags", "All").Click();

                }

            }
            catch { }
            

            try
            {
                
                CommonPOM.MouseActionForDropDownHandle(driver, FiltersPOM.ClickOnFilter(driver, "Mode").Item2,"Up",4);


            }
            catch { }


            try
            {

                FiltersPOM.ClearEnterPatientNameForSearch(driver);
            }
            catch { }







        }






    }
}
