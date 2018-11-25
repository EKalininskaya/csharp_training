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
            var oldProjects = app.ProjectManagement.GetOrCreateProjects();
            app.ProjectManagement.ProjectRemoval();
            var newProjects = app.ProjectManagement.GetProjects();
            app.ManagementMenu.Logout();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);
        }

        [TestFixtureTearDown]

        public void restoreConfig()
        {
        }
    }
}
