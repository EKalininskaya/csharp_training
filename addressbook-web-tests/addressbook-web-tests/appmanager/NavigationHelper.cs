using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }

        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
