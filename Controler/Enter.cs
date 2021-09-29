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
        public static int GetIntFromUser(string subtitle="Input the int data")
        {
            int input = 0;
            try
            {
                Console.WriteLine(subtitle);
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
        public static Document GetDocumentFromUser()
        {
            Document document = new Document();
            Console.WriteLine("Specify the parameters of the new document\n\nName: ");
            document.Name = Console.ReadLine();
            Console.WriteLine("Category: ");
            document.Category = Console.ReadLine();
            document.CreationDate = InputDateTime().Date;

            Console.WriteLine("Folder it is in: ");
            document.Folder = new Folder(Console.ReadLine());

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
        public static int GetCharFromUser(string label, params char[] allowsChars)
        {
            int charFromUser;
            Console.WriteLine(label);
            do
            {
                charFromUser = Console.ReadKey(true).KeyChar;
            }
            while (!allowsChars.Contains(((char)charFromUser)));
            return charFromUser;
        }
        public static string GetStringFromUser(string label, int maxSize = 40)
        {
            Console.WriteLine(label);
            string myString = Console.ReadLine();
            return myString.Length > maxSize ? myString.Substring(0, maxSize) : myString;
        }
        public static int? GetOneDocumentFromMany(string label, Document[] documents)
        {
            foreach (Document doc in documents) Console.WriteLine("Id [" + doc.Id + "] " + doc.ToString());
            return GetIntOrNullFromMany(label, documents.Select(d => d.Id).ToArray());
        } 
        public static int? GetIntOrNullFromMany(string label, params int[] intArrey)
        {
            Console.WriteLine(label);
            int? myInt;
            try
            {
                myInt = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                myInt = null;
            }
            if (intArrey.Contains(myInt.Value)) return myInt;
            else return null;
        }
    }
}
