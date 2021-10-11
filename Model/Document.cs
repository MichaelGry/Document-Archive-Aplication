using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Model
{
    public class Folder
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == "") name = "no folder";
                else name = value;
            }
        }
        public int Id { get; set; }
        public List<Document> Documents = new List<Document>(); 
        public Folder(string name)
        {
            Name = name;
        }
        public Folder()
        {

        }
        public override string ToString()
        {
            return "Id: " + Id + "\nFolder name: " + Name + ", Number of documents " + Documents.Count;
        }
    }
    public class Document
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
        public Folder Folder { get; set; }

        public override string ToString()
        {
            string s = "**" + Name.ToUpper() + "**\ncategory:".PadRight(17) + Category + (Folder == null ? 
                ("") : ("\nfolder in:".PadRight(15) + Folder.Name)) + 
                "\ncreated:".PadRight(15) + CreationDate.ToString("D");
            return s;
        }
        public string ToString(int indentationLevel)
        {
            const int indentantionValue = 4;
            string s = "".PadLeft(indentationLevel * indentantionValue) + "Document name:".PadRight(20) + Name +
                "\n" + "".PadLeft(indentationLevel * indentantionValue) + "Category:".PadRight(20) + Category +
                "\n" + "".PadLeft(indentationLevel * indentantionValue) + "Created:".PadRight(20) + CreationDate.ToString("D");
            return s;
        }
    }
}
