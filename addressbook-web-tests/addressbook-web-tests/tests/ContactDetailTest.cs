using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailTest : AuthTestBase

    {
        [Test]
        public void TestContactDetail()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromDetail = app.Contact.GetContactInformationFromDetailForm(0);

            //verification
            Assert.AreEqual(fromTable.DetailData, fromDetail.DetailData);
        }
    }
}
