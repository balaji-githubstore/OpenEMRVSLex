//using NUnit.Framework;
//using OpenEmrAutomation.Utilities;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Remote;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace UnitedLex.OpenEmrAutomation.Base
//{
//    public class WebDriverWrapper
//    {
//       protected IWebDriver driver;

//        [SetUp]
//        public void LaunchActivities()
//        {
//            string browser = JsonUtils.GetValue(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\data.json", "browser");
//            switch(browser)
//            {
//                case "ff":
//                case "firefox":
//                    driver = new FirefoxDriver();
//                    break;
//                case "ie":
//                    driver = new InternetExplorerDriver();
//                    break;
//                default:
//                    driver = new ChromeDriver();
//                    break;
//            }

            
//            driver.Manage().Window.Maximize();
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
//            driver.Url = "https://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

//            //creating test --> log to repor
//        }

//        [TearDown]
//        public void Terminate()
//        {
//            //verofy passed or failed and log to report
//            driver.Quit();
//        }
//    }
//}
