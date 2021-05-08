using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTextEditor
{
    class Facade
    {
        Folder folder;
        ClientFunctions functionClass;
        StringReplacer fileEditor;

        public void replaceStrings(string folderName, string oldString, string newString, bool replaceAll)
        {
            folder = new Folder("created for test");
            functionClass = new ClientFunctions();
            fileEditor = new StringReplacer(oldString, newString, functionClass, replaceAll);

            folder.extractFileNames(folderName);
            folder.applyForEach(fileEditor);
        }
    }
}
