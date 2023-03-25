using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.PageObjects
{
    internal class ArrangeTransportPopupPOM
    {
        public static void EnterPickupDate(IWebDriver Driver, String DateTime) // the format will be dd-mm--yyyy hh:
        {
            // checking if the datepicker is visible and make it visible in case it isnt
            if(Driver.FindElement(By.XPath("//div[contains(@class, 'xdsoft_datetimepicker')]")).GetCssValue("display") == "none")
            Driver.FindElement(By.Id("newPickupDate"))
            .Click();

            // making the year dropdown popup            
            Driver.FindElement(By.XPath("/descendant::div[contains(@class, 'xdsoft_datetimepicker')][4]/descendant::div[@class = 'xdsoft_label xdsoft_year'][1]"))
            .Click();

            // clicking the actual year
            Driver.FindElement(By.XPath($"/descendant::div[contains(@class, 'xdsoft_datetimepicker')][4]/descendant::div[@class = 'xdsoft_label xdsoft_year']/descendant::div[@data-value='{DateTime.Split("-")[2].Substring(0, 4)}']"))
            .Click();

            // making the month dropdown popup            
            Driver.FindElement(By.XPath("/descendant::div[contains(@class, 'xdsoft_datetimepicker')][4]/descendant::div[@class = 'xdsoft_label xdsoft_month']"))
            .Click();

            // clicking the actual month
            Driver.FindElement(By.XPath($"/descendant::div[contains(@class, 'xdsoft_datetimepicker')][4]/descendant::div[@class = 'xdsoft_label xdsoft_month']/descendant::div[@data-value='{int.Parse(DateTime.Split("-")[1]) - 1}']"))
            .Click();


            // now finally clicking the date
            Driver.FindElement(By.XPath($"/descendant::div[contains(@class, 'xdsoft_datetimepicker')][4]/descendant::div[@class = 'xdsoft_calendar']/descendant::td[@data-month = '{int.Parse(DateTime.Split("-")[1]) - 1}' and @data-year = '{DateTime.Split("-")[2].Substring(0, 4)}' and @data-date = '{DateTime.Split("-")[0]}']"))
            .Click();

            // This was not working so it is being skipped
            //Driver.FindElement(By.XPath($"//div[contains(@class, 'xdsoft_datetimepicker')]/descendant::div[@data-hour='{int.Parse(DateTime.Split("-")[2].Split(" ")[1].Split(":")[0])}']"))
            //.Click();

            


        }
        public static void EnterNoteInArrangeTransportForm(IWebDriver Driver, String Note)
        {
            Driver.FindElement(By.XPath("//app-arrange-transport-dialog/form/descendant::textarea[@id = 'newNote']"))
            .SendKeys(Note);
        }

        public static void ClickSubmitFormButton(IWebDriver Driver, String Note)
        {
            Driver.FindElement(By.XPath("//app-arrange-transport-dialog/form/descendant::textarea[@id = 'newNote']"))
            .SendKeys(Note);
        }

        public static void ClickSubmitFormButton(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//app-arrange-transport-dialog/form/descendant::mat-dialog-actions/descendant::button[@name = 'create']"))
            .Click();
        }

        public static void ClickCancelButtonInForm(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//app-arrange-transport-dialog/form/descendant::mat-dialog-actions/descendant::button[@name = 'cancel']"))
            .Click();
        }
        // //div[contains(@class, 'xdsoft_datetimepicker')][@class = 'xdsoft_label xdsoft_month']/descendant::div[contains(@class, 'xdsoft_monthselect')]/descendant::div[@data - value = '2']
    }
}
