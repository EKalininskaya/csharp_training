using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTastBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CheckAndCreate(1);

            List<ContactData> oldContacts = app.Contact.GetContactList();

            ContactData newContactData = new ContactData("Sergey", "Petrov");
            newContactData.Title = "Test";
            newContactData.NickName = "Ivanko";

            app.Contact.Modify(newContactData);
            
            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}