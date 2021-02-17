using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Pages
{
    class LoginPage
    {
        private By usernameLocator = By.Id("authUser");
        private By passwordLocator = By.Id("clearPass");
        private By languageLocator = By.Name("languageChoice");
        private By loginLocator = By.XPath("//button[@type='submit']");
        private By errorLocator = By.XPath("//*[contains(text(),'Invalid')]");
        private By ackLinkLocator = By.PartialLinkText("Acknowledgments");

        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public void SelectLangaugeByText(string languageText)
        {
            SelectElement select = new SelectElement(driver.FindElement(languageLocator));
            select.SelectByText(languageText);
        }

        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorLocator).Text;
        }

        public void ClickOnAcknowledgmentsLink()
        {
            driver.FindElement(ackLinkLocator).Click();
        }

        public void SwitchToDashboardPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
    }
}




