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
            var oldProjects = app.ProjectManagement.GetProjects();
            app.ProjectManagement.ProjectCreation();
            var newProjects = app.ProjectManagement.GetProjects();
            app.ManagementMenu.Logout();

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
        }
    }
}
