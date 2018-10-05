﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("qa");
            group.Header = "qd";
            group.Footer = "qf";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
        }
     }
}
