using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CheckAndCreate(1);
            ContactData contactData = new ContactData();
            contactData.FirstName = "Sergey";
            contactData.LastName = "Petrov";
            contactData.Title = "Test";
            contactData.NickName = "Ivanko";
            app.Contact.Modify(contactData);
        }
    }
}