using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public void GoToManage()
        {
            driver.FindElement(By.LinkText("Manage")).Click();
        }

        public void GoToManageProjects()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        
    }
}