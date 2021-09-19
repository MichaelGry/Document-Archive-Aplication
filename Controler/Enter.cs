using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document_Archive.Model;

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
        public static Document AddDocument()
        {
            Document document = new Document();
            Console.WriteLine("Specify the parameters of the new document\n\nName: ");
            document.Name = Console.ReadLine();
            Console.WriteLine("Category: ");
            document.Category = Console.ReadLine();
            document.CreationDate = InputDateTime().Date;

            return document;
        }
        public static DateTime InputDateTime()
        {
            DateTime? dateTime = null;
            do
            {
                Console.WriteLine("Specify date of document creation with format year/month/day: ");
                string[] date = Console.ReadLine().Split(' ', '/', '.', '-');
                try
                {
                    dateTime = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                } catch (Exception exc)
                {
                    Console.WriteLine("Date given in wrong format. Error: " + exc.Message);
                }
            } while (dateTime == null);
            return (DateTime)dateTime;
        }
    }
}
