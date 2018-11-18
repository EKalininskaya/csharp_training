using System;
using System.Collections.Generic;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {

        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUP = "Delete group";
        public static string source = "WindowsForms10.SysTreeView32.app.0.2c908d51";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CheckAndCreate(int v)
        {
            aux.WinWaitActive(WINTITLE);

            OpenGroupsDialog();
            int numOfGroup = GetNumOfGroups();
            if (numOfGroup == 0)
            {
                var newGroup = new GroupData
                {
                    Name = "New group"
                };
                Add(newGroup);
            }
            CloseGroupsDilog();
        }

        private int GetNumOfGroups()
        {
            string count = aux.ControlTreeView(GROUPWINTITLE, "", source, "GetItemCount", "#0", "");
            int numOfGroup = int.Parse(count);
            return numOfGroup;
        }

        public void Remove(GroupData toBeRemoved)
        {
            aux.WinWaitActive(WINTITLE);

            OpenGroupsDialog();
            aux.ControlTreeView(GROUPWINTITLE, " ", source, "Select", "#0|#1", "");
            aux.ControlClick(GROUPWINTITLE, " ", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEGROUP);
            aux.ControlClick(DELETEGROUP, " ", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDilog();
        }


        public void Add(GroupData newGroup)
        {
            aux.WinWaitActive(WINTITLE);

            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, " ", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDilog();
        }

      
        private void CloseGroupsDilog()
        {
            aux.ControlClick(GROUPWINTITLE, " ", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public List<GroupData> GetGroupList()
        {
           
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            int numOfGroup = GetNumOfGroups();
            for (int i = 0; i < numOfGroup; i++)
            {
               string item = aux.ControlTreeView(GROUPWINTITLE, "", source, "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });

            }
            CloseGroupsDilog();
            return list;
        }

    }
}