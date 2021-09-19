using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Viewer
{
    static class Menu
    {
        #region Elements menu
        static readonly Action addDocument = () => { };
        static readonly SortedList<int, MenuItem> MenuItems = new()
        {
            { 1, new MenuItem("Add new document to your repository", addDocument)}
        };
        #endregion
        public static void ShowMenu()
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
                } catch (Exception exc) { }
            } while (yourChoose != 0);
        }
        static void ShowItems()
        {
            foreach (KeyValuePair<int, MenuItem> menuItem in MenuItems)
                Console.WriteLine(menuItem.Key.ToString() + ". " + menuItem.Value.Description);
            Console.WriteLine("0. Exit");
        }
    }
}
