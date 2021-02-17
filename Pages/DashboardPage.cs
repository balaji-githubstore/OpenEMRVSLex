using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Pages
{
    class DashboardPage
    {
        private By flowBoardLocator = By.XPath("//*[text()='Flow Board']");

        private IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void WaitForFlowBoardElementPresent()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.Message = "Wait for flow board text!";
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(x => x.FindElement(flowBoardLocator));
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}
