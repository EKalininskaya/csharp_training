using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
      
        

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            GoToNewContact();
            FillContactForm();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectGroup(1);
            manager.Alert.AcceptAlert();

            driver.FindElement(By.CssSelector("input[value=\"Delete\"]")).Click();
            new WebDriverWait(driver, new TimeSpan(0, 0, 2));

            Assert.IsTrue(Regex.IsMatch(manager.Alert.CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));

            Logout();
            return this;
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void FillContactForm()
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Ivan");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Ivanov");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void GoToNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
      
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
    }
}

