using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTextEditor
{
    class StringReplacer: IFileFunction
    {
        private string oldString;
        private string newString;
        private IFunction replaceClass;
        private bool replaceAll;
        public StringReplacer(string oldString, string newString, IFunction replaceClass, bool replaceAll){
            this.oldString = oldString;
            this.newString = newString;
            this.replaceClass = replaceClass;
            this.replaceAll = replaceAll;
        }

        public void setOldString(string oldString)
        {
            this.oldString = oldString;
        }
        public void setNewString(string newString)
        {
            this.newString = newString;
        }
        public void setReplaceClass(IFunction replaceClass)
        {
            this.replaceClass = replaceClass;
        }
        public void setReplaceAll(bool replaceAll)
        {
            this.replaceAll = replaceAll;
        }
        public void fileFunction(TextFile file)
        {
            string fileName = file.Name;
            using (FileStream fileStream = new FileStream(
                fileName, FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                string currentContents = streamReader.ReadToEnd();
                string newContents;
                if (replaceAll) newContents = replaceClass.replaceAll(currentContents, oldString, newString);
                else newContents = replaceClass.replaceOnce(currentContents, oldString, newString);
                file.update();
                fileStream.SetLength(0);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(newContents);
                writer.Close();
            }
        }
    }
}
