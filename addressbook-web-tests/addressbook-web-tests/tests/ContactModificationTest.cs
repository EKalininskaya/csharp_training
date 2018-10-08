using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData = new ContactData();
            contactData.FirstName = "Ivan";
            contactData.LastName = "Ivanov";
            contactData.Title = "Test";
            contactData.NickName = "Ivanko";
            app.Contact.Modify(contactData);
        }
    }
}