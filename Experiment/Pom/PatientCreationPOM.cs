using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.Models;
using RovicareTestProject.Utilities;
using RovicareTestProject.Tests.PatientList;
using Newtonsoft.Json;


//using JsonReader = Newtonsoft.Json.JsonReader;

namespace RovicareTestProject.PageObjects
{
    public class PatientCreationPOM
    {
        /********************************************* Popup Form **********************************************************/
        
        public static void AddMoreIconInAddPatient(IWebDriver Driver, int cardNumber)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/descendant::add-more-icon[{cardNumber}]")));
            Driver.FindElement(By.XPath($"/descendant::add-more-icon[{cardNumber}]")).Click();
        }
        public static void EnterFirstNameField(IWebDriver Driver, String Firstname)
        {
            Driver.FindElement(By.Id("Firstname")).SendKeys(Firstname);

        }

        public static void EnterMiddleNameField(IWebDriver Driver, String MiddleName)
        {
            Driver.FindElement(By.XPath("//input[@id='MiddleName']"))
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
            if (Gender == "male")
                Driver.FindElement(By.Id("male")).Click();
            else if (Gender == "female")
                Driver.FindElement(By.Id("female")).Click();
            else
                Driver.FindElement(By.Id("other")).Click();
        }

        public static void EnterSSNPID(IWebDriver Driver, String SSN_PID)
        {
            Driver.FindElement(By.Id("SSN")).SendKeys(SSN_PID);
        }

        public static void ClickOnAddPatientButtonPopUp(IWebDriver Driver)
        {

            Driver.FindElement(By.XPath("//add-patient-dialog/descendant::button[@name= 'create']")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='col-md-4 ']")));


            String XPath = (String)GetLocatorFromJson()["AddPatientPopup"]["AddPatientButton"];
             Driver.FindElement(By.XPath(XPath))
                .Click();
        }

        /********************************************* Popup Form Ends **********************************************************/

        /********************************************* Add Patient Form **********************************************************/
        public static void WaitForAllCardsToAppearInPatientCreationForm(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));

            String[] CardIds = PatientAttributeCardIds.GetPatientAttributeCardIds().ToArray();
            
            foreach(String CardId in CardIds)
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(CardId)));
            }
            
        }

        public static void InsuranceDetailsAddAllFields(IWebDriver Driver, InsuranceNameModel[] insuranceNames)
        {
            String XPath;
           

            // adds equivalent number of Insurance Name dropdowns
            for (int i = 0; i < insuranceNames.Length; i++)
            {
                //Driver.FindElement(By.XPath(".//i[contains(@class, 'addMorePatientFormFieldsButtom')]")).Click();
                XPath = (String)GetLocatorFromJson()["PatientCreationForm"]["AddInsuranceField"];
                Driver.FindElement(By.XPath(XPath)).Click();
            }

            // removes one of the Insurance Name 
            XPath = (String)GetLocatorFromJson()["PatientCreationForm"]["RemoveInsuranceField"];
            Driver.FindElement(By.XPath(XPath)).Click();

            // Enters Values in Insurance Name dropdowns based on the strings in the array
            for (int i = 0; i < insuranceNames.Length; i++)
            {
                SelectElement insuranceDropdown = new SelectElement(Driver.FindElement(By.XPath($".//select[contains(@class, 'form-control') and contains(@id, 'Provider_{i}')]")));
                insuranceDropdown.SelectByText(insuranceNames[i].InsuranceName);


                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'planname_{i}')]")).SendKeys(insuranceNames[i].PlanName);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'Groupnumber_{i}')]")).SendKeys(insuranceNames[i].GroupNumber);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'Groupname_{i}')]")).SendKeys(insuranceNames[i].GroupName);
                Driver.FindElement(By.XPath($".//input[contains(@class, 'form-control') and contains(@id, 'memberId_{i}')]")).SendKeys(insuranceNames[i].InsuranceMemberID);
            }

        }                           
        
        // Add Diagnosis Popup starts
        public static void AddDiagnosisEnterDataInAllFields(IWebDriver Driver, DiagnoisPopupFieldsModel[] DiagnosisData, Boolean? Submit = null)
        { 
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            // this step adds presses the blue plus icon repeatedly to add equivalent fields as the array
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//add-diagnosis/descendant::i[contains(@class, 'fa-plus-circle')]")));
            for (int i = 1; i < DiagnosisData.Length; i++)
            {                      
                Driver.FindElement(By.XPath("//add-diagnosis/descendant::i[contains(@class, 'fa-plus-circle')]"))
                    .Click();
            }

            int Index = 0;
            foreach (DiagnoisPopupFieldsModel Diagnosis in DiagnosisData)
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Code_0")));
                Driver.FindElement(By.Id("Code_" + Index)).SendKeys(Diagnosis.Code);

                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Date_0")));
                Driver.FindElement(By.Id("Date_" + Index)).SendKeys(Diagnosis.Date);

                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Description_0")));
                Driver.FindElement(By.Id("Description_" + Index)).SendKeys(Diagnosis.Description);

                Index++;
            }

            if(Submit != null)
            {
                ClickSubmitButtonInAddDiagnosisPopup(Driver);
            }
        }

        public static void AddDiagnosisEnterCode(IWebDriver Driver, String[] Code)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Code_0")));

            int Index = 0;
            foreach(String code in Code)
            {
                Driver.FindElement(By.Id($"Code_{Index}"))
                    .SendKeys(code);
                Index++;
            }    
        }

        public static void AddDiagnosisEnterDate(IWebDriver Driver, String[] Date)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Date_0")));

            int Index = 0;
            foreach (String code in Date)
            {
                Driver.FindElement(By.Id("Date_" + Index))
                    .SendKeys(code);
                Index++;
            }
        }

        public static void AddDiagnosisEnterDescription(IWebDriver Driver, String[] Descriptions)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Date_0")));

            int Index = 0;
            foreach (String description in Descriptions)
            {
                Driver.FindElement(By.Id($"Date_{Index}"))
                    .SendKeys(description);
                Index++;
            }
        }

        public static void ClickSubmitButtonInAddDiagnosisPopup(IWebDriver Driver)
        {
            String XPath = (string)GetLocatorFromJson()["PatientCreationForm"]["Diagnosis"]["SubmitButton"];
            Driver.FindElement(By.XPath(XPath))
                .Click();
        }
        // Add Diagnosis Popup ends


        // Add Allergy Popup starts
        public static void AddAllergy_EnterDataInAllFields(IWebDriver Driver, AllergyPopupModel[] Allergies, Boolean? Submit = null)
        {          
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            // this step adds presses the blue plus icon repeatedly to add equivalent fields as the array
            for (int i = 1; i < Allergies.Length; i++)
            {
                Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["Allergy"]["AddMoreFieldsButton"]))
                    .Click();
            }
            int Index = 0;
            foreach (AllergyPopupModel AllergyData in Allergies)
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("allergy_status_0")));

                SelectElement Selection = new SelectElement(Driver.FindElement(By.Id("allergy_status_" + Index)));
                Selection.SelectByText(AllergyData.Status);

                Selection = new SelectElement (Driver.FindElement(By.Id("allergy_categor_" + Index)));
                Selection.SelectByText(AllergyData.Category);

                Selection = new SelectElement (Driver.FindElement(By.Id("allergy_type_" + Index)));
                Selection.SelectByText(AllergyData.Type);
                
                Selection = new SelectElement (Driver.FindElement(By.Id("allergy_serverity_" + Index)));
                Selection.SelectByText(AllergyData.Severity);

                Driver.FindElement(By.Id("allergen_Name" + Index)).SendKeys(AllergyData.AllergyName);
                
                Index++;
            }

            if (Submit != null)
            ClickSubmitButtonInAddAllergyPopup(Driver);
        }

        public static void ClickSubmitButtonInAddAllergyPopup(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["Allergy"]["SubmitButton"]))
                .Click();
        }
        // Add Allergy Popup ends here

        // Add Immunization Popup Starts here
        public static void AddImmunizationEnterDataInAllFields(IWebDriver Driver, ImmunizationPopupModel[] Immunizations, Boolean? Submit = null)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("CreatedDates_0")));

            for (int i = 1; i < Immunizations.Length; i++)
            {
                Driver.FindElement(By.XPath("//add-immunization-old/descendant::i[contains(@class, 'fa-plus-circle')]"))
                    .Click();
            }

            int Occurence = 0;
            foreach (ImmunizationPopupModel Immunization in Immunizations)
            {
                Driver.FindElement(By.Id("CreatedDates_" + Occurence)).SendKeys(Immunization.DateGiven);
                Driver.FindElement(By.XPath("//h4[@class='modal-title margin-top-8 ng-star-inserted']")).Click();
                Driver.FindElement(By.Id("Immunization_" + Occurence)).SendKeys(Immunization.Immunization);
                Driver.FindElement(By.Id("Step_" + Occurence)).SendKeys(Immunization.Step);

                SelectElement ConsentStatusSelection = new SelectElement(Driver.FindElement(By.Id("ConsentStatus_" + Occurence)));
                ConsentStatusSelection.SelectByText(Immunization.ConsentStatus);

                Driver.FindElement(By.Id("Location_" + Occurence)).SendKeys(Immunization.LocationGiven);

                Occurence++;
            }

            if (Submit != null)
            {
                
                ClickSubmitButtonInAddImmunization(Driver);
            }
        }

        public static void ClickSubmitButtonInAddImmunization(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["Immunization"]["SubmitButton"]))
                .Click();
        }

        // Add Immunization Popup Ends here

        // Add Medication Popup Starts here
        public static void AddMedicationEnterDataInAllFields(IWebDriver Driver, MedicationPopupModel[] Medications, Boolean? Submit = null)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("DrugID_0")));

            for (int i = 1; i < Medications.Length; i++)
            {
                Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["AddMoreFields"]))
                    .Click();
            }

            int Occurence = 0;
            foreach (MedicationPopupModel Medication in Medications)
            {
                Driver.FindElement(By.Id("DrugID_" + Occurence)).SendKeys(Medication.DrugId);
                Driver.FindElement(By.Id("Generic_" + Occurence)).SendKeys(Medication.DrugName);
                Driver.FindElement(By.Id("Strength_" + Occurence)).SendKeys(Medication.Strength);

                SelectElement Selection = new SelectElement(Driver.FindElement(By.XPath(
                    InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["StrengthUnit"], new string[]{ (Occurence + 1).ToString() }
                    ))));

                SelectFromDropDownCaseInsensitive(Selection, Medication.StrengthUnit);      

                Driver.FindElement(By.Id("StartDate_" + Occurence))
                    .SendKeys(Medication.StartDate);

                Driver.FindElement(By.Id("EndDate_" + Occurence))
                    .SendKeys(Medication.EndDate);

                Driver.FindElement(By.Id("Description_" + Occurence))
                    .SendKeys(Medication.Description);

                // entering schedules
                // first, add equivalent fields
                for (int i = 1; i < Medication.Schedules.Length; i++)
                {
                    Driver.FindElement(By.XPath(
                        InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["AddMoreSchedules"], new String[] { (Occurence + 1).ToString() })
                        ))
                        .Click();
                }

                int ScheduleNumber = 0;
                foreach (MedicationScheduleModel Schedule in Medication.Schedules)
                {        
                    // Dose
                    Driver.FindElement(By.Id($"Dose_{Occurence}{ScheduleNumber}"))
                        .SendKeys(Schedule.Dose);

                    // Dose Unit
                    Selection = new SelectElement(Driver.FindElement(By.XPath(InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["DoseUnit"],
                        new String[] {Occurence.ToString(), ScheduleNumber.ToString() }))));

                    SelectFromDropDownCaseInsensitive(Selection, Schedule.DoseUnit);

                    // Schedule Type
                    Selection = new SelectElement(Driver.FindElement(By.XPath(InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["ScheduleType"],
                        new String[] { (Occurence + 1).ToString(), (ScheduleNumber + 1).ToString() }))));

                    SelectFromDropDownCaseInsensitive(Selection, Schedule.ScheduleType);

                    // Frequency
                    Selection = new SelectElement(Driver.FindElement(By.XPath(InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["Frequency"],
                       new String[] { (Occurence + 1).ToString(), (ScheduleNumber + 1).ToString() }))));

                    SelectFromDropDownCaseInsensitive(Selection, Schedule.Frequency);

                    // Start Date
                    Driver.FindElement(By.Id(InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["ScheduleStartDate"], 
                        new String[] { Occurence.ToString(), ScheduleNumber.ToString() })))
                        .SendKeys(Schedule.StartDate);

                    // End Date
                    Driver.FindElement(By.Id(InterpolateIntoString((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["ScheduleEndDate"],
                        new String[] { Occurence.ToString(), ScheduleNumber.ToString() })))
                        .SendKeys(Schedule.EndDate);
                    
                    ScheduleNumber++;
                }

                Occurence++;
            }

            if (Submit != null)
            ClickSubmitButtonInAddMedicationPopup(Driver);
           
        }

        public static void ClickSaveButtonPatientCreationFullPage(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath("//button[@name='create']"))
                .Click();
        }


        public static void ClickSubmitButtonInAddMedicationPopup(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["Medication"]["SubmitButton"]))
                .Click();
        }
        // Add Medication Popup Ends here

        // Add Progress Notes Starts here
        public static void AddProgressNoteEnterDataInAllFields(IWebDriver Driver, ProgressNotesModel[] ProgressNotes, Boolean? Submit = null)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("EffectiveDates_0")));

            for (int i = 1; i < ProgressNotes.Length; i++)
            {
                Driver.FindElement(By.XPath("//add-progress-note/descendant::i[contains(@class, 'fa-plus-circle')]"))
                    .Click();
            }
          
            int Progress = 0;
            foreach (ProgressNotesModel ProgressNote in ProgressNotes)
            {
                Driver.FindElement(By.Id("EffectiveDates_" + Progress)).SendKeys(ProgressNote.EffectiveDate);
                Driver.FindElement(By.Id("Types_" + Progress)).SendKeys(ProgressNote.Type);
                Driver.FindElement(By.Id("Notes_" + Progress)).SendKeys(ProgressNote.Note);
                Progress++;
            }

            // Removing field in Progress Notes
            Driver.FindElement(By.XPath("//add-progress-note/descendant::span[@Class='delete-medication']/descendant::i[contains(@title, 'Delete')]"))
                  .Click();
            if (Submit != null)
            {
                ClickSubmitButtonInAddProgressNote(Driver);
            }
        }
        public static void ClickSubmitButtonInAddProgressNote(IWebDriver Driver)
        {
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["ProgressNote"]["SubmitButton"]))
                .Click();
        }
        // Add Progress Notes Ends here

        // Medical Information Section Starts here
        public static void EnterNotesInMedicalInformation(IWebDriver Driver, String Notes)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("EffectiveDates_0")));
            Driver.FindElement(By.XPath((string)GetLocatorFromJson()["PatientCreationForm"]["MedicalInformation"]["Notes"]))
                .SendKeys(Notes);
        }

        // Medical Information Section Ends here


        /******************************************************** Generic Methods ***************************************************************/
        // Methods for json related actions
        public static JObject GetLocatorFromJson ()
        {
            return GetDataParser().GetJSonObjectFromFile(@"\Locators\PatientCreationForm.json");
        }

        public static PatientList_JSonReader GetDataParser()
        {
            return new PatientList_JSonReader() ;
        }
        // Methods for json related actions end here

        public static void SelectFromDropDownCaseInsensitive(SelectElement Select, String Choice)
        {
            foreach (WebElement Option in Select.Options)
            {
                if (Option.Text.ToLower().Trim() == Choice.ToLower().Trim())
                    Select.SelectByText(Option.Text);
            }
        }

        // Method to interpolate dynamic values in locators
        public static String InterpolateIntoString(String Locator, String[] Values)
        {
            String[] Fragments = Locator.Split("{{}}");
            // Guard Clause
            if (Fragments.Length != (Values.Length + 1))
                return Locator;

            String InterpolatedString = "";
            int Index = 0;
            foreach (var Fragment in Fragments)
            {
                InterpolatedString += Fragment;

                if(Index < Values.Length)
                InterpolatedString += Values[Index];

                Index++;
            }
             return InterpolatedString;
        }
        // Method to interpolate dynamic values in locators ends here

    }
}
