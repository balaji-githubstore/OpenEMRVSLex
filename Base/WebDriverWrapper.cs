using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenEmrAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Base
{
    public class WebDriverWrapper
    {
        protected IWebDriver driver;
        public static string projectPath;
        public static ExtentReports extent; //helps setting up the report dir,intialization
        public static ExtentTest test; //create and storing the test method status, info, warning
        public static string screenShotPath;


        [OneTimeSetUp]
        public void Init()
        {
            //to avoid unnecessary update on each class intialization
            if (extent == null)
            {
                projectPath = Assembly.GetCallingAssembly().CodeBase;
                projectPath = projectPath.Substring(0, projectPath.LastIndexOf("bin"));
                projectPath = new Uri(projectPath).LocalPath;

                string reportPath = projectPath + @"Reports\";

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }

        [SetUp]
        public void Initialization()
        {
            string browser = JsonUtils.GetValue(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\data.json", "browser");
          
            
            browser = TestContext.Parameters.Get("browser", browser);

            switch (browser)
            {
                case "ff":
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Url = "https://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void TakeScreenShot(string testName)
        {
            if (driver != null)
            {
                string name = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
                screenShotPath = projectPath + @"\Reports\screenshot_" + testName + "_" + name + ".png";

                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot ss = ts.GetScreenshot();
                ss.SaveAsFile(screenShotPath);
            }
        }

        [TearDown]
        public void AddTestResultAndQuitBrowser()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                TakeScreenShot(testName);
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Failed - Snapshot below:");
                test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Passed)
            {
                TakeScreenShot(testName);
                test.Log(Status.Pass, "Passed - Snapshot below:");
                //test.AddScreenCaptureFromPath(screenShotPath, title: testName);
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }
            driver.Quit();
        }
    }
}
