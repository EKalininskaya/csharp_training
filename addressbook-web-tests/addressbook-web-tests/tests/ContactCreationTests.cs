using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactCteationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = GenerateRandomString(30),
                    LastName = GenerateRandomString(100)
                });
            }

            return contacts;
        }
    }

    
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData)
        {

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        /*[Test]
        public void ContactCreationTest()
        {           
           
            ContactData contactData = new ContactData("Ivan", "Ivanov");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contactData);

            List<ContactData> newContacts = app.Contact.GetContactList();
          
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            
        }*/
    
}
