using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public void GoToProjects()
        {
            manager.ManagementMenu.GoToManage();
            manager.ManagementMenu.GoToManageProjects();
        }

        public List<ProjectData> GetOrCreateProjects()
        {
            GoToProjects();
            var projects = GetProjects();

            if (projects.Count == 0)
            {
                var projectName = "New project";
                CreateProject(projectName);
                projects.Add(new ProjectData { Name = projectName });
            }

            return projects;
        }

        public void ProjectRemoval()
        {
            GoToProjects();

            var projects = GetProjects();
            var projectName = projects[0].Name;

            manager.ProjectManagement.RemoveProject(projectName);
        }

        public void ProjectCreation()
        {
            GoToProjects();

            var projectName = string.Format("New Project {0}", DateTime.Now.Ticks);
            manager.ProjectManagement.CreateProject(projectName);
        }

        public List<ProjectData> GetProjects()
        {
            GoToProjects();
            var list = new List<ProjectData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("table[class=width100] tr[class=row-1], table[class=width100] tr[class=row-2]"));
            foreach (IWebElement element in elements)
            {
                var tds = element.FindElements(By.CssSelector("td"));
                var name = tds[0].Text;
                list.Add(new ProjectData { Name = name });
            }

            return list;
        }

        private void CreateProject(string projectName)
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Manage Configuration'])[1]/following::input[2]")).Click();
            Type(By.Name("name"), projectName);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Description'])[1]/following::input[1]")).Click();
        }


        private void RemoveProject(string projectName)
        {
            driver.FindElement(By.LinkText(projectName)).Click();  //click on project
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Description'])[1]/following::input[4]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Logout'])[1]/following::input[6]")).Click();

        }
    }
}
