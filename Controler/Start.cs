using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document_Archive.Model;
using Document_Archive.Viewer;

namespace Document_Archive.Controler
{
    public static class Start
    {
        public static void StartProgram()
        {
            DataBaseDocuments dataBase = new DataBaseDocuments();
            Menu MyMenu = new Menu();
            #region Menu elements
            Action addDocument = () => { dataBase.AddDocumentToDb(Enter.GetDocumentFromUser()); };
            MyMenu.MenuItems.Add(1, new MenuItem("Add new document to your repository", addDocument));
            #endregion
            MyMenu.ShowMenu();
        }
    }
}
