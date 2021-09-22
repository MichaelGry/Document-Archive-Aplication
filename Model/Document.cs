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

        public Folder(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return "Id: " + Id + "; Name: " + Name;
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
            string s = Name + ", category " + Category + (Folder == null ? 
                ("") : (", folder in: " + Folder.Name)) + ", created: " + CreationDate.ToString("D");
            return s;
        }
    }
}
