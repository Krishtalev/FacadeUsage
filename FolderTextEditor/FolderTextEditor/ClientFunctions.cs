using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTextEditor
{
    class ClientFunctions: IFunction
    {
        public string replaceAll(string content, string oldString, string newString)
        {
            return content.Replace(oldString, newString);
        }

        public string replaceOnce(string content, string oldString, string newString)
        {
            int pos = content.IndexOf(oldString);
            if (pos < 0)
            {
                return content;
            }
            return content.Substring(0, pos) + newString + content.Substring(pos + oldString.Length);
        }
    }
}
