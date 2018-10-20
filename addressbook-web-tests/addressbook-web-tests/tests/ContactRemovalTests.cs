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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CheckAndCreate(1);

            List<ContactData> oldContacts = app.Contact.GetContactList();


            app.Contact.Remove(0);
            app.Navigator.GoToHomePage();

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);
           
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
