﻿using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config_inc.php", localFile);
            }
        }


        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"

            };

            app.Registration.Register(account);

        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
            /*app.Ftp.RestoreBackupFile("");
            app.Ftp.Upload("", null);*/
        }
    }
}
