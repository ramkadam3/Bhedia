using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace RovicareTestProject.Tests.SuperAdmin
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_UserManagement_SuperAdmin : BaseClass
    {

        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, SuperAdmin_Email, SuperAdmin_Password);

        }
        [Test, Order(1)]
        public void Usermanagement()
        {
            
            string time = Time.TimeOfDay.ToString("hhmmss");
            string OrganizationName = $"DemoClient{time}";
            string[] MaxMemberMessage =  {"Success! Member information added.","Try to add a maximum of members as per  plan.", "Success! Member information updated." };
            //TestContext

            // Create Precondition required
            try
            {

                AddOrganizationList_AdminPOM.AddNewOrganization(Driver.Value, OrganizationName);
                try
                {
                Test.Value = ExtentTestManager.CreateTest($"Test_Usermanagement - Create Precondition required");
                    AddOrganizationList_AdminPOM.NavigateToOrganizationListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate to Organization list page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.SearchOrganizationByName(Driver.Value, OrganizationName);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "Search created organization by name");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(AddOrganizationList_AdminPOM.GetOrganizationNameFromList(Driver.Value).ToLower().Contains(OrganizationName.ToLower()));
                    Test.Value.Log(Status.Pass, "the new Organization added successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to add new organization Error: "+e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            catch
            {

            }

            try 
            {
                Test.Value = ExtentTestManager.CreateTest($"Test_Usermanagement 001 -To verify that the user management feature navigates to user management pop-up");

                PatientListPOM.OpenMoreActions(Driver.Value, 1);
                Test.Value.Log(Status.Pass, "Expand more action feature");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "User Management").Click();
                Test.Value.Log(Status.Pass, "Select 'user management' feature");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Assert.That(AddOrganizationList_AdminPOM.AddMultipleMemberButton_UsermanagementPOPup(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "User management feature navigates usermanagement pop-up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch(Exception e)
            {

                Test.Value.Log(Status.Fail, "Unable to navigate usermanagement pop-up Error: "+e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


            }
            //To verify that the add member feature working properly
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 002 - To verify that the add member feature working properly");
                
                for (int i = 1; i <=6; i++)
                {

                        string MessageText = MaxMemberMessage[0];
                    try
                    {
                        
                        AddOrganizationList_AdminPOM.ClickOnAddMemberButton_UsermanagementPOPup(Driver.Value);
                        //CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Thread.Sleep(1000);
                        Test.Value.Log(Status.Pass, "Click on add member button & navigate to add member pop-up");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        if (i <=10)
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email ID", $"Democlient{Time.ToString("hhmmssffff")}.{i}@interbizconsulting.com");
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Password", "RoviPass@321");
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Confirm Password", "RoviPass@321");
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "First Name", $"DemoAdmin{i}");
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Last Name", "AdminDemo");
                            AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Designation", "CEO");
                            AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Role", "Organization Admin");
                            Test.Value.Log(Status.Pass, "Provide required data to add member pop-up");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            AddOrganizationList_AdminPOM.ClickOnSave_AddMemberPOPup(Driver.Value);
                            Test.Value.Log(Status.Pass, "Click on save button");
                            BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                            Assert.That(AddOrganizationList_AdminPOM.CheckOktext_Confirmation_AddMemberPOPup(Driver.Value, MaxMemberMessage[0]).Displayed);
                            Test.Value.Log(Status.Pass, "Checked the message displaying on pop-up");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        else
                        {
                            MessageText = MaxMemberMessage[1];
                            Assert.That(AddOrganizationList_AdminPOM.CheckOktext_Confirmation_AddMemberPOPup(Driver.Value, MaxMemberMessage[1]).Displayed);
                            Test.Value.Log(Status.Pass, "Checked the MaxExid message displaying on pop-up");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Unable to add member for new organization" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, MessageText);
                        Test.Value.Log(Status.Pass, "Click on ok button on pop-up");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }

                Test.Value.Log(Status.Pass, "Add Member feature is working properly");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
                
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Add Member feature is not working properly Error: "+e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


            }


            //To verify that using Edit member action item member details can be edited	
            							
            
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 003 - To verify that using Edit member action Member details can be edited");

                AddOrganizationList_AdminPOM.ClickOnActionItem_UsermanagementPOPup(Driver.Value, "Edit Member", 1).Click();
                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Mobile Number", "(111) 111-1111");
                AddOrganizationList_AdminPOM.ClickOnSave_AddMemberPOPup(Driver.Value);
                AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, MaxMemberMessage[2]);
                Thread.Sleep(1000);
                Assert.That(AddOrganizationList_AdminPOM.CheckMobileNumbers_UsermanagementPOPup(Driver.Value, 1).Text.Contains("(111) 111-1111"));

                Test.Value.Log(Status.Pass, "Edit member feature is working properly");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Edit member feature is not working properly Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            finally
            {
                AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, "Error");
            }
            //To verify the Assign role feature shows the Assigned role of the member
            try
            {
                Thread.Sleep(2000);
                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 004 - To verify the Assign role feature shows the Assigned role of the member");
                string ReadRole=AddOrganizationList_AdminPOM.ReadRoleOfMember_UsermanagementPOPup(Driver.Value,1).Text;
                AddOrganizationList_AdminPOM.ClickOnActionItem_UsermanagementPOPup(Driver.Value, "Assign Role", 1).Click();
                Assert.That(AddOrganizationList_AdminPOM.CheckRoleOnAssignRolePopUp_UsermanagementPOPup(Driver.Value,ReadRole).Displayed);
                Test.Value.Log(Status.Pass, "Assign role feature is working properly");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, "Assign role feature is not working properly Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {
                AddOrganizationList_AdminPOM.CloseAssignRolePopUp(Driver.Value);
            }
            
            
            
            
            //To verify the disable member feature disables the member
            try
            {
                System_Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 005 - To verify the disable member feature disables the member");
                AddOrganizationList_AdminPOM.ClickOnActionItem_UsermanagementPOPup(Driver.Value, "Disable Member", 1).Click();
                Thread.Sleep(2000);
                AddOrganizationList_AdminPOM.ClickOnYes_Enable_DisablePop_up(Driver.Value);
                Assert.That(Success_Notification(Driver.Value).Displayed);
                                                                                                                  //Validation required
                


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Desable member feature is not working properly Error: "+e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //To verify the Status filter working properly
                string statusValue=null;
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 006 - To verify the Status filter working properly ");
                SelectElement El = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1);
                El.SelectByText("All");
                
                for (int j=2;j<=El.Options.Count();j++)
                {
                    try
                    {
                    
                       FiltersPOM.ClickOnFilter(Driver.Value,"Status").Item1.Click();
                        CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item2);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        statusValue=El.SelectedOption.Text;
                        //statusValue=FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1.Text;
                        for (int i=1;i < AddOrganizationList_AdminPOM.CheckRowsCount_UsermanagementPOPup(Driver.Value);i++)
                        {
                            string? CheckValue="";
                            try
                            {
                                if (statusValue.ToLower().Contains("inactive".ToLower()))
                                    CheckValue = "Enable Member";
                                else if (statusValue.ToLower().Contains("active".ToLower()))
                                    CheckValue = "Disable Member";
                                

                               if (AddOrganizationList_AdminPOM.ClickOnActionItem_UsermanagementPOPup(Driver.Value, CheckValue, i).Displayed)
                                  Assert.That(true);
                                  Test.Value.Log(Status.Pass, $"{CheckValue} is available in a Rownumber '{i}' " );
                                  Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                                if (statusValue.ToLower().Contains("inactive".ToLower()))
                                {

                                    Test.Value.Log(Status.Pass, $"Status filter working properly for status '{statusValue}' ");
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                                }
                            }
                            catch(Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"{CheckValue} is not available in a Rownumber '{i}' Error: " + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }

                        }
                        
                    }
                    catch 
                    {
                        Test.Value.Log(Status.Fail, $"Status filter working properly for status '{statusValue}' ");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                


                
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Status filter is not working properly for status '{statusValue}' ");
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {


                FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item1.Click();
                CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Status").Item2,"Up",4);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            }
            //To verify the Disignation filter working properly 
            string Designation =null;
            try
            {

                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 007 - To verify the Disignation filter working properly ");
                SelectElement El = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Designation").Item1);
                //El.SelectByText("All");
                for(int i=1;i<= El.Options.Count();i++)
                {
                    try {
                    
                    
                          FiltersPOM.ClickOnFilter(Driver.Value, "Designation").Item1.Click();
                           CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Designation").Item2);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                             Designation = El.SelectedOption.Text;
                        if (Designation.Contains("CEO"))
                            Designation = "Ceo";
                        try 
                        {
                        
                              AddOrganizationList_AdminPOM.CheckDesignationOfeachMember_UsermanagementPOPup(Driver.Value,Designation);
                            Test.Value.Log(Status.Pass, $"Designation of all rows are same '{Designation}' ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch
                        {
                            if(CommonPOM.CheckNoRecordsFound(Driver.Value))
                            Test.Value.Log(Status.Pass, $"No records found for Designation '{Designation}' ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }   


                        

                    }
                    catch {

                        Test.Value.Log(Status.Fail, $"Designation of all rows are not same '{Designation}' ");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }






                }

                



            }
            catch
            {

                Test.Value.Log(Status.Fail, $"Designation filter is not working properly ");
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));



            }
            finally
            {
                FiltersPOM.ClickOnFilter(Driver.Value, "Designation").Item1.Click();
                CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Designation").Item2,"Up",10);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            }
            //To verify the Role filter working properly 
            string Role = null;
            try
            {

                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 008 - To verify the Role filter working properly ");
                SelectElement El = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Role").Item1);
                El.SelectByText("All");
                for (int i = 1; i < El.Options.Count(); i++)
                {
                    try
                    {


                        FiltersPOM.ClickOnFilter(Driver.Value, "Role").Item1.Click();
                        CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Role").Item2);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Role = El.SelectedOption.Text;
                        
                        AddOrganizationList_AdminPOM.CheckRoleOfAllMember_UsermanagementPOPup(Driver.Value, Role);


                        Test.Value.Log(Status.Pass, $"Role of all rows are same '{Role}' ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch(Exception e)
                    {

                        Test.Value.Log(Status.Fail, $"Role of all rows are not same '{Role}' "+e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }






                }





            }
            catch
            {

                Test.Value.Log(Status.Fail, $"Role filter is not working properly ");
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));



            }
            finally
            {
                FiltersPOM.ClickOnFilter(Driver.Value, "Role").Item1.Click();
                CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Role").Item2, "Up", 10);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            }



            try 
            {

                Test.Value = ExtentTestManager.CreateTest("Test_Usermanagement 009 - To verify the search By Name filter working properly ");
                string NameInput = "Demoadmin1";
                AddOrganizationList_AdminPOM.SearchByName_UsermanagementPOPup(Driver.Value, NameInput);

                AddOrganizationList_AdminPOM.CheckNameOfeachMember_UsermanagementPOPup(Driver.Value, NameInput);
                Test.Value.Log(Status.Pass, $"Searching By-Name working properly  ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch 
            {
                Test.Value.Log(Status.Fail, $"Searching By-Name not working properly  ");
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
        }


    }
}
