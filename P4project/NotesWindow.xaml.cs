
using P4project.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace P4project
{
    /// <summary>
    /// Logika interakcji dla klasy NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
       // private ObservableCollection<Note> notes;
        public NotesWindow()
        {
            InitializeComponent();

            //DataContext = new MainViewModel();
        }

       


        public class Note : INotifyPropertyChanged
        {
            

            public string TextNote
            {
                get => TextNote; set
                {
                    if (value != TextNote)
                    {
                        TextNote = value;
                        NotifyPropertyChanged("TextNote");
                        
                    }
                }
            }

       

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
           MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }
    }
}
