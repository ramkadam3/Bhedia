using AngleSharp.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.Utilities;

namespace RovicareTestProject.PageObjects
{
    [TestFixture]
    public class Class1 : BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {
            string FileName = "Upload";
            int i = 2;
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;

            HandleOpenDialog hndOpen = new HandleOpenDialog();
            // hndOpen.fileOpenDialog("C:\\Users\\prata\\Rovicare\\rovicareNew\\rovicaretesting\\TestData\\SuperAdminTD", $"{FileName}{i}.png");
            string path = @$"{ProjectDirectory}\TestData\SuperAdminTD";
            hndOpen.fileOpenDialog(path, $"{FileName}{i}.png");//UploadFilePath
                                                                                                                 // hndOpen.fileOpenDialog(UploadFilePath, $"{FileName}{i}.png");//UploadFilePath
            BaseClass Base = new BaseClass();

            Driver.Value = Base.Browser(Driver.Value, SuperAdmin_Email, SuperAdmin_Password);

        }



        [Test]
        public void test()
        {

            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;


        }

    }
}
