    using AventStack.ExtentReports;
    using Experiment.Config;
    using MongoDB.Driver;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Experiment.BasePackage;

namespace Experiment.Test

    {
        public class TestSuite_PatientList_PatientListPage : BaseClass
    {
            [SetUp]
            public void BrowserLaunch()
            {

                BaseClass Base = new BaseClass();
                Driver = Base.Browser(Driver, Origin_Email, Origin_Password);

            }

            //*************************************************Test Execution E2E_SearchField_patientlist*********************************************************//


            [Test, Order(1)]
            [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]

            [TestCaseSource("SearchField_TD")]
            public void Test_SearchField
                (
                string Tags,
                string TrackedBy,
                string PlaceHolderWhenAllSelectedTag_Patient)
            {
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            try
            {
                FiltersPOM.ClearFilter_PatientList(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            }
            catch { }


            //Test_SearchField_001 - To verify that the Status search field working properly
                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_001 - To verify that the Status search field working properly");
            try
            {
                int Count = 0;
                SelectElement Selectstatus = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1);
                try
                {
                    // Navigate to Status column
                    try
                    {

                        for (int i = 1; i < Selectstatus.Options.Count(); i++)
                        {
                            FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1.Click();

                            //Thread.Sleep(1000);
                            CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item2);
                            string status = FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1.GetAttribute("value");
                            Count++;
                            Test.Value.Log(Status.Pass, $"Test_SearchField_001- '{status}' is selected from status drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            // PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                            try
                            {
                                Assert.That(PatientListPOM.CheckStatusOfAllRows(Driver.Value, status));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_001- All status are same as '{status}'", CaptureScreenShot(Driver.Value, Filename));

                            }
                            catch
                            {
                                Assert.That(PatientListPOM.CheckNoRecordsFound(Driver.Value));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_001- No Records Found for '{status}'", CaptureScreenShot(Driver.Value, Filename));
                            }
                            Thread.Sleep(500);

                        }
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_001- Status filter is not working properly  Error:{e},Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    // Resetting Mode to All Patients

                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item2, "Up", Count);

                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SearchField_001- Status filter is not working properly  Error:{ex},Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item2, "Up", Count);

                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                }
            }
            catch { }


            //Test_SearchField_002 - To verify that Tags Search field working properly
                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_002 - To verify that Tags Search field working properly");
            try
            {
                            Actions Act = new Actions(Driver.Value);
                    try
                    {

                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, $"Test_SearchField_002- All tag selected from drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                           // Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    
                          Assert.That(FiltersPOM.CheckAllTagsSelected(Driver.Value));
                          Test.Value.Log(Status.Pass, $"Test_SearchField_002 - Once click on All-Tag  all remaining tags have been selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_002 - All tag not working properly Screenshot: "+e, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try 
                    {
                    
                        Assert.That(FiltersPOM.CheckPlaceholder_Tags(Driver.Value, PlaceHolderWhenAllSelectedTag_Patient));
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - Once click on All-Tag  placeholder reflects text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_002 -Tag placeholder do not reflects correct text Screenshot: " + e  , CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {

                       // Actions Act = new Actions(Driver.Value);
                        Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    FiltersPOM.SelectTaginFilter(Driver.Value, Tags);
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - All tags are selected except 'All' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(FiltersPOM.CheckAllTagsSelected(Driver.Value));
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - All-tag is selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(FiltersPOM.CheckPlaceholder_Tags(Driver.Value, PlaceHolderWhenAllSelectedTag_Patient));
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - The placeholder of Tags filter reflects correct text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_002 - All-Tag feature not working properly Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    try
                    {//select multiple tags
                        string[] tag=Tags.Split("|").ToArray();

                     string tag2=(tag[1]+"|"+tag[2]).ToString();
                    
                    foreach (string Tag in tag2.Split("|"))
                        {

                        FiltersPOM.SelectTaginFilter(Driver.Value, Tag);
                            Test.Value.Log(Status.Pass, $"Test_SearchField_002 - '{Tag}' selected among drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        //Actions Act = new Actions(Driver.Value);
                        Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    try
                    {

                    Assert.That(FiltersPOM.CheckTagOfAllRows(Driver.Value, tag2));
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - Search action has been done for multiple tags successfully Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }catch
                    {
                        CommonPOM.CheckNoRecordsFound(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SearchField_002 - Search action has been done for multiple tags successfully: No Records Found: Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_002 - Unable to do search action for selected tags Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    

                }
                finally
                {
                    FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                    if (FiltersPOM.CheckAllTagsSelected(Driver.Value, "All"))
                        FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    else
                    {
                        FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                        FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                        //Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                        FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    }
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
            }
             catch(Exception e)
            {
                    Test.Value.Log(Status.Fail, $"Test_SearchField_002 - Tag filter not working properly for selected tags Screenshot: "+e, CaptureScreenShot(Driver.Value, Filename));
                if (FiltersPOM.CheckAllTagsSelected(Driver.Value, "All"))
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                else { FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                }
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            }











            

                //Test_SearchField_003 - To verify that Tracked By Search field working properly
                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_003 - To verify that Tracked By Search field working properly");
                try
                {
                    foreach (String by in TrackedBy.Split("|"))
                    {
                    FiltersPOM.SelectTrackedByFilter(Driver.Value, by);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        //PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SearchField_003- Tracked By filter set to '{by}' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                        int tempp = Driver.Value.FindElements(By.XPath("//div[@class='row_container']")).Count();
                         try
                         {
                            for (int i = 1; i <= tempp; i++)
                            {
                                PatientListPOM.OpenMoreActions(Driver.Value, i);
                                Assert.That(PatientListPOM.MoreAction_DropDown(Driver.Value, i, "Track").Displayed);
                                Driver.Value.FindElement(By.XPath($"//descendant::tr[{i + 1}]/descendant::div[contains(@class,'status-badge-container')]")).Click();
                            }
                            Test.Value.Log(Status.Pass, $"Test_SearchField_003- Tracked By filter searching out succesfully for '{by}' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                         }
                        catch 
                         {
                            Assert.That(PatientListPOM.CheckNoRecordsFound(Driver.Value));
                            Test.Value.Log(Status.Pass, $"Test_SearchField_003- No Records Found for '{by}'", CaptureScreenShot(Driver.Value, Filename));

                         }
                    }

                FiltersPOM.SelectTrackedByFilter(Driver.Value, "All");
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_SearchField_003- Unable to do search tracked by filter  Error: {e}, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                FiltersPOM.SelectTrackedByFilter(Driver.Value, "All");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                }


                //Test_SearchField_004 - To verify that the Insurance filter working properly
                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_004 - To verify that the Insurance filter working properly");
                try
                {
                    // Navigate to TrackedBy filter






                    SelectElement Selectinsurance = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item1);
                        int Count=0;
                    try
                    {

                        for (int i = 1; i < 10; i++)
                        {
                        Count++;
                        FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item1.Click();

                            Thread.Sleep(1000);
                            CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item2);
                            string Insurance = FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item1.GetAttribute("value");
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            //PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                            Test.Value.Log(Status.Pass, $"Test_SearchField_004- '{Insurance}' is slected from insurance drop-down ", CaptureScreenShot(Driver.Value, Filename));
                            try
                            {
                                Assert.That(PatientListPOM.CheckInsuranceOfAllRows(Driver.Value, Insurance));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_004- All patients have same insurance as '{Insurance}'", CaptureScreenShot(Driver.Value, Filename));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_004- Insurance filter working properly");
                            }
                            catch
                            {
                                Assert.That(PatientListPOM.CheckNoRecordsFound(Driver.Value));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_004- No Records Found for '{Insurance}'", CaptureScreenShot(Driver.Value, Filename));
                                Test.Value.Log(Status.Pass, $"Test_SearchField_004- Insurance filter working properly");
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SearchField_004- status filter is not working properly", CaptureScreenShot(Driver.Value, Filename));

                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item2,"Up",Count);
                    
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                // Resetting Mode to All Patients

                CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Insurance").Item2, "Up", Count);
                
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SearchField_004- status filter is not working properly", CaptureScreenShot(Driver.Value, Filename));
                }


                //Test_SearchField_005 - To verify that the Mode filter working properly
                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_005 - To verify that the Mode filter working properly");
                try
                {
                    // Navigate to TrackedBy filter


                    SelectElement SelectMode = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1);

                int Count = 0;


                    try
                    {

                        for (int i = 1; i < SelectMode.Options.Count; i++)
                        {
                        Count++;
                        FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.Click();

                            Thread.Sleep(1000);
                            CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item2);
                            string Mode = FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.GetAttribute("value");
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            //PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                            Test.Value.Log(Status.Pass, $"Test_SearchField_005- '{Mode}' is slected from Mode drop-down ", CaptureScreenShot(Driver.Value, Filename));
                            int temp = Driver.Value.FindElements(By.XPath("//descendant::tr")).Count;
                            try
                            {
                                for (int j = 1; j < temp && j < 5; j++)
                                {
                                    if (Mode.ToLower().Contains("inactive"))
                                    {
                                        Assert.That(Driver.Value.FindElement(By.XPath($"//descendant::tr[{j + 1}]/descendant::button[@title='Enable Patient']")).Displayed);
                                        Test.Value.Log(Status.Pass, $"Test_SearchField_005", CaptureScreenShot(Driver.Value, Filename));

                                    }




                                    else
                                    {
                                        try
                                        {
                                            //Click on More Actions to open all the options
                                            PatientListPOM.OpenMoreActions(Driver.Value, j);

                                            //Verify that Disable Patient is showing up
                                            Assert.That(PatientListPOM.MoreAction_DropDown(Driver.Value, j, "Disable Patient").Displayed);
                                            Driver.Value.FindElement(By.XPath($"//descendant::tr[{j + 1}]/descendant::div[contains(@class,'status-badge-container')]")).Click();
                                            Test.Value.Log(Status.Pass, $"Test_SearchField_005- ", CaptureScreenShot(Driver.Value, Filename));

                                        }
                                        catch (Exception ex)
                                        {
                                            Test.Value.Log(Status.Fail, "Test_SearchField_005- Unable to do search action by Mode filter " + ex, CaptureScreenShot(Driver.Value, Filename));
                                        }
                                    }

                                }
                                Test.Value.Log(Status.Pass, $"All rows have same mode as '{Mode}'", CaptureScreenShot(Driver.Value, Filename));

                            }
                            catch
                            {
                                Assert.That(PatientListPOM.CheckNoRecordsFound(Driver.Value));
                                Test.Value.Log(Status.Pass, $"No Records Found for '{Mode}'", CaptureScreenShot(Driver.Value, Filename));
                            }

                        }

                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item2,"Up",Count);
                    
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);


                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Mode filter is not working properly", CaptureScreenShot(Driver.Value, Filename));
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item2, "Up", Count);
                    
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                    // Resetting Mode to All Patients
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Mode filter is not working properly", CaptureScreenShot(Driver.Value, Filename));
                }


     




                //Test_SearchField_006- To verify that the by-patient-name filter can do searching properly


                    Test.Value = ExtentTestManager.CreateTest("Test_SearchField_PatientList_006- To verify that the by-patient-name filter can do searching properly");
                try
                {
                    string PatientName = CommonPOM.GetPatientNameFromList(Driver.Value);
                FiltersPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Assert.That(PatientName.Contains(CommonPOM.GetPatientNameFromList(Driver.Value)));


                    Test.Value.Log(Status.Pass, "Test_SearchField_006- Search action done by patient name successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_SearchField_006- Unable to search by patient name Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }












            }


        //***************************************** Test Data *********************************************************//
        //PlaceHolderWhenAllSelectedTag_Patient
        public static IEnumerable<TestCaseData> SearchField_TD()
            {
                String Path = GetDataParser().TestData_Path("SearchField_TD");
                yield return new TestCaseData(
                                                            
                    GetDataParser().TestData("Tags", Path),
                    GetDataParser().TestData("TrackedBy", Path),
                    GetDataParser().TestData("PlaceHolderWhenAllSelectedTag_Patient", Path)
                    );
            }


            //***************************************** Test Execution *********************************************************//

        
       
        }

    }
