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
            Action showDocuments = () => { MyMenu.ShowDataBaseItems(dataBase); };
            Action showFolders = () => { MyMenu.ShowFolders(dataBase); };
            MyMenu.MenuItems.Add(1, new MenuItem("Add new document to your repository", addDocument));
            MyMenu.MenuItems.Add(2, new MenuItem("Show your all documents", showDocuments));
            MyMenu.MenuItems.Add(3, new MenuItem("Show your all folders", showFolders));
            #endregion
            MyMenu.ShowMenu();
        }
    }
}
