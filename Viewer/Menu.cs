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
                } catch (Exception exc) { }
            } while (yourChoose != 0);
        }
        protected void ShowItems()
        {
            foreach (KeyValuePair<int, MenuItem> menuItem in MenuItems)
                Console.WriteLine(menuItem.Key.ToString() + ". " + menuItem.Value.Description);
            Console.WriteLine("0. Exit");
        }
    }
}
