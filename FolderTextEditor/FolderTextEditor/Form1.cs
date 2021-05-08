using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderTextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            string oldString = textBox2.Text;
            string newString = textBox3.Text;
            bool replaceAll = checkBox1.Checked;
            Facade facade = new Facade();
            facade.replaceStrings(fileName,oldString,newString,replaceAll);
        }

    }
}
