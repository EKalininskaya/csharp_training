using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public void CreateProject()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Manage Configuration'])[1]/following::input[2]")).Click();
            Type(By.Name("name"), "Newone");
            /*driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("First");*/
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Description'])[1]/following::input[1]")).Click();
        }

       
        public void RemoveProject()
        {
            //click on project
            driver.FindElement(By.LinkText("FirstProject")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Description'])[1]/following::input[4]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Logout'])[1]/following::input[6]")).Click();
        
    }
    }
}
