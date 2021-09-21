using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Model
{
    public class Folder
    {
        public string Name
        {
            get => Name;
            set
            {
                if (value == "") Name = "no folder";
                else Name = value;
            }
        }
        public int Id { get; set; }

        public Folder(string name)
        {
            Name = name;
        }
    }
    public class Document
    {
        static private int actualId = 0;
        public int Id { get; set; } //primary key
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
        public Folder Folder { get; set; }
        public Document()
        {
            Id = ++actualId;
        }

        public override string ToString()
        {
            string s = Name + ", category " + Category + ", created: " +
                CreationDate.ToString("D");
            return s;
        }
    }
}
