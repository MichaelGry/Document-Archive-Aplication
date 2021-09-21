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
