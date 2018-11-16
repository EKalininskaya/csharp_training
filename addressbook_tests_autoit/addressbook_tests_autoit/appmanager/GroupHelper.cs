using System;
using System.Collections.Generic;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {

        public static string GROUPWINTITLE = "Group editor";
        public static string source = "WindowsForms10.SysTreeView32.app.0.2c908d51";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CheckAndCreate(int v)
        {
            aux.WinWaitActive(WINTITLE);

            OpenGroupsDialog();

            // проверить количество групп string count = aux.ControlTreeView(GROUPWINTITLE, "", source, "GetItemCount", "#0", "");
            /* усли 0, то создать новый  for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", source, "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });

            }*/
            CloseGroupsDilog();
        }

        public void Remove(GroupData toBeRemoved)
        {
            aux.WinWaitActive(WINTITLE);

            OpenGroupsDialog();
            // выбрать группу для удаления
            aux.ControlClick(GROUPWINTITLE, " ", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(GROUPWINTITLE, " ", "WindowsForms10.BUTTON.app.0.2c908d51");//нажать delete
            aux.ControlClick("Delete group", " ", "WindowsForms10.BUTTON.app.0.2c908d53");
            
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

            string count = aux.ControlTreeView(GROUPWINTITLE, "", source, "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
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