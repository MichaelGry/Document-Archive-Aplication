using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Model
{
    public class Folder
    {
        List<Document> Documents;
    }
    public class Document
    {
        static private int actualId = 0;
        public int Id { get; set; } //primary key
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
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
