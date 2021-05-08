using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTextEditor
{
    class TextFile
    {
        private string name;
        private DateTime updateTime;

        public TextFile(string path)
        {
            name = path;
            updateTime = DateTime.Now;
        }

        public void update()
        {
            updateTime = DateTime.Now;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string UpdateTime
        {
            get { return Convert.ToString(updateTime); }
        }
    }
}
