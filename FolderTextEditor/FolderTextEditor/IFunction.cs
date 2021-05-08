using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTextEditor
{
    interface IFunction
    {
        public string replaceAll(string content, string oldString, string newString);
        public string replaceOnce(string content, string oldString, string newString);

    }
}
