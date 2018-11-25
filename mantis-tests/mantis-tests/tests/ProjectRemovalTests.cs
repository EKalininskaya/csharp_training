using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [TestFixtureSetUp]

        public void SetUpConfig()
        {
        }


        [Test]
        public void TestProjectRemoval()
        {
            app.Login.Login(new AccountData("administrator", "root"));

            app.ManagementMenu.GoToManage();
            app.ManagementMenu.GoToManageProjects();

            app.ProjectManagement.RemoveProject();

            app.ManagementMenu.Logout();
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
        }
    }
}
