using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemovingContactFromGroup : AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();
            //ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contact.RemoveContactFromGroup(contact, group);
                
            List<ContactData> newList = group.GetContacts();
            newList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }


    }
}
