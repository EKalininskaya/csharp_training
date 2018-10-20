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

        public ContactHelper Create(ContactData contactData)
        {
            GoToNewContact();
            FillContactForm(contactData);
            ClickEnter();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(0);
            manager.Alert.AcceptAlert();

            driver.FindElement(By.CssSelector("input[value=\"Delete\"]")).Click();
            Assert.IsTrue(Regex.IsMatch(manager.Alert.CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));

            return this;
        }

        public ContactHelper Modify(ContactData contactData)
        {
            ClickEdit();
            FillContactForm(contactData);
            Update();
            ReturnToHomePage();
            return this;
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("nickname"), contactData.NickName);

            /*driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contactData.Title);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contactData.NickName);*/

            /*driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactData.MiddleName);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contactData.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contactData.Adress);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contactData.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactData.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contactData.Work);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contactData.Fax);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contactData.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contactData.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contactData.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contactData.HomePage);*/

        }
        public void ClickEnter()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        
        private void ClickEdit()
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
        }
        private void Update()
        {
            driver.FindElement(By.CssSelector("input[name=\"update\"][type=\"submit\"]")).Click();
        }
        public void GoToNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

         public void CheckAndCreate (int index)
        {
            if (! IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                ContactData contactData = new ContactData("Ivan", "Ivanov");
                manager.Contact.Create(contactData);
            }
        }

        public void SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
            foreach (IWebElement element in elements)
            {
                var text = element.Text;
                var firstname = text.Split(' ')[1];
                var lastname = text.Split(' ')[0];

                contacts.Add(new ContactData(firstname, lastname));
            }
            return contacts;
        }
    }
}

