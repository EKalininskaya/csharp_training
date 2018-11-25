using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void SetUpConfig()
        {
        }


        [Test]
        public void TestProjectCreation()
        {
            app.Login.Login(new AccountData("administrator", "root"));

            app.ManagementMenu.GoToManage();
            app.ManagementMenu.GoToManageProjects();

            app.ProjectManagement.CreateProject();

            app.ManagementMenu.Logout();
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
        }
    }
}
