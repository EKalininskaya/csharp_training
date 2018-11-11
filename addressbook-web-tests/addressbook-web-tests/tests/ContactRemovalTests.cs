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
    public class ContactRemovalTests : ContactTastBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CheckAndCreate(1);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contact.Remove(toBeRemoved);

            app.Navigator.GoToHomePage();

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
