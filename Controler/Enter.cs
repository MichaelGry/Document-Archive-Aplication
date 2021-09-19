using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Controler
{
    static class Enter
    {
        public static int InputIntFromKeyboard(string subtitle="Input the int data")
        {
            int input = 0;
            try
            {
                Console.Write(subtitle + ": ");
                input = int.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine("Data input error: " + exc.Message + "\nTry again. " +
                    "Choose any key to continue...");
                Console.ReadLine();
                return -1;
            }
        } //return int from keyboard or -1 when error exception
    }
}
