using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document_Archive.Model;

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
                yourChoose = Controler.Enter.InputIntFromKeyboard("Choose from menu");
                try
                {
                    MenuItems[yourChoose].action();
                } catch (Exception exc) 
                {
                    Console.Error.WriteLine("Error with menu action -> \"" + MenuItems[yourChoose].Description +
                        "\"\n" + exc.Message);
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
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
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
    }
}
