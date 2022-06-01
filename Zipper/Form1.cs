using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zipper
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        internal void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        internal void zipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        openFileDialog1.InitialDirectory = "%USERPROFILE%";
        //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        //openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string IFile = openFileDialog1.FileName;


                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "zip files (*.dfl)|*.dfl|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string OFile = saveFileDialog1.FileName;
                    using FileStream originalFileStream = File.Open(IFile, FileMode.Open);
                    using FileStream compressedFileStream = File.Create(OFile);
                    using var compressor = new DeflateStream(compressedFileStream, CompressionMode.Compress);
                    originalFileStream.CopyTo(compressor);
                }
            }
        }

        private void deZipToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "%USERPROFILE%";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                //Get the path of specified file
                string IFile = openFileDialog1.FileName;








                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string OFile = saveFileDialog1.FileName;
                    using FileStream compressedFileStream = File.Open(IFile, FileMode.Open);
                    using FileStream outputFileStream = File.Create(OFile);
                    using var decompressor = new DeflateStream(compressedFileStream, CompressionMode.Decompress);
                    decompressor.CopyTo(outputFileStream);
                }
            }
        }
    }
}
