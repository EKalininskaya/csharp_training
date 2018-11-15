using System;
using System.Collections.Generic;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {

        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

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
            string count = aux.ControlTreeView(GROUPWINTITLE,"", "WindowsForms10.SysTreeView32.app.0.2c908d5",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d5",
                "GetText", "#0|#"+i, "");
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