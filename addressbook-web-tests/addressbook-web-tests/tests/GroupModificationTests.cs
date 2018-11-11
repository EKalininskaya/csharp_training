using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
     public class GroupModificationTests : GroupTastBase

    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CheckAndCreate(1);
                        
            GroupData newData = new GroupData("vvv");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll().OrderBy(x => x.Name).ToList();
            GroupData oldData = oldGroups[0];
            oldData.Name = newData.Name;

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll().OrderBy(x => x.Name).ToList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
