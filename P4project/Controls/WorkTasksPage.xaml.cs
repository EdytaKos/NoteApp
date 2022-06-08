using P4project.Controls;
using System;
using System.Collections.Generic;
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

namespace P4project.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy WorkTasksPage.xaml
    /// </summary>
    public partial class WorkTasksPage : Window
    {
        public WorkTasksPage()
        {
         //   InitializeComponent();
            this.DataContext = new WorkTaskViewModel();
            var notes = new  WorkTaskViewModel();
            notes.Title = "First";
            notes.Description = "my first  note is awesome";
            this.DataContext = notes;
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }

        private void btnExut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
