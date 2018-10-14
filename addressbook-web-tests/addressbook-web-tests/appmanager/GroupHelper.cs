using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            CheckAndCreate(p);
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupPage();
            CheckAndCreate(p);
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;

        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            //driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public void CheckAndCreate(int index)
        {
            if (! IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                GroupData group = new GroupData("qa");
                group.Header = "qd";
                group.Footer = "qf";
                manager.Groups.Create(group);
            }
        }


        public GroupHelper SelectGroup(int index)
        {
                //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='q'])[3]/input[1]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
                return this;
        }
        public GroupHelper RemoveGroup()
        {
            //driver.FindElement(By.Name("(.//*[normalize-space(text()) and normalize-space(.)='qa'])[3]/following::input[2]")).Click();
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click(); 
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click(); 
            return this;
        }

    }
}
