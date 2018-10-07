using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCteationTests : TestBase
    {


        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData();
            contactData.FirstName = "Sergey";
            contactData.LastName = "Sergeyev";
            app.Contact.Create(contactData);
        }
    }
}
