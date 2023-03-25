using OpenQA.Selenium;
using RovicareTestProject.Utilities;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace RovicareTestProject.PageObjects
{
    public class ReferralCreationPOM : BaseClass
    {
        
        // Page Objects: 

        public static void EnterFirstNameField(IWebDriver Driver, String Firstname)
        {
            Driver.FindElement(By.Id("Firstname")).SendKeys(Firstname);

        }

        public static void EnterMiddleNameField(IWebDriver Driver, String MiddleName)
        {
            Driver.FindElement(By.XPath(".//input[contains(@id, 'Middlename') and contains(@name, 'MiddleName') and contains(@class, 'form-control')]"))
                .SendKeys(MiddleName);

        }

            public static void EnterLastNameField(IWebDriver Driver, String Lastname)
        {
            Driver.FindElement(By.Id("Lastname")).SendKeys(Lastname);

        }

        public static void EnterDateOfBirthField(IWebDriver Driver, String DateOfBirth)
        {
            Driver.FindElement(By.Id("dateOfBirth")).SendKeys(DateOfBirth);

        }

        public static void SelectGender(IWebDriver Driver, String Gender)
        {
            if(Gender == "male")
                 Driver.FindElement(By.Id("male")).Click();
            else if(Gender == "female")
                Driver.FindElement(By.Id("female")).Click();
            else
                Driver.FindElement(By.Id("other")).Click();
        }   

        public static void EnterSSNPID (IWebDriver Driver, String SSN_PID )
        {
            Driver.FindElement(By.Id("ssn")).SendKeys(SSN_PID);
        }

        public static void EnterEmailIdField(IWebDriver Driver, String EmailId)
        {


            Driver.FindElement(By.XPath(".//input[contains(@name, 'patientEmailID') and contains(@class, 'form-control') and contains(@placeholder, 'Email ID')]"))
            .SendKeys(EmailId);

        }

        public static void EnterOrganizationName (IWebDriver Driver, String OrganizationName)
        {
            Driver.FindElement(By.Id("OrganizationName")).SendKeys(OrganizationName);

            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@title='values.Name']")));

            Driver.FindElement(By.XPath("//li[@title='values.Name']")).Click();
        }

        public static void EnterReceivedDate(IWebDriver Driver, String ReceivedDate)
        {
            Driver.FindElement(By.Id("referralDateReceived")).SendKeys(ReceivedDate);
        }

        public static void EnterMode(IWebDriver Driver, String ModeValue)
        {
            SelectElement modeSelection = new SelectElement(Driver.FindElement(By.XPath(".//select[contains(@name, 'select-input') and contains(@class, 'form-control')]")));
            modeSelection.SelectByText(ModeValue);
        }

        public static void SelectProviderType(IWebDriver Driver, String ProviderType)
        {
            SelectElement modeSelection = new SelectElement(Driver.FindElement(By.XPath(".//select[contains(@name, 'selectProviderType') and contains(@class, 'form-control')]")));
            modeSelection.SelectByText(ProviderType);
        }
        
        public static void SelectServicesNeeded(IWebDriver Driver, String [] serviceIds)
        {
            Driver.FindElement(By.Id("selectServicesNeeded")).Click();  
            for (int i = 0; i < serviceIds.Length; i++)
            {
                Driver.FindElement(By.Id("provider"+ serviceIds[i])).GetAttribute("Id");
            }
        }

        public static void SelectSpecialPrograms(IWebDriver Driver, String SpecialProgramIds)
        {
            Driver.FindElement(By.XPath(".//input[contains(@class, 'multi-select-border') and contains(@class, 'multi-select-placeholder-color') and contains(@name, 'selectSpecialPrograms') and contains(@id, 'selectSpecialPrograms')]"))
            .Click();
            int i = 0;
            for (i = 0; i < SpecialProgramIds.Length; i++)
            {
                Driver.FindElement(By.XPath($".//input[contains(@type, 'checkbox') and contains(@id, {SpecialProgramIds[i]}")).Click();
            }
        }


        public static void EnterReferralNote(IWebDriver Driver, String ReferralNote)
        {
            Driver.FindElement(By.XPath(".//textarea[contains(@autocomplete, 'new-password') and contains(@class, 'form-control') and contains(@id, 'ReferralNote') and contains(@name, 'ReferralNote')]"))
                .SendKeys(ReferralNote);
        }




        //Shubham//

            


        public static void EnterMobileNumberField(IWebDriver Driver, String MobileNumber)
        {


            Driver.FindElement(By.XPath(".//input[contains(@id, 'patientPhoneNumber_0') and contains(@name, 'patientPhonenumber') and contains(@placeholder, '(xxx) xxx-xxxx')]"))
            .SendKeys(MobileNumber);


        }
        public static void EnterHomeNumberField(IWebDriver Driver, String HomeNumber)
        {
            Driver.FindElement(By.XPath(".//input[contains(@id, 'patienthomenumber_0') and contains(@name, 'patienthomenumber') and contains(@placeholder, '(xxx) xxx-xxxx')]"))
         .SendKeys(HomeNumber);


        }
        public static void EnterCheckBoxField(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath(".//input[contains(@id, 'policyholder') and contains(@name, 'policyholder') and contains(@type, 'checkbox')]"))
            .Click();


        }
        public static void EnterInsuranceDetailsSectionFirstNameField(IWebDriver Driver, String InsFirstName)
        {
            Driver.FindElement(By.XPath(".//input[contains(@id, 'Firstname') and contains(@name, 'FirstNameResponsibleParty')]"))
            .SendKeys(InsFirstName);
        }


        public static void EnterInsuranceDetailsSectionLastNameField(IWebDriver Driver, String InsLastName)
        {
            Driver.FindElement(By.XPath(".//input[contains(@id, 'lastname') and contains(@name, 'lastNameResponsibleParty')]"))
            .SendKeys(InsLastName);
        }


        public static void SelectInsuranceDetailsSectionRelationship(IWebDriver Driver, String InsRelationship)
        {
            SelectElement modeSelection = new SelectElement(Driver.FindElement(By.Id("Relationship_insurance")));
            modeSelection.SelectByText(InsRelationship);
        }


        public static void EnterInsuranceDetailsSectionMobileNumberField(IWebDriver Driver, String InsMobileNumber)
        {
            Driver.FindElement(By.Id("patientcellnumber")).SendKeys(InsMobileNumber);
        }


        public static void EnterInsuranceDetailsSectionHomeNumberField(IWebDriver Driver, String InsHomeNumber)
        {
            Driver.FindElement(By.XPath("//input[@name='PIhomenumber']")).SendKeys(InsHomeNumber);
        }


        public static void SelectInsuranceDetailsSectionInsuranceName(IWebDriver Driver, string insuranceNames)
        {
            int i = 0;
            List<InsuranceNameModel> InsuranceNames = JsonConvert.DeserializeObject<List<InsuranceNameModel>>(insuranceNames);

            // adds equivalent number of Insurance Name dropdowns
            for (i = 0; i < InsuranceNames.Count; i++)
            {
                Driver.FindElement(By.XPath(".//i[contains(@class, 'addMorePatientFormFieldsButtom')]")).Click();
            }


            // removes one of the Insurance Name 
            Driver.FindElement(By.XPath(".//a[contains(@class, 'removeButton show-pointer') and contains(@title, 'Remove')]")).Click();


            // Enters Values in Insurance Name dropdowns based on the strings in the array
            for (i = 0; i < InsuranceNames.Count; i++)
            {
                SelectElement insuranceDropdown = new SelectElement(Driver.FindElement(By.XPath($".//select[contains(@class, 'form-control') and contains(@id, 'Provider_{i}')]")));
                insuranceDropdown.SelectByText(InsuranceNames[i].InsuranceName);


                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'planname_{i}')]")).SendKeys(InsuranceNames[i].PlanName);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'Groupnumber_{i}')]")).SendKeys(InsuranceNames[i].GroupNumber);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'Groupname_{i}')]")).SendKeys(InsuranceNames[i].GroupName);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'memberId_{i}')]")).SendKeys(InsuranceNames[i].InsuranceMemberID);
                }



        }

        public static void ClickOnSubmit(IWebDriver Driver)
        {
            Driver.FindElement(By.CssSelector("button[name='create']")).Click();
        }
        public static void ClickOnCancel(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//button[contains(text(),'CANCEL')]")).Click();
        }

        // Add More Details Pop Up
        public static void ClickOnNo(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//button[contains(text(),'No')]")).Click();
        }

        public static void ClickOnYes(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//button[contains(text(),'Yes')]")).Click();
        }

        public static void ErrorMessage(IWebDriver Driver)
        {
            //ReadOnlyCollection <IWebElement> list = Driver.FindElements(By.XPath("//div"));
            List<IWebElement> list = Driver.FindElements(By.ClassName("error")).ToList();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                String msg = list[i].Text;
                if (msg == "Enter First Name." || msg == "Enter Last Name." || msg == "Enter Date of Birth." || msg == "Enter SSN / PID." 
                    || msg == "Select or Enter Organization" || msg == "Please select received date." ||
                    msg == "Select a Mode" || msg == "Enter Relationship.")
                {
                    Console.WriteLine(list[i].Text);
                    Test.Value.Log(Status.Info, "Enter missing information " + msg);
                }
                
            }
        }
        

        public static ReferralCreationPOM ReturnTheDriverObject()
        {
            return new ReferralCreationPOM ();
        }
    }
}
