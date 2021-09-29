using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document_Archive.Model;
using Document_Archive.Controler;

namespace Document_Archive.Viewer
{
    public class Menu
    {
        public SortedList<int, MenuItem> MenuItems = new();
        public void ShowMenu() 
        {
            int yourChoose = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to your private document archive!\n\nMenu:");
                ShowItems();
                yourChoose = Enter.GetIntFromUser("Choose from menu");
                try
                {
                   if (MenuItems.ContainsKey(yourChoose)) MenuItems[yourChoose].action();
                } catch (Exception exc) 
                {
                    Console.Error.WriteLine("Error with menu action -> " + 
                        (MenuItems.ContainsKey(yourChoose) ? MenuItems[yourChoose].Description : "") + 
                        "\n" + exc.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            } while (yourChoose != 0);
        }
        protected void ShowItems()
        {
            foreach (KeyValuePair<int, MenuItem> menuItem in MenuItems)
                if (menuItem.Key != 0) 
                    Console.WriteLine(menuItem.Key.ToString() + ". " + menuItem.Value.Description);

            if (MenuItems.ContainsKey(0)) Console.WriteLine("0. " + MenuItems[0].Description);
        }
        public void ShowDataBaseItems(DataBaseDocuments dataBase)
        {
            foreach (Folder folder in dataBase.GetFullContentFolders())
            {
                Console.WriteLine(folder.ToString());
                foreach (Document document in folder.Documents.OrderBy(d => d.Category)) Console.WriteLine(
                    "".PadRight(4).PadRight(31, '.') + "\n" + document.ToString(1));
                Console.WriteLine("".PadLeft(35, '-'));
            }
            Console.WriteLine("\nPress Enter to continue...");
            _ = Console.ReadLine();
        }
        public void ShowFolders(DataBaseDocuments dataBase)
        {
            foreach (Folder folder in dataBase.Folders)
            {
                Console.WriteLine(folder.ToString());
                Console.WriteLine("".PadLeft(35, '-'));
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        public void DeleteDocumentByNameOrId(DataBaseDocuments dataBase)
        {
            int noi; //name or id
            string label = ("\nDeleting data. Enter a name or id.\n" +
                "Press N (name) or I (id)...");
            int? idToDelete = null;

            noi = Enter.GetCharFromUser(label, 'n', 'N', 'i', 'I', ((char)ConsoleKey.Escape));
            if (noi == ((char)ConsoleKey.Escape)) return;
            if (noi == 'n' || noi == 'N')
            {
                string name = Enter.GetStringFromUser("\nDocument name to delete:");
                var DocToDelete = dataBase.Documents.Where(d => d.Name == name);
                if (DocToDelete.ToList().Count == 0)
                {
                    Console.WriteLine("No document with the specified name\nPress any key to continue...");
                    _ = Console.ReadKey();
                    return;
                } // if no name
                else if (DocToDelete.ToList().Count == 1) // id doc name = 1
                {
                    idToDelete = DocToDelete.ToList()[0].Id;
                }
                else // if doc name > 1
                {
                    Console.WriteLine("There is more then one documenta with that name");
                    idToDelete = Enter.GetOneDocumentFromMany("Choose document's id to delete:", DocToDelete.ToArray());
                }
            } //delete the document with the specified name
            else
            {
                idToDelete = Enter.GetIntFromUser("Enter document's id to delete:");

            }
            if (idToDelete != null) dataBase.DeleteDocumentById(idToDelete.Value);
        }
    }
}
