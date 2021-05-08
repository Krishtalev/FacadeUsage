using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace FolderTextEditor
{
    class Folder
    {
        public List<TextFile> files = new List<TextFile>();
        public string comment;
        public Folder(string comment)
        {
            this.comment = comment;
        }
        public void extractFileNames(string path)
        {
            if (File.Exists(path))
            {
                TextFile file = new TextFile(path);
                files.Add(file);
            }
            else if (Directory.Exists(path))
            {
                processDirectory(path);
            }
        }
        public void exportToExcel()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            for (int j = 1; j <= files.Count; j++)
            {
                workSheet.Cells[j, 1] = files[j - 1].Name;
                workSheet.Cells[j, 2] = files[j - 1].UpdateTime;
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        private void processDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                TextFile file = new TextFile(fileName);
                files.Add(file);
            }

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                processDirectory(subdirectory);
        }

        public void applyForEach(IFileFunction fileFunctionClass)
        {
            for (int i = 0; i < files.Count; i++) {
                fileFunctionClass.fileFunction(files[i]);
            }
        }
    }
}



