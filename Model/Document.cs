using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Model
{
    class DocumentLocation
    {
        string folder;
        string box;
    }
    class Document
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
        public DocumentLocation Location { get; set; }

        public override string ToString()
        {
            string s = Name + ", category " + Category + ", created: " +
                CreationDate.ToString("D");
            return s;
        }
    }
}
