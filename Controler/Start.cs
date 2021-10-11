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
            Action exitApp = () => { };
            Action addDocument = () => { dataBase.AddDocumentToDb(Enter.GetDocumentFromUser()); };
            Action showDocuments = () => { MyMenu.ShowDataBaseItems(dataBase); };
            Action showFolders = () => { MyMenu.ShowFolders(dataBase); };
            Action deleteDocument = () => { MyMenu.DeleteDocumentByNameOrId(dataBase); };
            Action showDocumentsFromFolder = () => { MyMenu.ShowSpecificFolder(dataBase); };
            Action saveToXml = () => { dataBase.SaveToXml("DocumentsXmlData.xml"); };
            Action showSpecifiedDocuments = () => { MyMenu.ShowSpecificDocuments(dataBase); };
            
            MyMenu.MenuItems.Add(1, new MenuItem("Add new document to your repository", addDocument));
            MyMenu.MenuItems.Add(2, new MenuItem("Show your all documents", showDocuments));
            MyMenu.MenuItems.Add(3, new MenuItem("Show your all folders", showFolders));
            MyMenu.MenuItems.Add(4, new MenuItem("Delete document from your repository", deleteDocument));
            MyMenu.MenuItems.Add(5, new MenuItem("Show documents from folder", showDocumentsFromFolder));
            MyMenu.MenuItems.Add(6, new MenuItem("Save yours datas to Xml file", saveToXml));
            MyMenu.MenuItems.Add(7, new MenuItem("View documents with the specified parameters", showSpecifiedDocuments));
            MyMenu.MenuItems.Add(0, new MenuItem("Exit", exitApp));
            #endregion
            MyMenu.ShowMenu();
        }
    }
}
