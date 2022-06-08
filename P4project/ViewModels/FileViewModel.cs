using P4project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Win32;


namespace P4project.ViewModels
{
    public  class FileViewModel
    {
        public DocumentModel Document { get; private set; }
        public ICommand NewCommand { get; }
        public ICommand Saveommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            Saveommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);

        }

        private void OpenFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
               // DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        public void NewFile()
        {
            Document.FileName =String.Empty;
            Document.FilePath = String.Empty;
            Document.Text = String.Empty;

        }


        private void SaveFile()
        {
          
                File.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
           // if (saveFileDialog.ShowDialog() = true)
           //   {
            DockFile(saveFileDialog);
             File.WriteAllText(saveFileDialog.FileName, Document.Text);
          //  }
        }

        

        private void DockFile(System.Windows.Forms.SaveFileDialog saveFileDialog)
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();

           // if (openFileDialog.ShowDialog() = true)
           // {
                  DockFile(saveFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
          //  }
        }

        private void DockFile<T> (T dialog) where T : System.Windows.Forms.FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FilePath = dialog.FileName;
        }
    }
}
