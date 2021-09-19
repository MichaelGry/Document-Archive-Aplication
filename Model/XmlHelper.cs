using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document_Archive.Controler;

namespace Document_Archive.Model
{
    class XmlHelper
    {
        public void AddOrUpdateXmlFile()
        {
            Document document = Enter.AddDocument();
            //System.IO.File.WriteAllText("test.txt", document.ToString());
        }
    }
}
