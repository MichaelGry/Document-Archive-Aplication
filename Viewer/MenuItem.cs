using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Archive.Viewer
{
    class MenuItem
    {
        public string Description { get; set; }
        public Action action;
        public MenuItem(string description, Action action)
        {
            this.Description = description;
            this.action = action;
        }
    }
    
}
