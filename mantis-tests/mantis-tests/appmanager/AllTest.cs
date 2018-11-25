using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    /*[TestFixture]
    public class LoginHelper
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void CreateProject()
        {
            //driver.Navigate().GoToUrl("http://localhost/mantisbt-1.2.17/login_page.php");
            Login("administrator", "root");
            GoToManagePanale();
            GoToManageProject();
            CreateNewProject();
            FillField();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Description'])[1]/following::input[1]")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void FillField()

        {
            driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("First");
        }

        private void CreateNewProject()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Manage Configuration'])[1]/following::input[2]")).Click();
        }

        private void GoToManageProject()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Manage Configuration'])[1]/following::input[2]")).Click();
        }

        private void GoToManagePanale()
        {
            driver.FindElement(By.LinkText("Manage")).Click();

        
        */



        /*private bool IsElementPresent(By by)
{
   try
   {
       driver.FindElement(by);
       return true;
   }
   catch (NoSuchElementException)
   {
       return false;
   }
}

private bool IsAlertPresent()
{
   try
   {
       driver.SwitchTo().Alert();
       return true;
   }
   catch (NoAlertPresentException)
   {
       return false;
   }
}

private string CloseAlertAndGetItsText()
{
   try
   {
       IAlert alert = driver.SwitchTo().Alert();
       string alertText = alert.Text;
       if (acceptNextAlert)
       {
           alert.Accept();
       }
       else
       {
           alert.Dismiss();
       }
       return alertText;
   }
   finally
   {
       acceptNextAlert = true;
   }
    }
    }*/
}
