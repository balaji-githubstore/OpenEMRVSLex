using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using UnitedLex.OpenEmrAutomation.Base;
using UnitedLex.OpenEmrAutomation.Pages;
using UnitedLex.OpenEmrAutomation.Utilities;

namespace UnitedLex.OpenEmrAutomation
{
    public class LoginTest : WebDriverWrapper
    {
        //admin,pass,English (Indian),OpenEMR
        //physician,physician,English (Indian),OpenEMR
        public static object[] ValidCredentialTestData()
        {
            object[] temp1 = new object[4]; //number of paramter
            temp1[0] = "admin";
            temp1[1] = "pass";
            temp1[2] = "English (Indian)";
            temp1[3] = "OpenEMR";

            object[] temp2 = new object[4]; //number of parameter
            temp2[0] = "physician";
            temp2[1] = "physician";
            temp2[2] = "English (Indian)";
            temp2[3] = "OpenEMR";

            //object[] temp3 = new object[4]; //number of parameter
            //temp3[0] = "clinician";
            //temp3[1] = "clinician";
            //temp3[2] = "English (Indian)";
            //temp3[3] = "OpenEMR";

            object[] main = new object[2]; //number of test case
            main[0] = temp1;
            main[1] = temp2;
            //main[2] = temp3;

            return main;
        }

        [Test, TestCaseSource("ValidCredentialTestData"), Category("high"), Category("login")]
        public void ValidCredentialTest(string username, string password, string language, string expectedValue)
        {
            test.Log(Status.Info, "Valid Credential Test Started");

            LoginPage login = new LoginPage(driver); //login--> load the driver
            login.EnterUsername(username);
            login.EnterPassword(password);

            login.SelectLangaugeByText(language);
            login.ClickOnLogin();

            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.WaitForFlowBoardElementPresent();
            string actualValue = dashboard.GetTitle();
            Assert.AreEqual(expectedValue, actualValue);
            test.Log(Status.Info, "Valid Credential Test Completed");

        }

        [Test]
        public void InvalidTest()
        {
            Console.WriteLine("invalid");
        }

        [Test]
        public void ForgotPasswordTest()
        {
            Console.WriteLine("forgot");
        }


        //public static object[] InvalidCredentialTestData()
        //{
        //    object[] main = ExcelUtils.GetSheetIntoObjectArray(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\OpenEmrData.xlsx", "InvalidCredentialTestData");
        //    return main;
        //}

        //[Test, TestCaseSource("InvalidCredentialTestData"), Category("low"), Category("login")]
        //public void InvalidCredentialTest(string username, string password, string language, string expectedValue)
        //{


        //    LoginPage login = new LoginPage(driver);
        //    login.EnterUsername(username);
        //    login.EnterPassword(password);
        //    login.SelectLangaugeByText(language);
        //    login.ClickOnLogin();
        //    string actualValue = login.GetErrorMessage();
        //    Assert.AreEqual(expectedValue, actualValue);

        //}

        //[Test]
        //public void AcknowledgmentsLicensingandCertificationLinkTest()
        //{
        //    LoginPage login = new LoginPage(driver);
        //    login.ClickOnAcknowledgmentsLink();

        //    login.SwitchToDashboardPage();
        //    //check for true==true
        //    Assert.True(driver.PageSource.Contains("List of Contributors"), "Assertion on the text - List of Contributors");

        //}
    }
}